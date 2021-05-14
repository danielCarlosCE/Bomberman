using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BombDelegate {
    void OnBombExplode(Bomb bomb);
}

public class Bomb : MonoBehaviour
{       
    public BombDelegate myDelegate;
    public int firePower;    

    void Start()
    {
        Invoke("Explode", 2);   
    }
   
    void Explode() {      
        if (myDelegate != null) {
            myDelegate.OnBombExplode(this);
        }
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {     
        bool isFire = other.gameObject.GetComponent<Fire>() != null;   
        if (isFire) {
            Explode();
        }
    }

}