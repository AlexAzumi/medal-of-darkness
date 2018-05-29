using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelScore : MonoBehaviour 
{
    public string m_PublishURL = "https://aldanproject.000webhostapp.com/unity-scripts/submit-score.php";
    public int m_MaxPoints = 1500;

    public string m_Username;
    public int m_TotalScore = 0;

    private Animator m_PublishMessage;
    private int m_ActualScore;
    private bool m_StartPuzzle = true;
    private float m_Count = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (m_StartPuzzle)
        {
            m_Count += Time.deltaTime%60;
        }
    }

    public void SetUsername(string username)
    {
        m_Username = username;
        Debug.Log("Username: " + m_Username);
    }

    public void StartPuzzle()
    { 
        if (!string.IsNullOrEmpty(m_Username))
        {
            m_ActualScore = m_MaxPoints;
            m_StartPuzzle = true;
            Debug.Log(m_Username + " started the puzzle");
        }
        else
        {
            Debug.Log("A username is needed or the puzzle has already started");
        }
    }

    public void StopPuzzle()
    {
        CalculateScore();
        m_StartPuzzle = false;
        m_Count = 0.0f;
        Debug.Log("Puzzled was resolved");
        Debug.Log("Points gained: " + m_ActualScore);
    }

    public void PausePuzzle()
    {
        m_StartPuzzle = false;
    }

    public void RemovePoints(int points)
    {
        m_ActualScore -= points;
        Debug.Log("Removing points: " + points);
    }

    public void SubmitScore()
    {
        StartCoroutine(PublishScore());
    }

    private void CalculateScore()
    {
        m_ActualScore -= (int)m_Count/2;
        if (m_ActualScore < 500)
        {
            m_ActualScore = 500;
        }
        m_TotalScore += m_ActualScore;
        Debug.Log("Total score: " + m_TotalScore);
    }

    private IEnumerator PublishScore()
    {
        Debug.Log("Publicando puntuación...");
        WWWForm score = new WWWForm();
        score.AddField("username", m_Username);
        score.AddField("score", m_TotalScore);
        WWW sendData = new WWW(m_PublishURL, score);
        yield return sendData;
        string result = sendData.text;
        Debug.Log("result = " + sendData.text);
        if (result.Contains("submitted"))
        {
            Debug.Log("Scores were submitted correctly");
            SetPublishedMessage();
        }
        else
        {
            if (result.Contains("Error01"))
            {
                Debug.Log("SQL was not prepared correctly");
            }
            else
            {
                Debug.Log("Error while submitting player's score");
            }
        }
    }
        
    private void SetPublishedMessage()
    {
        m_PublishMessage = GameObject.FindGameObjectWithTag("PublishMessage").GetComponent<Animator>();
        m_PublishMessage.SetTrigger("Published");
    }
}
