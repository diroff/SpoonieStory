using System.Collections.Generic;
using UnityEngine;

public class AlertController : MonoBehaviour
{
    public Alert SpoonsLessFive;
    public Alert SpoonsLessTwo;

    public Alert HungerLessThirty;
    public Alert HungerLessTen;

    public Alert HygieneLessThirty;
    public Alert HygieneLessTen;

    public static AlertController Alerts;

    [SerializeField] private Parameter _spoons;
    [SerializeField] private Parameter _hunger;
    [SerializeField] private Parameter _hygiene;

    private void Awake()
    {
        Alerts = this;
    }

    private List<Alert> _alerts = new List<Alert>();

    public void ShowAlert(Alert alertPrefab)
    {
        Alert alert = Instantiate(alertPrefab, gameObject.transform);
        _alerts.Add(alert);
    }

    public void RemoveFlashingAlerts()
    {
        if (_alerts.Count == 0)
            return;

        for (int i = 0; i < _alerts.Count; i++)
        {
            if (_alerts[i].Type == Alert.AlertType.Flashing)
            {
                Destroy(_alerts[i].gameObject);
                _alerts.RemoveAt(i);
                RemoveFlashingAlerts();
                return;
            }
        }
    }

    public void RemoveStickyAlerts()
    {
        if (_alerts.Count == 0)
            return;

        for (int i = 0; i < _alerts.Count; i++)
        {
            if (_alerts[i].Type == Alert.AlertType.Sticky)
            {
                Destroy(_alerts[i].gameObject);
                _alerts.RemoveAt(i);
                RemoveStickyAlerts();
                return;
            }
        }
    }

    public void CheckParamsAlerts()
    {
        RemoveStickyAlerts();

        if (_spoons.CurrentValue <= 5 && _spoons.CurrentValue > 2)
            ShowAlert(SpoonsLessFive);
        else if (_spoons.CurrentValue <= 2)
            ShowAlert(SpoonsLessTwo);

        if (_hunger.CurrentValue <= 30 && _hunger.CurrentValue > 10)
            ShowAlert(HungerLessThirty);
        else if (_hunger.CurrentValue <= 10)
            ShowAlert(HungerLessTen);

        if (_hygiene.CurrentValue <= 30 && _hygiene.CurrentValue > 10)
            ShowAlert(HygieneLessThirty);
        else if (_hygiene.CurrentValue <= 10)
            ShowAlert(HygieneLessTen);
    }
}