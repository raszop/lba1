using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Joystick movementJoystick;
    [SerializeField]
    private Joystick shootingJoystick;

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Rigidbody rb;

    public Animator animator;

    private float lastShot = 0f;


    private Vector3 horizontalMovement;
    private Vector3 verticalMovement;
    private Vector3 movementVector;

    private Vector3 horizontalShooting;
    private Vector3 verticalShooting;
    private Vector3 shootingVector;

    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleVirtualJoysticks();

        //HandleMovementInput();
        //HandleShootingInput();

        HandleActualMovement();
        HandlePlayerModelRotation();

        HandleActualShooting();
    }

    public virtual void HandleVirtualJoysticks()
    {
        movementVector = new Vector3(movementJoystick.InputDirection.x, 0, movementJoystick.InputDirection.y).normalized;
        shootingVector = new Vector3(shootingJoystick.InputDirection.x, 0, shootingJoystick.InputDirection.y);
    }

    public virtual void HandlePlayerModelRotation()
    {
        if (shootingVector != Vector3.zero)
        {
            transform.LookAt(transform.position + shootingVector);
        }
        else
        if (movementVector != Vector3.zero)
        {
            transform.LookAt(transform.position + movementVector);
        }
    }

    private void HandleActualShooting()
    {
        if (shootingVector != Vector3.zero)
        {
            TryShooting();
        }
    }

    protected void TryShooting()
    {
        if (Time.time > lastShot)
        {
            lastShot = Time.time + player.shootingRate;
            Shoot();
            //lastShot = Time.time + currentGun.ShootingRate;
            //currentGun.TryShooting();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(999, 999, 999), Quaternion.identity);
        bullet.transform.position = this.transform.position;
        bullet.transform.rotation = this.transform.rotation;
        //bullet.transform.Rotate(0, RandomSpread(), 0, Space.World); //disabled
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = Vector3.zero;
        bulletRb.AddForce(bullet.transform.TransformDirection(Vector3.forward) * bulletSpeed);
        bullet.GetComponent<Bullet>().damage = player.damage;
    }

    private void HandleActualMovement()
    {
        if (movementVector != Vector3.zero)
        {
            //Debug.Log("now in moving!")
            animator.SetBool("Isrunning", true);
            rb.velocity = movementVector * movementSpeed;
        }
        else
        {
            //Debug.Log("now i don't move!")
            animator.SetBool("Isrunning", false);
            rb.velocity = Vector3.zero;
        }
    }

    private void HandleMovementInput()
    {
        HandleKeyboardMovement();
    }

    private void HandleKeyboardMovement()
    {
        horizontalMovement = Vector3.zero;
        verticalMovement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            verticalMovement = Vector3.forward;
        }
        else
        if (Input.GetKey(KeyCode.S))
        {
            verticalMovement = Vector3.back;
        }

        if (Input.GetKey(KeyCode.A))
        {
            horizontalMovement = Vector3.left;
        }
        else
        if (Input.GetKey(KeyCode.D))
        {
            horizontalMovement = Vector3.right;
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            verticalMovement = Vector3.zero;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            horizontalMovement = Vector3.zero;
        }

        movementVector = horizontalMovement + verticalMovement;
    }

    private void HandleShootingInput()
    {
        horizontalShooting = Vector3.zero;
        verticalShooting = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalShooting = Vector3.forward;
        }
        else
        if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalShooting = Vector3.back;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalShooting = Vector3.left;
        }
        else
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalShooting = Vector3.right;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            verticalShooting = Vector3.zero;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            horizontalShooting = Vector3.zero;
        }

        shootingVector = horizontalShooting + verticalShooting;
    }
}
