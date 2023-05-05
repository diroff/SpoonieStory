using TMPro;
using UnityEngine;

public class EmotionController : MonoBehaviour
{
    public Emotion Sad;
    public Emotion Frustrated;
    public Emotion Bored;
    public Emotion Excited;
    public Emotion Attentive;

    [SerializeField] private TextMeshProUGUI _sadValue;
    [SerializeField] private TextMeshProUGUI _frustratedValue;
    [SerializeField] private TextMeshProUGUI _boredValue;
    [SerializeField] private TextMeshProUGUI _excitedValue;
    [SerializeField] private TextMeshProUGUI _attentiveValue;

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
    }

    public void ChangeFrustrated(int value)
    {
        Frustrated.ChangeValue(value);
    }

    public void ChangeBored(int value)
    {
        Bored.ChangeValue(value);
    }

    public void ChangeExcited(int value)
    {
        Excited.ChangeValue(value);
    }

    public void ChangeAttentive(int value)
    {
        Attentive.ChangeValue(value);
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