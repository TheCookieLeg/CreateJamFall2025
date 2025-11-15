using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.Splines;

public class CameraMovement : MonoBehaviour
{
    [Header("Header 1")]
    [SerializeField] private CinemachineSplineDolly dollyCart;
    [SerializeField] private SplineContainer smoothPath;

    [Header("Header 2")]
    [SerializeField] private float moveDuration = 0.6f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (dollyCart == null || smoothPath == null)
        {
            Debug.LogError("Dollycart or smoothPath is missing, please set them in the editor");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
