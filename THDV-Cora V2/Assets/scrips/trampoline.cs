using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampoline : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody player;

    
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("sobre el trampolin");
            player.AddForce(transform.up * jumpForce, ForceMode.Force);
        }
    }
}
    