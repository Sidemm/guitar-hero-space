using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public PlayerController playerShip;
	public GameObject mainMenu;
	public AudioSource gamemusic;
	public AudioSource menumusic;

	void Start () {
	
	}

	void Update () {
	
	}

	public void OnStartPressed()
	{
		mainMenu.SetActive (false);
		playerShip.enabled = true;
		gamemusic.enabled = true;
		menumusic.enabled = false;
	}
}
