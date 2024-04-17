using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialUI : MonoBehaviour
{
    public static TutorialUI instance;

    public Image Image;
    public TMP_Text Content;

    public Button NextBtn;
    public Button PrevBtn;
    private void Awake()
    {
        instance = this;
    }
}
