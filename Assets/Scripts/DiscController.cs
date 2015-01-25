using UnityEngine;
using System.Collections;

public class DiscController : MonoBehaviour {
    private GameObject selectedDisc = null;

    public bool isDiscSelected()
    {
        return selectedDisc != null;
    }

    public void setDiscSelected(GameObject selectedDisc)
    {
        if (this.selectedDisc != null)
        {
            this.selectedDisc.GetComponent<DiscSelector>().StopPulse();
        }

        if (selectedDisc != null)
        {
            Debug.Log("The following disc is active: " + selectedDisc.name);
        }
        else
        {
            Debug.Log("No disc is selected.");
        }
        this.selectedDisc = selectedDisc;
    }

    public GameObject getSelectedDisc()
    {
        return this.selectedDisc;
    }
}
