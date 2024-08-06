using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing.Extension;
using UnityEngine.Purchasing;
using System;

public class PrchsMan : MonoBehaviour, IDetailedStoreListener
{
 //   public BuyBg buybg;

    private static PrchsMan _instance;
    public IStoreController _storeController;
    private IExtensionProvider _storeExtensionProvider;

    public Action<bool> onMs;

    public static PrchsMan Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject iapManager = new GameObject("PurchaseManager");
                DontDestroyOnLoad(iapManager);
                _instance = iapManager.AddComponent<PrchsMan>();
                _instance.InitializePurchasing();
            }
            return _instance;
        }
        set
        {
            if (_instance == null)
            {
                _instance = value;
            }
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

    }

    public void InitializePurchasing()
    {
        if (IsInitialized())
            return;

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct("premium", ProductType.NonConsumable);
        builder.AddProduct("BeginnerSubscription", ProductType.NonConsumable);
        builder.AddProduct("SilverSubscription", ProductType.NonConsumable);
        builder.AddProduct("GoldenSubscription", ProductType.NonConsumable);
        builder.AddProduct("PROSubscription", ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public bool IsInitialized()
    {
        return _storeController != null && _storeExtensionProvider != null;
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        _storeController = controller;
        _storeExtensionProvider = extensions;
    }

    public void OnInitializeFailed(InitializationFailureReason reason, string msg)
    {
        Debug.Log($"IAP Initialization Failed: {reason.ToString()} - {msg}");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        switch (args.purchasedProduct.definition.id)
        {
            case "premium":
                Debug.Log("premium successfully purchased!");
                PokupkaScreenUI.Instance.ShowSuccess();
                PlayerPrefs.SetInt("premium", 1);
                break;
            case "BeginnerSubscription":
                Debug.Log("BeginnerSubscription successfully purchased!");
                PokupkaScreenUI.Instance.ShowSuccess();
                PlayerPrefs.SetInt("BeginnerSubscription", 1);
                break;
            case "SilverSubscription":
                Debug.Log("SilverSubscription successfully purchased!");
                PokupkaScreenUI.Instance.ShowSuccess();
                PlayerPrefs.SetInt("SilverSubscription", 1);
                break;
            case "GoldenSubscription":
                Debug.Log("GoldenSubscription successfully purchased!");
                PokupkaScreenUI.Instance.ShowSuccess();
                PlayerPrefs.SetInt("GoldenSubscription", 1);
                break;
            case "PROSubscription":
                Debug.Log("PROSubscription successfully purchased!");
                PokupkaScreenUI.Instance.ShowSuccess();
                PlayerPrefs.SetInt("PROSubscription", 1);
                break;

            default:
                Debug.Log($"Unexpected product ID: {args.purchasedProduct.definition.id}");
                PokupkaScreenUI.Instance.ShowFailed();
                break;
        }
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        PokupkaScreenUI.Instance.ShowFailed();
        Debug.Log($"Purchase of {product.definition.id} failed due to {failureReason}");
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log($"IAP Initialization Failed: {error.ToString()}");
    }

    public void ReactivatePurchases()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer ||
            Application.isEditor)
        {
            Debug.Log("Starting purchase restoration...");

            var apple = _storeExtensionProvider.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((result, error) =>
            {
                if (result)
                {
                    Debug.Log("Purchases successfully restored.");

                    //onMs?.Invoke(true);
                    PlayerPrefs.SetInt("premium", 1);
                    PlayerPrefs.SetInt("BeginnerSubscription", 1);
                    PlayerPrefs.SetInt("SilverSubscription", 1);
                    PlayerPrefs.SetInt("GoldenSubscription", 1);
                    PlayerPrefs.SetInt("PROSubscription", 1);
                }
                else
                {
                    Debug.Log($"Failed to restore purchases. Error: {error}");
                }
            });
        }
        else
        {
            Debug.Log("Restore purchases is not supported on this platform.");
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
        PokupkaScreenUI.Instance.ShowFailed();
        Debug.Log($"Purchase of {product.definition.id} failed due to {failureDescription}");
    }
}
