using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpTest : MonoBehaviour, IInteractable
{
    public IntEventSO scoreUpEvent;
    public int score;
    public void TriggerAction()
    {
        scoreUpEvent.RaiseEvent(score);
    }
}
