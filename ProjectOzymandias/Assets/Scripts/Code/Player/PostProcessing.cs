using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{
    public PostProcessVolume volume;
    public SlowMotion slowMotion;
    private Vignette vignette;
    private LensDistortion lensDistortion;
    private PlayerController pc;
    public float slowTimer = 100;
    private bool canSlowTime = true; // New flag to control slow time activation

    void Start()
    {
        volume.profile.TryGetSettings(out vignette);
        volume.profile.TryGetSettings(out lensDistortion);
        vignette.smoothness.value = 0.6f;
        lensDistortion.intensity.value = 0f;
        pc = GameObject.Find("Hips").GetComponent<PlayerController>();
        StartCoroutine(SlowMotionIncrease());
    }

    void Update()
    {
        slowTimer = Mathf.Clamp(slowTimer, 0, 100); // Simplified clamping of slowTimer

        if (Input.GetKeyDown(KeyCode.LeftShift) && slowTimer > 0 && canSlowTime)
        {
            ActivateSlowMotion();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || slowTimer <= 0)
        {
            DeactivateSlowMotion();
        }
        slowMotion.SetSlowMo(slowTimer);
    }

    void ActivateSlowMotion()
    {
        Time.timeScale = 0.25f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        vignette.smoothness.value = 2f;
        lensDistortion.intensity.value = -50f;
        canSlowTime = false; // Prevent reactivation without releasing the key
        StartCoroutine(SlowMotion());
    }

    void DeactivateSlowMotion()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        vignette.smoothness.value = 0.6f;
        lensDistortion.intensity.value = 0f;
        canSlowTime = true; // Allow slow time to be reactivated
    }

    IEnumerator SlowMotion()
    {
        while (Input.GetKey(KeyCode.LeftShift) && slowTimer > 0)
        {
            slowTimer -= 0.4f;
            yield return new WaitForSecondsRealtime(0.01f); // Use WaitForSecondsRealtime to respect Time.timeScale
        }
        DeactivateSlowMotion();
    }

    IEnumerator SlowMotionIncrease()
    {
        while (true) // Simplify to a loop that continuously runs
        {
            yield return new WaitForSecondsRealtime(2); // Use WaitForSecondsRealtime to keep increasing even in slow motion
            slowTimer += 10;
        }
    }
}