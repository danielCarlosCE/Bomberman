using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBoard : MonoBehaviour
{
    double matrixLimitZ = 6;
    double matrixLimitX = 5;

    public void ReloadScene() {
        Invoke("Reload", 2f);
    }

    void Reload() {
        SceneManager.LoadScene("SampleScene");
    }

    public bool IsOutBounds(Vector3 target) {
        if (target.x > matrixLimitX || target.x < -matrixLimitX) {
            return true;
        }

        if (target.z > matrixLimitZ || target.z < -matrixLimitZ) {
            return true;
        }

        return false;
    }

    public bool CollidesWithBlocks(Vector3 target) {
        GameObject blocks = GameObject.Find("Blocks");
        foreach (Transform block in blocks.transform) {
            if (target.x == block.position.x && target.z == block.position.z) {
                return true;
            }
        }         
        return false;
    }
}
