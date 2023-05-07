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
            GetRandomNumber();
            SetLessonType();
            IsVisited = true;
            _schoolTask.AddValue(1);
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
        }
        else if (_lessonTypeNumber >= 6 && _lessonTypeNumber < 11)
        {
            if (!IsVisited)
                _schoolTask.BoringTopic.MakeEffect();

            AlertController.Alerts.ShowAlert(_schoolTask.BoringAlert);
        }
        else if (_lessonTypeNumber >= 11 && _lessonTypeNumber < 16)
        {
            Debug.Log("No effects");
        }
        else if (_lessonTypeNumber >= 16 && _lessonTypeNumber < 19)
        {
            if (!IsVisited)
                _schoolTask.EasyTopic.MakeEffect();

            AlertController.Alerts.ShowAlert(_schoolTask.EasyAlert);
        }
        else if (_lessonTypeNumber >= 19)
        {
            if (!IsVisited)
                _schoolTask.InterestingTopic.MakeEffect();

            AlertController.Alerts.ShowAlert(_schoolTask.InterestingAlert);
        }
    }

    private void GetRandomNumber()
    {
        _lessonTypeNumber = Random.Range(1, 21);
    }
}