using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _gamePanel;

    [SerializeField] private TextMeshProUGUI _reason;
    [SerializeField] private Grade _grade;

    private void OnEnable()
    {
        _grade.GradesOver.AddListener(ShowGameOverPanel);
    }

    private void OnDisable()
    {
        _grade.GradesOver.RemoveListener(ShowGameOverPanel);
    }

    private void ShowGameOverPanel(string reason)
    {
        _gamePanel.SetActive(false);
        _gameOverPanel.SetActive(true);
        _reason.text = reason;
    }
}