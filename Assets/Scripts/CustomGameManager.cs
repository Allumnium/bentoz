using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomGameManager : MonoBehaviour
{
    public GameObject player;

    public bool gameOver = false;

    void Start()
    {
        
    }

    void Update()
    {
        //CheckGameOver();
    }

	void CheckGameOver()
	{
		PlayerAttributes attrs = player.GetComponent<PlayerAttributes>();
		if (!attrs.Alive)
		{
			gameOver = true;
			SceneManager.LoadScene("GameOver");
		}
	}

}
