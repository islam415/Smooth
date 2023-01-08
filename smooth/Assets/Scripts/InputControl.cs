using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputControl : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public bool gameStart = false;
    public Transform player;
    public float smoothx = 0.0225f;
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 temPosition = player.localPosition;
        temPosition.x = Mathf.Clamp(temPosition.x + eventData.delta.x * smoothx, -4.5f, 4.5f);
        player.localPosition = temPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        gameStart = true;
    }
}
