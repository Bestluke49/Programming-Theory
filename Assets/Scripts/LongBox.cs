using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongBox : Grabbable
{
    private GameObject TargetLongBox;

    private void Start()
    {
        TargetLongBox = Manager.Instance.targetLongBox;
    }

    public override void IsOnSorter(Collider other, bool IsOnSorter)
    {
        if (other.gameObject == TargetLongBox)
        {
            base.IsOnSorter(other, IsOnSorter);
        }
    }
}
