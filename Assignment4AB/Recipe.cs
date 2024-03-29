

namespace Assignment_AB
{
    internal class Recipe
    {
        /// <summary>
        /// Represents a recipe with a name, instructions, category, and ingredients.
        /// </summary>
        private string _name;
        private string _instructions;
        private FoodCategory _category;
        private string[] _ingredients;
        private readonly int _maxIngredients;

        /// <summary>
        /// Initializes a new instance of the <see cref="Recipe"/> class with the specified maximum number of ingredients.
        /// </summary>
        /// <param name="maxIngredients">The maximum number of ingredients that the recipe can have.</param>
        public Recipe(int maxIngredients)
        {
            _maxIngredients = maxIngredients;
            _ingredients = new string[maxIngredients];
        }

        /// <summary>
        /// Gets or sets the name of the recipe.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "Recipe name cannot be null or empty.");
                }
                _name = value;
            }
        }

        /// <summary>
        /// Gets or sets the instructions for preparing the recipe.
        /// </summary>
        public string Instructions
        {
            get => _instructions;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "Instructions cannot be null or empty.");
                }
                _instructions = value;
            }
        }

        /// <summary>
        /// Gets or sets the category of the recipe.
        /// </summary>
        public FoodCategory Category
        {
            get => _category;
            set => _category = value;
        }


        /// <summary>
        /// Adds an ingredient to the recipe.
        /// </summary>
        /// <param name="ingredient">The ingredient to add.</param>
        public void AddIngredient(string ingredient)
        {
            int i;
            for (i = 0; i < _maxIngredients; i++)
            {
                if (_ingredients[i] == null)
                {
                    _ingredients[i] = ingredient;
                    break;
                }
            }
            if (i == _maxIngredients)
            {
                throw new InvalidOperationException("Cannot add more ingredients. Maximum limit reached.");
            }
        }

        /// <summary>
        /// Changes an ingredient at the specified index.
        /// </summary>
        /// <param name="index">The index of the ingredient to change.</param>
        /// <param name="newIngredient">The new ingredient to replace the existing one.</param>
        public void ChangeIngredient(int index, string newIngredient)
        {
            try
            {
                if (index >= 0 && index < _maxIngredients)
                {
                    _ingredients[index] = newIngredient;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Invalid index.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while changing ingredient: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Removes an ingredient at the specified index.
        /// </summary>
        /// <param name="index">The index of the ingredient to remove.</param>
        public void RemoveIngredient(int index)
        {
            try
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
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Invalid index.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while removing ingredient: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Gets the array of ingredients in the recipe.
        /// </summary>
        /// <returns>An array of ingredients.</returns>
        public string[] GetIngredients()
        {
            return _ingredients;
        }
    }
}
