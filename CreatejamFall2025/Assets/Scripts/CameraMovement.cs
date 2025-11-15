using System.Collections;
using UnityEngine;
using Unity.Cinemachine;
using Unity.Mathematics;
using UnityEngine.Splines;

public class CameraMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private CinemachineSplineDolly dollyCart;
    [SerializeField] private SplineContainer smoothPath;
    [SerializeField] private CinemachineBasicMultiChannelPerlin perlinNoise;

    [Header("Header 2")]
    [Tooltip("Changes how fast the camera moves between points.\nThe higher the slower")]
    [SerializeField] private float moveDuration = 0.6f;

    private Coroutine _currentCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (dollyCart == null || smoothPath == null)
        {
            Debug.LogError("Dollycart or smoothPath is missing, please set them in the editor");
            dollyCart.PositionUnits = PathIndexUnit.Normalized;
            perlinNoise.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) { Step(1); }
        if (Input.GetKeyDown(KeyCode.A)) { Step(-1); }
    }

    void Step(int dir)
    {
        if (smoothPath.Splines.Count < 1) return;

        if (_currentCoroutine == null)
        {
            Debug.Log("Coroutine starts");
            _currentCoroutine = StartCoroutine(MoveCamera(dir));
        }
        
    }

    IEnumerator MoveCamera(int dir)
    {
        float startPos = dollyCart.CameraPosition;
        float targetPos = startPos + dir;
        float elapsed = 0f;
        perlinNoise.enabled = true;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / moveDuration;
            dollyCart.CameraPosition = Mathf.Lerp(startPos, targetPos, t);
            yield return null;
        }

        dollyCart.CameraPosition = targetPos; // snap to final
        _currentCoroutine = null;
        perlinNoise.enabled = false;
    }

}
