using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public int correctFragmentID;
    private bool isFilled = false;

    public void TryPlaceFragment(Fragment fragment)
    {
        if (isFilled)
        {
            return;
        }

        if (fragment.fragmentID == correctFragmentID)
        {
            isFilled = true;
            fragment.transform.position = transform.position;
            fragment.transform.SetParent(transform);
            fragment.GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            
        }
    }

    public bool IsFilled()
    {
        return isFilled;
    }
}
