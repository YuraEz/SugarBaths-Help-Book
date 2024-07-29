using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditBtn : MonoBehaviour
{
    public NoteContainer note;
    public Button BTN;
    public Button BTN_OK;

    private void Start()
    {
        BTN.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("edit", note.index);
        });

        BTN_OK.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt($"deleted{note.index}", 1);
            //    PlayerPrefs.DeleteKey("edit");
            ServiceLocator.GetService<UIManager>().ChangeScreen("selection1");
            ServiceLocator.GetService<UIManager>().ChangeScreen("selection31");
        });
    }
}
