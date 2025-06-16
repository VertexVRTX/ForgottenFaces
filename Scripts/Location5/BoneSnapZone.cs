using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneSnapZone : MonoBehaviour
{
    public Transform targetZone;          // Целевая позиция для магнита
    public float snapDistance = 0.5f;     // Радиус срабатывания магнита
    public BoneController boneController; // Контроллер стадий кости

    private bool isSnapped = false;

    void Start()
    {
        // Скрываем крестики в начале (если boneController уже содержит логику скрытия)
        boneController.HideAllCrosses();
    }

    void Update()
    {
        if (!isSnapped)
        {
            float distance = Vector2.Distance(transform.position, targetZone.position);

            if (distance <= snapDistance)
            {
                SnapToTarget();
            }
        }
    }

    void SnapToTarget()
    {
        // Зафиксировать позицию кости
        transform.position = targetZone.position;

        isSnapped = true;

        // Отключить перетаскивание, если оно есть
        if (TryGetComponent<DragAndDrop>(out var drag))
            drag.enabled = false;

        // Показать крестики для первой стадии (или текущей)
        boneController.ShowStage(0);
    }
}
