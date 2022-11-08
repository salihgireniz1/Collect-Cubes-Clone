using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(IHandleCollection))]
public class Base : MonoBehaviour
{
    [SerializeField]
    private float collectSpeed;

    [SerializeField]
    private AnimationCurve collectionType;

    private IHandleCollection collectionRespond;

    private void Awake()
    {
        collectionRespond = GetComponent<IHandleCollection>();
    }
    private void OnEnable()
    {
        GameManager.OnGameStateChange += ResetBase;
    }
    private void OnDisable()
    {
        GameManager.OnGameStateChange -= ResetBase;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ICollectable collectable))
        {
            // In any case, prevent a collected cube to be collected again.
            string currentLayerOfObject = LayerMask.LayerToName(other.gameObject.layer);
            if (currentLayerOfObject != "Cube") return;

            collectable.Collect();
            other.transform.DOMove(transform.position, collectSpeed).SetEase(collectionType)
                .OnComplete(()=> collectionRespond.UpdateCollectionScore(collectable.Amount));
        }
    }
    public void ResetBase(GameState state)
    {
        switch (state)
        {
            case GameState.Normal:
                collectionRespond.ResetCollectionScore();
                collectionRespond.ScoreText.enabled = false;
                break;
            case GameState.WithTimer:
                collectionRespond.ResetCollectionScore();
                collectionRespond.ScoreText.enabled = true;
                break;
            case GameState.AICompetative:
                collectionRespond.ResetCollectionScore();
                collectionRespond.ScoreText.enabled = true;
                break;
            default:
                break;
        }
    }
}