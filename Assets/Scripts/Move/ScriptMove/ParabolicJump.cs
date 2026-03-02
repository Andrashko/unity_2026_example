using UnityEngine;

public class ParabolicJump : MonoBehaviour
{
    [SerializeField]
    private float jumpHeight = 2f;
    [SerializeField]
    private float jumpDistance = 4f;
    [SerializeField]
    private  float jumpDuration = 0.8f;

    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTime = 0f;
    private Vector3 startPos;
    private Vector3 moveDir;

    [SerializeField]
    private string groundTag = "Ground";
    [SerializeField]
    private GameObject groundDetector = null;
    void Start()
    {
        if (groundDetector == null)
            Debug.LogWarning("Error, do not jump");
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded && !isJumping)
        {
            StartJump();
        }

        if (isJumping)
        {
            UpdateJump();
        }
    }

    void StartJump()
    {
        isJumping = true;
        isGrounded = false;
        jumpTime = 0f;

        startPos = transform.position;

        // напрямок вперед по XZ
        moveDir = transform.forward;
        moveDir.y = 0f;
        moveDir.Normalize();
    }

    void UpdateJump()
    {
        jumpTime += Time.deltaTime;
        float t = jumpTime / jumpDuration;
        t = Mathf.Clamp01(t);

        // горизонтальний рух
        Vector3 horizontal = moveDir * jumpDistance * t;

        // парабола
        float height = jumpHeight * 4f * t * (1f - t);

        Vector3 pos = startPos + horizontal;
        pos.y = startPos.y + height;

        transform.position = pos;

        if (t >= 1f)
        {
            isJumping = false;
        }
    }

    // ТРИГЕР ЗЕМЛІ
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
