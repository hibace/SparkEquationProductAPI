# SparkEquationProductAPI
SparkEquationProductAPI - .net core webapi


Backend engineer trial
Before you begin
Estimated time for the task is 3 hours. You don’t need to perform any specific configuration for
your machine, SQLite database will be provided.
Technical requirements:
- Language: C#
- Framework: ASP.NET Core
- Utilize REST principles for API endpoints
Initial API application will be provided.
Statement
Extend the initial API application with the following functionality:
- Add endpoint to be able to get a product
- Add endpoint to be able to create a product
- Add endpoint to be able to delete a product
- Add endpoint to be able to update a product
Create and update endpoints should have the following validation:
- Product fields should have basic validation (required, type, min/max length) according to
the existing database structure.
- A product can have from 1 to 5 categories.
- If a product has an expiration date it should expire not less than 30 days since now.
- If a product rating is greater than 8 it should automatically become “featured” product.
Optional
This part is not required but would be considered an advantage:
- The solution should have unit tests
- Test coverage of the solution should be at least 80%