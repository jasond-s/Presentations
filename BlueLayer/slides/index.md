- title : BlueLayer.io
- description : A case study of growing an early stage company
- author : Jason Dryhurst-Smith
- theme : night
- transition : slide

***
 
# BlueLayer.io

## the next 18 months

---

## Case Study Target

|Carta|Personio|Shopify|

</br>

Early stages there isn't a huge amount of difference in the way any organization builds. 

The product might be different but the practices that go into building it are broadly the same.

Someone is trying to turn a spreadsheet into an interactive and scalable solution with strict access control and workflow management.

---

## Where I Did Not Go Into Detail

There was a lot of cover so this is a *strategic overview*.

- Hiring outside of engineers (I do however think an engineering team should include all skills needed to execute).
- Specific processes and communication channels between teams.
- Code level architecture, or details about components in specific hosting providers.

---

## It's Time To Talk About Opportunity Cost*

`$4,000,000(raise) / 18(months) / 4.345(weeks)`

`= $51,144 a week`

This gives us a figure for the amount of value we need to create with our cash each week to keep up with the valuation.

Cashflow is offset by ARR so can hide your execution on the mission set at the raise.

</br>

<small style="font-family: 'Comic Sans MS' !important; color: pink">
*this is not how investors calculate it.
</small>

***

# Hiring

---

## Expertise Lays The Foundation

The first 6 months are about hiring rock solid senior technical individuals. They should all lead from the front.

They need to be adaptable and have the experience to be active in deep conversations about **what and why** we are building something, **not just how**.

Having more than one strategic and architectural thinker, and a collaborative culture, leads to better long term designs and short term execution.


### Expert Generalists

---

## Useful People Early On

1. **Front-End** - Pixel perfect UI and a grasp of UX can help product owners and designers also tasked with marketing activites to get the product design right.
2. **DevOps** - Getting networking, IaC, and CI/CD right first time will speed up the team generally.
3. **Database Administrator** - Whatever you choose, you need to have skills in understanding your choosen database at operational load.
4. **Operational Organiser** - [Glue work](https://locallyoptimistic.com/post/glue-work/) is often underrated, but engineers need an agile coach, minute taker, meeting booker.

---

## Who Writes All The Code?

In my experience it is possible to find excellent *full-stack* developers who are looking to take a risk on a funded early stage company, and who lean into a specialism, but are capable of much more. 

With a culture of quality they should be writing test automation, this is not a skill separate from implementation.

</br>

### 3 Senior Full Stack
### 1 Senior Front End

---

## What next?

The next 6 hires are really going to depend on the feedback from the product build. 

I like a ratio of 1/2/1 for Snr/Mid/Jnr in any given team.

---

### Leadership

Once the team is at 10 engineers you will need to coordinate work in multiple streams. It's a good idea to have at least **2 Engineering Managers** before this time. 

This person should have been selected in the first batch of hiring to build leadership early. They are likely to be the *Operational Organiser* we wanted.

---

### Quality

I do not think it is a good thing to hire a lot of dedicated testers or automation engineers.

It would be wise to have a couple of quality champions in the team though, to help build infrastructure to **enable** testing by everyone.

Get this wrong and it is very easy to build a culture of throwing things over fences. I really believe in [shifting left](https://en.wikipedia.org/wiki/Shift-left_testing) on everything.

***

# Tech Stack

---

<h2 style="font-family: 'SF Comic Script' !important; color: hotpink">
They are all the same who cares*
</h2>
</br>
<small style="font-family: 'Comic Sans MS' !important; color: pink">
*spicy take
</small>

---

## How Should You Pick?

1. [Choose Really Boring Technology.](https://boringtechnology.club/)
2. What can you afford?
3. Cloud hosting (good support on platform).
4. Observability (easy to monitor).
5. Accountability (no single point of failure in expertise).

---

## All In One Stacks

- LAMP - MySQL and Python
- MERN - Mongo and Node (TypeScript)
- ASP.NET - C#/F# and MSSQL

These all represent a suite of tools that are going to play nicely together and have good volumes of operational support (stackoverflow).

<small style="font-family: 'Comic Sans MS' !important; color: pink">
Bias alert: I have a fondness for C# as a language and the new runtime on Linux is actually pretty good
</small>

---

## Frontend

- Everyone uses React and it's easy to hire for
- Administrative tools will only need to scale as the team does, maybe use MVC.

---

## Backend

- If you are going to be hiring Data Scientists early, use Python. 
- If the UI is complex, then use TypeScript.
- If the domain is complex and you need static typing, use C#.

Don't use Java you'll have a bad time.

---

## Database

- If you hate yourself choose MySQL. Otherwise use PostgresSQL
- If you deal with documents only, [choose Mongo](https://medium.com/nerd-for-tech/the-dark-side-of-the-mongodb-f66f198a566b).
- If you are all in with Microsoft MSSQL is [the pit of success if you are using their stack](https://blog.codinghorror.com/falling-into-the-pit-of-success/).

Don't use a graph database you don't know it as well as you think.

---

## Recommendation

**Pay money or embrace simplicity to save time**

`React with Typescript`

`Python, Django, and PostgresSQL` 

`Manage with Basecamp and Github, deploy to Heroku`

Open source tooling is attractive for the baseline invoice cost. There is a [paradox of choice](https://en.wikipedia.org/wiki/The_Paradox_of_Choice) and poor interoperability though.

As things get complex in the domain, keeping things simple in the operations can be hard, I rate the Microsoft stack as a complete package for rapid delivery.

***

# Architecture

---

<h2 style="font-family: 'SF Comic Script' !important; color: hotpink">
Build an 'unmaintainable' monolith*
</h2>
</br>
<small style="font-family: 'Comic Sans MS' !important; color: pink">
*spicy take
</small>

---

## Learn From The Monolith

1. Alter deployment of software to service oriented pieces when:
   1. Unbalanced load leads to multi dimensional scaling.
   2. There are too many devs in one code base leading to increased change fail percentage and slow cycle times.
2. Use the strangler method to move subsystems into services.

--- 

## Learn From Service Orientation

3. Even a monolith should use messaging patterns.
4. Even a monolith should used SaaS logging ([something like Sematext](https://sematext.com/))

---

### Personio Example Architecture

![an architectural diagram](../images/arch.png)

***

# Governance

---

## My Important Things To Remember

[There are a bunch of rules that are worth following](https://jasonds.com/talks/what-is-solid). 

This is normally a 1 hour talk on it's own, so I will be brief.

---

### 1. Building

1. There is no slack for quality, ever.
2. It's better to show no data that the wrong data.
3. Agile is no excuse not to design (context, impact, measure, document, checklists).
4. Acronyms, KISS, DRY, YAGNI, most are overrated.
5. The only constant is change, all processes must embrace it
6. Expand and contract.

---

### 2. Not Building

1. Deadlines are hard, fixed scope or fixed dates.
2. Always have a launch plan.
3. Champions and playbooks for interop.
4. RCAs are what went wrong, and what went right.
5. Use systems thinking all the time you can.
6. Escalate.

---

<h3 style="font-family: 'SF Comic Script' !important; color: hotpink">
You don't have to do TDD or always pair*
</h3>
</br>
</br>
<small style="font-family: 'Comic Sans MS' !important; color: pink">
<a href="https://istacee.wordpress.com/2013/09/18/kent-beck-i-get-paid-for-code-that-works-not-for-tests/">*hot take</a>
</small>

***

# Questions