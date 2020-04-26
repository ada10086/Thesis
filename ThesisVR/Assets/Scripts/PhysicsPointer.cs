using UnityEngine;

public class PhysicsPointer : MonoBehaviour
{
    public float defaultLength = 3.0F;
    private LineRenderer lineRenderer = null;

    float maxDistance = 1000f;

    public bool targetIsHit = false;
    public Vector3 hitPointRelativeToTarget;


    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;

    }

    private void Update() {
        updateLength();

        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawLine(transform.position, transform.position + (transform.forward*500), Color.green);
        if(Physics.Raycast(ray, out hit, maxDistance))  //out parameter to populate hit object
        { 
            string hitName = hit.collider.gameObject.name;
            Debug.Log("Successful hit: " + hitName);

            if (hitName == "Room3 Cube")
            {
                targetIsHit = true;
                Debug.DrawLine(transform.position, hit.point, Color.red);
                hitPointRelativeToTarget = hit.transform.InverseTransformPoint(hit.point);
            } else{ 
                targetIsHit = false;
            }
        }


        if(GameObject.Find("Room3 Cube").GetComponent<Renderer>().isVisible){
            lineRenderer.enabled = true;
        } else {
            lineRenderer.enabled = false;
        }
    }

    private void updateLength(){
        lineRenderer.SetPosition(0,transform.position);
        // lineRenderer.SetPosition(1, CalculateEnd());
        lineRenderer.SetPosition(1, DefaultEnd(defaultLength));
    }
    private Vector3 CalculateEnd()
    {
        RaycastHit hit = CreateForwardRaycast();
        Vector3 endPosition = DefaultEnd(defaultLength);
        // if (hit.collider)
        if (hit.collider.gameObject.name == "Plane")

            endPosition = hit.point;
        return endPosition;
    }

    private RaycastHit CreateForwardRaycast()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        Physics.Raycast(ray, out hit, defaultLength);

        string hitName = hit.collider.gameObject.name;
            // Debug.Log("Successful hit: " + hitName);

            if (hitName == "Plane")
            {
                targetIsHit = true;
                // Debug.DrawLine(transform.position, hit.point, Color.red);
                //convert hit.point from world space to local target space
                // hitPointRelativeToTarget = ImageTarget.transform.InverseTransformPoint(hit.point);
                hitPointRelativeToTarget = hit.transform.InverseTransformPoint(hit.point);
                // Debug.Log("hitPointRelativeX:" + hitPointRelativeToTarget.x);  //scale/2  range -0.5 to 0.5
            }

        return hit;
    }

    private Vector3 DefaultEnd(float length)
    {
        return transform.position + (transform.forward*length);
    }

    

}
