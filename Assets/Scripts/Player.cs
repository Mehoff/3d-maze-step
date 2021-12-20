using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 forceDirection;
    public Vector3 oldPosition;
    public float speed;
    public float currentSpeed;
    public float forceMultipier;
    public AudioSource collisionAudio;
    public int Points;
    public TextMeshProUGUI textMeshPoints;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        forceMultipier = 10;
        speed = 5f;
        Points = 0;

        collisionAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        currentSpeed = Vector3.Distance(oldPosition, transform.position) * 100f;
        oldPosition = transform.position;

        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        var camera = Camera.main;

        var forward = camera.transform.forward;
        var right = camera.transform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        var desiredMoveDirection = forward * verticalAxis + right * horizontalAxis;
        rb.AddForce(desiredMoveDirection * speed * forceMultipier * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Player collision with " + other.gameObject.name);

        if (other.gameObject.name.StartsWith("Button"))
            return;

        if (other.gameObject.name.StartsWith("Finish"))
        {
            AddPoints();
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        if (currentSpeed > 1.2f && !other.gameObject.name.StartsWith("Finish"))
            collisionAudio.Play();

    }

    public void AddPoints(int _points = 1)
    {
        Points += _points;
        textMeshPoints.text = Points.ToString();
    }
}
