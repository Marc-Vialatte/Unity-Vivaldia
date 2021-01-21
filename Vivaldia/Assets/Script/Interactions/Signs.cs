using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signs : MonoBehaviour
{

    public GameObject dialogBox;
    public Text dialogText;
    public Text dialogText1;
    public Text dialogText2;
    public string dialog;
    public string dialog1;
    public string dialog2;
    public bool playerInrange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInrange) //Si il est dans la zone et que le joueur appui sur espace alors
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);//On active la boite de dialogue
            }
            else
            {
                dialogBox.SetActive(true);//On active la boite de dialogue
                dialogText.text = dialog; //Le text dans le canvas est remplacé par ce que l'on a écrit dans l'inspecteur
                dialogText1.text = dialog1;//Le text dans le canvas est remplacé par ce que l'on a écrit dans l'inspecteur
                dialogText2.text = dialog2;//Le text dans le canvas est remplacé par ce que l'on a écrit dans l'inspecteur
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))// On vérifie si il est dans la zone d'activation
        {
            playerInrange = true; 
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Si le Joueur sort de la zone alors
        {
            playerInrange = false; //Il n'est plus dans la zone d'activation
            dialogBox.SetActive(false); //On désactive la boite de dialogue
        }
    }


}
