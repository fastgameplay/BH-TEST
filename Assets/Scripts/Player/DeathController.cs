using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour{
    private Material playerMaterial;
    void Awake(){
        playerMaterial = GetComponent<MeshRenderer>().material;
    }

    IEnumerable hit(float Seconds){
        Color oldColor = playerMaterial.color;
        playerMaterial.color = Color.red;
        yield return new WaitForSeconds(Seconds);
        playerMaterial.color = oldColor;
    }
}
