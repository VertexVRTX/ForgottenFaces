using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
     public GameObject[] puzzlePieces;
    public Transform[] correctPositions;
    public GameObject objectToReveal;
    public float snapDistance = 0.5f;
    
    public GameObject fragmentsPanel;
    public GameObject correctPlacePanel;

    private bool[] piecesInPlace;
    private int piecesCount;
    private bool puzzleCompleted = false;

    void Start()
    {
        piecesCount = puzzlePieces.Length;
        if (correctPositions.Length != piecesCount)
        {
            enabled = false;
            return;
        }

        piecesInPlace = new bool[piecesCount];
        objectToReveal.SetActive(false);
    }

    void Update()
    {
        if (!puzzleCompleted)
        {
            CheckPuzzleCompletion();
        }
    }

    void CheckPuzzleCompletion()
    {
        int completedPieces = 0;
        for (int i = 0; i < piecesCount; i++)
        {
            if (Vector2.Distance(puzzlePieces[i].transform.position, correctPositions[i].position) < snapDistance)
            {
                piecesInPlace[i] = true;
            }
            else
            {
                piecesInPlace[i] = false;
            }

            if (piecesInPlace[i])
            {
                completedPieces++;
            }
        }

        if (completedPieces == piecesCount)
        {
            puzzleCompleted = true;
            objectToReveal.SetActive(true);

            foreach (GameObject piece in puzzlePieces)
            {
                Destroy(piece);
            }
            
            if (fragmentsPanel != null)
                fragmentsPanel.SetActive(false);
            if (correctPlacePanel != null)
                correctPlacePanel.SetActive(false);

            enabled = false;
        }
        else
        {
            objectToReveal.SetActive(false);
        }
    }
    
}
