using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    public Player player;

    void Update()
    {
        float horizontal = Input.GetAxis(player.player == 1 ? "Horizontal" : "HorizontalP2");
        float vertical = Input.GetAxis(player.player == 1 ? "Vertical" : "VerticalP2");
        
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude < 0.1f) { return; }

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f); 

        controller.Move(direction * player.speed * Time.deltaTime);
    }
}
