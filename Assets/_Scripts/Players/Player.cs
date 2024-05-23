using System;
using ScriptableObjects.CharacterVisuals;
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
        
        private CharacterVisualSO m_CharacterVisual;


        private void Awake()
        {
            GameManager.OnCharacterVisualChanged += GameManagerOnCharacterVisualChanged;
        }

        private void Update()
        {
            TryUpdateVisual();
        }
        
        private void OnDestroy()
        {
            GameManager.OnCharacterVisualChanged -= GameManagerOnCharacterVisualChanged;
        }


        private void GameManagerOnCharacterVisualChanged(CharacterVisualSO obj)
        {
            SetCharacterVisual(obj);
            
            _spriteRenderer.sprite = m_CharacterVisual.GetNormalSprite();
        }
        
        
        private bool TryUpdateVisual()
        {
            if (!m_CharacterVisual) return false;
            
            UpdateVisual(m_CharacterVisual.GetIsFlip());
            return true;
        }
        
        private void UpdateVisual(bool isFlip)
        {
            if (m_CharacterVisual.GetIsCanan()) _spriteRenderer.flipX = true;
            if (_playerProperties.IsFalling())
            {
                _spriteRenderer.sprite = m_CharacterVisual.GetNormalSprite();
                if (isFlip) _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.sprite = m_CharacterVisual.GetJumpSprite();
                if (isFlip) _spriteRenderer.flipX = false;
            }
        }
        
        private void SetCharacterVisual(CharacterVisualSO characterVisual)
        {
            m_CharacterVisual = characterVisual;
        }
        
        public CharacterVisualSO GetCharacterVisual()
        {
            return m_CharacterVisual;
        }
    }
}