using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

public class FountainManager : MonoBehaviour
{
    [SerializeField]
    private float startDuration;

    private FountainInfo fountainInfo;

    private void OnEnable()
    {
        LevelManager.OnTimerLevelGenerated += InitializeFountain;
        LevelManager.OnAILevelGenerated += InitializeFountain;
        TimerManager.OnTimesOut += StopFlow;
    }
    private void OnDisable()
    {
        LevelManager.OnTimerLevelGenerated -= InitializeFountain;
        LevelManager.OnAILevelGenerated -= InitializeFountain;
        TimerManager.OnTimesOut -= StopFlow;
    }
    public void InitializeFountain(LevelInfoAsset asset)
    {
        fountainInfo = asset.levelFountainInfo;
        StartFlowing();
    }
    public void StopFlow()
    {
        StopAllCoroutines();
    }

    [Button("Test Fountain")]
    public void StartFlowing()
    {
        try
        {
            // Prevent system collapse caused by while loop.
            float spawnDuration = fountainInfo.spawnDuration;
            if (spawnDuration <= 0) spawnDuration = 0.1f;

            StartCoroutine(SpawnInfinitly(spawnDuration));
        }
        catch (System.NullReferenceException)
        {
            Debug.LogWarning("Cannot initialize fountain. " +
                "Please insert a proper FountainInfo from Inspector to LevelInfoAsset.");
        }
    }
    void SpawnFromFountain()
    {
        foreach (Transform spawnPoint in fountainInfo.SpawnPoints)
        {
            GameObject newObj = ObjectPooler.SpawnFromQueue();
            newObj.transform.localScale = Vector3.one * fountainInfo.fountainObjectSize;
            newObj.transform.position = spawnPoint.position;
            newObj.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * fountainInfo.throwForce, ForceMode.VelocityChange);
        }
    }
    IEnumerator SpawnInfinitly(float spawnDuration)
    {
        float timer = 0f;
        yield return new WaitForSeconds(startDuration);

        while (true)
        {
            if (timer < spawnDuration)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            else
            {
                timer = 0f;
                SpawnFromFountain();
            }
        }

    }
}
