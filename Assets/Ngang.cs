using UnityEngine;

public class Ngang : MonoBehaviour
{
    private Vector3 mouseOffset;
    private float snapThreshold = 0.5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        mouseOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + mouseOffset;
        rb.MovePosition(new Vector3(newPosition.x, transform.position.y, transform.position.z));
    }

    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x) < snapThreshold)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }
}
