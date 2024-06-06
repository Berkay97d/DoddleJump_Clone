using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private ChestCollisionController _chestCollisionController;
    [SerializeField] private ChestVisualController _chestVisualController;
    [SerializeField] private int _health;
    [SerializeField] private GameObject _point;
    [SerializeField] private Color _chestColor;
    
    public event Action<int> OnHealthChanged;
    
    private void SetHealth(int health, int damage)
    {
        _health = health;
        OnHealthChanged?.Invoke(health);
        
        var pointInstance = Instantiate(_point, transform.position + Vector3.up * 0.40f, Quaternion.identity);
        var point = pointInstance.GetComponent<TMP_Text>();

        if (damage == 3)
        {
            point.text = "375";
            point.color = _chestColor;
            AnimatePoint(pointInstance);
            
            DestroySelf();
            return;
        }
        
        point.text = "125";
        point.color = _chestColor;

        AnimatePoint(pointInstance);

        if (GetHealth() <= 0)
        {
            DestroySelf();
        }
    }

    private void AnimatePoint(GameObject pointInstance)
    {
        var point = pointInstance.GetComponent<TMP_Text>();
        point.alpha = 0;

        // Scale and fade in
        pointInstance.transform.localScale = Vector3.zero;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(pointInstance.transform.DOScale(Vector3.one * 1.45f, 0.2f))
            .Join(point.DOFade(1, 0.2f))
            .AppendInterval(0.50f)
            .Append(point.DOFade(0, 0.1f))
            .Join(pointInstance.transform.DOScale(Vector3.zero, 0.1f))
            .OnComplete(() => Destroy(pointInstance));
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
        SetHealth(GetHealth() + health, health);
    }
}
