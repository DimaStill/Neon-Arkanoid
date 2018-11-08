using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallHelper : MonoBehaviour {
	public float speed = 1.0f;
	public Text amountScoreText;
	public GameObject panel;
	[SerializeField] private AudioClip hitSound;
	int score = 0;
	AudioSource audioSource;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col) {
		audioSource.PlayOneShot (hitSound);
		if (col.gameObject.name == "Player") {
			if (gameObject.GetComponent<LineRenderer> ().material.ToString ().Split (' ') [0] !=
			    col.gameObject.GetComponent<LineRenderer> ().material.ToString ().Split (' ') [0]) {
				GameOver ();
				return;
			}
			float x = hitFactor (transform.position,
				          col.transform.position,
				          col.collider.bounds.size.x);

			Vector2 dir = new Vector2 (x, 1).normalized;

			GetComponent<Rigidbody2D> ().velocity = dir * speed;
		} else if (col.gameObject.name == "Hole") {
			GameOver ();
		} else if (col.gameObject.tag == "Block")
			score++;
	}

	float hitFactor(Vector2 ballPos, Vector2 racketPos,	float racketWidth) {
		return (ballPos.x - racketPos.x) / racketWidth;
	}

	void GameOver () {
		panel.SetActive (true);
		amountScoreText.text = score.ToString ();
		Destroy (gameObject);
	}
}
