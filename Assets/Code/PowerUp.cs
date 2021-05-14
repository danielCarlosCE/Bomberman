using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int puType = 0;

    void Start() {
        var renderer = GetComponent<Renderer>();
        switch (puType) {
            case 1:
                renderer.material.SetColor("_Color", Color.red);
                break;
            case 2:
                renderer.material.SetColor("_Color", Color.blue);
                break;
            case 3:
                renderer.material.SetColor("_Color", Color.green);
                break;
            default:
                break;
        }
    }
    void OnTriggerEnter(Collider other)
    {       
        bool isFire = other.gameObject.GetComponent<Fire>() != null; 
        if (isFire) {            
            Destroy(this.gameObject);
        } 
    }
}
