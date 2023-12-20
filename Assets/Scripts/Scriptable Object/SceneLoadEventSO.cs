using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/SceneLoadEventSO")]
public class SceneLoadEventSO : ScriptableObject
{
    public UnityAction<GameSceneSO, Vector3> LoadRequestEvent;

    public void RaiseLoadRequestEvent(GameSceneSO mapToLoad, Vector3 posToGo)
    {
        LoadRequestEvent?.Invoke(mapToLoad, posToGo);
    }
}