using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    public string Name;
    public EmotionController Emotions;
    public TimeManagment TimeManagment;

    public int CountOfEffects = 0;

    public int HoursLasts;

    public int HoursStarted;
    public int MinutesStarted;

    public bool EffectStarted;

    public void CheckTimeLeft()
    {
        //22:34 Lasts - 4 hours
        int hoursFinished = HoursStarted + HoursLasts; //02:34

        if (hoursFinished > 23) //26:34
            hoursFinished = hoursFinished - 24;

        if(TimeManagment.CurrentHours > hoursFinished)
        {
            StopEffect();
        }
        if(hoursFinished == TimeManagment.CurrentHours) 
        { 
            if(TimeManagment.CurrentMinutes >= MinutesStarted)
            {
                StopEffect();
            }
        }
    }

    public abstract void MakeEffect();
    public abstract void StopEffect();
}