using UnityEngine;

public class ChestCollisionController : MonoBehaviour
{
    [SerializeField] private Chest _chest;
    
    
    public Chest GetChest()
    {
        return _chest ? _chest : null;
    }
}