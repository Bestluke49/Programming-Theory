using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public float speed;
    public bool onConveyor = false;

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
    }

    void OnMouseDrag()
    {
        Drag();
    }

    private void OnMouseUp()
    {
        SetGravity(true);
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
        while (!onConveyor)
        {
            float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        }        
    }
}
