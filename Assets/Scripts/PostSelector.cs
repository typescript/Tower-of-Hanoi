using UnityEngine;
using System.Collections;

public class PostSelector : MonoBehaviour {
    private PostController postController;

	// Use this for initialization
	void Start () {
        postController = this.GetComponentInParent<PostController>();
	}

    void OnMouseDown()
    {
        if (!postController.isPostSelected())
        {
            postController.setSelectedPost(this.gameObject);
        }
    }
}
