using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class EmotionController : MonoBehaviour
{
    public Emotion Sad;
    public Emotion Frustrated;
    public Emotion Bored;
    public Emotion Excited;
    public Emotion Attentive;

    [SerializeField] private List<Emotion> _emotions; 

    [SerializeField] private TextMeshProUGUI _sadValue;
    [SerializeField] private TextMeshProUGUI _frustratedValue;
    [SerializeField] private TextMeshProUGUI _boredValue;
    [SerializeField] private TextMeshProUGUI _excitedValue;
    [SerializeField] private TextMeshProUGUI _attentiveValue;

    [SerializeField] private TextMeshProUGUI _moodletFirstText;
    [SerializeField] private TextMeshProUGUI _moodletSecondText;

    private List<Emotion> _moodlets = new List<Emotion>();

    private void Start()
    {
        MoodletChecker();
    }

    public void MoodletChecker()
    {
        _moodlets.Clear();

        foreach (Emotion emotion in _emotions)
        {
            emotion.IsActive = false;

            if (emotion.MoodletChecker())
                _moodlets.Add(emotion);
        }

        var list = _moodlets.OrderByDescending(m => m.CurrentValue).ToList();

        _moodlets.Clear();
        _moodlets = list;

        if (_moodlets.Count == 0)
        {
            _moodletFirstText.text = "Calm";
            _moodletSecondText.text = "Empty";
        }
        else if (_moodlets.Count == 1)
        {
            _moodletFirstText.text = _moodlets[0].Name;
            _moodlets[0].IsActive = true;
            _moodletSecondText.text = "Empty";
        }
        else if(_moodlets.Count == 2)
        {
            _moodletFirstText.text = _moodlets[0].Name;
            _moodlets[0].IsActive = true;

            if (!_moodlets[0].UnCompatibilityEmotions.Contains(_moodlets[1]))
            {
                _moodletSecondText.text = _moodlets[1].Name;
                _moodlets[1].IsActive = true;
            }
            else
                _moodletSecondText.text = "Empty";
        }
        else
        {
            Debug.Log("More than 2 moodlets");

            _moodletFirstText.text = _moodlets[0].Name;
            _moodlets[0].IsActive = true;

            for (int i = 1; i < _moodlets.Count; i++)
            {
                if (!_moodlets[0].UnCompatibilityEmotions.Contains(_moodlets[i]))
                {
                    _moodletSecondText.text = _moodlets[i].Name;
                    _moodlets[i].IsActive = true;
                    break;
                }
                else
                {
                    Debug.Log(_moodlets[i].Name + " can't be with " + _moodlets[0].Name + "!");
                    _moodletSecondText.text = "Empty";
                }
            }
        }
    }

    private void Update()
    {
        _sadValue.text = "Sad:" + Sad.CurrentValue;
        _frustratedValue.text = "Frustrated:" + Frustrated.CurrentValue;
        _boredValue.text = "Bored:" + Bored.CurrentValue;
        _excitedValue.text = "Excited:" + Excited.CurrentValue;
        _attentiveValue.text = "Attentive:" + Attentive.CurrentValue;
    }

    public void ChangeSad(int value)
    {
        Sad.ChangeValue(value);
        MoodletChecker();
    }

    public void ChangeFrustrated(int value)
    {
        Frustrated.ChangeValue(value);
        MoodletChecker();
    }

    public void ChangeBored(int value)
    {
        Bored.ChangeValue(value);
        MoodletChecker();
    }

    public void ChangeExcited(int value)
    {
        Excited.ChangeValue(value);
        MoodletChecker();
    }

    public void ChangeAttentive(int value)
    {
        Attentive.ChangeValue(value);
        MoodletChecker();
    }

    public void ShowEmotionsLevel()
    {
        Debug.Log("Sad:" + Sad);
        Debug.Log("Frustrated:" + Frustrated);
        Debug.Log("Bored:" + Bored);
        Debug.Log("Excited:" + Excited);
        Debug.Log("Attentive:" + Attentive);
    }
}