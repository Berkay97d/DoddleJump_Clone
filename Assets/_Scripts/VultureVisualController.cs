using System;
using UnityEngine;

public class VultureVisualController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;


    private void Start()
    {
        int random = UnityEngine.Random.Range(0, 2);

        _spriteRenderer.flipX = random switch
        {
            0 => false,
            1 => true,
            _ => throw new ArgumentOutOfRangeException(random + " Invalid random value")
        };
    }
}