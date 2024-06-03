using System;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private ChestCollisionController _chestCollisionController;
    [SerializeField] private ChestVisualController _chestVisualController;
    [SerializeField] private int _health;
    
    public event Action<int> OnHealthChanged;
    
    
    private void SetHealth(int health)
    {
        _health = health;
        OnHealthChanged?.Invoke(health);
        
        if (GetHealth() <= 0)
        {
            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        if (gameObject) Destroy(gameObject);
    }

    private int GetHealth()
    {
        return _health;
    }
    
    public ChestVisualController GetChestVisualController()
    {
        return _chestVisualController;
    }
    
    public ChestCollisionController GetChestCollisionController()
    {
        return _chestCollisionController;
    }
    
    public void AddHealth(int health)
    {
        SetHealth(GetHealth() + health);
    }
}