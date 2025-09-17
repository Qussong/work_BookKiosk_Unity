using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCanvasController : MonoBehaviour
{
    public static BackCanvasController instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

}
