using Microsoft.EntityFrameworkCore;
using Project0.DataAccess;
using Project0.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library.Control.Model
{
    public class IngredientController
    {
        IngredientRepository repository = null;

        public IngredientController()
        {
            repository = new IngredientRepository(DbOptions.Context);
        }

        public List<Ingredients> getAll()
        {
            return (List<Ingredients>)repository.GetAll();
        }
    }
}
