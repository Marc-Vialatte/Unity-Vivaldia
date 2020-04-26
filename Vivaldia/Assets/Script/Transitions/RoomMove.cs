using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour //Faire des carré de zone pour la caméra
{
    public Vector2 CamMax; //son maximum en position
    public Vector2 CamMin; //son minimum en position
    public Vector3 playerChange; //Une légère téléportation du joueur

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerInventory>().CamMax = CamMax; //On passe ces variables
            collision.GetComponent<PlayerInventory>().CamMin = CamMin; //On passe ces variables 
            collision.transform.position += playerChange; //et on ajoute "playerChange" a la position du personnage pour la téléportation 
        }
    }
}
