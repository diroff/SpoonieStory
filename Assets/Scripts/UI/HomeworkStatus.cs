using TMPro;
using UnityEngine;

public class HomeworkStatus : MonoBehaviour
{
    [SerializeField] private StudyController _studyController;
    [SerializeField] private TextMeshProUGUI _statusText;

    private void OnEnable()
    {
        _studyController.HomeworkFinished.AddListener(DisplayHomeworkStatus);
        DisplayHomeworkStatus(_studyController.HomeWorkIsReady);
    }

    private void OnDisable()
    {
        _studyController.HomeworkFinished.RemoveListener(DisplayHomeworkStatus);
    }

    private void DisplayHomeworkStatus(bool isReady)
    {
        _statusText.text = "Homework: ";

        if (isReady)
            _statusText.text += "finished";
        else
            _statusText.text += "unfinished";
    }
}