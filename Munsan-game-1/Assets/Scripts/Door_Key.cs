using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Key : MonoBehaviour
{
    public GameManager gameManager;
    public float RandomKey_1;
    public float RandomKey_2;
    public float RandomKey_3;
    public float RandomKey_4;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        gameManager = GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            gameManager.RandomKey.gameObject.SetActive(true);
            gameManager.RandomKeyPaper = true;
            RandomKey_1 = Random.Range(0, 9);
            RandomKey_2 = Random.Range(0, 9);
            RandomKey_3 = Random.Range(0, 9);
            RandomKey_4 = Random.Range(0, 9);
        }
    }
}
