using System.Linq;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Equipement[] equipements = new Equipement[6];

    public void Awake()
    {
        //inventoryManager = InventoryManager.instance;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)){
            Debug.Log("F key pressed down");
            Equipe();
        }
    }
    public void Equipe()
    {
       var selectedItem = inventoryManager.GetSelectedItem(false);
        if (selectedItem != null)
        {
            Debug.Log("Selected item " +  selectedItem.name);
            equipements.Append(selectedItem);
        }
    }
}
