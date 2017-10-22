using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

    // If plane clears clouds successfully and hits the trigger, send signal to GameController
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.GetComponent<Plane>() != null)
        {
            PlaneControll.instance.PlaneScored();
        }
    }
}
