using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Donjon1 : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
        SceneManager.LoadScene("TransitionDonjon1");//Ajouter un Nom de Scene correspondant au donjon n°1
    }
}

