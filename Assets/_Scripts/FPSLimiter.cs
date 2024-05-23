using UnityEngine;
using UnityEngine.Serialization;

public class FPSLimiter : MonoBehaviour
{
    [SerializeField] private int _targetFPS;

    
    private void Start()
    {
        Application.targetFrameRate = _targetFPS;
    }
}