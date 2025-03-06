using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    [Header("Only gameplay")]
    public TileBase tile;
    ItemType Type {get; set; }
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Only UI")]
    public bool stackable = true;
    public int maxStackSize = 10;


    [Header("Both")]
    public Sprite image;
}

public enum ActionType
{
    Dig,
    Mine,
}

public enum ItemType
{
    BuildingBlock,
    Tool,
    Consumable,
    Equipment,
    Material,
}