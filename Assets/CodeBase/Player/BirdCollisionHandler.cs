using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.EnemyShip;
using UnityEngine;


namespace CodeBase.Player
{
    [RequireComponent(typeof(Bird))]
    public class BirdCollisionHandler : MonoBehaviour
    {
        private Bird _bird;

        private void Start()
        {
            _bird = GetComponent<Bird>();
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.TryGetComponent(out EnemyBullet enemyBullet))
            {
                _bird.Died();
            }
        }
    }
}
