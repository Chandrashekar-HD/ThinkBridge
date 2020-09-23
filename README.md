# Steps to run the application:
1. modify web.config - mention the correct Data source, User ID and Password in the connectionString,  example: connectionString="Data Source=localhost\SQLEXPRESS;Initial Catalog=Inventory_System;Integrated Security=False;User ID=sa;Password=abc-123;" providerName="System.Data.SqlClient" />

2. Clean the solution, Build and run it

3. When the appliction is launched make sure the port number is-59915, if it's running in a different port number then search for 59915 in the solution and change that to new port number (it's being used in 2 controller's for making Web API call which is part of the same project)

4. When the application is launched, button Add- add's the item to inventory, Delete icon- removes the item from the list, Details- Navigates to new page with the selected item information

# For running unit test code
before running test code mention the existing ID of the item in the test method DetailFound() of ItemDetailControllerTest.cs
and then choose Test -> Run All Tests

# Code coverage test
 I developed the aplication using Visual studio 2017 Professional. In Professional there is no built in tool support to run code coverage test due to this i couldn't run code coverage test
 
