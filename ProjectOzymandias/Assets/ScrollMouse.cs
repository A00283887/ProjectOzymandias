using UnityEngine;
using Cinemachine;

public class ScrollMouse : MonoBehaviour
{
    public float zoomSpeed = 10f;
    public float minSize = 2f; 
    public float maxSize = 10f;

    private CinemachineVirtualCamera virtualCamera;
    private float targetSize;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        targetSize = virtualCamera.m_Lens.OrthographicSize;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        targetSize -= scroll * zoomSpeed;
        targetSize = Mathf.Clamp(targetSize, minSize, maxSize);
        virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, targetSize, Time.deltaTime * zoomSpeed);
    }
}