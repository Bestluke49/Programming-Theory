using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance { get; private set; }

    public GameObject targetCubeBox, targetLongBox;

    private void Awake()
        {
            Instance = this;
        }

}
