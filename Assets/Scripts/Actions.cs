using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    [SerializeField] private List<SimpleAction> _roomActions;

    private void OnEnable()
    {
        //CheckActionsState();
    }

    public void CheckActionsState()
    {
        foreach (SimpleAction action in _roomActions)
            action.SetButtonInteractable();
    }
}
