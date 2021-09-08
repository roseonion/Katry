using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public LocationType KeyPoint;
    public KeySpawn KeySpawn_1;
    public Door_Key door_Key;
    public Button RandomKeyBtn;

    public KeySpawn[] PossibleLocations;

    public Text keyUI, UiText, ClearTime, RandomKey_1;

    public float keyCountPlayer = 0, KeyCount = 4;

    public bool EndScreen = false, RandomKeyPaper = false;

    public GameObject KeyPrefebs, Main, End, EndUi, RandomKey;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {

            KeyPoint = (LocationType)Random.Range(0, 3);
            KeySpawn_1 = FindLocationOfType(KeyPoint);
            KeyPrefebs = Instantiate(KeyPrefebs.gameObject, KeySpawn_1.transform.position, KeySpawn_1.transform.rotation) as GameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        door_Key = GetComponent<Door_Key>();
        
        keyUI.text = "X" + keyCountPlayer;

        if(keyCountPlayer >= KeyCount)
        {
            UiText.text = "이제 탈출하실 수 있습니다.";
        }

        if (RandomKeyPaper)
        {
            RandomKey_1.text ="-"+door_Key.RandomKey_1 + door_Key.RandomKey_2 + door_Key.RandomKey_3 + door_Key.RandomKey_4 + door_Key+"-";
        }

        if (EndScreen)
        {
            Main.SetActive(false);
            End.SetActive(true);
            Invoke("EndUiScreen", 5);
            ClearTime.text = "";
        }
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            if (keyCountPlayer>=KeyCount)
            {
                EndScreen = true; 
            }
            else
            {
                EndScreen = false; 
            }
        }

    }

    void RandomKeyBtn_1 ()
    {
        door_Key.RandomKey_1 = Random.Range(0, 9);
        door_Key.RandomKey_2 = Random.Range(0, 9);
        door_Key.RandomKey_3 = Random.Range(0, 9);
        door_Key.RandomKey_4 = Random.Range(0, 9);
    }

    public KeySpawn FindLocationOfType(LocationType i)
    {
        foreach (KeySpawn l in PossibleLocations)
        {
            if (l.Type == i)
            {
                return l;
            }
        }
        return null;
    }

    void EndUiScreen()
    {
        EndUi.SetActive(true);
    }
}
