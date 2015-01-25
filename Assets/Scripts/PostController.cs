using UnityEngine;
using System.Collections;

public class PostController : MonoBehaviour {
    private GameObject selectedPost = null;
    private GameController gameController;
    private DiscController discController;

	// Use this for initialization
	void Start () {
        gameController = this.GetComponentInParent<GameController>();
        discController = transform.parent.GetComponentInChildren<DiscController>();
	}

    public bool isPostSelected()
    {
        return this.selectedPost != null;
    }

    public void setSelectedPost(GameObject selectedPost)
    {
        if (discController.isDiscSelected()) {
            if (selectedPost != null)
            {
                Debug.Log("The following post was selected: " + selectedPost.name);
            }
            else
            {
                Debug.Log("No post is selected.");
            }
            this.selectedPost = selectedPost;
        }
        else
        {
            Debug.Log("Cannot select post until disc is selected.");
        }
    }

    public GameObject getSelectedPost()
    {
        return this.selectedPost;
    }
}
