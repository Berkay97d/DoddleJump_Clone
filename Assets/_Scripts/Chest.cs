using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private ChestCollisionController _chestCollisionController;
    [SerializeField] private ChestVisualController _chestVisualController;
    
    
    public ChestVisualController GetChestVisualController()
    {
        return _chestVisualController;
    }
    
    public ChestCollisionController GetChestCollisionController()
    {
        return _chestCollisionController;
    }
}