using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private IInteractable targetItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Score"))
        {
            targetItem = other.GetComponent<IInteractable>();
            targetItem.TriggerAction();
        }
    }
    private void OnTriggerExit(Collider other)
    {

    }
}
