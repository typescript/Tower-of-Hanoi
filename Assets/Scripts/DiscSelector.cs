using UnityEngine;
using System.Collections;

public class DiscSelector : MonoBehaviour {
	public float pulseTime = 1.0f;

	private SpriteRenderer discSprite;
	private float nextPulse;
	private int pulseDirection = -1;
	private bool thisDiscIsSelected = false;
    private static bool aDiscIsSelected = false;

	// Use this for initialization
	void Awake () {
		discSprite = transform.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (thisDiscIsSelected) {
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
        Debug.Log(transform.name + " was clicked on.");

        if (!aDiscIsSelected) { 
		    thisDiscIsSelected = true;
            nextPulse = Time.time + pulseTime;
            aDiscIsSelected = true;
            pulseDirection = -1;
        } else if (aDiscIsSelected && thisDiscIsSelected) {
			discSprite.color = Color.white;
            aDiscIsSelected = false;
            thisDiscIsSelected = false;
        }
	}
}
