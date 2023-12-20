using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CanvasRotation : MonoBehaviour
{
    public Transform playerTrans;
    // Start is called before the first frame update
    void Start()
    {
        var obj = GameObject.FindGameObjectWithTag("Player");
        if (obj == null)
            return;
        playerTrans = obj.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTrans != null)
        {
            // 获取目标的位置
            Vector3 targetPosition = playerTrans.position;

            // 将目标的y坐标设置为Canvas的y坐标，只保留x和z坐标
            targetPosition.y = transform.position.y;

            // 让Canvas面向目标的x和z坐标
            transform.LookAt(targetPosition);
            Vector3 rotation = transform.rotation.eulerAngles;

            // 绕y轴旋转180度
            rotation.y += 180f;

            // 设置新的Rotation
            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}
