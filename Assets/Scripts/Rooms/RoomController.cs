using UnityEngine;
using UnityEngine.UI;

public class RoomController : MonoBehaviour
{
    [SerializeField] private Room _startRoom;
    [SerializeField] private Room _phone;

    [SerializeField] private Button _roomButton;

    private Room _currentRoom;
    private Room _nextRoom;

    private void Start()
    {
        _currentRoom = _startRoom;
        OpenRoom(_currentRoom);
    }

    public void OpenRoom(Room room)
    {
        _currentRoom.SetRoomState(false);
        _nextRoom = room;
        _nextRoom.SetPreviousRoom(_currentRoom);
        _nextRoom.SetRoomState(true);
        _currentRoom = _nextRoom;
        AlertController.Alerts.CheckParamsAlerts();
        SetPhoneButtonState();
    }

    public void CloseRoom()
    {
        _currentRoom.SetRoomState(false);
        _nextRoom = _currentRoom.PreviousRoom;
        _nextRoom.SetRoomState(true);
        _currentRoom = _nextRoom;
        AlertController.Alerts.CheckParamsAlerts();
        SetPhoneButtonState();
    }

    private void SetPhoneButtonState()
    {
        if (_currentRoom == _phone)
            _roomButton.interactable = false;
        else
            _roomButton.interactable = true;
    }
}