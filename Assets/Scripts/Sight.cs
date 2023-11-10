using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    // Start is called before the first frame update
    public float distance;
    public float angle;
    public LayerMask objectLayers;
    public LayerMask ObstacleLayers;
    public Collider detectedObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distance, objectLayers);
        detectedObject = null;

        for(int i = 0; i < colliders.Length; i++){
            Collider collider = colliders[i];
            Vector3 directionBetween = (collider.transform.position - transform.position).normalized;
            float angleToCollider = Vector3.Angle(transform.forward, directionBetween);
            if(collider.gameObject.tag == "Player"){
                Debug.Log("Player detected");
                 print(angleToCollider);
            }
            if(angleToCollider < angle){
                if(!Physics.Linecast(transform.position, collider.transform.position, ObstacleLayers)){
                    detectedObject = collider;
                    break;
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);
        Vector3 leftRayRotation = Quaternion.AngleAxis(-angle, transform.up) * transform.forward;
        Vector3 rightRayRotation = Quaternion.AngleAxis(angle, transform.up) * transform.forward;
        
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, leftRayRotation * distance);
        Gizmos.DrawRay(transform.position, rightRayRotation * distance);
        // Draw a ray that stops at the collision
        if(detectedObject != null){
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, detectedObject.transform.position);
        }

    }
}
