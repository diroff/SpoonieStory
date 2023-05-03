using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FoodRecipe : MonoBehaviour
{
    public string Name;
    public string Description;
    public int TimeCooking;
    public int TimeEating;
    public int Hunger;

    public int FoodCount = 0;

    public int SpoonsCost;
    public int HungerCost;
    public int HygieneCost;

    public Button RecipeButton;

    private Color _color;

    private void Awake()
    {
        RecipeButton = GetComponent<Button>();
        ColorUtility.TryParseHtmlString("#ECFDB2", out _color);
    }

    public UnityEvent<int> CountChanged;

    private void Start()
    {
        CountChanged?.Invoke(FoodCount);
    }

    public void SetButtonColor()
    {
        if (FoodCount > 0)
            RecipeButton.image.color = _color;
        else
            RecipeButton.image.color = Color.white;
    }

    public void ChangeFoodCount(int value)
    {
        FoodCount += value;
        CountChanged?.Invoke(FoodCount);

        if(FoodCount < 0)
            FoodCount = 0;
    }
}