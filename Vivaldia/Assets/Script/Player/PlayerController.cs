using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //CE script gere tous les mouvment du joueur ainsi que les animations qui lui sont liées et qui permet aussi de récuperer les informatins necssaire a l'utilisation des différents items


    public Vector2 mousePosition;//Vecteur avec la position de la souris
    public float vitesse;//Float qui va gere la vitesse du joueur
    private Rigidbody2D RB;//RigudBody de PLAYER
    private Vector3 change;//Changelnt de scene
    private Animator PlayerAnimator;//Animator du joueur
    public VectorValues startingPosition;//Position du joueur quand il change d'une scene
    //Ensembles des booléen qui permet de gerer la selection des items pour gerer les animations
    public bool Shield;
    public bool SelectBaguetteFeu;
    public bool SelectBaguetteEau;
    public bool SelectSword;
    public bool SelectShield;
    float Timer = 0.5f;
    PlayerInventory PlayerI;
    public Transform shotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SelectSword = true;
        SelectBaguetteFeu = false;
        SelectBaguetteEau = false;
        SelectShield = false;
        Shield = false;
        RB = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        
        //transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime; //un Timer
        PlayerI = gameObject.GetComponent<PlayerInventory>(); //Script de l'inventaire du joueur
        if (Input.GetButton("Fire1") && SelectShield) //Pour ce protéger il doit avoir le bouclier et faire clic gauche
        {
            Shield = true; //Le joueur utilise le bouclier
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && Timer <= 0 && SelectSword) //Si il n'utilise pas le bouclier et quil a sélectionné l'épée
            {
                PlayerAnimator.SetBool("Attack", true); //On lance l'animation d'attaque
                gameObject.transform.GetChild(0).gameObject.GetComponent<AttackPlayer>().PlayerAttack = true; //On initialise la variable "PlayerAttack" a vrai
                Timer = 0.5f;//On remet le timer a sa valeur
            }
            if (Timer <= 0)
            {
                PlayerAnimator.SetBool("Attack", false); //On arrete l'animation d'attaque
                gameObject.transform.GetChild(0).gameObject.GetComponent<AttackPlayer>().PlayerAttack = false; //On initialise la variable "PlayerAttack" a faux
            }
            Shield = false; //Le joueur n'utilise plu le bouclier
        }

        if(Input.GetKeyDown(KeyCode.Alpha1)) // Faire "1" pour séléctionné l'épée et donc faire des dégat
        {
            SelectSword = true; //Image de séléction affiché
            SelectBaguetteEau = false; //Image de séléction caché
            SelectBaguetteFeu = false; //Image de séléction caché
            SelectShield = false; //Image de séléction caché
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && PlayerI.HaveBaguetteEau) // Faire "2" pour séléctionné la baguette d'eau si il là
        {
            SelectBaguetteEau = true; //Image de séléction affiché
            SelectBaguetteFeu = false; //Image de séléction caché
            SelectSword = false; //Image de séléction caché
            SelectShield = false; //Image de séléction caché
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && PlayerI.HaveBaguetteFeu) // Faire "3" pour séléctionné la baguette de feu si il là
        {
            SelectBaguetteFeu = true; //Image de séléction affiché
            SelectBaguetteEau = false; //Image de séléction caché
            SelectSword = false; //Image de séléction caché
            SelectShield = false; //Image de séléction caché
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && PlayerI.HaveShield) // Faire "4" pour séléctionné le bouclier si il là
        {
            SelectShield = true; //Image de séléction affiché
            SelectSword = false; //Image de séléction caché
            SelectBaguetteEau = false; //Image de séléction caché
            SelectBaguetteFeu = false; //Image de séléction caché
        }

        if (Input.GetKeyDown(KeyCode.Space) && PlayerI.nbBomb > 0) // Faire "Espace" pour poser une bombe si il en a
        {
            PlayerI.RemoveBomb();//On lui en enlève 1
            var shotTransform = Instantiate(shotPrefab) as Transform; //On instancie un préfab
            shotTransform.position = transform.position; // a la position du joueur
        }
        mousePosition = Input.mousePosition; //Donné de la position de la souris
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (change != Vector3.zero) //Mouvement du joueur pour savoir dans quelle sens il est tourné
        {
            MoveCharacter();
            PlayerAnimator.SetFloat("moveX", change.x);
            PlayerAnimator.SetFloat("moveY", change.y);
            PlayerAnimator.SetBool("moving", true);
            
        }
        else
        {
            PlayerAnimator.SetBool("moving", false);
        }
    }
   


    void MoveCharacter() //On fait bougé le joueur dans le sens voulu (change)
    {
        RB.MovePosition(transform.position + change * vitesse * Time.deltaTime);
       
    }
}
