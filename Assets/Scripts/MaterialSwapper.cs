using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwapper : MonoBehaviour
{
    // The name of the material we want to target
    [SerializeField] private string targetMaterialName;
    
    // The material to swap with
    [SerializeField] private Material alternateMaterial;

    // To store the original material for toggling
    private Material originalMaterial;

    // Reference to the MeshRenderer
    private Renderer objectRenderer;

    // A flag to toggle between original and alternate material
    private bool swapMaterials = true;

    
    private string altMaterialName;

    void Start()
    {
        // Get the renderer component
        objectRenderer = GetComponent<Renderer>();
        altMaterialName = alternateMaterial.name;

        // Find and store the original material based on the name
        FindOriginalMaterial();
    }

    // Function to find the original material by name
    void FindOriginalMaterial()
    {
        if (objectRenderer != null && objectRenderer.materials.Length > 0)
        {
            foreach (Material mat in objectRenderer.materials)
            {
                if (mat.name.StartsWith(targetMaterialName))
                {
                    originalMaterial = mat;
                    break;
                }
            }
        }

        // Check if the material was found
        if (originalMaterial == null)
        {
            Debug.LogWarning("Target material not found on the GameObject.");
        }
    }

    // Function to swap the material
    public void SwapMaterial()
    {
        if (originalMaterial == null || alternateMaterial == null) return;

        // Get all the materials applied to the GameObject
        Material[] materials = objectRenderer.materials;

        if (swapMaterials)
        {
            for (int i = 0; i < materials.Length; i++)
            {
                // Check if this is the material we want to swap
                if (materials[i].name.StartsWith(targetMaterialName))
                {
                    // Toggle between the original and the alternate material
                    materials[i] = alternateMaterial;
                    swapMaterials= !swapMaterials;

                    // Apply the modified materials array back to the renderer
                    objectRenderer.materials = materials;
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < materials.Length; i++)
            {
                // Check if this is the material we want to swap
                if (materials[i].name.StartsWith(altMaterialName))
                {
                    // Toggle between the original and the alternate material
                    materials[i] = originalMaterial;
                    swapMaterials= !swapMaterials;

                    // Apply the modified materials array back to the renderer
                    objectRenderer.materials = materials;
                    break;
                }
            }
        }

    }
}