using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // Utilisé pour la transition de scene
    public string sceneToLoad;
    public Vector2 PlayerPosition;
    public Vector2 CamMax;
    public Vector2 CamMin;
    //ublic VectorValues PlayerStorage;
    // DontDestroyOnLoad(Object target);
    //public GameObject Player;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            collision.GetComponent<PlayerInventory>().CamMax = CamMax; //On passe les données CamMax et CamMin
            collision.GetComponent<PlayerInventory>().CamMin = CamMin;
            //DontDestroyOnLoad(Player);
            SceneManager.LoadScene(sceneToLoad);//On Charge la scene
            collision.transform.position = PlayerPosition; //Position du joueur dans la scène charger
        }
    }
}
