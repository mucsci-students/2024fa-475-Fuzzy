using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float movementDuration = 2f;
    public float idleTime = 3f;

    private Vector3 moveDirection;

    void Start()
    {
        StartCoroutine(MoveRandomly());
    }

    IEnumerator MoveRandomly()
    {
        while (true)
        {
            // Random idle time before moving
            yield return new WaitForSeconds(Random.Range(0, idleTime));

            // Random direction
            int direction = Random.Range(0, 3);
            switch (direction)
            {
                case 0:
                    moveDirection = transform.forward;
                    break;
                case 1:
                    moveDirection = -transform.right;
                    break;
                case 2:
                    moveDirection = transform.right;
                    break;
            }

            // Move in the chosen direction
            float elapsedTime = 0f;
            while (elapsedTime < movementDuration)
            {
                transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Reset direction
            moveDirection = Vector3.zero;
        }
    }

    void FixedUpdate() {
        Rigidbody rb = GetComponent<Rigidbody>();
        // Apply a downward force to help the entity stick to the terrain
        rb.AddForce(Vector3.down * 10f); // Adjust the value to find the right amount
    }
}
