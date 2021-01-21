using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Verifiction : MonoBehaviour
{
    //Ce script permet de savoir si il a tout les élément pour aller au donjon du boss
    public string sceneToLoad;
    public Vector2 PlayerPosition;
    public Vector2 CamMax;
    public Vector2 CamMin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<PlayerInventory>().HaveBaguetteEau == true && collision.GetComponent<PlayerInventory>().HaveBaguetteFeu == true && collision.GetComponent<PlayerInventory>().HaveShield == true)
            {
                collision.GetComponent<PlayerInventory>().CamMax = CamMax;
                collision.GetComponent<PlayerInventory>().CamMin = CamMin;
                collision.transform.position = PlayerPosition;         
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
