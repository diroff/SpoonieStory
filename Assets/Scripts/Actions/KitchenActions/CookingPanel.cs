using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CookingPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _timeCookCost;
    [SerializeField] private TextMeshProUGUI _timeEatCost;
    [SerializeField] private TextMeshProUGUI _hunger;
    [SerializeField] private TextMeshProUGUI _count;

    [SerializeField] private List<FoodRecipe> _foodRecipes;
    [SerializeField] private CookingAction _cookingAction;
    [SerializeField] private EatAction _eatAction;
    [SerializeField] private Actions _actions;

    private FoodRecipe _currentRecipe;

    public FoodRecipe CurrentRecipe => _currentRecipe;
    public List<FoodRecipe> FoodRecipes => _foodRecipes;

    private void Awake()
    {
        SetRecipe(_foodRecipes[0]);
    }

    private void OnEnable()
    {
        SetRecipe(_foodRecipes[0]);
        _currentRecipe.CountChanged.AddListener(UpdateFoodCount);
    }

    private void OnDisable()
    {
        _currentRecipe.CountChanged.RemoveListener(UpdateFoodCount);
    }

    public void SetRecipe(FoodRecipe recipe)
    {
        _currentRecipe = recipe;

        _name.text = _currentRecipe.Name;
        _description.text = _currentRecipe.Description;
        _timeCookCost.text = "Time cooking:" + _currentRecipe.TimeCooking + " min";
        _timeEatCost.text = "Time eating:" + _currentRecipe.TimeEating + " min";
        _hunger.text = "Hunger:" + _currentRecipe.Hunger;
        UpdateFoodCount(_currentRecipe.FoodCount);
        _cookingAction.SetCost(_currentRecipe);
        _eatAction.SetCost(_currentRecipe);
        _actions.CheckActionsState();
        SetButtonsColor();
    }

    public void SetButtonsColor()
    {
        for (int i = 0; i < _foodRecipes.Count; i++)
        {
            _foodRecipes[i].SetButtonColor();
        }
    }

    public void UpdateFoodCount(int count)
    {
        _count.text = "Count:" + count;
    }
}