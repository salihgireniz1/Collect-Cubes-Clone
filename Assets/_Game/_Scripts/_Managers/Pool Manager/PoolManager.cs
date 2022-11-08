using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField]
    private PoolInfo poolInfo;

    [SerializeField]
    private Transform poolParent;

    private void Awake()
    {
        InitializePool();
    }
    private void OnEnable()
    {
        TimerManager.OnTimesOut += ResetPool;
    }
    private void OnDisable()
    {
        TimerManager.OnTimesOut -= ResetPool;
    }
    void InitializePool()
    {
        ObjectPooler.GeneratePool(poolInfo, poolParent);
    }
    public void ResetPool()
    {
        ObjectPooler.ResetQueue();
    }
}
