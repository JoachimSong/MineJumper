using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    private IInteractable targetItem;

    public void Awake()
    {

    }
    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }
    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            targetItem = other.GetComponent<IInteractable>();
            targetItem.TriggerAction();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
