using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public float speed, screenDistance;
    public bool onConveyor = false, onSorter = false;
    public Vector3 dragOffset;
    public Rigidbody rb;

    private void Awake()
    {
        screenDistance = GetScreenDistance();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveRight();        
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnPhysicalCollision(collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        Dispose(other);
        IsOnSorter(other, true);
    }    

    private void OnTriggerExit(Collider other)
    {
        IsOnSorter(other, false);
    }

    private void OnMouseDown()
    {
        PickUp();
    }    

    void OnMouseDrag()
    {
        Drag();
    }

    private void OnMouseUp()
    {
        Drop();
    }

    void Drop()
    {
        rb.velocity = Vector3.zero;
        if (onSorter)
        {
            Destroy(gameObject);
        }
    }
    
    void MoveRight()
    {
        if (onConveyor)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.right, Space.World);
        }
    }

    void OnPhysicalCollision(Collision collision)
    {
        if (collision.gameObject.CompareTag("Conveyor") || collision.gameObject.CompareTag("Grabbable"))
        {
            StopDrag();
        }
    }

    void Drag()
    {
        if (!onConveyor)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenDistance));
            transform.position = pos + dragOffset;
            if (transform.position.y < -1.815f)
            {
                transform.position = new(transform.position.x, -1.814f, transform.position.z);
            }
        }        
    }

    float GetScreenDistance()
    {
        return Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
    }

    void StopDrag()
    {
        onConveyor = true;
        rb.velocity = Vector3.zero;
    }

    void IsOnSorter(Collider other, bool IsOnSorter)
    {
        if (other.gameObject.CompareTag("Sorter"))
        {
            onSorter = IsOnSorter;
        }
    }

    void Dispose(Collider other)
    {
        if (other.gameObject.CompareTag("Disposer"))
        {
            Destroy(gameObject);
        }
    }

    void PickUp()
    {
        onConveyor = false;
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenDistance));
        dragOffset = transform.position - pos;
    }
}
