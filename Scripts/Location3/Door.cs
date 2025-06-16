using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int doorIndex;
    public DoorPuzzleManager puzzleManager;

    void OnMouseDown()
    {
        puzzleManager.CheckDoor(doorIndex);
    }
}
