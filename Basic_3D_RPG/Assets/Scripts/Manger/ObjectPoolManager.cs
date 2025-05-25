using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 전반에 사용되는 오브젝트 풀 시스템을 관리하는 매니저입니다.
/// </summary>
public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance { get; private set; }

    [System.Serializable]
    public class PoolSetting
    {
        public PoolType poolType;
        public GameObject prefab;
        public int initialSize;
    }

    [SerializeField] private List<PoolSetting> poolSettings;
    private Dictionary<PoolType, Queue<GameObject>> poolDict = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        InitAllPools();
    }

    private void InitAllPools()
    {
        foreach (var setting in poolSettings)
        {
            Queue<GameObject> queue = new();
            for (int i = 0; i < setting.initialSize; i++)
            {
                GameObject go = Instantiate(setting.prefab);
                go.SetActive(false);
                queue.Enqueue(go);
            }

            poolDict[setting.poolType] = queue;
        }
    }

    public GameObject Spawn(PoolType type, Vector3 pos, Quaternion rot)
    {
        if (!poolDict.ContainsKey(type))
        {
            return null;
        }

        GameObject obj = poolDict[type].Count > 0 ? poolDict[type].Dequeue() : Instantiate(GetPrefab(type));
        obj.transform.SetPositionAndRotation(pos, rot);
        obj.SetActive(true);

        obj.GetComponent<IPoolable>()?.OnSpawn();
        return obj;
    }

    public void ReturnToPool(PoolType type, GameObject obj)
    {
        obj.SetActive(false);
        obj.GetComponent<IPoolable>()?.OnDespawn();
        poolDict[type].Enqueue(obj);
    }

    private GameObject GetPrefab(PoolType type)
    {
        return poolSettings.Find(p => p.poolType == type)?.prefab;
    }
}
