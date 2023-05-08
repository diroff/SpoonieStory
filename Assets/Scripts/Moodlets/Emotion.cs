using System.Collections.Generic;
using UnityEngine;

public class Emotion : MonoBehaviour
{
    public int CurrentValue;
    public int StartValue;
    public Sprite Icon;
    public string Name;

    public List<Emotion> UnCompatibilityEmotions;

    public bool IsActive = false;

    private void Awake()
    {
        CurrentValue = StartValue;
    }

    public void ChangeValue(int value)
    {
        CurrentValue += value;
    }

    public bool MoodletChecker()
    {
        if (CurrentValue <= 0)
            return false;
        else
            return true;
    }
}