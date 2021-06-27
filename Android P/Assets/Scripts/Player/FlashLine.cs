using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLine : MonoBehaviour
{
    public bool canFlash;

    private void Start()
    {
        canFlash = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Wall"))
            canFlash = false;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Wall"))
            canFlash = true;
    }
}
