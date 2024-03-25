using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Spawner Spawner;
    public GameObject title;
    private Vector2 screenBounds;

    void Awake()
    {
        Spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(screenBounds.width, screenBounds.height, Camera.main.transform.postion.z));
    }

    void Start()
    {
        Spawner.active = false;
        title.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Spawner.active = true;
            title.SetActive(false);
        }

        var nextBomb = GameObject.FindGameObjectsWithTag("Bomb");

        foreach (GameObject bombObject in nextBomb)
        {
            if (bombObject.transform.position.y < (-screenBounds.y) - 12)
            {
                Destroy(bombObject);
            }
        }
    }
}
