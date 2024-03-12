using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class storeInteraction : MonoBehaviour
{
    [SerializeField] private GameObject storeCue;
    public GameObject storePanel;
    public Button interactButton;

    private bool PlayerInRange;

    private storeManager storeManager;

    private void Awake()
    {
        PlayerInRange = false;
        storeCue.SetActive(false);
        storePanel.SetActive(false);

        interactButton.onClick.AddListener(InteractWithStore);

        storeManager = GetComponent<storeManager>();
    }

    private void Update()
    {
        if (PlayerInRange)
        {
            storeCue.SetActive(true);
        }
        else
        {
            storeCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PlayerInRange = false;
        }
    }

    private void InteractWithStore()
    {
        if (PlayerInRange)
        {
            storePanel.SetActive(!storePanel.activeSelf);
            storeManager.OpenShop();
        }
    }
}
