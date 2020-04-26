using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Ennemis : MonoBehaviour
{
    SpriteRenderer catRenderer;//Le sprite render
    Animator CatAnim;                          //Variable of type Animator to store a reference to the enemy's Animator component.
    Transform target;                           //Transform to attempt to move toward each turn.
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    public float targetTime = 0.2f;
    public float speed;
    public int Viewdistance;
    bool turnRight = true;
    bool turnLeft = false;
    public bool follow = false;
    public bool SpriteDif = false;
    int sensR = 180;
    int sensF = 0;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;// On récupère l'objet avec un tag Player
    }
    void Update()
    {
        if (!(gameObject.transform.GetChild(0).gameObject.GetComponent<Attack>().DoAttack))//Si il n'attaque pas
        {
            if (SpriteDif)//Permet de tourné les sprites en fonction de comment il est tourné de base
            {
                sensR = 0;
                sensF = 180;
            }
            targetTime -= Time.deltaTime; //Cette variable en float moins le temps écoulé

            if (ViewDistance() < Viewdistance) //si la distance entre l'ennemi et le joueur est inférieur alors
            {
                Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z); //On fait un vecteur entre le joueur et l'ennemis
                //gameObject.transform.position = new Vector3.Lerp (target.position.x, target.position.y, 5);
                transform.position = Vector3.Lerp(transform.position, targetPosition, speed);// On modifie sa position pour quil ce rapproche du joueur avec une certaine vitesse
                follow = true;//L'ennemi suit le joueur
            }
            else follow = false;//Sinon il ne le suit pas

            if (HitRight()) //Si il ce prend un mur a droite
            {
                turnLeft = true;
                turnRight = false;
            }
            if (HitLeft()) //Si il ce prend un mur a gauche
            {
                turnLeft = false;
                turnRight = true;
            }
        // Petit partit lui permettant de bougé de gauche a droite
            if (turnRight && !turnLeft && !follow) 
            {
                transform.position = new Vector2(transform.position.x + speed, transform.position.y);
                transform.localRotation = Quaternion.Euler(0, sensR, 0);
            }

            if (turnLeft && !turnRight && !follow)
            {
                transform.position = new Vector2(transform.position.x - speed, transform.position.y);
                transform.localRotation = Quaternion.Euler(0, sensF, 0);
            }
        //==========================================================
        //Si il suit le joueur alors les sprite sont tourné de façon a bien le faire
            if (position() && follow)
            {
                transform.localRotation = Quaternion.Euler(0, sensR, 0);
            }
            if (!position() && follow)
            {
                transform.localRotation = Quaternion.Euler(0, sensF, 0);
            }
        //==========================================================
        }
        else //Sinon
        {
            transform.position = transform.position; //On l'arrete quand il tap;
        }
    }

   /* bool HitDown()
    {
        Vector2 position = gameObject.transform.position;
        Vector2 direction = Vector2.down;// + Vector2.left;
        float distance = 1.0f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        Debug.DrawRay(position, direction, Color.red);
        //Debug.Log(hit.collider);
        if (hit.collider == null)
            return false;
        else
            return true;
    }*/
    bool HitRight() //On vérifie avec des Raycast si il ce prend un mur(tag Ground) sur la droite
    {
        Vector2 position = gameObject.transform.position;
        Vector2 direction = Vector2.right;// + Vector2.left;
        float distance = 0.7f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        Debug.DrawRay(position, direction, Color.red);
        //Debug.Log(hit.collider);
        if (hit.collider == null)
            return false;
        else
            return true;
    }
    bool HitLeft()//On vérifie avec des Raycast si il ce prend un mur(tag Ground) sur la gauche
    {
        Vector2 position = gameObject.transform.position;
        Vector2 direction = Vector2.left;// + Vector2.left;
        float distance = 0.7f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        Debug.DrawRay(position, direction, Color.red);
        //Debug.Log(hit.collider);
        if (hit.collider == null)
            return false;
        else
            return true;
    }

    float ViewDistance() //Distance entre le joueur et l'ennemi
    {
        float view = Vector2.Distance(transform.position, target.transform.position);
        return view;
    }
    bool position() //Voir si le joueur est a sa gauche ou a sa droite
    {
        if (gameObject.transform.position.x < target.transform.position.x)
            return true; // A sa gauche
        else
            return false; // A sa droite
    }
}
