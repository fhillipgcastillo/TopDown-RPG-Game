using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipement", menuName = "Scriptable Objects/Equipement")]
public class Equipement : Item
{
  public int defense;
  public int attackPower;
  public EquipementSlot slot;
  public new bool stackable = false;
  public EquipementQuality quality = EquipementQuality.Common;
  ItemType Type = ItemType.Equipment;
}

public enum EquipementSlot { Head, Chest, Lesgs, Hands, Feet, Weapon }

public enum EquipementQuality {
  Common,
  Uncommon,
  Rare,
  Epic,
  Legendary
}
