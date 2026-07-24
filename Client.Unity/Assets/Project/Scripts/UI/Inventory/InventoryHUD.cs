using UnityEngine;

public class InventoryHUD : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    private int currentWoodAmount => playerInventory.WoodAmount;
    [SerializeField] private TMPro.TextMeshProUGUI woodAmountText;

    private void OnEnable()
    {
        playerInventory.OnItemAmountChanged += UpdateItemAmountUI;
        UpdateItemAmountUI();
    }

    private void OnDisable()
    {
        playerInventory.OnItemAmountChanged -= UpdateItemAmountUI;
    }

    private void UpdateItemAmountUI()
    {
        woodAmountText.text = currentWoodAmount.ToString();
    }

}
