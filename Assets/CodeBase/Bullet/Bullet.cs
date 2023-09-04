using UnityEngine;

namespace CodeBase.Bird
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] protected float Speed;
        [SerializeField] private int _damage;

        protected Rigidbody2D BulletRigidbody2D;

        public int Damage => _damage;

        private void Start()
        {
            BulletRigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out DestroyBullet destroyBullet))
            {
                Destroy(gameObject);
            }
        }
    }
}