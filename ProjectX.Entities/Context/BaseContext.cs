using Repository.Pattern.Ef6;
using System.Data.Entity;

namespace Northwind.Entities.Context
{
    public class BaseContext<TContext> : DataContext where TContext : DataContext
    {
        static BaseContext()
        {
            Database.SetInitializer<TContext>(null);
        }

        protected BaseContext() :
            base("Name=NorthwindContext")
        { }
    }
}