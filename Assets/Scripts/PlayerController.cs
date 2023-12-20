using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    // 控制旋转速度
    public float rotateSpeed = 3f;
    // 控制跳跃高度
    public float jumpSpeed = 5f;
    // Start is called before the first frame update

    public Rigidbody rb;
    public Transform cameraTrans;
    private bool isDown;
    private float downTime;
    private AudioDefinition audioDefinition;
    public PhysicsCheck physicsCheck;
    public GvrReticlePointer pointer;
    public float maxDownTime;
    public float minDownTime;
    public VoidEventSO gameoverEvent;
    public int bestScore;
    public IntEventSO scoreUpEvent;
    public AudioClip jumpAudioClip;
    public AudioClip powerfulJumpAudioClip;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioDefinition = GetComponent<AudioDefinition>();
        downTime = 0;
        int loadedInt = PlayerPrefs.GetInt("MyInt");
        if (loadedInt != 0)
        {
            bestScore = loadedInt;
        }
    }
    void Start()
    {

    }

    private void OnEnable()
    {
        gameoverEvent.OnEventRaised += EndlessGameOver;
        scoreUpEvent.OnEventRaised += ScoreUp;
    }



    private void OnDisable()
    {
        gameoverEvent.OnEventRaised -= EndlessGameOver;
        scoreUpEvent.OnEventRaised -= ScoreUp;
    }

    private void ScoreUp(int score)
    {
        this.Reset();
        this.transform.position = new Vector3(0, 0.4f, 0);
    }
    private void EndlessGameOver()
    {
        this.Reset();
        this.transform.position = new Vector3(0, 0.4f, 0);
    }
    // Update is called once per frame
    void Update()
    {
        Test();
        Timer();
    }

    void Test()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isDown = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isDown = false;
        }
    }
    void Timer()
    {
        if (isDown)
        {
            downTime += Time.deltaTime;
        }
        else if (!isDown && downTime > minDownTime && physicsCheck.isOnGround)
        {
            downTime = downTime > maxDownTime ? downTime = maxDownTime : downTime;

            float percentum = (downTime - minDownTime) / (maxDownTime - minDownTime) * 1f; 

            float power = 2f * percentum + 1f;
            audioDefinition.audioClip = powerfulJumpAudioClip;
            audioDefinition.PlayAudioClip();
            Move(power);
            downTime = 0;
        }
        else if (!isDown && downTime > 0 && downTime <= minDownTime  && physicsCheck.isOnGround) 
        {
            float power = 1f;
            audioDefinition.audioClip = jumpAudioClip;
            audioDefinition.PlayAudioClip();
            Move(power);
            downTime = 0;
        }
        else if (!isDown && !physicsCheck.isOnGround) 
        {
            downTime = 0;
        }
        float angle = (downTime - minDownTime) * 360 / (maxDownTime - minDownTime);
        angle = Mathf.Clamp(angle, 0, 360);
        pointer.UpdateAngle(angle);

    }

    void Move(float power)
    {
        // 获取摄像机前向向量，将其y轴的值设置为0，得到一个只在x轴和z轴上移动的方向向量
        Vector3 cameraForward = cameraTrans.forward;
        cameraForward.y = 0f;
        Vector3 moveDirection = cameraForward.normalized;

        // 根据移动方向和速度，计算刚体的速度向量
        Vector3 velocity = moveDirection * moveSpeed * (power * 0.8f + 0.2f);
        rb.velocity = new Vector3(velocity.x, jumpSpeed * (power * 0.4f + 0.6f), velocity.z);
    }

    public void Reset()
    {
        rb.velocity = Vector3.zero;
        downTime = 0;
    }
}
