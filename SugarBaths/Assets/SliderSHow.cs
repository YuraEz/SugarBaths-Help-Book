using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSHow : MonoBehaviour
{
    public Sprite[] images; // массив картинок для слайдшоу
    public GameObject[] obj;
    public Image displayImage; // UI Image для отображения текущего изображения
    private int currentIndex = 0; // текущий индекс изображения

    [Space]
    public Button left;
    public Button right;

    // Метод для смены изображения на следующее
    private void Awake()
    {
        left.onClick.AddListener(PreviousImage);
        right.onClick.AddListener(NextImage);
    }

    public void NextImage()
    {
        currentIndex = (currentIndex + 1) % images.Length;
        UpdateImage();
    }

    // Метод для смены изображения на предыдущее
    public void PreviousImage()
    {
        currentIndex = (currentIndex - 1 + images.Length) % images.Length;
        UpdateImage();
    }

    // Метод для обновления текущего изображения
    private void UpdateImage()
    {
        displayImage.sprite = images[currentIndex];
    }
}
