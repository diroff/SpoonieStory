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

    public void WaitTenSeconds()
    {
        _timeManagment.SpendTime(0, 10);
    }
}