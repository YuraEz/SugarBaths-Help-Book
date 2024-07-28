using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteContainer : MonoBehaviour
{
    public TextMeshProUGUI namef;
    public TextMeshProUGUI rate;
    public TextMeshProUGUI adress;
    public TextMeshProUGUI price;
    public TextMeshProUGUI desc;
    public List<Star> stars;

    public void OnChangeStars(int amount)
    {
        ResetStars();
        SetStars(amount);
    }

    private void SetStars(int amount)
    {
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
