using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject PowerUp;
    /// It will not spawn if < 1
    public int spawnPowerUp = 0;

    void OnTriggerEnter(Collider other)
    {   
        GameObject fireGameObj = other.gameObject;
        if (fireGameObj.GetComponent<Fire>() == null) {
            return;
        }

        if (spawnPowerUp > 0) {
            GameObject gameObj = Instantiate(PowerUp, transform.position, Quaternion.identity);
            PowerUp powerUp = gameObj.GetComponent<PowerUp>();            
            powerUp.puType = spawnPowerUp;
        }

        Destroy(fireGameObj);
        Destroy(this.gameObject);
    }
}
