using System;
using CodeBase.EnemyShip;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase
{
    public class EnemyGeneration:ObjectPool
    {
        [SerializeField] private GameObject[] _template;
        [SerializeField] private Player.Bird _birdTarget;
        [SerializeField] private float _secondSpawn;
        [SerializeField] private float _maxSpawnPositionY;
        [SerializeField] private float _minSpawnPositionY;

        private float _elepsedTime;

        private void Start()
        {
            Initilization(_template);
        }

        private void Update()
        {
            _elepsedTime += Time.deltaTime;

            if (_elepsedTime > _secondSpawn)
            {
                if (TryGetObject(out GameObject enemy))
                {
                    _elepsedTime = 0;

                    float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                    Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                    
                    enemy.SetActive(true);
                    enemy.transform.position = spawnPoint;

                    if (enemy.TryGetComponent(out Enemy enemyComponent))
                    {
                        enemyComponent.Died -= OnEnemyDied;
                        enemyComponent.Died += OnEnemyDied;
                        enemyComponent.Reset();    
                    }

                    DisableObjectAbroadScreen();
                }
            }
        }

        private void OnEnemyDied(Enemy enemy)
        {
            _birdTarget.IncrementScore();
            enemy.Died -= OnEnemyDied;
        }
    }
}