using UnityEngine;

public class WoodPickup : MonoBehaviour
{
    [SerializeField, Min(1)] private int woodAmount = 1;
    public int WoodAmount => woodAmount;
}
