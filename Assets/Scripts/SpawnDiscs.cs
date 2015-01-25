using UnityEngine;
using System.Collections;

public class SpawnDiscs : MonoBehaviour {

	public Transform disc;
	public Transform startingPost;
	public float discReduction = 0.15f;

	private Transform largeDisc;
	private Transform mediumDisc;
	private Transform smallDisc;

	// Use this for initialization
	void Awake () {
		if (disc != null) {
			float postHeight = startingPost.GetComponent<SpriteRenderer>().bounds.size.y;
			float discHeight = disc.GetComponent<SpriteRenderer>().bounds.size.y;
			largeDisc = Instantiate(disc, startingPost.position - new Vector3(0, postHeight / 2 - discHeight / 2, 0), startingPost.rotation) as Transform;
			largeDisc.name = "Large Disc";

            largeDisc.parent = transform;

			mediumDisc = Instantiate(disc, largeDisc.position + new Vector3(0, discHeight, 0), largeDisc.rotation) as Transform;
			mediumDisc.localScale = largeDisc.localScale - new Vector3(discReduction, 0f, 0f);
			mediumDisc.name = "Medium Disc";

            mediumDisc.parent = transform;

			smallDisc = Instantiate(disc, mediumDisc.position + new Vector3(0, discHeight, 0), mediumDisc.rotation) as Transform;
			smallDisc.localScale = mediumDisc.localScale - new Vector3(discReduction, 0f, 0f);
			smallDisc.name = "Small Disc";

            smallDisc.parent = transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
