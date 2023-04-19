using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Actions _roomActions;
    [SerializeField] private GameObject _room;

    private Room _previousRoom;

    public Room PreviousRoom => _previousRoom;

    public void SetRoomState(bool open)
    {
        _room.SetActive(open);
    }

    public void SetPreviousRoom(Room room)
    {
        _previousRoom = room;
    }
}
