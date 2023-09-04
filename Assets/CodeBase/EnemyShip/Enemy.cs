using System.Collections;
using CodeBase.Bird;
using CodeBase.Player;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.EnemyShip
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private float _timerColorChange;
        
        private Color _currentColor;
        private Color _takeDamageColor = Color.red;
        private SpriteRenderer _spriteRenderer;
        private Coroutine _changedColorRoutine;
        private int _currentHealth;
        
        public event UnityAction<Enemy> Died;
    
        private void Start()
        {
            _currentHealth = _health;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _currentColor = _spriteRenderer.color;
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out BirdBullet bullet))
            {
                TakeDamage(bullet.GetComponent<Bullet>().Damage);
                Destroy(bullet.gameObject);
            }
        }
    
        public void Reset()
        {
            _currentHealth = _health;
        }
    
        private void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            
            if (_currentHealth <= 0)
            {
                Died?.Invoke(this);
                gameObject.SetActive(false);
            }
            else
            {
                _changedColorRoutine = StartCoroutine(ChangeColorIn(_timerColorChange));
            }
        }
    
        private IEnumerator ChangeColorIn(float time)
        {
            _spriteRenderer.color = _takeDamageColor;
            yield return new WaitForSeconds(time);
            _spriteRenderer.color = _currentColor;
        }
    }
}
