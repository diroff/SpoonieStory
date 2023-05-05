public class StickyEffect : Effect
{
    public override void MakeEffect()
    {
        if (EffectStarted)
            return;

        Emotions.ChangeSad(SadCost);
        Emotions.ChangeFrustrated(FrustratedCost);
        Emotions.ChangeBored(BoredCost);
        Emotions.ChangeExcited(ExcitedCost);
        Emotions.ChangeAttentive(AttentiveCost);

        EffectStarted = true;
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

        EffectStarted = false;
    }
}