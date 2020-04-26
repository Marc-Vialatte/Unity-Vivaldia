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

    void FinAnim()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerInventory>().AnimPlayed = true;
        GameObject.Find("HUD").GetComponent<Canvas>().enabled = false;
        Destroy(Cam);
    }
}
