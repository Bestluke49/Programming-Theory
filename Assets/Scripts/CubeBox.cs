using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBox : Grabbable
{
    private GameObject targetCubeBox;

    private void Start()
    {
        targetCubeBox = Manager.Instance.targetCubeBox;
    }

    public override void IsOnSorter(Collider other, bool IsOnSorter)
    {
        if (other.gameObject == targetCubeBox)
        {
            base.IsOnSorter(other, IsOnSorter);
        }        
    }
}
