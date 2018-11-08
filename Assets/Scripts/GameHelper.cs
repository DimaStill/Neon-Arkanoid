using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour {
	[SerializeField] private GameObject leftWall;
	[SerializeField] private GameObject rightWall;
	[SerializeField] private GameObject roof;
	[SerializeField] private GameObject panel;
	[SerializeField] private GameObject nextLevel;
	BallHelper ballHelper;
	// Use this for initialization
	void Start () {
		Camera.main.orthographicSize = 10;
		roof.transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width / 2, Screen.height - 1f, 10));
		leftWall.transform.position = Camera.main.ScreenToWorldPoint(new Vector3 (1f, Screen.height / 2, 10));
		rightWall.transform.position = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width - 1f, Screen.height / 2, 10));
		ballHelper = GameObject.FindObjectOfType<BallHelper>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!CheckAvailabilityBlock ()) {
			panel.SetActive (true);
			ballHelper.speed = 0;
		}
	}

	public void Restart () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	bool CheckAvailabilityBlock () {
		if (GameObject.FindGameObjectsWithTag ("Block").Length == 0)
			return false;
		return true;
	}

	public void NextLevel () {
		int indexNextScene = SceneManager.GetActiveScene ().buildIndex + 1;
		SceneManager.LoadScene(indexNextScene);
	}
}
