using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.DataAccess.Repositories
{
    public class CustomerRepository : ARepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="db">Project0Context</param>
        public CustomerRepository(Project0Context db) : base(db) { }

        public override void Delete(int id)
        {
            Customers tracked = Db.Customers.Find(id);
            if (tracked == null)
            {
                throw new ArgumentException("No Customer with this id", nameof(id));
            }
            Db.Remove(tracked);
        }

        public override IList GetAll()
        {
            return (List<Customers>)Db.Customers.AsNoTracking().ToList();
        }

        public IList GetAllWithAddress()
        {
            return (List<Customers>)Db.Customers.Include(m => m.Addresses).AsNoTracking().ToList();
        }

        public override AModel GetById(int id)
        {
            return Db.Customers.Find(id);
        }

        public override IList GetByName(string name)
        {
            return (List<Customers>)Db.Customers.Where(model => model.FirstName.Contains(name) || model.LastName.Contains(name)).ToList();
        }

        protected override AModel Create(AModel model)
        {
            Db.Add((Customers)model);

            return (Customers)model;
        }

        protected override AModel Update(AModel model, int? id = null)
        {
            if (id == null)
            {
                throw new ArgumentException("Nedded id", nameof(id));
            }

            Customers tracked = Db.Customers.Find(id);
            if (tracked == null)
            {
                throw new ArgumentException("No Customer with this id", nameof(id));
            }

            Db.Entry(tracked).CurrentValues.SetValues(model);

            return (Customers)model;
        }
    }
}
