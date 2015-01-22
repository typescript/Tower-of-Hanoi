using UnityEngine;
using System.Collections;

public class DiscSelector : MonoBehaviour {
	public float pulseTime = 1.0f;

	private SpriteRenderer discSprite;
	private float nextPulse;
	private int pulseDirection = -1;
	private bool clicked = false;

	// Use this for initialization
	void Awake () {
		discSprite = transform.GetComponent<SpriteRenderer>();
		nextPulse = Time.time + pulseTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (clicked) {
			float r = discSprite.color.r;
			float timeDiff = 1.0f * pulseDirection * Time.deltaTime / pulseTime;
			r = r + timeDiff;

			if (Time.time >= nextPulse) {
				if (pulseDirection == -1) {
					r = 0.0f;
				} else {
					r = 1.0f;
				}

				nextPulse = Time.time + pulseTime;
				pulseDirection *= -1;
			}

			discSprite.color = new Color(r, 1.0f, 1.0f);
		}
	}

	void OnMouseDown() {
		clicked = !clicked;

		Debug.Log (transform.name + " was clicked.");
		if (clicked) {
			nextPulse = Time.time + pulseTime;
		} else {
			discSprite.color = Color.white;
		}
	}
}
