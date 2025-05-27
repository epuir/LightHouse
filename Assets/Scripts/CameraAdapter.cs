using UnityEngine;

public class CameraAdapter : MonoBehaviour
{
    public float designResolutionWidth = 720;
    public float designResolutionHeight = 1280f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        AdjustCameraSize();
    }

    void AdjustCameraSize()
    {
        float targetAspectRatio = designResolutionWidth / designResolutionHeight;
        float windowAspectRatio = (float)Screen.width / (float)Screen.height;

        if (windowAspectRatio >= targetAspectRatio)
        {
            // 宽度适配
            mainCamera.orthographicSize = ((designResolutionHeight / 2) * (Screen.height / designResolutionHeight))/(float)100;
        }
        else
        {
            // 高度适配
            float differenceInAspectRatio = targetAspectRatio / windowAspectRatio;
            mainCamera.orthographicSize = (designResolutionHeight / 2) * (differenceInAspectRatio)/(float)100;
        }
    }
}
