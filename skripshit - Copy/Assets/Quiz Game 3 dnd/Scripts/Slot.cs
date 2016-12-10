using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class Slot : MonoBehaviour, IDropHandler {

    public DragHandeler.Slot typeOfItem = DragHandeler.Slot.Hijaiah;
    //public string pictureName;
    public Text ket;
    public int nilai = 0;
    public int check = 0;
    
    public GameObject item {
        get {
            if(transform.childCount>0) {
                return transform.GetChild (0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData) {
        DragHandeler d = eventData.pointerDrag.GetComponent<DragHandeler>();
        
        //if (!item) {
        if (!item && typeOfItem == d.typeOfItem || typeOfItem == DragHandeler.Slot.Hijaiah) {
            DragHandeler.itemBeingDragged.transform.SetParent(transform);
            ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
            ket.gameObject.SetActive(true);
                
        }
                
        //}
                
    }

}
