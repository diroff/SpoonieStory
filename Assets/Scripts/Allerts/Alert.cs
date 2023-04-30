using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Alert : MonoBehaviour
{
    [SerializeField] private AlertType _type;

    public AlertType Type => _type;

    public enum AlertType
    {
        Flashing,
        Sticky,
    }
}
