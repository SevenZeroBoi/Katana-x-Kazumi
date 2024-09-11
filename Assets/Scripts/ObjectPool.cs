using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    private void Awake()
    {
        Instance = this;
    }

    private Dictionary<string, Queue<GameObject>> _poolDictionary = new Dictionary<string, Queue<GameObject>>();

    public GameObject GetFromPool(string poolKey, GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (_poolDictionary.ContainsKey(poolKey) && _poolDictionary[poolKey].Count > 0)
        {
            GameObject objectToReuse = _poolDictionary[poolKey].Dequeue();
            objectToReuse.SetActive(true);
            objectToReuse.transform.position = position;
            objectToReuse.transform.rotation = rotation;
            return objectToReuse;
        }
        else
        {
            GameObject newObject = Instantiate(prefab, position, rotation);
            return newObject;
        }
    }

    public void ReturnToPool(string poolKey, GameObject objectToReturn)
    {
        if (!_poolDictionary.ContainsKey(poolKey))
        {
            _poolDictionary[poolKey] = new Queue<GameObject>();
        }

        objectToReturn.SetActive(false);
        _poolDictionary[poolKey].Enqueue(objectToReturn);
    }
}
