using UnityEngine;

public class Timer : MonoBehaviour
{
  private TMPro.TextMeshProUGUI timerText;

  private float currentTime = 0;
  private float startTime = 300;

  void Start()
  {
    // Get the TextMeshProUGUI component from the GameObject.
    currentTime = startTime;
    timerText = GameObject.FindWithTag("Timer").GetComponent<TMPro.TextMeshProUGUI>();
  }

  // Show time to survive
  void Update()
  {
    currentTime -= 1 * Time.deltaTime;
    timerText.text = currentTime.ToString("0");

    // Load victory scene if time is 0
    if (currentTime <= 0)
    {
      MenuManager menu = GameObject.FindObjectOfType<MenuManager>();
      GetHighscore highscore = GameObject.FindObjectOfType<GetHighscore>();
      highscore.SetHighscore();
      menu.Victory();
    }
  }
}
