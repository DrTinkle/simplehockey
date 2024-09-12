using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    Rigidbody2D rb2D;
    private Vector3 originalPosition;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        originalPosition = transform.position;
    }

    public void ResetPosition()
    {
        rb2D.velocity = Vector3.zero;
        transform.position = originalPosition;
    }
}
