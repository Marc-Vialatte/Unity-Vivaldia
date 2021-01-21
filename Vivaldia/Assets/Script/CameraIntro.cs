using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class CameraIntro : MonoBehaviour
{
    
    public GameObject dialogBox;
    public Text dialog;
    public GameObject Life;
    public GameObject Cam;
    float timer = 30.20f;
    private bool Animplayed;

    //Script pour l'animation de départ et savoir si on l'a bien regarder jusqua la fin
    private void Update()
    {
        GameObject.Find("HUD").GetComponent<Canvas>().enabled = false;
        Animplayed = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>().AnimPlayed;
        timer -= Time.deltaTime;
        if (Animplayed)
        {
            FinAnim();
        }
        if(timer <= 0 && !Animplayed)
        {
            FinAnim();
        }
        if(timer == 10)
        {
            print("10");
            dialogBox.SetActive(true);
        }
        if(timer == 15)
        {
            print("15");
            dialogBox.SetActive(false);
        }


    }

    void FinAnim() //Si on a vue l'animation jusqu'a la fin 
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerInventory>().AnimPlayed = true;
        GameObject.Find("HUD").GetComponent<Canvas>().enabled = true;
        Destroy(Cam);
    }
}
