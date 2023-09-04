using System;
using CodeBase.Bird;
using UnityEngine;


namespace CodeBase.Player
{
    public class BirdBullet:Bullet
    {
        private void Update()
        {
           BulletRigidbody2D.velocity = transform.right * Speed;
        }
    }
}