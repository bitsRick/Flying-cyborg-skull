using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Bird;
using UnityEngine;

namespace CodeBase.EnemyShip
{
    public class EnemyShoot : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletTemplate;
        [SerializeField] private Transform _positionShoot;
        [SerializeField] private float _timeShoot;

        private float _timer;
    
        private void Update()
        {
            _timer += Time.deltaTime;
        
            if (_timeShoot <= _timer)
            {
                _timer = 0;
                Instantiate(_bulletTemplate,_positionShoot.transform.position,Quaternion.identity);
            }
        }
    }
}
