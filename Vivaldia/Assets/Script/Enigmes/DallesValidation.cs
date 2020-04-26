using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DallesValidation : PlayerInventory
{
    //Création d'un string contenant le nom de la scene a charger et d'un vecteur pour teleporter le player a une position voulu sur le même principe des transition de scene.
    public string sceneToLoad;
    public Vector2 PlayerPosition;

    //Trigger Permettant la validation
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Vérification du tag du joueur
        if (collision.tag == "Player" && !collision.isTrigger)
        {
            print("Ordre Dalle: " + collision.GetComponent<PlayerInventory>().ordredalle);
            //Vérification pour savoir si l'énigme a été résolut
            if (collision.GetComponent<PlayerInventory>().ordredalle == 0)
            {
                //Si oui on passe a la salle suivante pour récuperer la baguette
                SceneManager.LoadScene(sceneToLoad);
                collision.transform.position = PlayerPosition;
            }
        }

    }
};


