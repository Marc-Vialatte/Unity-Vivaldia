using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScriptEnnemis : MonoBehaviour
{
    public Transform shotPrefab; //Une prefab
    public float shootingRate = 0.25f;
    private float shootCooldown;
    private float shootCooldown2 = 0.25f;
    public int typeOfAttack;

    void Start()
    {
        shootCooldown = 0f;
        shootCooldown2 = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
        if (shootCooldown2 > 0)
        {
            shootCooldown2 -= Time.deltaTime;
        }
        
    }
    public void Attack1(bool isEnemy)
    {
        bool CanAttack = gameObject.GetComponent<IA_Ennemis>().follow; //Si il le suit

        switch (typeOfAttack) //3 Type d'attaque différente
        {
            case 1: //Cette attaque tire des boules de feu qui suivent le joueur si il ce trouve a sa porté
                {
                    if (CanAttack1 && CanAttack)
                    {
                        shootCooldown = shootingRate;

                        // Création d'un objet copie du prefab
                        var shotTransform = Instantiate(shotPrefab) as Transform;

                        // Position
                        shotTransform.position = transform.position;

                        // Propriétés du script
                        ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
                        if (shot != null)
                        {
                            shot.isEnemyShot = isEnemy;
                        }

                        // On saisit la direction pour le mouvement
                        MoveScriptBulletEnnemis move = shotTransform.gameObject.GetComponent<MoveScriptBulletEnnemis>();
                        move.mouvement = position();
                    }
                   
                } break;
            case 2: //Cette attaque tire des boules de feu, a gauche et a droite
                {
                    shootCooldown = shootingRate;
                    shootCooldown2 = shootingRate;
                    // Création d'un objet copie du prefab
                    var shotTransform = Instantiate(shotPrefab) as Transform;
                    var shotTransform2 = Instantiate(shotPrefab) as Transform;
                    // Position
                    shotTransform.position = transform.position;
                    shotTransform2.position = transform.position;
                    // Propriétés du script
                    ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
                    ShotScript shot2 = shotTransform.gameObject.GetComponent<ShotScript>();
                    if (shot != null)
                    {
                        shot.isEnemyShot = isEnemy;
                    }
                    if (shot2 != null)
                    {
                        shot2.isEnemyShot = isEnemy;
                    }

                    // On saisit la direction pour le mouvement
                    MoveScriptBulletEnnemis move = shotTransform.gameObject.GetComponent<MoveScriptBulletEnnemis>();
                    MoveScriptBulletEnnemis move2 = shotTransform2.gameObject.GetComponent<MoveScriptBulletEnnemis>();
                    move.mouvement = new Vector3(-10, 0);
                    move2.mouvement = new Vector3(10, 0);
                } break;
            case 3: //Cette attaque tire des boules de feu, en haut et en bas
                {
                    shootCooldown = shootingRate;
                    shootCooldown2 = shootingRate;
                    // Création d'un objet copie du prefab
                    var shotTransform = Instantiate(shotPrefab) as Transform;
                    var shotTransform2 = Instantiate(shotPrefab) as Transform;
                    // Position
                    shotTransform.position = transform.position;
                    shotTransform2.position = transform.position;
                    // Propriétés du script
                    ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
                    ShotScript shot2 = shotTransform.gameObject.GetComponent<ShotScript>();
                    if (shot != null)
                    {
                        shot.isEnemyShot = isEnemy;
                    }
                    if (shot2 != null)
                    {
                        shot2.isEnemyShot = isEnemy;
                    }

                    // On saisit la direction pour le mouvement
                    MoveScriptBulletEnnemis move = shotTransform.gameObject.GetComponent<MoveScriptBulletEnnemis>();
                    MoveScriptBulletEnnemis move2 = shotTransform2.gameObject.GetComponent<MoveScriptBulletEnnemis>();
                    move.mouvement = new Vector3(0, -10);
                    move2.mouvement = new Vector3(0, 10);
                } break;
            default:
                break;
        }
        

    }
    public bool CanAttack1
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
    Vector3 position() //Un vecteur de mouvement entre le joueur et l'objet
    {
        Transform target;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 mouvement = target.transform.position - transform.position;

        return mouvement;
    }
}
