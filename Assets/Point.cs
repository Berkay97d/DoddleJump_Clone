using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointText;
    [SerializeField] private Color _chestColor;
    [SerializeField] private Color _coinColor;
    
    public void SetPoint(int point)
    {
        _pointText.text = point.ToString();
    }
    
    public void UpdateChestColor()
    {
        _pointText.color = _chestColor;
    }
    
    public void UpdateCoinColor()
    {
        _pointText.color = _coinColor;
    }
}
