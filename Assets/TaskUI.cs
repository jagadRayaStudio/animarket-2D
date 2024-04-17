using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TaskUI : MonoBehaviour
{
    public static TaskUI instance;
    public Image icon;
    public TMP_Text itemInfo;
    public GameObject ClearIcon;

    public Task task;

    public void Awake()
    {
        instance = this;
    }

    public void SetTask(Task task)
    {
        this.task = task;
        icon.sprite = task.product.sprite;
        itemInfo.text = task.amount.ToString() + " " + task.product.name;
    }
}
