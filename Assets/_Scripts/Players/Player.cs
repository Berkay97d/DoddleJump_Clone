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
    }
}