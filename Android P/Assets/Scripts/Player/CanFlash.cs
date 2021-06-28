using UnityEngine;

public class CanFlash : MonoBehaviour
{
    public bool canFlash;

    private void Start()
    {
        canFlash = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(!other.CompareTag("Check") || other.CompareTag("Hole"))
        {
            canFlash = false;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(!other.CompareTag("Check") || other.CompareTag("Hole"))
        {
            canFlash = true;
        }
    }
}
