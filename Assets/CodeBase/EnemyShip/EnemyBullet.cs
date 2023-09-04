using CodeBase.Bird;
using UnityEngine;

namespace CodeBase.EnemyShip
{
    public class EnemyBullet:Bullet
    {
        private void Update()
        {
            BulletRigidbody2D.velocity = Vector3.left * Speed;
        }
    }
}