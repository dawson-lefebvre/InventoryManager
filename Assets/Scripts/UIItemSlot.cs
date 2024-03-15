using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Image uiImage;
    bool isInteractable = false;
    public bool isSelected = false;
    [SerializeField] public ItemScriptableObject currentItem;
    TextMeshProUGUI slotText;
    private void Start()
    {
        uiImage = GetComponent<Image>();
        slotText = GetComponentInChildren<TextMeshProUGUI>();

        UpdateItem();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isInteractable = true;
        uiImage.color = new Color(0.75f, 0.75f, 0.75f, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isInteractable = false;
        if (!isSelected)
        {
            uiImage.color = Color.white;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isInteractable)
        {
            isSelected = true;
            uiImage.color = new Color(0.75f, 0.75f, 0.75f, 1);
            InventoryMenuingManager.instance.SelectSlot(this);
        }
    }

    public void UpdateItem()
    {
        if (currentItem != null)
        {
            slotText.text = currentItem.name;
        }
        else
        {
            slotText.text = string.Empty;
        }
        isSelected = false;
        uiImage.color = Color.white;
    }
}
