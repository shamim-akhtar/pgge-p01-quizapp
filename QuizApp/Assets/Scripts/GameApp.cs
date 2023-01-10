using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameApp : Patterns.Singleton<GameApp>
{
  // Start is called before the first frame update
  [SerializeField]
  AudioSource _backgroundAudio;

  public string userFilename = "/user.json";
  public string userResponsesFilename = "/reponses.json";

  public User user { get; private set; }

  void Start()
  {
    user = new User();
    LoadUserData();
    SceneManager.LoadScene("PreQuiz");
  }

  // Update is called once per frame
  void Update()
  {

  }

  // We will now save the user data.


  public void SaveUserData()
  {
    string path = Application.persistentDataPath + userFilename;
    File.WriteAllText(path, user.ToJson().ToString());
  }
  void LoadUserData()
  {
    // Load the data.
    string path = Application.persistentDataPath + userFilename;
    if (File.Exists(path))
    {
      string str = File.ReadAllText(path);

      JSONNode n = JSON.Parse(str);
      user.FromJson(n);
    }
  }

  public void SaveResponses(List<Response> responses)
  {
    string path = Application.persistentDataPath + userResponsesFilename;
    string str = Response.ToJson(responses).ToString();
    File.WriteAllText(path, str);
  }
}
