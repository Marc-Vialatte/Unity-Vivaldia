using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneMaison : MonoBehaviour
{
    public string sceneToLoad;
    public void LoadSceneStart()
    {
        SceneManager.LoadScene(sceneToLoad); //La scene que l'on veut charger en fonction de son nom choisi dans l'inspecteur
    }
}
