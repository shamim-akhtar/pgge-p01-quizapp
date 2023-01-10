using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PostQuiz : MonoBehaviour
{
  [SerializeField]
  Text _totalScoreText;
  public void Start()
  {
    _totalScoreText.text = "Dummy";
  }
  public void OnClickPlay()
  {
    // Upon clicking this button we should launch the main game
    // which is Quiz.
    SceneManager.LoadScene("Quiz");
  }
}
