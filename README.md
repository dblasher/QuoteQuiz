# [Quote Quiz](https://quotequiz.azurewebsites.net/)
## By Daniel Blasher
### Term Project for CS 295N, Fall 2018, Lane Community College

#### The Quote Quiz allows users to test their knowledge of movie quotes and submit their own movie quotes to add more questions to the database. The home page, “About”, will explain to users that all quotes are from movies only.

#### The “Quiz” page will display a random quote from the Quotes table and a form with two multiple choice questions: 4 movie titles from the Movie table, and 4 characters from the Character table. Submitting the form requires selecting an answer from both categories. After a valid submission, a LINQ query will determine if the answers match what is in the database. Then the user is redirected to a “Results” page revealing the correct answers, whether the user was correct, and maybe an embedded youtube video (or just the link if I can’t get that working)
#### The “Add A Quote” page will be a form for adding a quote, the character who speaks it, the movie it is from, and the youtube link prooving the quote is true.

### Tools Used:
#### MVC Core 2.1, Razor Pages, Bootstrap SQL Server, Entity Framework, Azure

### Setup:
#### Make sure you have Entity Framework and the MVC Core 2.1 installed in Visual Studio.
#### run `dotnet ef create database` to create a local db on your machine.
#### then run `dotnet ef database update` to apply the seedData
#### Then the app should be ready to run locally!

