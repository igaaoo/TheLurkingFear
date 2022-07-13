using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
  private TMPro.TextMeshProUGUI highscoreText;


  // Show highscore
  void Start()
  {
    highscoreText = GameObject.Find("Highscore").GetComponent<TMPro.TextMeshProUGUI>();
    highscoreText.text = "Pontuacao: " + GameObject.FindObjectOfType<GetHighscore>().GetScore();
  }

  // Get inputs
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
  }
}
