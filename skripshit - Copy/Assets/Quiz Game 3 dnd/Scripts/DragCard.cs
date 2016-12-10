using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class DragCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{

    public Transform parentToReturn = null;

    GameObject placeHolder = null;

    //public enum Slot { Weapon, Head, Arm, Leg, Inventory };
    //public Slot typeOfItem = Slot.Weapon;

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("Begin Drag");

        placeHolder = new GameObject();

        parentToReturn = this.transform.parent;
        this.transform.SetParent (this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;


    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("On Drag");

        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("End Drag");

        this.transform.SetParent(parentToReturn);

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
