using UnityEngine;

namespace ScriptableObjects.CharacterVisuals
{
    [CreateAssetMenu(fileName = "CharacterVisual", menuName = "CharacterVisualSO", order = 0)]
    public class CharacterVisualSO : ScriptableObject
    {
        [SerializeField] private Sprite _iconSprite;
        [SerializeField] private Sprite _normalSprite;
        [SerializeField] private Sprite _jumpSprite;
        [SerializeField] private bool _isFlip;
        [SerializeField] private bool _isCanan;

        public Sprite GetIconSprite()
        {
            return _iconSprite;
        }
    
        public Sprite GetNormalSprite()
        {
            return _normalSprite;
        }

        public Sprite GetJumpSprite()
        {
            return _jumpSprite;
        }

        public bool GetIsFlip()
        {
            return _isFlip;
        }

        public bool GetIsCanan()
        {
            return _isCanan;
        }
    }
}