using UnityEngine;
using UnityEngine.Events;

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

    public UnityEvent<int> CountChanged;

    private void Start()
    {
        CountChanged?.Invoke(FoodCount);
    }

    public void ChangeFoodCount(int value)
    {
        FoodCount += value;
        CountChanged?.Invoke(FoodCount);

        if(FoodCount < 0)
            FoodCount = 0;
    }
}