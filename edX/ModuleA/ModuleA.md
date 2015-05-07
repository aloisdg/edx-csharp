# Module 10

## First Part

### Linq3()

This sample uses the where clause to find all products that are in stock and cost more than 3.00 per unit.

Add it in the method `Linq3()` :

    var expensiveInStockProducts = products.Where(p => p.UnitsInStock > 0
                                   && p.UnitPrice > (decimal)3.00);

*We found 71 results.*

### Linq4()

This sample uses the where clause to find all customers in Washington.

Add it in the method `Linq4()` :
		
    var waCustomers = from c in customers
    	              let isNotNull = !String.IsNullOrWhiteSpace(c.Region)
    	              where isNotNull && c.Region.Equals("WA")
    	              select c;

*We found 3 results.*

## Second Part


### Linq30()

This sample uses orderby to sort a list of products by name. Use the "descending" keyword at the end of the clause to perform a reverse ordering.

Add it in the method `Linq30()` :

    var sortedProducts = from product in products
                         orderby product.ProductName descending
                         select product;

### Linq32()

This sample uses orderby and descending to sort a list of doubles from highest to lowest.

Add it in the method `Linq32()` :
	
    var sortedDoubles = doubles.OrderByDescending(d => d);
