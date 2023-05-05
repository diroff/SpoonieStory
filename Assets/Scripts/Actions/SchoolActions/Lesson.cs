using UnityEngine;

public class Lesson : MonoBehaviour
{
    public SchoolTask _schoolTask;
    public bool IsVisited = false;

    private int _lessonTypeNumber = 0;

    public void VisitLesson()
    {
        if (!IsVisited)
        {
            SetLessonType();
            IsVisited = true;
            _schoolTask.AddValue(1);
            GetRandomNumber();
        }
        else
            SetLessonType();
    }

    public void UnVisitLesson()
    {
        IsVisited = false;
    }

    public void StopEffects()
    {
        _schoolTask.BoringTopic.StopEffect();
        _schoolTask.DifficultTopic.StopEffect();
        _schoolTask.EasyTopic.StopEffect();
        _schoolTask.InterestingTopic.StopEffect();
    }

    public void SetLessonType()
    {
        if (_lessonTypeNumber < 6)
        {
            if (!IsVisited)
                _schoolTask.DifficultTopic.MakeEffect();

            AlertController.Alerts.ShowAlert(_schoolTask.DifficultAlert);
            Debug.Log("+");
        }
        else if (_lessonTypeNumber >= 6 && _lessonTypeNumber < 11)
        {
            if (!IsVisited)
                _schoolTask.BoringTopic.MakeEffect();

            AlertController.Alerts.ShowAlert(_schoolTask.BoringAlert);
            Debug.Log("+");
        }
        else if (_lessonTypeNumber >= 11 && _lessonTypeNumber < 16)
        {
            //No effect
        }
        else if (_lessonTypeNumber >= 16 && _lessonTypeNumber < 19)
        {
            if (!IsVisited)
                _schoolTask.EasyTopic.MakeEffect();

            AlertController.Alerts.ShowAlert(_schoolTask.EasyAlert);
            Debug.Log("+");
        }
        else if (_lessonTypeNumber >= 19)
        {
            if (!IsVisited)
                _schoolTask.InterestingTopic.MakeEffect();

            AlertController.Alerts.ShowAlert(_schoolTask.InterestingAlert);
            Debug.Log("+");
        }
    }

    private void GetRandomNumber()
    {
        _lessonTypeNumber = Random.Range(1, 21);
    }
}