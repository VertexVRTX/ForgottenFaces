using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainInteraction : MonoBehaviour
{
    public GameObject triggerObject;
    public GameObject targetObject;

    private bool targetActivated = false;

    void Start()
    {
        targetObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                GameObject clicked = hit.collider.gameObject;

                if (clicked == triggerObject && !targetActivated)
                {
                    Debug.Log("Клик по триггеру");
                    targetObject.SetActive(true);
                    targetActivated = true;
                }
                else if (clicked == targetObject && targetActivated)
                {
                    Debug.Log("Клик по целевому объекту — взаимодействие!");
                }
            }
        }
    }
}
