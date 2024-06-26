﻿namespace Assignment_AB
{
    internal class RecipeManager
    {
        private readonly Recipe[] _recipes;
        private int _numOfElems = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeManager"/> class with the specified maximum number of recipes.
        /// </summary>
        /// <param name="maxRecipes">The maximum number of recipes that can be stored.</param>
        public RecipeManager(int maxRecipes)
        {
            _recipes = new Recipe[maxRecipes];
        }

        /// <summary>
        /// Adds a recipe to the recipe manager.
        /// </summary>
        /// <param name="recipe">The recipe to be added.</param>
        /// <returns>True if the recipe was successfully added, otherwise false.</returns>
        public bool AddRecipe(Recipe recipe)
        {
            if (_numOfElems >= _recipes.Length)
            {
                throw new InvalidOperationException("Cannot add more recipes. Maximum limit reached.");
            }
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe), "Recipe cannot be null.");
            }
            _recipes[_numOfElems] = recipe;
            _numOfElems++;
            return true;
        }
        
        /// <summary>
        /// Edits a recipe at the specified index in the recipe manager.
        /// </summary>
        /// <param name="index">The index of the recipe to edit.</param>
        /// <param name="recipe">The updated recipe.</param>
        /// <returns>True if the recipe was successfully edited, false otherwise.</returns>
        public bool EditRecipe(int index, Recipe recipe)
        {
            if (index >= 0 && index < _recipes.Length && recipe != null)
            {
                _recipes[index] = recipe;
                return true;
            }
            return false;
        }


        /// <summary>
        /// Retrieves the recipe at the specified index.
        /// </summary>
        /// <param name="index">The index of the recipe to retrieve.</param>
        /// <returns>The recipe at the specified index.</returns>
        public Recipe GetRecipe(int index)
        {
            if (index < 0 || index >= _numOfElems)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
            }

            var recipe = _recipes[index];
            if (recipe == null)
            {
                throw new InvalidOperationException("No recipe at this index");
            }

            return recipe;
        }

        /// <summary>
        /// Removes a recipe at the specified index from the recipe manager.
        /// </summary>
        /// <param name="index">The index of the recipe to remove.</param>
        /// <returns>True if the recipe was successfully removed, false otherwise.</returns>
        public bool RemoveRecipe(int index)
        {
            try
            {
                if (index >= 0 && index < _numOfElems)
                {
                    _recipes[index] = null;
                    _numOfElems--;
                    MoveElementsOneStepToLeft(index);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while removing recipe: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Moves the elements in the recipe array one step to the left starting from the specified index.
        /// </summary>
        /// <param name="index">The starting index from which the elements should be moved.</param>
        private void MoveElementsOneStepToLeft(int index)
        {
            for (int i = index; i < _numOfElems; i++)
            {
                _recipes[i] = _recipes[i + 1];
            }
            _recipes[_numOfElems] = null;
        }

        
        /// <summary>
        /// Retrieves an array of recipes.
        /// </summary>
        /// <returns>An array of Recipe objects.</returns>
        public Recipe[] GetRecipes()
        {
            /// <summary>
            /// Creates a copy of the Recipe array. This method ensures that the internal array is not exposed directly to external code. Instead, a copy of the array is returned.
            /// </summary>
            /// <remarks>
            /// The copy array will have the same number of elements as the original array.
            /// </remarks>
            Recipe[] copy = new Recipe[_numOfElems];
            Array.Copy(_recipes, copy, _numOfElems);
            return copy;
        }
    }
}
