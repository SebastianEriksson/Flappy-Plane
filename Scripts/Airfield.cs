using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airfield : MonoBehaviour {

    // If plane reaches the end successfully, send signal to GameController
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Plane>() != null)
        {
            PlaneControll.instance.PlaneEnd();
        }
    }
}
