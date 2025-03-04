using UnityEngine;

[CreateAssetMenu(fileName = "Equipement", menuName = "Scriptable Objects/Equipement")]
public class Equipement : Item
{
    public int defense;
    public int attackPower;
    public EquipementSlot slot;
    public new bool stackable = false;
}

public enum EquipementSlot { Head, Chest, Lesgs, Hands, Feet, Weapon }
