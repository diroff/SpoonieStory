using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    [SerializeField] private List<Effect> _effects;

    public NightmareEffect NightmareEffect;

    public void CheckEffectTimes()
    {
        foreach (Effect effect in _effects)
        {
            effect.CheckTimeLeft();
        }
    }
}
