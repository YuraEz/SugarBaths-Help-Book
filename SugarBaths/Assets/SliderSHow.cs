using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSHow : MonoBehaviour
{
    public GameObject[] obj; // ������ ������� �������� ��� ��������
    public GameObject[] obj2;
    private int currentIndex = 0; // ������� ������ �������

    [Space]
    public Button left;
    public Button right;

    // ����� ��� ����� ������� �� ���������
    private void Awake()
    {
        left.onClick.AddListener(PreviousObject);
        right.onClick.AddListener(NextObject);

        // ���������, ��� ������ ������ ������ ������� ��� �������
        UpdateObject();
    }

    public void NextObject()
    {
        currentIndex = (currentIndex + 1) % obj.Length;
        UpdateObject();
    }

    // ����� ��� ����� ������� �� ����������
    public void PreviousObject()
    {
        currentIndex = (currentIndex - 1 + obj.Length) % obj.Length;

        UpdateObject();
    }

    // ����� ��� ���������� �������� �������
    private void UpdateObject()
    {
        // ��������� ��� �������
        for (int i = 0; i < obj.Length; i++)
        {
            obj[i].SetActive(false);
            obj2[i].SetActive(false);
        }
        // �������� ������� ������
        obj[currentIndex].SetActive(true);
        obj2[currentIndex].SetActive(true);
    }
}
