using System;
using UnityEngine;

namespace Players
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerBoostController _playerBoostController;
        [SerializeField] private PlayerDeadChecker _playerDeadChecker;
        [SerializeField] private PlayerHorizontalMove _playerHorizontalMove;
        [SerializeField] private PlayerJumper _playerJumper;
        [SerializeField] private PlayerProperties _playerProperties;
        [SerializeField] private PlayerRotation _playerRotation;
        [SerializeField] private PlayerTeleport _playerTeleport;
        
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _normalSprite;
        [SerializeField] private Sprite _jumpSprite;


        private void Update()
        {
            if (_playerProperties.IsFalling())
            {
                _spriteRenderer.sprite = _normalSprite;
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.sprite = _jumpSprite;
                _spriteRenderer.flipX = false;
            }
        }
    }
}