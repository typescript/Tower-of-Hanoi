using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PostMonitor : MonoBehaviour {
    private Stack<GameObject> discStack = new Stack<GameObject>();
    public bool isWinningPost = false;
    private bool winner = false;
    public Transform winningImage;

    public void SetTopDisc(GameObject topDisc)
    {
        discStack.Push(topDisc);
        if (discStack.Count == 3 && isWinningPost)
        {
            winner = true;
        }
    }

    public GameObject GetTopDisc()
    {
        return discStack.Peek();
    }

    public GameObject PullTopDisc()
    {
        return discStack.Pop();
    }

    public bool HasTopDisc()
    {
        return discStack.Count > 0;
    }

    void Update()
    {
        if (winner)
        {
            Debug.Log("You wonned!");
            Instantiate(winningImage);
            winner = false;
        }
    }
}
