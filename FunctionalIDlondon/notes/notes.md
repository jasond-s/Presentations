THE GOOD

DATA TRANSFORMATION

1. Types and therefore concepts in the domain are easy to express
    - clojure - defrecord
    - f# - records
    - elm - records
    - scala - case

2. There are a load of syntax helpers for dealing with data.
    - f# elm - with
    - clojure - update
    - scala - copy

3. Immutable by default is very common and this makes reasoning and testing code easier.
    - #testing FTW


CENTRALISED EXCEPTION HANDLING  

Why is this important, not just for code, for the business!

1. Union types/Algebraic Types, they can hold data to.
2. Take a look at the construct, not need for messy exceptions, ew know what is going on in our app.
3. Incomplete, lets add a case.
4. Take a look at what the compiler and intellisense is telling us!

INFRASTRUCTURE

Much of the code we all write these days is not business code, but 'glue'
between other peoples libraries and our own business domain.

1. It's .Net we still have classes and so we also do in F#
2. Lets use partial application to abstract away this dependency.
3. We can call the function, or we can pipe a value into it to create our new function.

4. Then whenever we need to use that function, use our 'primed' version.
5. This is doubly useful with testing, also, checkout lambdas.

COMPILER HEAVY LIFTING

1. We've got a super boring and primitive heavy object.
2. Lets define some units that we might need in out domain.
3. Lets make our types even richer with single case unions and alias types.
4. Just like we did with all the preceeding steps, in the exception handling and infrastructure, let the compiler work.
5. If we get a calculation wrong, it will tell us! This is so useful when business guys can define those units.


SUMMARISE!!!! 


THE BAD


VENDOR HELL

1. So many libraries in the chosen ecosystem, either .Net or Java, are built around classes and mutation and that can make it messy.

UNCLE BEN CODE

1. A lot of code out there that is built from functional first, is built by people that are into the maths of it.
2. Classes and OO were built around and became so popular because it was an abstraction with language that people understood.
3. Don't forget your lessons learned from here, name things, terse code isn't always the best code.
4. Code needs to be maintained and needs to be open to change if it is going to do really hard work in a business.

TRAINING

1. So you have got over all the humps and you have learned this stuff and love it. What next?
2. How do you take the time to get a team excited and motivated to use the stuff.
3. How do you get the time to keep up with 2 platforms all the time and that "it is easier in X mentality".
4. How do you convince managers that the time take to do something, maybe twice, you will get it wrong first time, is worth it.
5. How do you prove the benefits in your business to be able to do these things, without actually doing them!

SUMMARISE!!!!


HOW TO GET INVOLVED