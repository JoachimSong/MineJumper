using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPoint : MonoBehaviour, IInteractable
{
    public SceneLoadEventSO loadEventSO;
    public GameSceneSO sceneToGo;
    public Vector3 positionToGo;
    public AudioDefinition audioDefinition;
    public AudioClip teleportClip;
    private void Awake()
    {
        audioDefinition = GetComponent<AudioDefinition>();
        audioDefinition.audioClip = teleportClip;
    }
    public void TriggerAction()
    {
        audioDefinition.PlayAudioClip();
        loadEventSO.RaiseLoadRequestEvent(sceneToGo, positionToGo);
    }
}
