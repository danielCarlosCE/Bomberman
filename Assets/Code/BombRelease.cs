using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //to use Func<>


public class BombRelease : MonoBehaviour, BombDelegate
{
    public Player player;
    
    //Type to instantiate 
    public GameObject Bomb;
    public GameObject Fire;

    public int currentBombsCount = 0;

    void Update()
    {        
        string fire = (player.player == 1) ? "Fire1" : "Fire1P2";
        if (!Input.GetButtonDown(fire) || currentBombsCount >= player.bombsPerTime) {
            return;
        }

        var position = transform.position;
        position.x = (float) Mathf.Round(position.x);
        position.z = (float) Mathf.Round(position.z);
        position.y = 0;
        
        Bomb bomb = Instantiate(Bomb, position, Quaternion.identity).GetComponent<Bomb>();
        bomb.myDelegate = this;
        bomb.firePower = player.fireDistance;
        
        currentBombsCount ++;
    }

    public void OnBombExplode(Bomb bomb) {
        currentBombsCount --;
        
        Vector3 bombPostion = bomb.transform.position;
        Instantiate(Fire, bombPostion, Quaternion.identity);
         
        //top:
        AddFire(bomb, (p, i) => {
            p.z += i;
            return p;
        });

        //right:
        AddFire(bomb, (p, i) => {
            p.x += i;
            return p;
        });

        //bottom:
        AddFire(bomb, (p, i) => {
            p.z -= i;
            return p;
        });

        //left:
        AddFire(bomb, (p, i) => {
            p.x -= i;
            return p;
        });
    }

    void AddFire(Bomb bomb, Func<Vector3, int, Vector3> action) {  
        for (int i = 0; i < bomb.firePower; i++) {            
            Vector3 target = action(bomb.transform.position, i+1);
            
            if (player.gameboard.IsOutBounds(target)) {
                break;
            }
            if (player.gameboard.CollidesWithBlocks(target)) {
                Instantiate(Fire, target, Quaternion.identity); 
                break;
            }

            Instantiate(Fire, target, Quaternion.identity); 
        }          
    }
}
