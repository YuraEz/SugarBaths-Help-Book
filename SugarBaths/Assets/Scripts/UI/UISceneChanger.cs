using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UISceneChanger : MonoBehaviour
{
    [SerializeField] private string sceneName;

    [Space]
    [SerializeField] private float delay;

    [Space]
    [SerializeField] private bool isRetry = false;
    [SerializeField] private bool isNextScene = false;

    [Space]
    [SerializeField] private bool isLvl = false;
    [SerializeField] private bool lvl1 = false;
    [SerializeField] private Image locked;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI2;
    [SerializeField] private Button btn1;

    private Button button;
    private bool isClicked;



    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OnBtnClick()
    {
        if (isRetry)
        {
            Scene Scennnnn = SceneManager.GetActiveScene();
            sceneName = Scennnnn.name;
        }
        if (isNextScene)
        {

        }

        if (isClicked) return;

        isClicked = true;
        Invoke(nameof(ChangeScene), delay);
    }

    private void Start()
    {
        for (int i = 0; i < sceneName.Length; i++)
        {
            // print(sceneName[i]);
        }

        button = GetComponent<Button>();
        button.onClick.AddListener(OnBtnClick);


        if (isLvl)
        {
            if (btn1) btn1.onClick.AddListener(OnBtnClick);

            print(sceneName);

            string lastTwoChars = sceneName.Substring(sceneName.Length - 2);


            textMeshProUGUI.text = $"{lastTwoChars}";


            int lastLevel = int.Parse(lastTwoChars);

            if (lvl1)
            {
                locked.gameObject.SetActive(false);
                button.interactable = true;

                return;
            }

            if (PlayerPrefs.GetInt("lvl", 0) + 1 >= lastLevel)
            {
                locked.gameObject.SetActive(false);

                button.interactable = true;
            }
            else
            {
                locked.gameObject.SetActive(true);

                button.interactable = false;

                ColorBlock colors = button.colors;

                colors.disabledColor = colors.normalColor;
                button.colors = colors;
            }
        }



    }

}
