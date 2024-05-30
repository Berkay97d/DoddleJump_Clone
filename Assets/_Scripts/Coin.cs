using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private CoinCollisionController _coinCollisionController;
    [SerializeField] private CoinVisualController _coinVisualController;
    
    
    public CoinCollisionController GetCoinCollisionController()
    {
        return _coinCollisionController;
    }
    
    public CoinVisualController GetCoinVisualController()
    {
        return _coinVisualController;
    }
    
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}