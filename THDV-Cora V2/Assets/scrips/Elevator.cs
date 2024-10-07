using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform targetPosition;  

    private void Start()
    {
       
    }

    private void Update()
    {
        
    }

   
 

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Player"))
            Debug.Log("en el ascens");


        if (other.GetComponent<Collider>().CompareTag("Player")&&Input.GetKeyDown(KeyCode.E))
        {
            other.transform.position = targetPosition.position;
        }
    }

    private void OnCollisionExit(Collision collision)   
    {
        
    }
}
