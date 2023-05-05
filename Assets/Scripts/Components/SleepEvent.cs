using UnityEngine;

public class SleepEvent : MonoBehaviour
{
    [SerializeField] private Parameter _spoons;

    [SerializeField] private Alert _insomniaAlert;
    [SerializeField] private Alert _nightmareAlert;
    [SerializeField] private Alert _neutralAlert;
    [SerializeField] private Alert _refreshAlert;

    [SerializeField] private Effects _effects;

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

        if (randomValue < 4)
        {
            AlertController.Alerts.ShowAlert(_insomniaAlert);
            _effects.InsomniaEffect.MakeEffect();
            return -3;
        }

        if (randomValue >= 4 && randomValue < 9)
        {
            AlertController.Alerts.ShowAlert(_nightmareAlert);
            _effects.NightmareEffect.MakeEffect();
            return -2;
        }

        if (randomValue >= 9 && randomValue < 19)
        {
            AlertController.Alerts.ShowAlert(_neutralAlert);
            return 0;
        }

        if (randomValue >= 19)
        {
            AlertController.Alerts.ShowAlert(_refreshAlert);
            _effects.SleptWellEffect.MakeEffect();
            return 2;
        }

        return 0;
    }
}