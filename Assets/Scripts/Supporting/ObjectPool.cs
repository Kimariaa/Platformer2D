using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Supporting
{
    public class ObjectPool
    {
        private List<GameObject> _pooledObject;

        public ObjectPool(int amount, GameObject prefabObject)
        {
            _pooledObject = new List<GameObject>();
            GameObject tmp;
            for (int i = 0; i < amount; i++)
            {
                tmp = GameObject.Instantiate(prefabObject);
                tmp.SetActive(false);
                _pooledObject.Add(tmp);
            }
        }

        public GameObject GetObject()
        {
            for (int i = 0; i < _pooledObject.Count; i++)
            {
                if(!_pooledObject[i].activeInHierarchy)
                {
                    return _pooledObject[i];
                }
            }
            return null;
        }
    }
}

