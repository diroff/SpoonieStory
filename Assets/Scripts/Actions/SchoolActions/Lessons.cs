using System.Collections.Generic;
using UnityEngine;

public class Lessons : MonoBehaviour
{
    [SerializeField] private List<Lesson> _lessons;

    public void ResetLessons()
    {
        foreach (Lesson lesson in _lessons)
            lesson.UnVisitLesson();
    }
}