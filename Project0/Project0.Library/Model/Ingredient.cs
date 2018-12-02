using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library.Model
{
    /// <summary>
    /// Ingrendients Model
    /// </summary>
    public class Ingredient : AModelBase
    {
        /// <summary>
        /// AModelBase function
        /// </summary>
        /// <returns>Model Name</returns>
        protected override string GetModelName()
        {
            return "Ingredient";
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
