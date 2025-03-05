using UnityEngine;

public class FloorTextureScaler : MonoBehaviour
{
    void Update()
    {
        // Get the scale of the object
        Vector3 scale = transform.localScale;

        // Get the MeshRenderer component of the object
        Renderer renderer = GetComponent<Renderer>();

        // Adjust the tiling based on scale (X and Y scale) for this object
        // This ensures that only the material on this object is affected
        renderer.material.mainTextureScale = new Vector2(scale.x*10, scale.y*10);
    }
}