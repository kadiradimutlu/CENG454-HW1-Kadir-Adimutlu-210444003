// FlightController.cs
// CENG 454 HW1: Sky-High Prototype
// Author: Kadir ADIMUTLU | Student ID: 210444003

using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = 45f;
    [SerializeField] private float yawSpeed = 45f;
    [SerializeField] private float rollSpeed = 45f;
    [SerializeField] private float thrustSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
        // Cache the Rigidbody component for performance
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Lock physics rotation to prevent the engine from fighting our custom flight logic
            rb.freezeRotation = true;
            Debug.Log("FlightController: Physics initialized and rotation locked.");
        }
        else
        {
            Debug.LogError("FlightController: Rigidbody missing on the aircraft!");
        }
    }
    
    void Update()
    {
        HandleRotation();
        HandleThrust();
    }

    private void HandleRotation()
    {
        // Pitch: Arrow Up/Down
        float pitchInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right * pitchInput * pitchSpeed * Time.deltaTime);

        // Yaw: Arrow Left/Right
        float yawInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * yawInput * yawSpeed * Time.deltaTime);

        // Roll: Q/E Keys
        float rollInput = 0f;
        if (Input.GetKey(KeyCode.Q)) rollInput = 1f;
        else if (Input.GetKey(KeyCode.E)) rollInput = -1f;
        transform.Rotate(Vector3.forward * rollInput * rollSpeed * Time.deltaTime);
    }

    private void HandleThrust()
    {
        // Thrust: Spacebar
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
        }
    }
}