using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ZoneDrop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler{

    public DragCard.Slot typeOfItem = DragCard.Slot.Hijaiah;

    public void OnDrop(PointerEventData eventData) {
        Debug.Log(eventData.pointerDrag.name+ "Drop " + gameObject.name);

        DragCard d = eventData.pointerDrag.GetComponent<DragCard>();
        if(d != null) {
            if(typeOfItem == d.typeOfItem || typeOfItem == DragCard.Slot.Hijaiah) { 
                d.parentToReturn = this.transform; 
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("On enter");
    }

    public void OnPointerExit(PointerEventData eventData) {
        Debug.Log("On exit");
    }

}
