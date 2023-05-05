using UnityEngine;

public class NightmareEffect : Effect
{
    public override void MakeEffect()
    {
        HoursStarted = TimeManagment.CurrentHours;
        MinutesStarted = TimeManagment.CurrentMinutes;

        Emotions.ChangeSad(4);
        Emotions.ChangeFrustrated(2);
        Emotions.ChangeBored(-2);
        Emotions.ChangeExcited(-2);
        Emotions.ChangeAttentive(-4);
        EffectStarted = true;
        CountOfEffects += 1;

        Debug.Log("Nightmare started!");
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

        Debug.Log("Nightmare ended!");
    }
}