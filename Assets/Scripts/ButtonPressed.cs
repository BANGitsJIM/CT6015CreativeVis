using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool beingPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        beingPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        beingPressed = false;
    }

    public bool Pressed ()
    {
        return beingPressed;
    }

    
}
