using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
  [SerializeField]
  private AudioMixer ambientMixer;

  [SerializeField]
  private AudioMixer enemyMixer;

  void Awake()
  {
    DontDestroyOnLoad(this.gameObject);
  }

  // Update is called once per frame
  public void SetAmbientVolume(float sliderValue)
  {
    ambientMixer.SetFloat("AmbientVolume", Mathf.Log10(sliderValue) * 20);
  }

  public void SetEnemyVolume(float sliderValue)
  {
    enemyMixer.SetFloat("EnemyVolume", Mathf.Log10(sliderValue) * 20);
  }
}
