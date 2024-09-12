using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controls : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] float rotateSpeed = 15.0f;
    [SerializeField] float shotPower = 60.0f;
    [SerializeField] float shotDuration = 0.1f;
    [SerializeField] float timeBetweenShots = 0.2f;
    [SerializeField] float speedBonus = 0.1f;
    [SerializeField] float rotationSpeedBonus = 0.05f;
    [SerializeField] float shotPowerBonus = 0.1f;

    float speedMultiplier = 1.0f;
    float rotationMultiplier = 1.0f;
    float shotPowerMultiplier = 1.0f;

    float movement;
    float rotation;
    
    bool isShooting = false;

    Rigidbody2D rb2D;

    Vector3 originalPosition;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        PlayerInput();
    }

    void FixedUpdate()
    {
        PlayerControls();
    }

    void PlayerControls()
    {
        if (isShooting)
        {
            StartCoroutine(ShootRotation());
        }

        else
        {
            MoveCharacter(movement);
            RotateCharacter(rotation);
        }
    }

    void PlayerInput()
    {
        movement = Input.GetAxis("Vertical") * speed * speedMultiplier;
        rotation = Input.GetAxis("Horizontal") * rotateSpeed * rotationMultiplier;

        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        isShooting = true;
    }

    void MoveCharacter(float amount)
    {
        rb2D.AddForce(transform.up * amount);
    }

    void RotateCharacter(float amount)
    {
        rb2D.AddTorque(-amount);
    }

    IEnumerator ShootRotation()
    {
        rb2D.AddTorque(shotPower * shotPowerMultiplier);
        yield return new WaitForSeconds(shotDuration);
        rb2D.AddTorque(-shotPower * shotPowerMultiplier);
        yield return new WaitForSeconds(timeBetweenShots);
        isShooting = false;
        yield break;
    }

    public void PlayerPowerUp()
    {
        speedMultiplier += speedBonus;
        rotationMultiplier += rotationSpeedBonus;
        shotPowerMultiplier += shotPowerBonus;
    }

    public void ResetPosition()
    {
        transform.position = originalPosition;
    }
}
