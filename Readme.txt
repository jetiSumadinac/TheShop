This is a refactoring exercise in C#. Imagine that this is a part of larger enterprise system and you are given this code to do code review before this goes to production. 
Please apply every principle and practice that you would in real situation so that this solution satisfies all of the coding standards.
Code is really simple. There's a ShopService that has the ability to display, order and sell the items. 
Client code (Program.cs) orders and sells items and also displays those that he has been able to find and those that he hasn't been able to find in the Shop.
When ordering an article, Shop needs to find the article amongst the given suppliers (It can be any external service) where they have it in stock 
and where the price is not more expensive than the maximum price a client is ready to pay for.
If naming and structure doesn't suit you, fell free to change them.
Introducing tests to the existing code is more than welcome.
Once you're finished with coding send us your code via email or URL to your GitHub/Bitbucket repository. Please include your source control history.
Should you have any questions or feedback for the assignment, feel free to contact us.