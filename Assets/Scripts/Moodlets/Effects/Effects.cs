using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    [SerializeField] private List<Effect> _effects;

    [Header("Sleep effects")]
    public TimedEffect NightmareEffect;
    public TimedEffect InsomniaEffect;
    public TimedEffect SleptWellEffect;
    public TimedEffect EatingEffect;

    public void CheckEffectTimes()
    {
        foreach (Effect effect in _effects)
        {
            effect.CheckTimeLeft();
        }
    }
}
