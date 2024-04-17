using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] PlayerInteractionsUI playerUI;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] PlayerSpawner playerSpawner;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    private void Update()
    {
        
    }

}
