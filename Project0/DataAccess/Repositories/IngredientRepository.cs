using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.DataAccess.Repositories
{
    public class IngredientRepository : ARepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="db">Project0Context</param>
        public IngredientRepository(Project0Context db) : base(db) { }

        public override void Delete(int id)
        {
            Ingredients tracked = Db.Ingredients.Find(id);
            if (tracked == null)
            {
                throw new ArgumentException("No Ingredient with this id", nameof(id));
            }
            Db.Remove(tracked);
        }

        public override IList GetAll()
        {
            return (List<Ingredients>) Db.Ingredients.AsNoTracking().ToList();
        }

        public override AModel GetById(int id)
        {
            return Db.Ingredients.Find(id);
        }

        public override AModel GetByName(string name)
        {
            return Db.Ingredients.FirstOrDefault(model => model.Name == name);
        }

        protected override AModel Create(AModel model)
        {
            Db.Add((Ingredients)model);

            return (Ingredients)model;
        }

        protected override AModel Update(AModel model, int? id = null)
        {
            if (id == null)
            {
                throw new ArgumentException("Nedded id", nameof(id));
            }

            Ingredients tracked = Db.Ingredients.Find(id);
            if (tracked == null)
            {
                throw new ArgumentException("No Ingredient with this id", nameof(id));
            }

            Db.Entry(tracked).CurrentValues.SetValues(model);

            return (Ingredients)model;
        }
    }
}
