using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private GameObject _taskPanel;
    [SerializeField] private GameObject _taskListPanel;

    [SerializeField] private List<Task> _currentTasks = new List<Task>();
    [SerializeField] private List<Task> _availableTasks = new List<Task>();

    private bool _openedFirstTime = true;

    private void OnEnable()
    {
        if (_openedFirstTime)
            OpenFirstTime();
        else
            CheckTasks();
    }

    public void DoneTasks()
    {
        _taskPanel.SetActive(false);
        _openedFirstTime = false;
    }

    public void OpenFirstTime()
    {
        CheckButtonState();

        for (int i = 0; i < _currentTasks.Count; i++)
        {
            _currentTasks[i].SetQuestText();
        }

        for (int i = 0; i < _currentTasks.Count; i++)
        {
            RemoveTask(_currentTasks[i]);
        }

        EnableTasksAdding();
    }

    public void CheckTasks()
    {
        for (int i = 0; i < _currentTasks.Count; i++)
        {
            _currentTasks[i].AddTask();

            if (_currentTasks[i].TaskLink != null)
                _currentTasks[i].IsComplete = _currentTasks[i].TaskLink.IsComplete;

            _currentTasks[i].CheckQuestStatus();
        }

        DisableTasksAdding();
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

    public void CheckButtonState()
    {
        for (int i = 0; i < _currentTasks.Count; i++)
        {
            if (_currentTasks[i].IsEmpty)
                _currentTasks[i].AddTask();
            else
                _currentTasks[i].RemoveTask();
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