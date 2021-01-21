using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public GameObject endGame;
    public GameObject Gameover;
    public GameObject Youwin;
    public GameObject Main;
    public GameObject Boss;
    private bool IsPassed = false;

    private void Update()
    {

        if (!IsPassed) //évite le bug de recherche si le Boss est mort ou le joueur
        {
            if (GameObject.FindWithTag("Player").GetComponent<PlayerInventory>().life <= 0)
            {
                GameOver();
                IsPassed = true;
            }
            if (GameObject.FindWithTag("Ennemis").GetComponent<HealtScriptEnnemis>().hp <= 0 && GameObject.FindWithTag("Ennemis").GetComponent<HealtScriptEnnemis>().IsBoss)
            {
                YouWin();
                IsPassed = true;
            }
        }
    }

    public void GameOver() //alors il a perdu
    {
        endGame.SetActive(true); //On active les éléments vouluent
        Gameover.SetActive(true);
        Main.SetActive(true);
        Time.timeScale = 0;
    }
    public void YouWin() //Sinon il a gagné
    {
        endGame.SetActive(true);
        Youwin.SetActive(true);
        Main.SetActive(true);
        Time.timeScale = 0;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("EcranDemarage"); //Bouton pour le retour a la scène de base
    }
    
}
