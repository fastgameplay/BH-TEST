using UnityEngine;

public class TPPCamera : MonoBehaviour{
    [SerializeField] private GameObject target;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Vector3 offset;

    void LateUpdate(){
        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
        target.transform.Rotate(0,horizontal,0);

        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0,desiredAngle,0);
        transform.position = target.transform.position - (rotation * offset);

        transform.LookAt(target.transform);
    }
}
