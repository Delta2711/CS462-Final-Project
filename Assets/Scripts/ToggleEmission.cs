using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleEmission : MonoBehaviour
{
    [SerializeField]
    public Material material;

    public void Toggle()
    {
        if (material.IsKeywordEnabled("_EMISSION"))
        {
            material.DisableKeyword("_EMISSION");
        }
        else
        {
            material.EnableKeyword("_EMISSION");
        }

    }
}
