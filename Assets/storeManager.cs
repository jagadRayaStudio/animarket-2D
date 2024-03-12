using System.Collections.Generic;
using UnityEngine;

public class storeManager : MonoBehaviour
{
    public StoreSO storeData;

    public void OpenShop()
    {
        StoreUI.Instance.DisplayStore(storeData);
    }
}