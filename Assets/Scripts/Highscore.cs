using UnityEngine;

public class Highscore : MonoBehaviour
{

  private TMPro.TextMeshProUGUI highscoreText;

  private Transform player;

  // Show highscore
  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player").transform;
    highscoreText = GameObject.Find("highscore").GetComponent<TMPro.TextMeshProUGUI>();
  }

  // Update highscore
  void Update()
  {
    highscoreText.text = player.position.z.ToString("0");
  }

  // Return highscore value, used when death
  public string GetHighscore()
  {
    return highscoreText.text;
  }
}
