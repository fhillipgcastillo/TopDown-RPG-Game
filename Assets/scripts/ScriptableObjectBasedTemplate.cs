using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "ItemTemplate", menuName = "Scriptable Objects/ItemTemplate")]
public class ItemTemplate : ScriptableObject
{
    [Header("Only gameplay")]
    public TileBase tile;
    public ItemType type;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Only UI")]
    public bool stackable = true;

    [Header("Both")]
    public Sprite image;
}

//public enum ActionType
//{
//    Dig,
//    Mine,
//}

//public enum ItemType
//{
//    BuildingBlock,
//    Tool,
//}