using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiecePlacer : MonoBehaviour
{
    [SerializeField] private PuzzleProgress puzzleCompletion;

    private bool isPlaced = false;
    
    public void PlaceFragment()
    {
        if (isPlaced) return;

        isPlaced = true;
        puzzleCompletion.RegisterFragmentPlaced();
    }
}
