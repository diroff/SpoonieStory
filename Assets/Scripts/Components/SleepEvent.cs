using UnityEngine;

public class SleepEvent : MonoBehaviour
{
    [SerializeField] private Parameter _spoons;

    [SerializeField] private Alert _insomniaAlert;
    [SerializeField] private Alert _nightmareAlert;
    [SerializeField] private Alert _neutralAlert;
    [SerializeField] private Alert _refreshAlert;
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
        {
            AlertController.Alerts.ShowAlert(_insomniaAlert);
            return -3;
        }

        if (randomValue >= 5 && randomValue <= 11)
        {
            AlertController.Alerts.ShowAlert(_nightmareAlert);
            return -2;
        }

        if (randomValue >= 12 && randomValue <= 18)
        {
            AlertController.Alerts.ShowAlert(_neutralAlert);
            return 0;
        }

        if (randomValue >= 19 && randomValue <= 20)
        {
            AlertController.Alerts.ShowAlert(_refreshAlert);
            return 2;
        }

        return 0;
    }
}