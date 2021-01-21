using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Ennemi : MonoBehaviour
{
    Animator EnnemiAnimator;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        EnnemiAnimator = GetComponent<Animator>(); //Récupère l'animator de l'objet
        EnnemiAnimator.SetBool("Move", true); //On fait l'animation mouvement car il est toujour en mouvement
        timer = 0.9f; //Temps d'animation pour l'attaque et évité des attaque trop rapide
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; //On enlève a la variable timer le temps écoulé
        if (gameObject.transform.GetChild(0).gameObject.GetComponent<Attack>().DoAttack) // Si il est entrain d'attaquer
        {
            EnnemiAnimator.SetBool("Attack", true);// On fait l'animation attaque
            EnnemiAnimator.SetBool("Move", false);//On Stop l'animation du mouvement
            timer = 0.9f;// On remet le temps d'attaque pour évité les boucles trop a la suite de l'animation
        }
        if(!gameObject.transform.GetChild(0).gameObject.GetComponent<Attack>().DoAttack && timer <= 0) // Si il n'attaque pas et que le temps est tou de meme inférieur a 0
        {
            EnnemiAnimator.SetBool("Attack", false);//On Stop l'annimation de l'attaque
            EnnemiAnimator.SetBool("Move", true);// On fait l'animation Move soit le mouvement de l'ennemi
            gameObject.transform.GetChild(0).gameObject.GetComponent<Attack>().DoAttack = false; //Et on met bien a false la variable pour évité qql que probleme
        }
        
    }
}
