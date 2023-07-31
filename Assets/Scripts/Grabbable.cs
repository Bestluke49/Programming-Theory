using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public float speed, distanceScreen;
    public bool onConveyor = false;
    public Vector3 dragOffset;

    private void Awake()
    {
        distanceScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
    }

    private void Update()
    {
        MoveRight();        
    }

    private void OnCollisionEnter(Collision collision)
    {
        IsOnConveyor(collision, true);
    }

    private void OnCollisionExit(Collision collision)
    {
        IsOnConveyor(collision, false);
    }

    private void OnMouseDown()
    {
        SetGravity(false);
        onConveyor = false;
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceScreen));
        dragOffset = transform.position - pos;
    }

    void OnMouseDrag()
    {
        Drag();
    }

    private void OnMouseUp()
    {
        SetGravity(true);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    
    void MoveRight()
    {
        if (onConveyor)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.right, Space.World);
        }
    }

    void IsOnConveyor(Collision collision, bool isOnConveyor)
    {
        if (collision.gameObject.CompareTag("Conveyor"))
        {
            onConveyor = isOnConveyor;
        }
    }

    void SetGravity(bool feelsGrav)
    {
        GetComponent<Rigidbody>().useGravity = feelsGrav;
    }

    void Drag()
    {
        if (!onConveyor)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceScreen));
            transform.position = pos + dragOffset;
            if (transform.position.y < -1.815f)
            {
                transform.position = new(transform.position.x, -1.814f, transform.position.z);
                onConveyor = true;
                SetGravity(true);
            }
        }        
    }
}
