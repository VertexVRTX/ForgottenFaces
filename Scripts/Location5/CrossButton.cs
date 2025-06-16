using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossButton : MonoBehaviour
{
    public BoneController boneController;

    public void OnClick()
    {
        boneController.OnCrossClicked(gameObject);
    }
}
