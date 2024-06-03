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
    [SerializeField] private Sprite _2healthChestSprite;
    [SerializeField] private Sprite _1healthChestSprite;

    private CancellationTokenSource m_CancellationTokenSource;
    private Sprite m_CurrentSprite;


    private void Awake()
    {
        _chest.OnHealthChanged += OnHealthChanged;
    }

    private void Start()
    {
        m_CurrentSprite = _normalChestSprite;
    }

    private void OnDestroy()
    {
        _chest.OnHealthChanged -= OnHealthChanged;
    }
    
    
    private void OnHealthChanged(int health)
    {
        if (!_chest || !this) return;
        
        ShowDamageSprite();

        switch (health)
        {
            case 2:
                m_CurrentSprite = _2healthChestSprite;
                break;
            case 1:
                m_CurrentSprite = _1healthChestSprite;
                break;
        }
    }


    private async UniTaskVoid DisplayDamageSpriteAsync(CancellationToken token)
    {
        if (!_chest || !this) return;

        if (_damageChestSprite) SetSprite(_damageChestSprite);
        if (transform)
        {
            transform.localScale = Vector3.one * 0.150f;
            try
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_damageDisplayDuration), cancellationToken: token);
            }
            catch (OperationCanceledException)
            {
                return;
            }

            if (m_CurrentSprite) SetSprite(m_CurrentSprite);
            if (transform) transform.localScale = Vector3.one * 0.090f;
        }
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