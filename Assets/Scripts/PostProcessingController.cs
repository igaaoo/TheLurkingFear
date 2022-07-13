using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class PostProcessingController : MonoBehaviour
{
  private Volume volume;

  private Vignette vignette;

  private ChromaticAberration chromaticAberration;

  private LensDistortion lensDistortion;

  private static PostProcessingController _instance;
  public static PostProcessingController instance
  {
    get
    {
      if (_instance == null)
      {
        _instance = FindObjectOfType<PostProcessingController>();
      }
      return _instance;
    }
  }

  void Start()
  {
    volume = GetComponent<Volume>();
    volume.profile.TryGet<Vignette>(out vignette);

    volume.profile.TryGet<ChromaticAberration>(out chromaticAberration);

    volume.profile.TryGet<LensDistortion>(out lensDistortion);
  }

  //Apply the vignette effect
  public void ApplyVignette()
  {
    vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0.40f, Time.deltaTime * 5);
  }

  //Remove the vignette effect
  public void RemoveVignette()
  {
    vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0.15f, Time.deltaTime * 5);
  }

  //Apply the chromatic aberration effect
  public void ApplyChromaticAberration()
  {
    chromaticAberration.intensity.value = 0.45f;
  }

  //Remove the chromatic aberration effect
  public void RemoveChromaticAberration()
  {
    chromaticAberration.intensity.value = 0;
  }

  //Apply the lens distortion effect
  public void ApplyLensDistortion()
  {
    lensDistortion.intensity.value = 0.5f;
  }


  public void RemoveLensDistortion()
  {
    lensDistortion.intensity.value = 0;
  }
}
