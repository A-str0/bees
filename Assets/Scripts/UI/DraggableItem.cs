using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform parentAfterDrag;

    public void OnBeginDrag(PointerEventData eventData) {
        //parentAfterDrag = transform.parent;
        //transform.SetParent(transform.root);
        //transform.SetAsLastSibling();
    }
    public void OnDrag(PointerEventData eventData) {
        //transform.position = InputManager.Instance.GetPointerPos();
    }
    public void OnEndDrag(PointerEventData eventData) {
        //transform.SetParent(parentAfterDrag);
    }
}
