using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpObject : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpObjectScale = 30f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.AddForce(Vector2.up * jumpObjectScale, ForceMode.Impulse);
        }
    }
}
