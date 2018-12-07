using Project0.DataAccess;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;
using Project0.DataAccess.Repositories;
using System.Collections.Generic;

namespace Project0.Tests.DataAccess.Repositories
{
    public class IngredientsRepositoryTest
    {
        [Fact]
        public void CreateIngredientsWorks()
        {
            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project0Context>()
                .UseInMemoryDatabase("db_test_create").Options;
            using (var db = new Project0Context(options)) ;

            // act (for act, only use the repo, to test it)
            using (var db = new Project0Context(options))
            {
                var repo = new IngredientRepository(db);
                Ingredients ingredient = new Ingredients { Name = "Test", Stock = 10 };
                repo.Save(ingredient);
                repo.SaveChanges();
            }

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project0Context(options))
            {
                Ingredients ingredient = db.Ingredients.First(m => m.Name == "Test");
                Assert.Equal("Test", ingredient.Name);
                Assert.Equal(10, ingredient.Stock);
                Assert.NotEqual(0, ingredient.Id); // should get some generated ID
            }
        }

        [Fact]
        public void GetAllWorks()
        {
            List<Ingredients> list = new List<Ingredients>();

            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project0Context>()
                .UseInMemoryDatabase("db_test_getAll").Options;
            using (var db = new Project0Context(options)) ;

            // act (for act, only use the repo, to test it)
            using (var db = new Project0Context(options))
            {
                var repo = new IngredientRepository(db);

                for (int i = 0; i < 5; i++)
                {
                    Ingredients ingredient = new Ingredients { Name = $"Test {i}", Stock = 10 };
                    list.Add(ingredient);
                    repo.Save(ingredient);
                }
                repo.SaveChanges();
            }

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project0Context(options))
            {
                var repo = new IngredientRepository(db);
                List<Ingredients> ingredients = (List<Ingredients>)repo.GetAll();

                Assert.Equal(list.Count, ingredients.Count);

                for (int i = 0; i < list.Count; i++)
                {
                    Assert.Equal(list[i].Name, ingredients[i].Name);
                    Assert.Equal(10, ingredients[i].Stock);
                }
            }
        }

        [Fact]
        public void GetByIdWorks()
        {
            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project0Context>()
                .UseInMemoryDatabase("db_test_getById").Options;
            using (var db = new Project0Context(options)) ;

            // act (for act, only use the repo, to test it)
            using (var db = new Project0Context(options))
            {
                var repo = new IngredientRepository(db);

                Ingredients ingredient = new Ingredients { Name = "Test By Id", Stock = 10 };
                repo.Save(ingredient);
                repo.SaveChanges();
            }

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project0Context(options))
            {
                var repo = new IngredientRepository(db);
                Ingredients ingredient = (Ingredients)repo.GetById(1);

                Assert.Equal("Test By Id", ingredient.Name);
                Assert.Equal(10, ingredient.Stock);
            }
        }

        [Fact]
        public void GetByNameWorks()
        {
            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project0Context>()
                .UseInMemoryDatabase("db_test_getByName").Options;
            using (var db = new Project0Context(options)) ;

            // act (for act, only use the repo, to test it)
            using (var db = new Project0Context(options))
            {
                var repo = new IngredientRepository(db);

                Ingredients ingredient = new Ingredients { Name = "Test By Name", Stock = 10 };
                repo.Save(ingredient);
                repo.SaveChanges();
            }

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project0Context(options))
            {
                var repo = new IngredientRepository(db);
                Ingredients ingredient = (Ingredients)repo.GetByName("Test By Name");

                Assert.Equal(1, ingredient.Id);
                Assert.Equal(10, ingredient.Stock);
            }
        }
    }
}
