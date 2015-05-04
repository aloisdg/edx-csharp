using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World");
		}

		// Linq3() // 71 results
		// This sample uses the where clause to find all products that are in stock and 
		// cost more than 3.00 per unit.
		
		// var expensiveInStockProducts = products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > (decimal)3.00);

		// Linq4() // 3 results 
		// This sample uses the where clause to find all customers in Washington.
		
		// var waCustomers = from c in customers
		//		let isNotNull = !String.IsNullOrWhiteSpace(c.Region)
		//		where isNotNull && c.Region.Equals("WA")
		//		select c;

		// Linq30()
		// This sample uses orderby to sort a list of products by name.
		// Use the \"descending\" keyword at the end of the clause to perform a reverse ordering."
		
		// var sortedProducts = from product in products
		//		orderby product.ProductName descending
		//		select product;

		// Linq32()
		// "This sample uses orderby and descending to sort a list of doubles from highest to lowest."
		
		// var sortedDoubles = doubles.OrderByDescending(d => d);
	}
}
