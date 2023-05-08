using TMPro;
using UnityEngine;

public class HelpButton : MonoBehaviour
{
    [SerializeField] private GameObject _helpPanel;

    [SerializeField] private TextMeshProUGUI _buttonText;

    private bool _isActive = false;

    public void OpenPanel()
    {
        if (!_isActive)
        {
            _isActive = true;
            _buttonText.text = "Close Help";
            _helpPanel.SetActive(true);
        }
        else
        {
            _isActive = false;
            _buttonText.text = "Help";
            _helpPanel.SetActive(false);
        }
    }
}