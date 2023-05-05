using UnityEngine;

public class Emotion : MonoBehaviour
{
    public int CurrentValue;
    public int StartValue;
    public string Name;

    private void Awake()
    {
        CurrentValue = StartValue;
    }

    public void ChangeValue(int value)
    {
        CurrentValue += value;
    }
}