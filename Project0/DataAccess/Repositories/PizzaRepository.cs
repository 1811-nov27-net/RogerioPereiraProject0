﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.DataAccess.Repositories
{
    public class PizzaRepository : ARepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="db">Project0Context</param>
        public PizzaRepository(Project0Context db) : base(db) { }

        public override void Delete(int id)
        {
            Pizzas tracked = Db.Pizzas.Find(id);
            if (tracked == null)
            {
                throw new ArgumentException("No Pizza with this id", nameof(id));
            }
            Db.Remove(tracked);
        }

        public override IList GetAll()
        {
            return (List<Pizzas>) Db.Pizzas.AsNoTracking().ToList();
        }

        public IList GetAllWithIngredients()
        {
            return (List<Pizzas>)Db.Pizzas
                    .Include(pizza => pizza.PizzasIngredients)
                    .ThenInclude(pizzasIngredients => pizzasIngredients.Ingredient)
                    .AsNoTracking()
                    .ToList();
        }

        public override AModel GetById(int id)
        {
            return Db.Pizzas
                    .Include(pizza => pizza.PizzasIngredients)
                    .ThenInclude(pizzasIngredients => pizzasIngredients.Ingredient)
                    .Where(model => model.Id == id)
                    .ToList()
                    .First();
        }

        public override IList GetByName(string name)
        {
            return (List<Pizzas>)Db.Pizzas
                    .Include(pizza => pizza.PizzasIngredients)
                    .ThenInclude(pizzasIngredients => pizzasIngredients.Ingredient)
                    .Where(model => model.Name.Contains(name))
                    .ToList();
        }

        protected override AModel Create(AModel model)
        {
            Db.Add((Pizzas)model);

            return (Pizzas)model;
        }

        protected override AModel Update(AModel model, int? id = null)
        {
            if (id == null)
            {
                throw new ArgumentException("Nedded id", nameof(id));
            }

            Pizzas tracked = Db.Pizzas.Find(id);
            if (tracked == null)
            {
                throw new ArgumentException("No Pizza with this id", nameof(id));
            }

            Db.Entry(tracked).CurrentValues.SetValues(model);

            return (Pizzas)model;
        }
    }
}