using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private GameObject _taskPanel;
    [SerializeField] private GameObject _taskListPanel;

    [SerializeField] private List<Task> _currentTasks = new List<Task>();
    [SerializeField] private List<Task> _availableTasks = new List<Task>();

    [SerializeField] private TextMeshProUGUI _exitButtonText;
    [SerializeField] private TimeManagment _timeManagment;

    [SerializeField] private SchoolTask _schoolTask;

    public int TodayFailedTasks = 0;
    public int YesterdayFailedTasks = 0;

    public bool OpenedFirstTime = true;

    private void OnEnable()
    {
        if (OpenedFirstTime)
            OpenFirstTime();
        else
            CheckTasks();
    }

    public void DoneTasks()
    {
        _taskPanel.SetActive(false);
        OpenedFirstTime = false;
    }

    public void OpenFirstTime()
    {
        _schoolTask.FirstOpen(_timeManagment.CurrentWeekDay);
        _taskListPanel.SetActive(true);

        for (int i = 0; i < _currentTasks.Count; i++)
        {
            _currentTasks[i].SetButtonEnabled(true);
        }

        for (int i = 0; i < _availableTasks.Count; i++)
        {
            _availableTasks[i].IsComplete = false;
        }

        for (int i = 0; i < _currentTasks.Count; i++)
        {
            RemoveTask(_currentTasks[i]);
            _currentTasks[i].CheckQuestStatus(_timeManagment.CurrentHours);
        }

        EnableTasksAdding();
        _exitButtonText.text = "Done!";
    }

    public void CheckTasks()
    {
        _schoolTask.ShowProgress();

        _taskListPanel.SetActive(false);

        for (int i = 0; i < _currentTasks.Count; i++)
        {
            _currentTasks[i].AddTask();

            if (_currentTasks[i].TaskLink != null)
                _currentTasks[i].IsComplete = _currentTasks[i].TaskLink.IsComplete;

            _currentTasks[i].CheckQuestStatus(_timeManagment.CurrentHours);
        }

        for (int i = 0; i < _currentTasks.Count; i++)
        {
            _currentTasks[i].SetButtonEnabled(false);
        }

        DisableTasksAdding();
        _exitButtonText.text = "Exit";
    }

    public void CheckFailedTasksCount()
    {
        for (int i = 0; i < _currentTasks.Count; i++)
        {
            if (!_currentTasks[i].IsEmpty && !_currentTasks[i].IsComplete)
                TodayFailedTasks++;
        }

        if (!_schoolTask.IsComplete)
            TodayFailedTasks++;

        YesterdayFailedTasks = TodayFailedTasks;
        TodayFailedTasks = 0;
        Debug.Log("You failed " + YesterdayFailedTasks + " tasks!");
    }

    public void EnableTasksAdding()
    {
        for (int i = 0; i < _availableTasks.Count; i++)
        {
            _availableTasks[i].RemoveTask();
        }
    }

    public void DisableTasksAdding()
    {
        for (int i = 0; i < _availableTasks.Count; i++)
        {
            _availableTasks[i].AddTask();
        }
    }

    public int GetCountUnfinishedTasks()
    {
        int count = 0;

        for (int i = 0; i < _currentTasks.Count; i++)
        {
            if (!_currentTasks[i].IsEmpty && !_currentTasks[i].IsComplete)
                count++;
        }

        return count;
    }

    public void AddTask(Task task)
    {
        for (int i = 0; i < _currentTasks.Count; i++)
        {
            if (_currentTasks[i].IsEmpty)
            {
                _currentTasks[i].Description = task.Description;
                _currentTasks[i].IsComplete = task.IsComplete;
                _currentTasks[i].IsEmpty = task.IsEmpty;
                _currentTasks[i].OnComplete = task.OnComplete;
                _currentTasks[i].TaskLink = task;
                _currentTasks[i].SetQuestText();

                task.AddTask();
                CheckButtonState();
                return;
            }
        }
    }

    public void RemoveTask(Task task)
    {
        if(task.TaskLink != null)
            task.TaskLink.RemoveTask();

        task.Description = "empty";
        task.IsComplete = false;
        task.IsEmpty = true;
        task.TaskLink = null;
        task.SetQuestText();
        task.RemoveTask();
        CheckButtonState();
    }

    public void OpenPanel()
    {
        _taskPanel.SetActive(true);
    }

    public void CheckButtonState()
    {
        for (int i = 0; i < _currentTasks.Count; i++)
        {
            if (_currentTasks[i].IsEmpty)
                _currentTasks[i].AddTask();
            else
                _currentTasks[i].RemoveTask();

            _currentTasks[i].CheckQuestStatus(_timeManagment.CurrentHours);
        }
    }

    [ContextMenu("Show tasks status")]
    public void ShowAllTasks()
    {
        foreach (Task task in _currentTasks)
        {
            Debug.Log("Task:" + task.Description + ". Status:" + task.IsComplete);
        }
    }
}