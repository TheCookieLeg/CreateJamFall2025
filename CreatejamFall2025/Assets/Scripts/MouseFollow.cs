using Unity.Cinemachine;
using UnityEngine;

public class MouseFollow : CinemachineExtension
{
    public float maxTiltX = 5f; // up/down tilt
    public float maxTiltY = 8f; // left/right tilt

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage,
        ref CameraState state,
        float deltaTime)
    {
        if (stage != CinemachineCore.Stage.Aim) return;

        // Get mouse in viewport (0..1)
        Vector2 vp = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        // Convert to -1..+1 range
        float x = (vp.x - 0.5f) * 2f;
        float y = (vp.y - 0.5f) * 2f;

        // Tilt amounts
        float tiltYaw = x * maxTiltY;
        float tiltPitch = -y * maxTiltX;

        // Apply rotation correction
        Quaternion tilt = Quaternion.Euler(tiltPitch, tiltYaw, 0);
        state.OrientationCorrection *= tilt;
    }
}
