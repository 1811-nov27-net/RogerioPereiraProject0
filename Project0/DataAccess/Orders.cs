using Project0.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project0.DataAccess
{
    [Table("orders", Schema = "pizza")]
    public partial class Orders : AModel
    {
        public Orders()
        {
            OrderPizzas = new HashSet<OrderPizzas>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Column("customerId")]
        public int CustomerId { get; set; }
        [Column("addressId")]
        public int AddressId { get; set; }
        [Column("value", TypeName = "money")]
        public decimal Value { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }

        [ForeignKey("AddressId")]
        [InverseProperty("Orders")]
        public virtual Addresses Address { get; set; }
        [ForeignKey("CustomerId")]
        [InverseProperty("Orders")]
        public virtual Customers Customer { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<OrderPizzas> OrderPizzas { get; set; }
        
        public override string ToString()
        {
            string ret = $"ID: {Id} - {Customer.FirstName} {Customer.LastName}";
            ret = ret + $"\nDelivered at: { Address.ToString() }";

            if (OrderPizzas.Count > 0)
                ret = ret + "\nPizzas";

            foreach (OrderPizzas orderPizza in OrderPizzas)
            {
                Pizzas pizza = orderPizza.Pizza;
                ret = ret + $"\nPizza ID: {pizza.Id} - {pizza.Name} - $ {Convert.ToDecimal(string.Format("{0:0,00.00}", pizza.Price))}";
            }

            ret = ret + "\n";

            return ret;
        }
    }
}
