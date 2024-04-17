using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public static class EventUtils
{
    public static void AddListener(this EventTrigger eventTrigger, EventTriggerType type, UnityEngine.Events.UnityAction action)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = type;
        entry.callback.AddListener((data) => action());
        eventTrigger.triggers.Add(entry);
    }

    public static void RemoveListener(this EventTrigger eventTrigger, EventTriggerType type, UnityEngine.Events.UnityAction action)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = type;
        entry.callback.RemoveListener((data) => action());
        eventTrigger.triggers.Remove(entry);
    }

    public static void RemoveAllListeners(this EventTrigger eventTrigger)
    {
        eventTrigger.triggers.Clear();
    }

    public static bool HasEventObject(Vector2 screenPosition)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = screenPosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }
}
