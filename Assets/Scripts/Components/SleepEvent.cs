using UnityEngine;

public class SleepEvent : MonoBehaviour
{
    [SerializeField] private Parameter _spoons;

    public void CalculateSpoonsCount(int sleptHours)
    {
        _spoons.AddValue(sleptHours);
        Debug.Log("Slept hours:" + sleptHours);

        int bonus = CalculateAdditionalSpoons();

        _spoons.AddValue(bonus);
        Debug.Log("Slept bonus:" + bonus);
    }

    private int CalculateAdditionalSpoons()
    {
        int randomValue = Random.Range(0, 21);

        if (randomValue >= 0 && randomValue <= 4)
            return -3;

        if (randomValue >= 5 && randomValue <= 11)
            return -2;

        if (randomValue >= 12 && randomValue <= 18)
            return 0;

        if (randomValue >= 19 && randomValue <= 20)
            return 2;

        return 0;
    }
}