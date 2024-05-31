using System;
using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;

public class ChestVisualController : MonoBehaviour
{
    [SerializeField] private Chest _chest;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _normalChestSprite;
    [SerializeField] private Sprite _damageChestSprite;
    [SerializeField] private float _damageDisplayDuration;

    private CancellationTokenSource m_CancellationTokenSource;


    private void Awake()
    {
        _chest.OnHealthChanged += OnHealthChanged;
    }

    private void OnDestroy()
    {
        _chest.OnHealthChanged -= OnHealthChanged;
    }
    
    
    private void OnHealthChanged()
    {
        ShowDamageSprite();
    }


    private async UniTaskVoid DisplayDamageSpriteAsync(CancellationToken token)
    {
        SetSprite(_damageChestSprite);
        try
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_damageDisplayDuration), cancellationToken: token);
        }
        catch (OperationCanceledException)
        {
            return;
        }
        SetSprite(_normalChestSprite);
    }
    
    private void SetSprite(Sprite sprite)
    {
        if (_spriteRenderer) _spriteRenderer.sprite = sprite;
    }
    
    
    public Chest GetChest()
    {
        return _chest ? _chest : null;
    }

    
    private void ShowDamageSprite()
    {
        m_CancellationTokenSource?.Cancel();
        m_CancellationTokenSource = new CancellationTokenSource();
        DisplayDamageSpriteAsync(m_CancellationTokenSource.Token).Forget();
    }
}