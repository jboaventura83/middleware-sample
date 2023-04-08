# middleware-sample
Asp.net Core Middleware sample including custom middleware class

By default when you execute this program, it's return a response like this:

Response from Middleware 1!
It's is a response from Middleware 3!
It's is a response from Middleware 3!, after logic
Response from Middleware 1, after logic!

When we put query string params in the URL, for example ?firstname=John&&lastname=GoodAdventure&&nickname=jjboaventura, we have a response:

Response from Middleware 1!
Middleware 2, fullname -- > John GoodAdventure
It's is a response from Middleware 3!
It's is a response from Middleware 3!, after logic
Middleware 2, nickname --> jjboaventura, returned in after logic 
Response from Middleware 1, after logic!

The objective of this small program is show how the ASP.NET Core pipeline works.
