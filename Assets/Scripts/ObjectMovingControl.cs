using UnityEngine;

public class ObjectMovingControl : MonoBehaviour
{
    public Vector3 topPosition;
    public Vector3 bottomPosition;
    public float speed;

    private Rigidbody2D rb;
    private Vector3 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; 

        targetPosition = topPosition;
    }

    void FixedUpdate()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        rb.linearVelocity = direction * speed * 10;

        if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
        {
            targetPosition = (targetPosition == topPosition) ? bottomPosition : topPosition;
        }
    }
}
