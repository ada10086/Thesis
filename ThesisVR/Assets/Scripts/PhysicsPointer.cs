using UnityEngine;

public class PhysicsPointer : MonoBehaviour
{
    public string hitTarget = null;
    public Vector3 hitPointTargetLocalPos;

    private LineRenderer lineRenderer;
    private float defaultRayLength = 10F;
    private Vector3 lineRendererEnd;


    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    private void Update() {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawLine(transform.position, transform.position + (transform.forward*500), Color.green);
        

        if(Physics.Raycast(ray, out hit, defaultRayLength))  
        { 
            string hitName = hit.collider.gameObject.name;
            Debug.Log("Successful hit: " + hitName);

            if (hitName == "Fractal9" || hitName == "Fractal10" || hitName == "Fractal11")
            {
                hitTarget = hitName;
                hitPointTargetLocalPos = hit.transform.InverseTransformPoint(hit.point);
                lineRendererEnd = hit.point;

                Debug.DrawLine(transform.position, hit.point, Color.red);
            } else{ 
                hitTarget = null;
                lineRendererEnd = transform.position + (transform.forward*defaultRayLength);
            }
        }

        if(GameObject.Find("Fractal9").GetComponent<Renderer>().isVisible){
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0,transform.position);
            lineRenderer.SetPosition(1, lineRendererEnd);
        } else {
            lineRenderer.enabled = false;
        }
    }

}
