using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
  //Time needed to enemy die
  private float timeToDie = 2f;

  // Use this for initialization of audio source
  [SerializeField]
  private AudioSource audioSource;
  [SerializeField]
  private AudioClip deathSound;



  void Start()
  {
    StartCoroutine(FadeInAudio(audioSource, 3f));
  }

  public void Defeated()
  {
    //Play death sound
    audioSource.PlayOneShot(deathSound);
    audioSource.loop = false;
    audioSource.volume = 0.005f;

    //Destroy enemy
    timeToDie -= Time.deltaTime;
    if (timeToDie <= 0)
    {
      EventManager.instance.CanSpawnEnemy();
      Destroy(transform.parent.gameObject);
    }
  }

  // Fade in audio source
  private static IEnumerator FadeInAudio(AudioSource audioSource, float fadeTime)
  {
    while (audioSource.volume < 0.06f)
    {
      audioSource.volume += 0.01f * Time.deltaTime / fadeTime;
      yield return null;
    }
  }
}
