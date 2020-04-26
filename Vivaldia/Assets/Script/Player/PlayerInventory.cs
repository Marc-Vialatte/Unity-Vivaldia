using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnim;
    public int life = 10;
    public int nbBomb;
    public Vector2 CamMax;
    public Vector2 CamMin;

    public bool AnimPlayed = false;
    public int ordredalle = 3;
    public bool HaveBaguetteEau;
    public bool HaveBaguetteFeu;
    public bool HaveShield;
    public bool ActiveShield;
    // Start is called before the first frame update
    void Start()
    {
        CamMax = new Vector2(0.59f, 1.91f); //Utilisé pour la caméra car ce script ne ce détruit pas au changement de scene
        CamMin = new Vector2(0.59f, 1.91f); //Utilisé pour la caméra car ce script ne ce détruit pas au changement de scene
        HaveBaguetteEau = false; //Si le joueur a la baguette d'eau
        HaveBaguetteFeu = false; //Si le joueur a la baguette de feu
        HaveShield = false; //Si le joueur a le bouclier
        ActiveShield = false; //Si le joueur a le bouclier d'activé
        playerAnim = GetComponent<Animator>(); //Son animator
    }

    // Update is called once per frame
    void Update()
    {
        ActiveShield = GameObject.FindWithTag("Player").GetComponent<PlayerController>().Shield;
        /*if (HaveBaguetteEau)
        {
            playerAnim.SetBool("HaveBaguette", true);
        }
        if (HaveBaguetteFeu)
        {
            playerAnim.SetBool("HaveBaguetteFeu", true);
        }*/
    }


    public void AddLife(int nb) //Ajoute des Point de vie avec la variable passer en paramètre
    {
        if (life < 10)
        {
            life += nb;
        }
        print("Ma Vie Une Fois Soigné: " + life);
    }
    public void RemoveLife(int nb) //Retire des Point de vie avec la variable passer en paramètre
    {
        if (ActiveShield)
        {
            life -= nb/2;
        }
        else
        {
            life -= nb;
        }
        print("Ma Vie Une Fois Attaquer: " + life);
    }

    public void AddBomb() //Ajoute 1 bombe à l'inventaire
    {
        nbBomb++;
    }
    public void RemoveBomb() //Retire 1 bombe à l'inventaire
    {
        nbBomb--;
    }
}
