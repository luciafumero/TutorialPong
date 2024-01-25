using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScoreUI : MonoBehaviour
{
    int goalsPlayer1;
    int goalsPlayer2;
    public TextMeshProUGUI scoreText;
    [SerializeField]
    float animationTime = 0.2f;
    [SerializeField]
    LeanTweenType animationCurve;
    [SerializeField]
    float textPosition = 1400f;
    [SerializeField]
    GameObject textLabelGoal;
    float endAnimationPosition;

    public void ResetScore()
    {
        goalsPlayer1 = 0;
        goalsPlayer2 = 0;
        UpdateScoreText();
    }

    public void GoalsScoardPlayer1()
    {
        goalsPlayer1++;
        UpdateScoreText();
        AnimateGoalText(1, animationTime);
    }

    public void GoalsScoardPlayer2()
    {
        goalsPlayer2++;
        UpdateScoreText();
        AnimateGoalText(2, animationTime);
    }

    void AnimateGoalText(int player, float animationDuration)
    {
        float textinitialPosition = 0f;
        if (player == 1)
        {
            textinitialPosition = -textPosition;
        }
        else
        {
            textinitialPosition = textPosition;
        }

        endAnimationPosition -= textinitialPosition;

        LeanTween.moveLocalX(textLabelGoal, textinitialPosition, 0.0f);
        LeanTween.moveLocalX(textLabelGoal, 0.0f, 0.15f).setOnComplete(EndAnimation);
    }

    void EndAnimation()
    {
        LeanTween.moveLocalX(textLabelGoal, endAnimationPosition, 0.75f).setEaseInCirc ;
    }

    void UpdateScoreText()
    {
        LeanTween.scale(scoreText.gameObject, Vector3.zero, 0.0f);
        LeanTween.scale(scoreText.gameObject, Vector3.one, animationTime).setEase(animationCurve);
        scoreText.text = goalsPlayer1 + " : " + goalsPlayer2;
    }
}
