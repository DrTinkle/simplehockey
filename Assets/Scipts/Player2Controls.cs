using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controls : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] float rotateSpeed = 15.0f;
    [SerializeField] float shotPower = 60.0f;
    [SerializeField] float shotDuration = 0.2f;
    [SerializeField] float timeBetweenShots = 0.2f;
    [SerializeField] float speedBonus = 0.1f;
    [SerializeField] float rotationSpeedBonus = 0.05f;
    [SerializeField] float shotPowerBonus = 0.1f;

    [Header("AI")]
    [SerializeField] float shootRange = 1.2f;
    [SerializeField] float aiSpeed = 20.0f;
    
    float speedMultiplier = 1.0f;
    float rotationMultiplier = 1.0f;
    float shotPowerMultiplier = 1.0f;

    float movement;
    float rotation;
    
    bool isShooting = false;
    public bool onePlayer;

    Rigidbody2D rb2D;
    Puck puck;

    Vector3 originalPosition;

    Transform target;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        puck = FindObjectOfType<Puck>();
    }

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (!onePlayer)
        {
            PlayerInput();
        }

        // if ("Multiple Pucks")
        // {
        //     // FindClosestTarget();
        // }
    }

    void FixedUpdate()
    {
        PlayerControls();

        if (onePlayer)
        {
            AIControl();
        }
        
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
        movement = Input.GetAxis("Vertical2") * speed * speedMultiplier;
        rotation = Input.GetAxis("Horizontal2") * rotateSpeed * rotationMultiplier;

        if (Input.GetButton("Fire2"))
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

    void AIControl()
    {
        target = puck.transform;
        
        float targetDistance = Vector3.Distance(transform.position, target.position);
        float aiMovement = aiSpeed * speedMultiplier;
        
        RotateTowards(target.position);

        if (targetDistance <= shootRange && !isShooting)
        {
            Shoot();
        }
        
        else
        {
            MoveCharacter(aiMovement);
        }
    }

    void RotateTowards(Vector2 target)
    {     
        if(!isShooting)
        {
            Vector2 direction = (target - (Vector2)transform.position).normalized;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
            var offset = -90.0f;
            transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
        }   
    }
}
