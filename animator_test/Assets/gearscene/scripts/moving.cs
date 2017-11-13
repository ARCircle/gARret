using UnityEngine;
using UnityEngine.EventSystems;

public class moving : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private GameObject num;

    public void OnBeginDrag(PointerEventData eventDate)
    {
    }

    public void OnDrag(PointerEventData eventDate)
    {
        if (!MoveManeger.isMoving)//動かした直前には動かせないようにしている
            this.transform.position = eventDate.position;
    }

    public void OnEndDrag(PointerEventData eventDate)
    {
    }
}