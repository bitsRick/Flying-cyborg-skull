using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capcity;

    private Camera _camera;

    private List<GameObject> _pool = new List<GameObject>();

    public void RestPool()
    {
        foreach (var item in _pool) 
            item.SetActive(false);
    }

    protected void Initilization(GameObject[] template)
    {
        int randomEnemy;
        _camera = Camera.main;

        for (int i = 0; i < _capcity; i++)
        {
            randomEnemy = Random.Range(0, template.Length);
            GameObject spawner = Instantiate(template[randomEnemy], _container.transform);
            spawner.SetActive(false);
            _pool.Add(spawner);
        }
    }

    protected void DisableObjectAbroadScreen()
    {
        Vector3 disablePointX = _camera.ViewportToWorldPoint(new Vector2(0, 0.5f));
        
        foreach (var item in _pool)
        {
            if (item.transform.position.x < disablePointX.x) 
                item.SetActive(false);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }
}
