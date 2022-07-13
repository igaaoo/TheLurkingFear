using UnityEngine;

public class GetHighscore : MonoBehaviour
{
  private string highscore;

  // Store highscore
  void Awake()
  {
    DontDestroyOnLoad(this.gameObject);
  }

  // Set highscore value
  public void SetHighscore()
  {
    highscore = GameObject.FindObjectOfType<Highscore>().GetHighscore();
  }

  // Get highscore value
  public string GetScore()
  {
    return highscore;
  }
}
