using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class CoinThrower : MonoBehaviour
{
    [SerializeField] private Chest _chest;
    [SerializeField] private SpriteRenderer _coinPrefab;
    [SerializeField] private Transform _initialTransform;

    private void Awake()
    {
        _chest.OnHealthChanged += OnChestHealthChanged;
    }
    
    private void OnDestroy()
    {
        _chest.OnHealthChanged -= OnChestHealthChanged;
    }
    
    private void OnChestHealthChanged(int health)
    {
        ThrowCoin();
    }

    private async void ThrowCoin()
    {
        SpriteRenderer coin = CreateCoin();

        await coin.transform.DOJump(coin.transform.position + Vector3.up * 0.500f, 0.750f, 1, 0.500f).AsyncWaitForCompletion();

        await coin.transform.DOScale(Vector3.zero, 0.125f).AsyncWaitForCompletion();
        
        Destroy(coin.gameObject);
    }

    private SpriteRenderer CreateCoin()
    {
        SpriteRenderer coin = Instantiate(_coinPrefab, _initialTransform.position, Quaternion.identity);
        return coin;
    }
}