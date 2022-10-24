
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class HitDetector : MonoBehaviour{
    private BoxCollider _col;
    private bool _wasPlayerHit;
    void Awake(){
        _col = GetComponent<BoxCollider>();
    }
    public bool hit(Vector3 from, Vector3 to, Quaternion rotation){
        Vector3 center = Vector3.Lerp(from, to, 0.5f);
        float distance = Vector3.Distance(from,to);
        gameObject.transform.rotation = rotation;
        gameObject.transform.position = center;
        _col.size = new Vector3(distance,1,1);
        StartCoroutine(returnToStartPosition());
        return _wasPlayerHit;
    }
    public void OnTriggerEnter(Collider other){
        if(other.tag == "Enemy"){
            
        
            Debug.Log("Hitted");
        }

    }
    IEnumerator returnToStartPosition(){
        
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.position = new Vector3(0,-10,0);

        _wasPlayerHit = false;
    }


}
