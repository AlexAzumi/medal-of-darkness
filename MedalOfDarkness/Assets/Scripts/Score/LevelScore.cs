using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelScore : MonoBehaviour 
{
    public string m_PublishURL = "https://127.0.0.1/unity-scripts/submit.php";
    public Text m_Username;
    public Animator m_PublishMessage;

    private int score = 1000;
    private bool m_StartPuzzle = true;
    private float m_Count = 0;

    private void Update()
    {
        if (m_StartPuzzle)
        {
            m_Count += Time.deltaTime%60;
        }
    }

    public void StartPuzzle()
    {
        m_StartPuzzle = true;
    }

    public void FinishPuzzle()
    {
        m_StartPuzzle = false;
        m_Count = 0.0f;
    }

    public void PausePuzzle()
    {
        m_StartPuzzle = false;
    }

    public void RemovePoints(int points)
    {
        score -= points;
    }

    private void CalculateScore()
    {
        score -= (int)m_Count;
        if (score < 500)
        {
            score = 500;
        }
    }

    private IEnumerator PublishScore()
    {
        WWWForm score = new WWWForm();
        score.AddField("username", m_Username.text);
        score.AddField("score", score.ToString());
        WWW sendData = new WWW(m_PublishURL, score);
        yield return sendData;
        string result = sendData.text;
        if (result.Equals("true"))
        {
            SetPublishedMessage();
        }
    }

    private void SetPublishedMessage()
    {
        m_PublishMessage.SetTrigger("Published");
    }
}
