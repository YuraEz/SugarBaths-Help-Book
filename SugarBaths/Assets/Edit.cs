using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Edit : MonoBehaviour
{
    [SerializeField] private TMP_InputField noteName;
    [SerializeField] private TMP_Dropdown idk;
    [SerializeField] private TMP_InputField adress;
    [SerializeField] private TMP_InputField price;
    [SerializeField] private TMP_InputField desc;

    [SerializeField] private List<Star> stars;

    [SerializeField] private Button add;

    private int starsAmount;

    private void OnEnable()
    {
        int noteIndex = PlayerPrefs.GetInt("edit", 0);

        noteName.text = PlayerPrefs.GetString($"name{noteIndex}");
     //   idk.options[idk.value].text = PlayerPrefs.GetString($"stars{noteIndex}");
        adress.text = PlayerPrefs.GetString($"adress{noteIndex}");
        price.text = PlayerPrefs.GetString($"price{noteIndex}");
        desc.text = PlayerPrefs.GetString($"desc{noteIndex}");
        OnChangeStars(PlayerPrefs.GetInt($"stars{noteIndex}"));

        foreach (Star star in stars)
        {
            star.onChange += OnChangeStars;
        }

        add.onClick.AddListener(() => {
          //  int noteIndex = PlayerPrefs.GetInt("noteId", 0);
            PlayerPrefs.SetString($"name{noteIndex}", noteName.text);
            PlayerPrefs.SetString($"adress{noteIndex}", adress.text);
            PlayerPrefs.SetString($"price{noteIndex}", price.text);
            PlayerPrefs.SetString($"desc{noteIndex}", desc.text);
            PlayerPrefs.SetInt($"stars{noteIndex}", starsAmount);


            PlayerPrefs.SetString($"hz{noteIndex}", idk.options[idk.value].text);


            //   noteName.text = "";
            //  idk.itemText.text = "Finnish bathhouse";
            //  adress.text = string.Empty;
            //  price.text = string.Empty;
            //  desc.text = string.Empty;

            //    ResetStars();


            //    PlayerPrefs.SetInt("noteId", noteIndex + 1);
            ServiceLocator.GetService<UIManager>().ChangeScreen("selection1");
            ServiceLocator.GetService<UIManager>().ChangeScreen("selection31");
        });
    }

    private void OnChangeStars(int amount)
    {
        SetStars(amount);
    }

    private void SetStars(int amount)
    {
        starsAmount = amount;
        for (int i = 0; i < stars.Count; i++)
        {
            if (i < amount)
            {
                stars[i].on.gameObject.SetActive(true);
            }
            else
            {
                stars[i].on.gameObject.SetActive(false);
            }
        }
    }

    private void ResetStars()
    {
        foreach (Star star in stars)
        {
            star.on.gameObject.SetActive(false);
        }
    }
}
