using System.Collections;
using System.Collections.Generic;
using TMPro;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;
using UnityEngine.Rendering;

public class GetPremium : MonoBehaviour
{
    [SerializeField] private string bgPlayerPref;
    [SerializeField] private int ProductPrice= 2500;
    [SerializeField] private int bgIndex;
    [SerializeField] private Button buyPremium;
    [SerializeField] private TextMeshProUGUI selectText;

    [Space]
    [SerializeField] private string curProductType;


    [Space]
    [SerializeField] bool donateItem;
    [SerializeField] private string donateItemId;

    [Space]
    [SerializeField] private GameObject locked;

    private void Start()
    {
        OnStart();
        PrchsMan.Instance.onMs += OnStart;
    }

    private void OnStart(bool restore = false)
    {


        buyPremium.onClick.AddListener(() => {
            TryBuyProduct(donateItemId);
        }); //  (SelectItem);
//
//        if (donateItem)
//        {
//            if (restore)
//            {
//                PlayerPrefs.SetInt("BG4", 1);
//                PlayerPrefs.SetInt("curBG", 3);
//                BuyBG();
//            }
//       
//            buyBtn.onClick.AddListener(() => TryBuyProduct(donateItemId));
//        }
//        else buyBtn.onClick.AddListener(BuyBG);
//



        int hasPremium = PlayerPrefs.GetInt("premium", 0);

        if (hasPremium == 1) 
        {
            locked.SetActive(false);
        }
        else
        {
            locked.SetActive(true);
        }
    }


    private void Update()
    {
        if (PlayerPrefs.GetInt("premium", 0) == 1)
        {
           
            locked.SetActive(false);
        }
        else
        {
            locked.SetActive(true);
        }
    }

    //public void SelectItem()
    //{
    //    PlayerPrefs.SetInt(curProductType, bgIndex);
    //    selectText.text = "SELECTED";
    //}
    //
    //public void BuyBG()
    //{
    //    print("Buy");
    //    if (PlayerPrefs.GetInt("score", 0) >= ProductPrice)
    //    {
    //
    //        buyBtn.gameObject.SetActive(false);
    //        useBtn.gameObject.SetActive(true);
    //
    //        PlayerPrefs.SetInt(bgPlayerPref, 1);
    //        SelectItem();
    //    }
    //}

        private void TryBuyProduct(string stringId)
        {
        //PrchsM.Instance.buybg = this;

            if (!PrchsMan.Instance.IsInitialized())
            {
                Debug.Log("IAP is not initialized.");
            PokupkaScreenUI.Instance.ShowFailed();
                return;
            }

            Product product = PrchsMan.Instance._storeController.products.WithID(stringId);

        PokupkaScreenUI.Instance.ShowLoading();

            if (product != null && product.availableToPurchase)
            {
                Debug.Log($"Purchasing product asynchronously: '{product.definition.id}'");
                PrchsMan.Instance._storeController.InitiatePurchase(product);
            //BuyBG();
            }
            else
            {
                Debug.Log($"Could not initiate purchase for product ID: {stringId}. It might not be available for purchase.");
                PokupkaScreenUI.Instance.ShowFailed();
            }
        }

}
