using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
  #region Serializable parameters
  [SerializeField]
  RectTransform _panelQuiz;
  [SerializeField]
  RectTransform _panelCorrectAnswer;
  [SerializeField]
  RectTransform _panelInCorrectAnswer;
  [SerializeField]
  RectTransform _panelTimesUp;

  [SerializeField]
  Text _countdownTimerText;
  [SerializeField]
  Text _totalScoreText;
  [SerializeField]
  Text _progressText;
  [SerializeField]
  Text _questionText;
  [SerializeField]
  Text _optionAText;
  [SerializeField]
  Text _optionBText;
  [SerializeField]
  Text _optionCText;
  [SerializeField]
  Text _optionDText;

  [SerializeField]
  Text _scoreText;

  [SerializeField]
  Text _correctAnswerText;

  [SerializeField]
  Button _nextButton;
  #endregion

  List<Question> _questions = new List<Question>();
  int _currentIndex = 0;
  IEnumerator _countdownCoroutine = null;
  int _totalScore = 0;
  float _startTime = 0.0f;

  List<Response> _resposnes = new List<Response>();

  // Quiz related variables.
  // Start is called before the first frame update
  void Start()
  {
    _totalScoreText.text = _totalScore.ToString();
    _questions = Question.CreateSampleQuestions();
    ShowQuestion(0);
  }

  // Update is called once per frame
  void Update()
  {

  }

  #region Quiz related functions
  void ShowQuestion(int id)
  {
    if(id >= _questions.Count)
    {
      SceneManager.LoadScene("PostQuiz");
      //We need to create a new scene which
      //will open once we finish our quiz.
      return;
    }

    _startTime = Time.time;

    _progressText.text = (_currentIndex + 1).ToString() + "/" + _questions.Count;

    _panelCorrectAnswer.gameObject.SetActive(false);
    _panelInCorrectAnswer.gameObject.SetActive(false);
    _panelQuiz.gameObject.SetActive(true);
    _panelTimesUp.gameObject.SetActive(false);
    _nextButton.gameObject.SetActive(false);

    _currentIndex = id;
    Question q = _questions[id];
    _questionText.text = q.question;

    // TODO: Add validations before assiging variables.
    // Important!
    _optionAText.text = q.choices[0];
    _optionBText.text = q.choices[1];
    _optionCText.text = q.choices[2];
    _optionDText.text = q.choices[3];

    // Start the countdown timer.
    _countdownCoroutine = Coroutine_CountdownTimer(30.0f);
    StartCoroutine(_countdownCoroutine);
  }

  IEnumerator Coroutine_CountdownTimer(float t)
  {
    float dt = 0;
    while(dt < t)
    {
      yield return new WaitForSeconds(1.0f);
      dt += 1.0f;
      _countdownTimerText.text = (t - dt).ToString("F2");
    }
    // times up! show the times up panel.
    _panelCorrectAnswer.gameObject.SetActive(false);
    _panelInCorrectAnswer.gameObject.SetActive(false);
    _panelQuiz.gameObject.SetActive(false);
    _panelTimesUp.gameObject.SetActive(true);
    _nextButton.gameObject.SetActive(true);
  }

  void SelectOption(int id)
  {
    if (_countdownCoroutine != null)
      StopCoroutine(_countdownCoroutine);
    _countdownCoroutine = null;

    Response r = new Response();
    Question q = _questions[_currentIndex];
    int score = 0;
    if(q.correctAnswerId == id)
    {
      // User selected the correct answer. Shw=ow the correct answer panel.
      score = 100;
      ShowCorrectAnswerPanel(score);
      r.type = ResponseType.CORRECT;
    }
    else
    {
      ShowInCorrectAnswerPanel();
      r.type = ResponseType.INCORRECT;
    }
    _totalScore += score;
    _totalScoreText.text = _totalScore.ToString();

    r.score = 100;

    float endTime = Time.time;
    r.time = endTime - _startTime;
    _resposnes.Add(r);
  }
  void ShowCorrectAnswerPanel(int score)
  {
    _scoreText.text = score.ToString();

    _panelCorrectAnswer.gameObject.SetActive(true);
    _panelInCorrectAnswer.gameObject.SetActive(false);
    _panelQuiz.gameObject.SetActive(false);
    _panelTimesUp.gameObject.SetActive(false);

    StartCoroutine(Coroutine_ShowScore(score));
  }
  void ShowInCorrectAnswerPanel()
  {
    Question q = _questions[_currentIndex];
    int correctAnswerId = q.correctAnswerId;

    _correctAnswerText.text = q.choices[correctAnswerId];

    _panelCorrectAnswer.gameObject.SetActive(false);
    _panelInCorrectAnswer.gameObject.SetActive(true);
    _panelQuiz.gameObject.SetActive(false);
    _panelTimesUp.gameObject.SetActive(false);
    _nextButton.gameObject.SetActive(true);
  }

  public void OnClickOptionA()
  {
    SelectOption(0);
  }

  public void OnClickOptionB()
  {
    SelectOption(1);
  }

  public void OnClickOptionC()
  {
    SelectOption(2);
  }

  public void OnClickOptionD()
  {
    SelectOption(3);
  }

  public void OnClickNext()
  {
    _currentIndex++;
    if(_currentIndex == _questions.Count)
    {
      GameApp.Instance.user.score += _totalScore;
      GameApp.Instance.user.level += 1;
      // Lets save the userdata.
      GameApp.Instance.SaveUserData();
      // Lets save the user responses.
      GameApp.Instance.SaveResponses(_resposnes);

      // Go to the next scene.
      SceneManager.LoadScene("PostQuiz");
      return;
    }
    ShowQuestion(_currentIndex);
  }

  IEnumerator Coroutine_ShowScore(int score)
  {
    int count = 0;
    while(count < score)
    {
      yield return new WaitForSeconds(0.05f);
      count += 5;
      _scoreText.text = "+" + count.ToString();
    }
    _scoreText.text = "+" + score;
    _nextButton.gameObject.SetActive(true);
  }

  #endregion
}
