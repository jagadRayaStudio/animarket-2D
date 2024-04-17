using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractionsUI : MonoBehaviour
{
    public static PlayerInteractionsUI instance;

    public Button ButtonLeft;
    public Button ButtonRight;
    public Button Interactions;
    public Button ButtonPause;

    private void Awake()
    {
        instance = this;
    }
}
