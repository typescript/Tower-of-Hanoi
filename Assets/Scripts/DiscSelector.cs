using UnityEngine;
using System.Collections;

public class DiscSelector : MonoBehaviour {
	public float pulseTime = 1.0f;

	private SpriteRenderer discSprite;
	private float nextPulse;
	private int pulseDirection = -1;
	private bool thisDiscIsSelected = false;
    private DiscController discController;

    void Start()
    {
        discController = transform.GetComponentInParent<DiscController>();
    }

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
        if (!discController.isDiscSelected()) { 
		    thisDiscIsSelected = true;
            nextPulse = Time.time + pulseTime;
            discController.setDiscSelected(transform.gameObject);
            pulseDirection = -1;
        } else if (discController.isDiscSelected() && thisDiscIsSelected) {
            discController.setDiscSelected(null);
        }
	}

    public void StopPulse()
    {
        discSprite.color = Color.white;
        thisDiscIsSelected = false;
    }
}
