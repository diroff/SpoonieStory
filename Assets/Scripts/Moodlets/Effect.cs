using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    public string Name;
    public EmotionController Emotions;
    public TimeManagment TimeManagment;

    [Header("Emotion Cost")]
    public int SadCost;
    public int FrustratedCost;
    public int BoredCost;
    public int ExcitedCost;
    public int AttentiveCost;
    
    protected int CurrentSadCost;
    protected int CurrentFrustratedCost;
    protected int CurrentBoredCost;
    protected int CurrentExcitedCost;
    protected int CurrentAttentiveCost;

    private void Awake()
    {
        CurrentSadCost = SadCost / 2;
        CurrentFrustratedCost = FrustratedCost / 2;
        CurrentBoredCost = BoredCost / 2;
        CurrentExcitedCost = ExcitedCost / 2;
        CurrentAttentiveCost = AttentiveCost / 2;
    }

    [Space]
    public int HoursLasts;
    [Space]
    public int CountOfEffects = 0;
    public int HoursStarted;
    public int MinutesStarted;

    public bool EffectStarted;

    public void CheckTimeLeft()
    {
        //22:34 Lasts - 4 hours
        int hoursFinished = HoursStarted + HoursLasts; //02:34

        if (hoursFinished > 23) //26:34
            hoursFinished = hoursFinished - 24;

        if (TimeManagment.CurrentHours > hoursFinished)
        {
            StopEffect();
        }
        if (hoursFinished == TimeManagment.CurrentHours)
        {
            if (TimeManagment.CurrentMinutes >= MinutesStarted)
            {
                StopEffect();
            }
        }
    }

    public abstract void MakeEffect();
    public abstract void StopEffect();
}