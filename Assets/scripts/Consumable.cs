using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Scriptable Objects/Consumable")]

public class Consumable: Item
{
    public int healthRestore;
    public int staminaRestore;
}
