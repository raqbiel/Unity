using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Shoot : MonoBehaviour {

 
    public float damage = 20f;
    

    public float GetDamage(){
        return damage;

    }
   public void Hit(){

        Destroy(gameObject);

    }

    public void Zycie()
    {
        
    }
}
