using Project0.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Project0.Tests.Library.Model
{
    public class OrderTest
    {
        [Fact]
        public void CanAdd12Pizzas()
        {
            Order o = new Order();

            for (int i=0; i<12; i++)
            {
                Pizza p = new Pizza();
                p.Id = 1;
                p.Name = "Pizza";
                p.Price = 10;

                o.AddPizza(p);
            }

            Assert.Equal(12, o.Pizzas.Count);
        }

        [Fact]
        public void CannotAdd13Pizzas()
        {
            Order o = new Order();

            for (int i=0; i<13; i++)
            {
                Pizza p = new Pizza();
                p.Id = 1;
                p.Name = "Pizza";
                p.Price = 10;

                o.AddPizza(p);
            }

            Assert.Equal(12, o.Pizzas.Count);
        }

        [Fact]
        public void ValueCannotBeMoreThan500()
        {
            Order o = new Order();

            for (int i=0; i<12; i++)
            {
                Pizza p = new Pizza();
                p.Id = 1;
                p.Name = "Pizza";
                p.Price = 50;

                o.AddPizza(p);
            }

            Assert.Equal(10, o.Pizzas.Count);
        }
    }
}
