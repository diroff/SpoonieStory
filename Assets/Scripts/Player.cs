using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string _name;
    [Header("Parameters")]
    [SerializeField] private Parameter _spoons;
    [SerializeField] private Parameter _hungry;
    [SerializeField] private Parameter _hygiene;
    [Space]
    [SerializeField] private TimeManagment _timeManagment;
    [SerializeField] private SleepEvent _sleepEvent;

    private void Start()
    {
        _sleepEvent.CalculateSpoonsCount();
    }
}