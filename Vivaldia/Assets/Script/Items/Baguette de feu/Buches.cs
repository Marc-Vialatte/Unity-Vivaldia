using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buches : MonoBehaviour
{
    //script qui permet la destruction des bûches
    GameObject Player;
    public Sprite Buche;//Affectation d'un sprite pour faire afficher la buche
    public Sprite Cendre;//Affectation d'un sprite pour faire afficher les cendres une fois que la buche est détruite
    SpriteRenderer spriteRDR;//Gestion du sprite renderer
    

    void Start()
    {
        spriteRDR = gameObject.GetComponent<SpriteRenderer>();
        spriteRDR.sprite = Buche;
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    void OnMouseDown()
    {
        //Si le joueur a la baguette en main et que le bloc est encore une bûche alors on détruit son box collider, le joueur peut alors passer
        //et son sprite est remplacé par des cendres
        if (Player.GetComponent<PlayerInventory>().HaveBaguetteFeu && Player.GetComponent<PlayerController>().SelectBaguetteFeu)
        {
            print("IsTrigger" + this.gameObject.name);
            this.gameObject.GetComponent<Collider2D>().isTrigger = true;
            spriteRDR.sprite = Cendre;
        }
    }
}
