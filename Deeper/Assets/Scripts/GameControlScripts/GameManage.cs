using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{

    //Player Prefab
    [SerializeField] GameObject Anvil;
    // Actual player object
    GameObject realAnvil;

    //Empty Prefab
    [SerializeField] GameObject Camera;
    //Camera Object
    GameObject camObj;


    void Start()
    {
        Invoke("spawnAnvil", 0);
        Invoke("setUpCamera", 0.2f);
    }

    void Update()
    {
        
    }

    void spawnAnvil()
    {
        //find spawnpoint
        GameObject spawn = GameObject.Find("SpawnPoint");

        Vector3 spawnOffset = new Vector3(0, 1, 0);

        realAnvil = Instantiate(Anvil, spawn.transform.position + spawnOffset, Quaternion.identity);
    }

    void setUpCamera()
    {
        Vector3 camInitPos = realAnvil.transform.position + new Vector3(8, 0, 0);
        Camera.transform.position = camInitPos;
        Camera.transform.Rotate(new Vector3(0, 270, 0));
    }
}
