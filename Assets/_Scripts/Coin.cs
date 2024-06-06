using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private CoinCollisionController _coinCollisionController;
    [SerializeField] private CoinVisualController _coinVisualController;
    [SerializeField] private GameObject _point;
    [SerializeField] private Color _coinColor;
    
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
        var pointInstance = Instantiate(_point, transform.position, Quaternion.identity);
        var point = pointInstance.GetComponent<TMP_Text>();
        
        point.text = "100";
        point.color = _coinColor;

        AnimatePoint(pointInstance);
        
        Destroy(gameObject);
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
            .AppendInterval(1)
            .Append(point.DOFade(0, 0.2f))
            .Join(pointInstance.transform.DOScale(Vector3.zero, 0.2f))
            .OnComplete(() => Destroy(pointInstance));
    }
}