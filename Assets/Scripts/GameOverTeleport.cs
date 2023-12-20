using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTeleport : MonoBehaviour, IInteractable
{
    public VoidEventSO gameoverEvent;
    public void TriggerAction()
    {
        gameoverEvent.RaiseEvent();
    }
}
