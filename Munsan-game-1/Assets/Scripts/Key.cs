using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameManager gameManager;

    private void Start()
    {
        
    }

    private void Update()
    {
        //gameManager = GameObject.Find("GameManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
