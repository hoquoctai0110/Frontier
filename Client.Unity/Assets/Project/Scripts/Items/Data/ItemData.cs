using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string itemID;
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemIcon;
    [SerializeField] private bool isStackable;
    [SerializeField] private int maxStackSize;
    public int MaxStackSize => maxStackSize;
    public string ItemName => itemName;
}
