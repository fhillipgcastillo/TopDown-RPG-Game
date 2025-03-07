using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public PlayerStats_so playerStats;

    public void Awake()
    {
        Instance = this;
    }
    public void HealPlayer(int heal)
    {
        Instance.playerStats.health += heal;
        if (Instance.playerStats.health > Instance.playerStats.maxHealth)
        {
            Instance.playerStats.health = Instance.playerStats.maxHealth;
        }
    }
    public void RestoreStamina(int stamina)
    {
        Instance.playerStats.stamina += stamina;
        if (Instance.playerStats.stamina > Instance.playerStats.maxStamina)
        {
            Instance.playerStats.stamina = Instance.playerStats.maxStamina;
        }
    }

    public static void DamagePlayer(int damage)
    {
        Instance.playerStats.health -= damage;
        if (Instance.playerStats.health <= 0)
        {
            Instance.playerStats.health = 0;
            Debug.Log("Player is dead");
        }
    }
}
