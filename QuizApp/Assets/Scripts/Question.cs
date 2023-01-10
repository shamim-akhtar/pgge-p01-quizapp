using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question
{
  public string id = "";
  public string question = "";
  public List<string> choices = new List<string>();
  public int correctAnswerId = 0;
  public string category = "";

  // The following set of question is for testing purposes.
  // The real set of questions need to be from the database or
  // from some CSV/Json file.
  public static List<Question> CreateSampleQuestions()
  {
    List<Question> questions = new List<Question>();

    Question q1 = new Question();
    q1.id = "0";
    q1.question = "What is the capital of Norway?";
    q1.choices.Add("Oslo");
    q1.choices.Add("Helsinki");
    q1.choices.Add("Berlin");
    q1.choices.Add("London");
    q1.correctAnswerId = 0;
    q1.category = "Trivia";
    questions.Add(q1);


    Question q2 = new Question();
    q2.id = "1";
    q2.question = "Who is the author of David Copperfield?";
    q2.choices.Add("JK Rowling");
    q2.choices.Add("Charles Dickens");
    q2.choices.Add("Brandon");
    q2.choices.Add("RL Stevenson");
    q2.correctAnswerId = 1;
    q2.category = "Trivia";
    questions.Add(q2);

    Question q3 = new Question();
    q3.id = "2";
    q3.question = "What is the square root of 144?";
    q3.choices.Add("10");
    q3.choices.Add("11");
    q3.choices.Add("12");
    q3.choices.Add("13");
    q3.correctAnswerId = 2;
    q3.category = "Math";
    questions.Add(q3);


    Question q4 = new Question();
    q4.id = "3";
    q4.question = "Which Singapore dollar note has the National Anthem written on it?";
    q4.choices.Add("10");
    q4.choices.Add("50");
    q4.choices.Add("100");
    q4.choices.Add("1000");
    q4.correctAnswerId = 3;
    q4.category = "Math";
    questions.Add(q4);

    Question q5 = new Question();
    q5.id = "4";
    q5.question = "What is the atomic number of Carbon?";
    q5.choices.Add("4");
    q5.choices.Add("5");
    q5.choices.Add("6");
    q5.choices.Add("12");
    q5.correctAnswerId = 2;
    q5.category = "Science";
    questions.Add(q5);

    return questions;
  }
}
