using UnityEngine;
using UnityEngine.Rendering;

public class ParallaxManager : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public Transform layer;
        [Range(0, 1)] public float parallaxFactor;
    }

    public ParallaxLayer[] layers;

    public Transform camTransform;
    private Vector3 lastCameraPosition;

    void Start()
    {
        lastCameraPosition = camTransform.position;
    }

    void LateUpdate() // Update is called once per frame
    {
        Vector3 cameraDelta = camTransform.position - lastCameraPosition;
        foreach (ParallaxLayer layer in layers)
        {
            float moveX = cameraDelta.x * layer.parallaxFactor;
            float moveY = cameraDelta.y * layer.parallaxFactor;
            layer.layer.position += new Vector3(moveX, moveY, 0);
            lastCameraPosition = camTransform.position;
        }
    }
}
