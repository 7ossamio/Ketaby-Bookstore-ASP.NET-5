namespace BookStore.DAL.Migrations
{
    using BookStore.DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
   
    internal sealed class Configuration : DbMigrationsConfiguration<BookStore.DAL.EF.BookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookStore.DAL.EF.BookContext context)
        {
             
        }
    }
}
