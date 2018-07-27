using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {

	// 1
	public void StartGame() {
	  SceneManager.LoadScene("Battle");
	}

	// 2
	public void Quit() {
	  Application.Quit();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
