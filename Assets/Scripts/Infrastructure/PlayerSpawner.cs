using PlayerLogic;
using UnityEngine;

namespace Infrastructure
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Transform _spawnPoint;

        private void Awake()
        {
            Instantiate(_playerPrefab, _spawnPoint);
        }
    }
}