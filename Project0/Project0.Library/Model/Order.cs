using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library.Model
{
    /// <summary>
    /// Ingrendients Model
    /// </summary>
    public class Order : AModelBase
    {
        /// <summary>
        /// AModelBase function
        /// </summary>
        /// <returns>Model Name</returns>
        protected override string GetModelName()
        {
            return "Order";
        }

        public int Id { get; set; }
        public int CostumerId { get; set; }
        public int AddressId { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public double Value { get; set; }
        public DateTime date { get; set; }
    }
}
