using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouvement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;
    float timer = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(target.position.x, target.position.y, target.position.z);//censée éviter un effet de smooth quadn le player revient dans cette scene, il faut essayer de fixer cette erreur.

    }

    // Update is called once per frame

    
    void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) //petit temps avant la recherche du personnage
        {
            target = GameObject.FindWithTag("Player").transform;
            maxPosition = target.GetComponent<PlayerInventory>().CamMax;
            minPosition = target.GetComponent<PlayerInventory>().CamMin;
        }

        if (transform.position != target.position) //si la camera a une position différente du joueur
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing); //on fait un bougé la caméra vers le joueur avec un légé smoothing
        }

    }
}
