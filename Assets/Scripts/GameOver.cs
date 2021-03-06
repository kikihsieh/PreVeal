﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private Button[] buttons;
	private GameObject panel;
	private GameObject game_object_text;
	public GameObject gameOver;
	public static bool isInputEnabled = true;

	void Awake(){
		
		panel = GameObject.FindGameObjectWithTag("panel");
		game_object_text = GameObject.FindGameObjectWithTag("game_over_text");
		// at the beginging get the buttons
	
		buttons = GetComponentsInChildren<Button>();

		// Disable the buttons
		HideButtons();
	}

	public void HideButtons() {
		isInputEnabled = true;
		panel.SetActive(false);
		game_object_text.SetActive(false);
		//hide each button
		foreach (var b in buttons)
		{
			b.gameObject.SetActive(false);
		}
	}

    public void CowWins()
    {
        isInputEnabled = false;
        panel.SetActive(true);
        game_object_text.GetComponent<Text>().text = "Cow wins!";
        game_object_text.SetActive(true);
        //show each button
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(true);
        }
        Animation anim = gameOver.GetComponent<Animation>();
        anim.Play("game_over");
    }

    public void FarmerWins()
    {
        isInputEnabled = false;
        panel.SetActive(true);
        game_object_text.GetComponent<Text>().text = "Farmer wins!";
        game_object_text.SetActive(true);
        //show each button
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(true);
        }
        Animation anim = gameOver.GetComponent<Animation>();
        anim.Play("game_over");
    }


    public bool isShown() {
		return panel.activeSelf && game_object_text.activeSelf;
	}
	
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

	public void MainMenu() {
		Application.LoadLevel("MainMenu");
	}

	public void Quit() {
		Application.Quit();
	}
}
