using UnityEngine;
using System.Collections;

public class DiscMover : MonoBehaviour {
    private GameObject targetPost;
    private float startTime;
    private float journeyLength;
    private Vector3[] targetPositions = new Vector3[3];
    private int transitionIndex = 0;
    public float speed = 1.0f;

	// Update is called once per frame
	void Update () {
        if (targetPost != null)
        {
            if (journeyLength == 0f) { 
                journeyLength = Vector3.Distance(transform.position, targetPositions[transitionIndex]);
            }

            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, targetPositions[transitionIndex], fracJourney);

            if (transform.position == targetPositions[transitionIndex])
            {
                journeyLength = 0f;
                transitionIndex++;
                startTime = Time.time;
            }

            if (transitionIndex >= targetPositions.Length)
            {
                targetPost = null;
            }
        }
	}

    public void MoveToPost(GameObject targetPost) {
        this.targetPost = targetPost;
        this.transitionIndex = 0;
        targetPositions[0] = new Vector3(transform.position.x, 
            this.targetPost.transform.position.y + this.targetPost.GetComponent<SpriteRenderer>().bounds.size.y / 2 + transform.GetComponent<SpriteRenderer>().bounds.size.y, 
            0);
        targetPositions[1] = new Vector3(this.targetPost.transform.position.x, 
            this.targetPost.transform.position.y + this.targetPost.GetComponent<SpriteRenderer>().bounds.size.y / 2 + transform.GetComponent<SpriteRenderer>().bounds.size.y,
            0);
        targetPositions[2] = new Vector3(this.targetPost.transform.position.x,
            this.targetPost.transform.position.y - this.targetPost.GetComponent<SpriteRenderer>().bounds.size.y / 2 + transform.GetComponent<SpriteRenderer>().bounds.size.y / 2, 
            0);
        startTime = Time.time;
    }
}
