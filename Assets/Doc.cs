using UnityEngine;

public class Doc : MonoBehaviour
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
        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + mouseOffset;
        rb.MovePosition(new Vector3(transform.position.x, newPosition.y, transform.position.z));
    }

    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.y) < snapThreshold)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }
}
