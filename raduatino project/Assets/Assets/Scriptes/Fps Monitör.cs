using UnityEngine;
using UnityEngine.UI;

public class FpsMonitör : MonoBehaviour
{
    [SerializeField] private Text fpsText;
    private float deltaTime = 0.0f;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;

        if (fpsText != null)
        {
            fpsText.text = $"{fps:0.} FPS";
        }
    }
}