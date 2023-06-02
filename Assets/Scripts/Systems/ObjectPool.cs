using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool
{
    private readonly GameObject _prefab;
    private readonly int _capacity;
    private readonly Transform _container;
    private readonly List<GameObject> _spawnList;

    public ObjectPool(GameObject prefab, int capacity, Transform container)
    {
        _prefab = prefab;
        _capacity = capacity;
        _container = container;
        _spawnList = new List<GameObject>(capacity);
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        for(int i = 0; i < _capacity; i++)
        {
            GameObject spawnedObj = MonoBehaviour.Instantiate(_prefab, _container);
            spawnedObj.SetActive(false);
            _spawnList.Add(spawnedObj);
        }
    }

    public GameObject ActivateObject()
    {
        GameObject obj = _spawnList.FirstOrDefault(o => o.activeSelf == false);

        if (obj == null)
            throw new System.Exception("All objects in object pool are activated");
        else
            obj.SetActive(true);

        return obj;
    }
}
