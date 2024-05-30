using UnityEngine;

public class CoinCollisionController : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    
    
    public Coin GetCoin()
    {
        return _coin;
    }
}