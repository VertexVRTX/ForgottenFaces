using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BoneController : MonoBehaviour
{
    public List<GameObject> boneStages;
    public List<GameObject> crossGroups;

    private int currentStage = 0;
    private int crossCount = 0;

    public void HideAllCrosses()
    {
        foreach (var crossGroup in crossGroups)
        {
            crossGroup.SetActive(false);
        }
    }
    void Start()
    {
        ShowStage(0);
    }

    public void ShowStage(int stage)
    {
        // Скрыть все кости и крестики
        foreach (var bone in boneStages) bone.SetActive(false);
        foreach (var cross in crossGroups) cross.SetActive(false);

        // Показать текущую стадию костей
        boneStages[stage].SetActive(true);

        // Если это не последний этап — показать крестики
        if (stage < crossGroups.Count - 1)
        {
            crossGroups[stage].SetActive(true);
            crossCount = crossGroups[stage].transform.childCount;
        }
        else
        {
            // Для последней стадии крестики не показывать
            crossCount = 0;
        }

        currentStage = stage;
    }

    public void OnCrossClicked(GameObject cross)
    {
        Destroy(cross);
        crossCount--;

        if (crossCount <= 0)
        {
            if (currentStage < boneStages.Count - 1)
            {
                ShowStage(currentStage + 1);
            }
            else
            {
                Debug.Log("Финальная стадия достигнута.");
            }
        }
    }
}
