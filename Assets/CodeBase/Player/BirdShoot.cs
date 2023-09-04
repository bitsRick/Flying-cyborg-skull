using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace CodeBase.Player
{
    [RequireComponent(typeof(Bird))]
    public class BirdShoot : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletTemplate;
        [SerializeField] private Transform _shootPosition;

        private Bird _bird;
    
        private void Start()
        {
            _bird = GetComponent<Bird>();
            GetComponent<Rigidbody2D>().freezeRotation = true;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Instantiate(_bulletTemplate, _shootPosition.position, _bird.transform.rotation);
            }
        }
    }
}