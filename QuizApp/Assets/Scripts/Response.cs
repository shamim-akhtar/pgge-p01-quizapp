using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResponseType
{
  CORRECT,
  INCORRECT,
  TIMEOUT,
}
public class Response
{
  public ResponseType type = ResponseType.INCORRECT;
  public float time = 0.0f;
  public string question_id = "";
  public int score = 0;

  public virtual JSONNode ToJson()
  {
    JSONNode n = new JSONObject();
    n["type"] = (int)type;
    n["time"] = time;
    n["question_id"] = question_id;
    n["score"] = score;
    return n;
  }

  public virtual void FromJson(JSONNode n)
  {
    type = (ResponseType)(n["type"].AsInt);
    time = n["time"].AsFloat;
    question_id = n["question_id"];
    score = n["score"].AsInt;
  }


  static public JSONNode ToJson(List<Response> responses)
  {
    JSONObject n = new JSONObject();
    JSONArray ar = new JSONArray();
    for(int i = 0; i < responses.Count; ++i)
    {
      ar.Add(responses[i].ToJson());
    }

    n["responses"] = ar;
    return n;
  }
}
