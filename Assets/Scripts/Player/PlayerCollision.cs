using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour{

    void OnTriggerEnter(Collider other){
        Debug.Log(other.tag);
    }
}
