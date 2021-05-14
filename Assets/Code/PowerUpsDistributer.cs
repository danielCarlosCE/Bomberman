using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsDistributer : MonoBehaviour
{
    int[] powerUps = new int[] { 
        1, 1, 1, 1, 1, 1 ,1,
        2, 2, 2, 2, 2, 2,
        3, 3, 3
    };

    void Start() {
        List<Block> blocks = new List<Block>(GameObject.FindObjectsOfType<Block>());
    
        if (powerUps.Length > blocks.Count) {
            print("⛔️ Wrong Setup - Not enough blocks to hide powerups");
            return;
        }

        int[] spots = new int[blocks.Count];
        for (int i = 0; i < powerUps.Length; i++) {
            spots[i] = powerUps[i];
        }

        var rng = new System.Random();
        rng.Shuffle(spots);
        
        for (int i = 0; i < spots.Length; i++) {            
            blocks[i].spawnPowerUp = spots[i];
        }
    }
}

static class RandomExtensions
{
    /// Fisher–Yates shuffle
    public static void Shuffle<T> (this System.Random rng, T[] array)
    {
        int n = array.Length;
        while (n > 1) 
        {
            int nextRandomIndex = rng.Next(n--);
            T temp = array[n];
            //swap:
            array[n] = array[nextRandomIndex];
            array[nextRandomIndex] = temp;
        }
    }
}