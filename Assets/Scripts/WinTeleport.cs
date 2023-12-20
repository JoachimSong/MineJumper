using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTeleport : MonoBehaviour, IInteractable
{
    public Vector3 transPos;
    public GameObject player;
    public AudioDefinition audioDefinition;
    public AudioClip clip;
    private void Awake()
    {
        audioDefinition = GetComponent<AudioDefinition>();
        audioDefinition.audioClip = clip;
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void TriggerAction()
    {
        if(player != null)
        {
            audioDefinition.PlayAudioClip();
            player.transform.position = transPos;
            player.GetComponent<PlayerController>().Reset();
        }
    }
}
