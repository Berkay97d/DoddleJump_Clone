using UnityEngine;
using Random = UnityEngine.Random;

public class CoinVisualController : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] _coinSprites;

    
    private void Start()
    {
        SetSprite(GetRandomCoinSprite());
    }

    
    private Sprite GetRandomCoinSprite()
    {
        return _coinSprites[Random.Range(0, _coinSprites.Length)];
    }
    
    private void SetSprite(Sprite sprite)
    {
        if (_spriteRenderer) _spriteRenderer.sprite = sprite;
    }

    public Coin GetCoin()
    {
        return _coin;
    }
}