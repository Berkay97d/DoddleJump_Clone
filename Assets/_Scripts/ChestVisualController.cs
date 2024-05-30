using System;
using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class ChestVisualController : MonoBehaviour
{
    [SerializeField] private Chest _chest;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _normalChestSprite;
    [SerializeField] private Sprite _damageChestSprite;
    [SerializeField] private float _damageDisplayDuration;

    private CancellationTokenSource m_CancellationTokenSource;

    
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
        _spriteRenderer.sprite = sprite;
    }
    
    
    public Chest GetChest()
    {
        return _chest;
    }
    
    public void ShowDamageSprite()
    {
        m_CancellationTokenSource?.Cancel();
        m_CancellationTokenSource = new CancellationTokenSource();
        DisplayDamageSpriteAsync(m_CancellationTokenSource.Token).Forget();
    }
}