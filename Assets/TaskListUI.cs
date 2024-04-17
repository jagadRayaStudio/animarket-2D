using UnityEngine;
using UnityEngine.UI;

public class TaskListUI : MonoBehaviour
{
    public static TaskListUI Instance;

    public void Awake()
    {
        Instance = this;
    }
}
