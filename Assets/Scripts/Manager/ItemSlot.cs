using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public RandomQuestion randomQuestion;
    public bool isTrue { get; set; }
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop");
        if (eventData.pointerDrag != null){
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            GameObject droppedObject = eventData.pointerDrag;

            if (droppedObject.GetComponent<ImageToBox>().getImageUrl() == randomQuestion.imageAnswer)
            {
                isTrue = true;
            }
            else
            {
                isTrue = false;
            }
        }
    }

    public bool checkAnswer()
    {
        return isTrue;
    }
}
