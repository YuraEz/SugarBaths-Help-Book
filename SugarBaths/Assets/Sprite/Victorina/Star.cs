using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    public Action<int> onChange;

    [SerializeField] private Button btn;
    [SerializeField] private int index;
    public Image on;
    private void Start()
    {
        btn.onClick.AddListener(() =>
        {
            onChange?.Invoke(index);
        });
    }

}
