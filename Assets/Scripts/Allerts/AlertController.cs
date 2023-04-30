using System.Collections.Generic;
using UnityEngine;

public class AlertController : MonoBehaviour
{
    public static AlertController Alerts;

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
        if( _alerts.Count == 0 ) 
            return;

        for (int i = 0; i < _alerts.Count; i++)
        {
            if (_alerts[i].Type == Alert.AlertType.Flashing)
            {
                Destroy(_alerts[i].gameObject);
                _alerts.RemoveAt(i);
            }
        }
    }
}