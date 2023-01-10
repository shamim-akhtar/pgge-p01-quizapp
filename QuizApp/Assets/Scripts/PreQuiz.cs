using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreQuiz : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void OnClickPlay()
  {
    // Upon clicking this button we should launch the main game
    // which is Quiz.
    SceneManager.LoadScene("Quiz");
  }
}
