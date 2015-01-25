using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    private DiscController discController;
    private PostController postController;

	// Use this for initialization
	void Start () {
        discController = this.GetComponentInChildren<DiscController>();
        postController = this.GetComponentInChildren<PostController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (discController.isDiscSelected() && postController.isPostSelected()) 
        {
            Debug.Log("Moving disc '" + discController.getSelectedDisc().name + "' to post '" + postController.getSelectedPost().name + "'.");
            discController.getSelectedDisc().GetComponent<DiscMover>().MoveToPost(postController.getSelectedPost());
            postController.setSelectedPost(null);
            discController.setDiscSelected(null);
        }
	}
}
