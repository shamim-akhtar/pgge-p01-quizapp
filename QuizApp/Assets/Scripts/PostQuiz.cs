using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PostQuiz : MonoBehaviour
{
  [SerializeField]
  Text _totalScoreText;
  [SerializeField]
  Text _levelText;
  public void Start()
  {
    _totalScoreText.text = GameApp.Instance.user.score.ToString();
    _levelText.text = "Level " + GameApp.Instance.user.level.ToString();
  }
  public void OnClickPlay()
  {
    // Upon clicking this button we should launch the main game
    // which is Quiz.
    SceneManager.LoadScene("Quiz");
  }
}
