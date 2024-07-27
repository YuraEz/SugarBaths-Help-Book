using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Victorina : MonoBehaviour
{
   // [SerializeField] private string bgPlayerPref;
    [SerializeField] private int choseAnswer;
    [SerializeField] private Button SelectChose;
    [SerializeField] private Button NotSelected;
    [SerializeField] private Button change;

    [Space]
    [SerializeField] private string curAnswerId;

    private void OnEnable()
    {
        SelectChose.onClick.AddListener(SelectAnswer);
        NotSelected.onClick.AddListener(Klick);
        change.onClick.AddListener(ChangeSelection);

        int ChoseAnswer = PlayerPrefs.GetInt(curAnswerId, 0);

        print("работает");

        if (ChoseAnswer == choseAnswer)
        {
            NotSelected.gameObject.SetActive(false);
            SelectChose.gameObject.SetActive(true);
        }
        else
        {
            NotSelected.gameObject.SetActive(true);
            SelectChose.gameObject.SetActive(false);
        }
    }


    private void Update()
    {
        if (PlayerPrefs.GetInt(curAnswerId, 0) == choseAnswer)
        {
            NotSelected.gameObject.SetActive(false);
            SelectChose.gameObject.SetActive(true);
        }
        else
        {
            NotSelected.gameObject.SetActive(true);
            SelectChose.gameObject.SetActive(false);
        }
    }

    private void ChangeSelection()
    {
        PlayerPrefs.SetInt(curAnswerId, choseAnswer);
    }

    public void SelectAnswer()
    {
        PlayerPrefs.SetInt(curAnswerId, choseAnswer);
    }

    public void Klick()
    {
        print("Клик");
       // print("Buy");
       // if (PlayerPrefs.GetInt("score", 0) >= ProductPrice)
       // {
       //
       //     NotSelected.gameObject.SetActive(false);
       //     SelectChose.gameObject.SetActive(true);
       //
       //     PlayerPrefs.SetInt(bgPlayerPref, 1);
       //     SelectItem();
       // }
    }

}
