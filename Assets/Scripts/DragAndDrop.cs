using UnityEngine;
using System;
using TMPro;

public class DragAndDrop : MonoBehaviour
{
    public TMP_Text text;
    public Rigidbody rb;
    public bool isDragging = false;
    public Vector3 offset;
    public Vector3 lastMousePosition;

    void Start()
    {
        text.text = "";
    }
    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~0, QueryTriggerInteraction.Ignore))
        {
            if (hit.collider.tag != "Untagged" && hit.collider.tag != "Player")
            {
                text.text = hit.collider.tag;
                if (rb == null)
                { 
                    rb = hit.collider.GetComponent<Rigidbody>();
                }
            }
            else
            {
                text.text = "";
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (rb != null)
            {
                rb.freezeRotation = true;
                move();
            }
        }
        else
        {
            if (rb != null)
            {
                rb.freezeRotation = false;
                rb = null;
            }

        }
    }
    private void move()
    {
        Camera mainCamera = Camera.main;

        Vector3 targetPosition = mainCamera.transform.position + mainCamera.transform.forward * 2f;
        Vector3 directionToTarget = (targetPosition + offset - rb.position);
        float forceMultiplier = 300f; 
        rb.velocity = directionToTarget * forceMultiplier * Time.fixedDeltaTime;
    }
}
