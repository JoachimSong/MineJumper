using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    public float checkRadius;
    public LayerMask groundLayer;
    public Vector3 offset;

    [Header("State")]
    public bool isOnGround;

    private void Awake()
    {

    }
    private void Update()
    {
        Check();
    }
    private void Check()
    {
        //地面
        isOnGround = (Physics.OverlapSphere(transform.position + offset, checkRadius, groundLayer).Length) > 0 ? true : false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + offset, checkRadius);
    }
}
