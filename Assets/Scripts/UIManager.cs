using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
  public TextMeshProUGUI scoreText;


  public TextMeshProUGUI levelText;

  private void OnEnable()
  {
    GameEventManager.OnScoreUpdate += UpdateScoreText;
  }

  private void OnDisable()
  {
    GameEventManager.OnScoreUpdate -= UpdateScoreText;
  }

  void Start()
  {
    UpdateScoreText(GameScoreManager.Instance.Value);
  }

  private void UpdateScoreText(int newScore)
  {
    scoreText.text = "Score: " + newScore.ToString();
  }

  private void UpdateLevelText(int newLevel)
  {
    levelText.text = "Level: " + newLevel.ToString();
  }

}
