using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
  private GameObject tutorial;

  void Start()
  {
    tutorial = GameObject.FindWithTag("Tutorial");
    tutorial.SetActive(true);
    Time.timeScale = 0;

  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      tutorial.SetActive(false);
      Time.timeScale = 1;
    }

  }
}
