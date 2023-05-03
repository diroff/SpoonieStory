using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _descripionText;

    public string Description;
    public bool IsComplete = false;
    public bool IsEmpty = false;
    public Button AddTaskButton;
    public Task TaskLink;

    public UnityEvent<bool> OnComplete;

    private void OnEnable()
    {
        SetQuestText();
    }

    public void CompleteTask()
    {
        IsComplete = true;
        OnComplete?.Invoke(true);
    }

    public void SetQuestText()
    {
        _descripionText.text = Description;
    }

    public void CheckQuestStatus(int currentHoursTime)
    {
        _descripionText.color = Color.black;

        if (IsEmpty)
            _descripionText.color = Color.gray;

        if (IsComplete)
            _descripionText.fontStyle = FontStyles.Strikethrough;
        else if(!IsComplete && currentHoursTime >= 18 && !IsEmpty)
            _descripionText.color = Color.red;
        else
            _descripionText.fontStyle = FontStyles.Normal;
    }

    public void UnCompleteQuest()
    {
        IsComplete = false;
    }

    public void AddTask()
    {
        AddTaskButton.interactable = false;
    }

    public void RemoveTask()
    {
        AddTaskButton.interactable = true;
    }

    public void SetButtonEnabled(bool enabled)
    {
        AddTaskButton.gameObject.SetActive(enabled);
    }
}