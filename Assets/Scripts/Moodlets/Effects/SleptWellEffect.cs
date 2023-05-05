using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleptWellEffect : Effect
{
    public override void MakeEffect()
    {
        HoursStarted = TimeManagment.CurrentHours;
        MinutesStarted = TimeManagment.CurrentMinutes;

        Emotions.ChangeExcited(1);
        Emotions.ChangeAttentive(1);
        EffectStarted = true;
        CountOfEffects += 1;

        Debug.Log("SleptWell started!");
    }

    public override void StopEffect()
    {
        if (!EffectStarted)
            return;

        Emotions.ChangeExcited(-1 * CountOfEffects);
        Emotions.ChangeAttentive(-1 * CountOfEffects);
        EffectStarted = false;
        CountOfEffects = 0;

        Debug.Log("SleptWell ended!");
    }
}
