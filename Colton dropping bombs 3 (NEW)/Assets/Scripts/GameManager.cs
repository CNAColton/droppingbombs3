using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
// using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Spawner Spawner;
    public GameObject title;
    private Vector2 screenBounds;
    public GameObject playerPrefab;
    private GameObject player;
    private bool gameStarted = false;

    void Awake()
    {
        Spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(screenBounds.x, screenBounds.y, Camera.main.transform.position.z));
        player = playerPrefab;
    }

    void Start()
    {
        Spawner.active = false;
        title.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.anyKeyDown)
            {
                ResetGame();
            }
        }
        else
        {
            if (!player)
            {
                OnPlayerKilled();
            }
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
    void ResetGame()
    {
        Spawner.active = true;
        title.SetActive(false);
        player = Instantiate(playerPrefab, new Vector3(0, 0, 0), playerPrefab.transform.rotation);
        gameStarted = true;
    }

    void OnPlayerKilled()
    {
        Spawner.active = false;
        gameStarted = false;

        splash.SetActive(true);
    }
}
