using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

    public static int score;
    private Text t_score;

    void Start()
    {
        t_score = GetComponent<Text>();
        t_score.text = score.ToString();
        sReset();
    }

    public int Score(int points)
    {
        score += points;
        t_score.text = score.ToString();
        return score;
    }

    public static void sReset()
    {
        score = 0;
    }

}
