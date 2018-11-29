# QuoteQuiz
## By Daniel Blasher
## Term Project for CS 295N, Fall 2018, Lane Community College

#### The Quote Quiz allows users to test their knowledge of movie quotes and submit their own movie quotes to add more questions to the database. The home page, “About”, will explain to users that all quotes are from movies only.

#### The “Quiz” page will display a random quote from the Quotes table and a form with two multiple choice questions: 4 movie titles from the Movie table, and 4 characters from the Character table. Submitting the form requires selecting an answer from both categories. After a valid submission, a LINQ query will determine if the answers match what is in the database. Then the user is redirected to a “Results” page revealing the correct answers, whether the user was correct, and maybe an embedded youtube video (or just the link if I can’t get that working)
#### The “Add A Quote” page will be a form for adding a quote, the character who speaks it, the movie it is from, and the youtube link prooving the quote is true.
