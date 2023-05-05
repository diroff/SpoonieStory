using UnityEngine;

public class NightmareEffect : Effect
{
    public override void MakeEffect()
    {
        HoursStarted = TimeManagment.CurrentHours;
        MinutesStarted = TimeManagment.CurrentMinutes;

        Emotions.ChangeSad(2);
        Emotions.ChangeFrustrated(1);
        Emotions.ChangeBored(-1);
        Emotions.ChangeExcited(-1);
        Emotions.ChangeAttentive(-2);
        EffectStarted = true;
        CountOfEffects += 1;

        Debug.Log("Effect started!");
    }

    public override void StopEffect()
    {
        if (!EffectStarted)
            return;

        Emotions.ChangeSad(-2 * CountOfEffects);
        Emotions.ChangeFrustrated(-1 * CountOfEffects);
        Emotions.ChangeBored(1 * CountOfEffects);
        Emotions.ChangeExcited(1 * CountOfEffects);
        Emotions.ChangeAttentive(2 * CountOfEffects);
        EffectStarted = false;
        CountOfEffects = 0;

        Debug.Log("Effect ended!");
    }
}