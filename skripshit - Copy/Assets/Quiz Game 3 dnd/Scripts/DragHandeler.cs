using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{

    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;

    public enum Slot { Iqra, ain, dhod, dal, ba, Hijaiah };
    public Slot typeOfItem = Slot.Iqra;

    public void OnBeginDrag(PointerEventData eventData){
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData){
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData){
        itemBeingDragged = null;
        if(transform.parent == startParent) {
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            transform.position = startPosition;
        }
        
    }

}
