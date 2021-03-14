using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;

    public float movementSpeed = 5;

    public float pitchSpeed = 1;
    public float yawSpeed = 1;

    public float jumpForce = 10;
    public float bulletCooldown = 1;

    private float timeElapsed;

    Rigidbody rigidbody;
    Camera camera;
    float forwardMovement;
    float sidewaysMovement;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = bulletCooldown;
        rigidbody = GetComponent<Rigidbody>();
        camera = GetComponentInChildren<Camera>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        forwardMovement = Input.GetAxisRaw("Horizontal") * movementSpeed;
        sidewaysMovement = Input.GetAxisRaw("Vertical") * movementSpeed;

        float pitch = Input.GetAxis("Mouse Y") * pitchSpeed * Time.deltaTime;
        float yaw = Input.GetAxis("Mouse X") * yawSpeed * Time.deltaTime;

        camera.transform.Rotate(- pitch, 0, 0, Space.Self);
        transform.Rotate(0, yaw, 0, Space.World);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rigidbody.velocity.y == 0)
                rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpForce, rigidbody.velocity.z);
        }

        if (Input.GetKey(KeyCode.Mouse0) && timeElapsed > bulletCooldown)
        {
            GameObject newBullet = Instantiate(bullet);
            Rigidbody bulletRigidBody = newBullet.GetComponent<Rigidbody>();
            bulletRigidBody.velocity = camera.transform.forward * newBullet.GetComponent<Bullet>().speed;
            newBullet.transform.position = transform.position + camera.transform.forward * 0.5f;
            newBullet.transform.rotation = Quaternion.FromToRotation(transform.up, camera.transform.forward);
            timeElapsed = 0;
        }

        timeElapsed += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = transform.right * forwardMovement + transform.forward * sidewaysMovement + new Vector3(0, rigidbody.velocity.y);
    }
}
