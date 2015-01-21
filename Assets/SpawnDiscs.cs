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
			// todo consider scale with collider
			largeDisc = Instantiate(disc, startingPost.position - new Vector3(0, postHeight / 2 - discHeight / 2, 0), startingPost.rotation) as Transform;
			largeDisc.name = "Large Disc";
			BoxCollider2D collider = largeDisc.GetComponent<BoxCollider2D>();
			collider.size = largeDisc.GetComponent<SpriteRenderer>().bounds.size;

			mediumDisc = Instantiate(disc, largeDisc.position + new Vector3(0, discHeight, 0), largeDisc.rotation) as Transform;
			mediumDisc.localScale = largeDisc.localScale - new Vector3(discReduction, 0f, 0f);
			mediumDisc.name = "Medium Disc";
			collider = mediumDisc.GetComponent<BoxCollider2D>();
			collider.size = mediumDisc.GetComponent<SpriteRenderer>().bounds.size;


			smallDisc = Instantiate(disc, mediumDisc.position + new Vector3(0, discHeight, 0), mediumDisc.rotation) as Transform;
			smallDisc.localScale = mediumDisc.localScale - new Vector3(discReduction, 0f, 0f);
			smallDisc.name = "Small Disc";
			collider = smallDisc.GetComponent<BoxCollider2D>();
			collider.size = smallDisc.GetComponent<SpriteRenderer>().bounds.size;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
