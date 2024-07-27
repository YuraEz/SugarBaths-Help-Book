using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSHow : MonoBehaviour
{
    public Sprite[] images; // ������ �������� ��� ��������
    public GameObject[] obj;
    public Image displayImage; // UI Image ��� ����������� �������� �����������
    private int currentIndex = 0; // ������� ������ �����������

    [Space]
    public Button left;
    public Button right;

    // ����� ��� ����� ����������� �� ���������
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

    // ����� ��� ����� ����������� �� ����������
    public void PreviousImage()
    {
        currentIndex = (currentIndex - 1 + images.Length) % images.Length;
        UpdateImage();
    }

    // ����� ��� ���������� �������� �����������
    private void UpdateImage()
    {
        displayImage.sprite = images[currentIndex];
    }
}
