using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTP : MonoBehaviour
{
    //Script pour faire les carré de zone pour la caméra
    public Vector3 cameraChange;
    public Vector3 playerChange;
    private GameObject cam;
    public Vector3 maxcam;
    public Vector3 mincam;



    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<Camera>().gameObject;


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            cam.transform.position = cameraChange;
            GameObject.Find("Main Camera").GetComponent<CameraMouvement>().maxPosition = cameraChange + maxcam; //Ajout a la position de la caméra
            GameObject.Find("Main Camera").GetComponent<CameraMouvement>().minPosition = cameraChange + mincam; //Ajout a la position de la caméra
            other.transform.position = playerChange;
        }
    }
}