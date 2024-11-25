using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField]
    private Camera topDownCamera;
    [SerializeField]
    private GameObject navTargetObject;

    private UnityEngine.AI.NavMeshPath path; // Current calculated path
    private LineRenderer line; // LineRenderer to display path

    private bool lineToggle = false;

    private void Start() {
        path = new UnityEngine.AI.NavMeshPath();
        line = GetComponent<LineRenderer>();
    }

    private void Update() {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            lineToggle = !lineToggle;
        }

        if (lineToggle)
        {
            UnityEngine.AI.NavMesh.CalculatePath(transform.position, navTargetObject.transform.position, UnityEngine.AI.NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            line.SetPositions(path.corners);
            line.enabled = true;
        }
    }
}
