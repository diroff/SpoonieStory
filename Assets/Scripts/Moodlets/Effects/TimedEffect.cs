using UnityEngine;

public class TimedEffect : Effect
{
    public override void MakeEffect()
    {
        HoursStarted = TimeManagment.CurrentHours;
        MinutesStarted = TimeManagment.CurrentMinutes;

        if (!EffectStarted)
        {
            Emotions.ChangeSad(SadCost);
            Emotions.ChangeFrustrated(FrustratedCost);
            Emotions.ChangeBored(BoredCost);
            Emotions.ChangeExcited(ExcitedCost);
            Emotions.ChangeAttentive(AttentiveCost);
        }
        else
        {
            Emotions.ChangeSad(CurrentSadCost);
            Emotions.ChangeFrustrated(CurrentFrustratedCost);
            Emotions.ChangeBored(CurrentBoredCost);
            Emotions.ChangeExcited(CurrentExcitedCost);
            Emotions.ChangeAttentive(CurrentAttentiveCost);
        }

        EffectStarted = true;
        CountOfEffects += 1;

        Debug.Log(Name + " started!");
    }

    public override void StopEffect()
    {
        if (!EffectStarted)
            return;

        Emotions.ChangeSad(-SadCost);
        Emotions.ChangeFrustrated(-FrustratedCost);
        Emotions.ChangeBored(-BoredCost);
        Emotions.ChangeExcited(-ExcitedCost);
        Emotions.ChangeAttentive(-AttentiveCost);

        Emotions.ChangeSad(-((CountOfEffects - 1) * CurrentSadCost));
        Emotions.ChangeFrustrated(-((CountOfEffects - 1) * CurrentFrustratedCost));
        Emotions.ChangeBored(-((CountOfEffects - 1) * CurrentBoredCost));
        Emotions.ChangeExcited(-((CountOfEffects - 1) * CurrentExcitedCost));
        Emotions.ChangeAttentive(-((CountOfEffects - 1) * CurrentAttentiveCost));

        EffectStarted = false;
        CountOfEffects = 0;

        Debug.Log(Name + " ended!");
    }
}
