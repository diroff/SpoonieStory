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
            SetLessonType();
        }
    }

    public void UnVisitLesson()
    {
        IsVisited = false;
    }

    public void SetLessonType()
    {
        int number = GetRandomNumber();

        if (number < 6)
        {
            //Difficult
        }
        else if (number >= 6 && number < 11)
        {
            //Boring
        }
        else if (number >= 11 && number < 16)
        {
            //No effect
        }
        else if(number >= 16 && number < 19)
            {
            //Easy
        }
        else if(number >= 19)
        {
            //Interesting
        }
    }

    private int GetRandomNumber()
    {
        return Random.Range(1, 21);
    }
}