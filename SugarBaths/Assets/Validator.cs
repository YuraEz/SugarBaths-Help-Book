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
        // Подписываемся на событие изменения текста в поле ввода
        inputField.onValueChanged.AddListener(ValidateInput);
    }

    private void ValidateInput(string input)
    {
        // Используем LINQ для фильтрации символов, оставляем только цифры
        inputField.text = string.Concat(input.Where(char.IsDigit));
    }

    private void OnDestroy()
    {
        // Отписываемся от события при уничтожении объекта, чтобы избежать утечек памяти
        inputField.onValueChanged.RemoveListener(ValidateInput);
    }
}
