using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class Validator : MonoBehaviour
{
    public TMP_InputField inputField;

    private void Start()
    {
        // ������������� �� ������� ��������� ������ � ���� �����
        inputField.onValueChanged.AddListener(ValidateInput);
    }

    private void ValidateInput(string input)
    {
        // ���������� LINQ ��� ���������� ��������, ��������� ������ �����
        inputField.text = string.Concat(input.Where(char.IsDigit));
    }

    private void OnDestroy()
    {
        // ������������ �� ������� ��� ����������� �������, ����� �������� ������ ������
        inputField.onValueChanged.RemoveListener(ValidateInput);
    }
}
