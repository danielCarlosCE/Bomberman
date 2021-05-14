using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public GameBoard gameboard;    
    public int player = 1;
    public int bombsPerTime { get; protected set; } = 1;
    public int fireDistance { get; protected set; } = 1; 
    public float speed { get; protected set; } = 5f;

    void OnTriggerEnter(Collider other)
    {   
        var isFire = other.gameObject.GetComponent<Fire>() != null;
        if (isFire) {
            gameboard.ReloadScene();            
            Destroy(this.gameObject);
            return;
        } 

        var isPowerUp = other.gameObject.GetComponent<PowerUp>() != null;
        if (isPowerUp) {
            HandlePowerUpPickup(other.gameObject);
        }
    }

    void HandlePowerUpPickup(GameObject powerUpGameObj) {
        PowerUp powerUp = powerUpGameObj.GetComponent<PowerUp>();
        if (powerUp == null) { return; }

        Destroy(powerUpGameObj);
        switch (powerUp.puType) {
            case 1:
                fireDistance += 1;
                break;
            case 2:
                bombsPerTime += 1;
                break;
            case 3:
                speed += 1;
                break;  
            default:
                break;
        }
    }
    
}
