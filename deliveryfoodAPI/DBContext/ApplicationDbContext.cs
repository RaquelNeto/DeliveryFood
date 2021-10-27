using deliveryFoodAPI.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.DBContext
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }
        public DbSet<Deliveryman> deliveryman { get; set; }
        public DbSet<Mealhistory> Mealhistory { get; set; }
        public DbSet<Feedback> feedback { get; set; }
        public DbSet<Ingredients> ingredients { get; set; }
        public DbSet<IngredientsExtra> ingredientsextra { get; set; }
        public DbSet<Meal> meal { get; set; }
        public DbSet<MealsIngredients> MealsIngredients { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<OwnerRestaurant> ownerRestaurants { get; set; }
        public DbSet<Restaurants> restaurants { get; set; }
        public DbSet<Types> types { get; set; }
        public DbSet<IngredientOrderExtra> ingredientoorderextra { get; set; }
        public DbSet<MealsOrders> mealsOrders { get; set; }








        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
