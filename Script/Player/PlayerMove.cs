using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField]
    private float walkSpeed;

    [SerializeField]
    private float lookSensitivity;

    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX;


    AudioSource shootaudio;
    public bool isStoryState = false;
    public int Shootcount = 1;
    public GameObject Bullet;

    [SerializeField]
    private Camera theCamera;
    private Rigidbody myRigid;

    private Camera cam;
    private Animator ani;
    private playerState nowstate = playerState.Idle;
    private bool isDead = false;
    private readonly int hasMove = Animator.StringToHash("isWalk");
    private readonly int hasShoot = Animator.StringToHash("isShoot");
    private enum playerState
    {
        Idle,
        Shoot
    }
    void Start()
    {
        shootaudio = GetComponent<AudioSource>();
        myRigid = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        cam = GetComponentInChildren<Camera>();
        StartCoroutine(CheckPlayerAni());
    }

    void FixedUpdate()
    {
        if (Time.timeScale == 1f)
        {
            Move();
            CameraRotation();
            CharacterRotation();
        }
    }

    void Update()
    {
        if (Time.timeScale == 1f)
        {
            BulletShot();
        }

    }

    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * walkSpeed;

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);

        nowstate = playerState.Idle;
    }

    private void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;

        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

    private void CharacterRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
    }

    private void ShootLogic()
    {
        if (!isStoryState)
        {
            if (Shootcount > 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("BUllet LOgic");
                    Instantiate(Bullet, Camera.main.transform.position, Camera.main.transform.rotation);
                    shootaudio.Play();
                    nowstate = playerState.Shoot;
                    Shootcount--;
                }
            }
        }

    }
    public void BulletShot()
    {
        if (Input.GetMouseButton(1))
        {
            cam.fieldOfView = 30;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            cam.fieldOfView = 50;
        }
        ShootLogic();
    }

    private IEnumerator CheckPlayerAni()
    {
        while (!isDead)
        {
            switch (nowstate)
            {

                case playerState.Shoot:
                    ani.SetTrigger("Shoottrigger");

                    break;

            }
            yield return new WaitForSeconds(0.1f);
        }
    }
/*    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }*/
}
