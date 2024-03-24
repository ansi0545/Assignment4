using System;
using System.Linq;
using System.Windows.Forms;

namespace Assignment_AB
{
    internal class Recipe
    {
        private string _name;
        private string _instructions;
        private FoodCategory _category;
        private string[] _ingredients;
        private readonly int _maxIngredients;

        public Recipe(int maxIngredients)
        {
            _maxIngredients = maxIngredients;
            _ingredients = new string[maxIngredients];
        }

        public string Name
        {
            get => _name;
            set => _name = !string.IsNullOrEmpty(value) ? value : throw new ArgumentNullException(nameof(value), "Recipe name cannot be null or empty.");
        }

        public string Instructions
        {
            get => _instructions;
            set => _instructions = !string.IsNullOrEmpty(value) ? value : throw new ArgumentNullException(nameof(value), "Instructions cannot be null or empty.");
        }

        public FoodCategory Category
        {
            get => _category;
            set => _category = value;
        }

        public void AddIngredient(string ingredient)
        {
            for (int i = 0; i < _maxIngredients; i++)
            {
                if (_ingredients[i] == null)
                {
                    _ingredients[i] = ingredient;
                    break;
                }
            }
        }

        public void ChangeIngredient(int index, string newIngredient)
        {
            if (index >= 0 && index < _maxIngredients)
            {
                _ingredients[index] = newIngredient;
            }
        }

        public void RemoveIngredient(int index)
        {
            if (index >= 0 && index < _maxIngredients)
            {
                // Shift all elements down by one
                for (int i = index; i < _maxIngredients - 1; i++)
                {
                    _ingredients[i] = _ingredients[i + 1];
                }

                // Clear the last element
                _ingredients[_maxIngredients - 1] = null;
            }
        }

        public string[] GetIngredients()
        {
            return _ingredients;
        }
    }
}
