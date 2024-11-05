using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    public TrampolinSO trampolin;
    public Rigidbody player;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("sobre el trampolin");
            player.AddForce(transform.up * trampolin.jumpForce, ForceMode.Force);
        }
    }
}
