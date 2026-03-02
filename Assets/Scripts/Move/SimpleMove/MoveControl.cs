using UnityEngine;

public class MoveControl : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private float rotationSpeed = 90.0f;
    void Start()
    {
        
    }

    void Update()
    {
        // рух взад-вперед
        Vector3 moveDelta = transform.forward*speed*Time.deltaTime*Input.GetAxis("Vertical");
        transform.Translate(moveDelta);
        // поворот
        float rotationAngle = rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        transform.Rotate(transform.up, rotationAngle);
    }
}
