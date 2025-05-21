using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RayCast : MonoBehaviour
{

    [SerializeField] private float rayDistance = 5f;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private TextMeshProUGUI interactionText;

    private Transform cameraTransform;
    
    void Start()
    {
        cameraTransform = Camera.main.transform;

        if (interactionText != null)
        {
            interactionText.text = "";
        }
    }
    
    void Update()
   {
    RaycastHit hit;
    if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, rayDistance, interactableLayer))
    {
        string objectName = hit.collider.gameObject.name;
        float distance = hit.distance;

        if (interactionText != null)
        {
            interactionText.text = ($"{objectName}\n거리: {distance:F2}m");
        }
        
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * hit.distance, Color.green);
    }
    else
    {
        if (interactionText != null)
        {
            interactionText.text = "";
        }
        
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * rayDistance, Color.red);
    }
}
    
   
}
