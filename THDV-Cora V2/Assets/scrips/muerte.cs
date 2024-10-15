using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muerte : MonoBehaviour
{
    [SerializeField] Transform respawnPoint;
    [SerializeField] Transform playerPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("muerte"))
        {
            Debug.Log("senti la muerte");
            playerPos.position = respawnPoint.position;
        }
    }
}
