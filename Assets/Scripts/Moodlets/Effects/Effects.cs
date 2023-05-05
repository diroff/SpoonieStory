using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    [SerializeField] private List<Effect> _effects;

    [Header("Sleep effects")]
    public SleepEffect NightmareEffect;
    public SleepEffect InsomniaEffect;
    public SleepEffect SleptWellEffect;

    public void CheckEffectTimes()
    {
        foreach (Effect effect in _effects)
        {
            effect.CheckTimeLeft();
        }
    }
}
