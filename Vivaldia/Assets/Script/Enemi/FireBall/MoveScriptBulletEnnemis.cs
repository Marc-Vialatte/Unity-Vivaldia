using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScriptBulletEnnemis : MonoBehaviour //Script du mouvement de l'objet tiré
{
    public Vector3 mouvement; //On passe le Vecteur auquelle on veut lui associé le mouvement
    void Update()
    {
        transform.Rotate(Vector3.forward * -90); //Rotation infini, effet de mouvement
        GetComponent<Rigidbody2D>().mass = 75; //On modifie la mass de l'objet
        GetComponent<Rigidbody2D>().AddForce(2*mouvement, ForceMode2D.Impulse); //Et on lui fait faire le mouvement voulu en fonstion de son poid pour plus d'inertie
    }
}
