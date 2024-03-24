using System;

namespace Assignment_AB
{
    internal class RecipeManager
    {
        private readonly Recipe[] _recipes;
        private int _numOfElems = 0;

        public RecipeManager(int maxRecipes)
        {
            _recipes = new Recipe[maxRecipes];
        }

        public bool AddRecipe(Recipe recipe)
        {
            if (_numOfElems < _recipes.Length && recipe != null)
            {
                _recipes[_numOfElems] = recipe;
                _numOfElems++;
                return true;
            }
            return false;
        }

        public bool EditRecipe(int index, Recipe recipe)
        {
            if (index >= 0 && index < _recipes.Length && recipe != null)
            {
                _recipes[index] = recipe;
                return true;
            }
            return false;
        }

        public Recipe GetRecipe(int index)
        {
            if (index >= 0 && index < _numOfElems)
            {
                return _recipes[index] ?? throw new Exception("No recipe at this index");
            }
            throw new IndexOutOfRangeException("Index is out of range");
        }

        public bool RemoveRecipe(int index)
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

        private void MoveElementsOneStepToLeft(int index)
        {
            for (int i = index; i < _numOfElems; i++)
            {
                _recipes[i] = _recipes[i + 1];
            }
            _recipes[_numOfElems] = null;
        }

        public Recipe[] GetRecipes()
        {
            return _recipes;
        }
    }
}
