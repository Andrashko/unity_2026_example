using UnityEngine;

public class ForceJump : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 200f;
    [SerializeField]
    private GameObject groundDetector = null;
    private Rigidbody rb;

    private bool isGrounded = false;
    [SerializeField]
    private string groundTag = "Ground";

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (groundDetector == null || rb == null)
            Debug.LogWarning("Error, do not jump");

    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Vector3 force = transform.up * jumpForce;
            rb.AddForce(force);
        }         
    }


    // “–»√≈– «≈ÃÀ≤
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(groundTag)) return;
        isGrounded = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag(groundTag)) return;
        isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(groundTag)) return;
        isGrounded = false;
    }
}
