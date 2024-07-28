using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictorinaResults : MonoBehaviour
{
    // Ссылка на родительский контейнер с Grid Layout Group
    public Transform container;

    void OnEnable()
    {
        Shuffle();
    }

    // Метод для перемешивания изображений
    void Shuffle()
    {
        // Получаем все дочерние объекты
        List<Transform> children = new List<Transform>();
        foreach (Transform child in container)
        {
            children.Add(child);
        }

        // Перемешиваем дочерние объекты
        for (int i = 0; i < children.Count; i++)
        {
            Transform temp = children[i];
            int randomIndex = Random.Range(0, children.Count);
            children[i] = children[randomIndex];
            children[randomIndex] = temp;
        }

        // Назначаем новый порядок дочерних объектов
        for (int i = 0; i < children.Count; i++)
        {
            children[i].SetSiblingIndex(i);
        }

        PlayerPrefs.SetInt("V1", 0);
        PlayerPrefs.SetInt("V2", 0);
        PlayerPrefs.SetInt("V3", 0);
        PlayerPrefs.SetInt("V4", 0);
        PlayerPrefs.SetInt("V5", 0);
        PlayerPrefs.SetInt("V6", 0);
        PlayerPrefs.SetInt("V7", 0);
    }
}
