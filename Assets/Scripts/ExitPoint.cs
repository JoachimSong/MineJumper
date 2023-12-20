using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint : MonoBehaviour, IInteractable
{
    public void TriggerAction()
    {
        Application.Quit();
    }
}

