using UnityEngine;
using System.Collections;

public class ReverseMovement : MonoBehaviour
{
    private AutoMove autoMove;  

    public GameObject objectToDisable;  
    public GameObject objectToEnable;
    public GameObject objectToDisable2;
    public GameObject objectToEnable2;
    public float timeOfSeconds;

    void Start()
    {
        // Get the AutoMove script component
        autoMove = GetComponent<AutoMove>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.CompareTag("ReverseMovement"))
        {
            // Reverse the movement direction
            autoMove.moveRight = !autoMove.moveRight;

      
            if (objectToDisable != null)
            {
                StartCoroutine(DisableAfterDelay(timeOfSeconds));  
            }

            
            if (objectToEnable != null)
            {
                objectToEnable.SetActive(true);
            }



            
        }
        if (collision.gameObject.CompareTag("ReverseMovement2"))
        {
            autoMove.moveRight = !autoMove.moveRight;
            if (objectToDisable2 != null)
            {
                objectToDisable2.SetActive(false);
            }
            if (objectToEnable2 != null)
            {
                objectToEnable2.SetActive(true);
            }
        }
    }

    // Coroutine to wait and disable object
    private IEnumerator DisableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  

        // Disable the object after the wait
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
        }
    }
}
