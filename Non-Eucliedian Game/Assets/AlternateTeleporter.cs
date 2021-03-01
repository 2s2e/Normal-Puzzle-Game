using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateTeleporter : MonoBehaviour
{
    BoxCollider col;
    Vector3 offset;
    Vector3 rotationOffset;
    public Color gizmoColor;
    public GameObject waypoint;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();
        offset = waypoint.transform.position - transform.position;
        Debug.Log(waypoint.transform.position);
        Debug.Log(transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawCube(transform.position, new Vector3(0.5f, 0.5f, 0.5f));
        Gizmos.DrawSphere(transform.position + offset, 0.5f);

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);

        if (other.CompareTag("Player"))
        {
            Vector3 otherrotation = other.transform.eulerAngles;
            if(true)
            {
                CharacterController cc = other.GetComponent<CharacterController>();
                cc.enabled = false;
                other.transform.position += offset;
                cc.enabled = true;
            }

        }
    }
}
