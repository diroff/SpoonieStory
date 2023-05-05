using TMPro;
using UnityEngine;

public class SchoolTask : MonoBehaviour
{
    public int NeedToComplete = 5;
    public int CurrentValue = 0;
    public string Description;
    public TextMeshProUGUI TaskText;
    public bool IsComplete = false;
    public bool IsEmpty = false;

    public void ShowProgress()
    {
        if (IsEmpty)
            return;

        if(!IsComplete)
            TaskText.text = Description + CurrentValue + "/" + NeedToComplete;

        CheckComplete();
    }

    public void AddValue(int value)
    {
        CurrentValue += value;
        ShowProgress();
    }

    public void CheckComplete()
    {
        if (CurrentValue >= NeedToComplete)
        {
            TaskText.fontStyle = FontStyles.Strikethrough;
            IsComplete = true;
        }

        if (!IsComplete)
        {
            TaskText.fontStyle = FontStyles.Normal;
            return;
        }
    }

    public void FirstOpen(string day)
    {
        if(day == "Saturday" || day == "Sunday")
        {
            IsEmpty = true;
            TaskText.color = Color.gray;
            TaskText.text = "No plans here!";
        }
        else
        {
            IsEmpty = false;
            TaskText.color = Color.black;
            CurrentValue = 0;
            IsComplete = false;

            ShowProgress();
        }
    }
}
