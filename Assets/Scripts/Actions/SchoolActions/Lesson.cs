using UnityEngine;

public class Lesson : MonoBehaviour
{
    public SchoolTask _schoolTask;
    public bool IsVisited = false;
    
    public void VisitLesson()
    {
        if (!IsVisited)
        {
            IsVisited = true;
            _schoolTask.AddValue(1);
        }
    }

    public void UnVisitLesson()
    {
        IsVisited = false;
    }
}