using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSHow : MonoBehaviour
{
    public GameObject[] obj; // массив игровых объектов для слайдшоу
    public GameObject[] obj2;
    private int currentIndex = 0; // текущий индекс объекта

    [Space]
    public Button left;
    public Button right;

    // Метод для смены объекта на следующий
    private void Awake()
    {
        left.onClick.AddListener(PreviousObject);
        right.onClick.AddListener(NextObject);

        // Обеспечим, что только первый объект активен при запуске
        UpdateObject();
    }

    public void NextObject()
    {
        currentIndex = (currentIndex + 1) % obj.Length;
        UpdateObject();
    }

    // Метод для смены объекта на предыдущий
    public void PreviousObject()
    {
        currentIndex = (currentIndex - 1 + obj.Length) % obj.Length;

        UpdateObject();
    }

    // Метод для обновления текущего объекта
    private void UpdateObject()
    {
        // Выключаем все объекты
        for (int i = 0; i < obj.Length; i++)
        {
            obj[i].SetActive(false);
            obj2[i].SetActive(false);
        }
        // Включаем текущий объект
        obj[currentIndex].SetActive(true);
        obj2[currentIndex].SetActive(true);
    }
}
