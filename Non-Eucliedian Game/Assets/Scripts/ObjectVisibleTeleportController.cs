using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVisibleTeleportController : MonoBehaviour
{
    BoxCollider col;
    public Vector3 offset;
    public Color gizmoColor;
    public GameObject[] nonVisibles;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawCube(transform.position, new Vector3(0.5f, 0.5f, 0.5f));
        Gizmos.DrawCube(transform.position + offset, new Vector3(0.5f, 0.5f, 0.5f));

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);

        if (other.CompareTag("Player"))
        {
            foreach(GameObject obj in nonVisibles)
            {
                Renderer m_renderer = obj.GetComponent<Renderer>();
                if(m_renderer.isVisible)
                {
                    return;
                }
            }
            CharacterController cc = other.GetComponent<CharacterController>();
            cc.enabled = false;
            other.transform.position += offset;
            cc.enabled = true;

        }
    }
}
