using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _gamePanel;

    [SerializeField] private TextMeshProUGUI _reason;
    [SerializeField] private Grade _grade;

    public void ShowGameOverPanel()
    {
        if (_grade.CurrentValue > 49)
            return;

        _gamePanel.SetActive(false);
        _gameOverPanel.SetActive(true);
        _reason.text = _grade.Reason;
    }
}