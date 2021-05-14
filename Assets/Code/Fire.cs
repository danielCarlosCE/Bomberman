using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    void Start()
    {
        Invoke("Vanish", 0.8f);  
    }

    void Vanish() {
        Destroy(this.gameObject);
    }
}
