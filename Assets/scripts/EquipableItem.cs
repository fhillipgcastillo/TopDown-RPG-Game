using UnityEngine;

public class EquipableItem : MonoBehaviour
{
    public Equipement equipement;
    private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake(){
        sr = GetComponent<SpriteRenderer>();

    }
    void Start()
    {
         if (equipement != null)
        {
            sr.sprite = equipement.image;
        }
    }

    // Update is called once per frlame
    void Update()
    {
        
    }
}
