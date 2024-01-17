- title : Things to remember
- description : Just a placeholder
- author : Jason Dryhurst-Smith
- theme : night
- transition : slide

***
 
# Things I think you should think about

***

## The agile feedback loop

This goes from customer to code, and back up.
More specifically it goes from a customers wallet to the code in production.

- Does the work impact the buying decision, 
- Is not doing it a realistic churn risk.

---

Let's take a look at a nice animation on excalidraw.

***

## Moving At Pace

[Sooner, safer, happier](https://www.soonersaferhappier.com/)

---

## DevOps: The 4 key metrics

---

### Deployment Frequency

How often do you put new software into the hands of the customer.

---

### Cycle Time

This is classically thought in DevOps as the time from merged in main to production deployment.

As the deployment frequency increases this is better thought of as the time from **ideation** to **deployed to production**.

---

### Mean Time to Restore

Time from event to correction.

This can be a deployment event, or external impact.

#### Defects are customer outages

Is the system behaving in a way that the customer expects.

Not just drops in availability or jumps in error rate.

---

### Change Failure Rate

Does a deployment contain a new and unexpected defect.

---

![we should be targeting elite](../images/targets.png)

---

### Culture 

![we should be targeting elite](../images/culture.png)

---

### Westrum - Generative Business

- **Open Communication:** Encourage transparent and open sharing.
- **Collaboration:** A culture of teamwork and cooperation.
- **Proactive Learning:** Proactive learning from mistakes.
- **Fear-Free Environment:** Safe to express ideas without fear.
- **Trust and Respect:** Trust and mutual respect across team.
- **Adaptability:** Adapt to challenges and changing circumstances.
- **Continuous Improvement:** Mindset of continuous improvement.
- **Innovation and Creativity:** Cultivates an environment of creativity.
- **Resilience:** Contributes to the organization's overall success.

#### No burn out

---

### User Focus

![we should be targeting elite](../images/user-focus.png)

---

### Things like: 

1. OKRs related to user need
2. Personas for development and design
3. User feedback integration
4. Monitoring and analytics based on behavior

***

## Design

---

### Written Culture

[Town Planning](https://wardleypedia.org/mediawiki/index.php/Pioneers_settlers_town_planners#Town_Planners)

1. Can we state the objective in a single paragraph.
2. Can we draw the specification on a single page.
3. Document decisions 
3. Shift left:
   - Stakeholder impact analysis
   - Testing strategy
   - Measurability

---

### Thinking

![Stop and think. That's it, that's the tweet.](../images/prophet.png)

<span style="font-size: 75%">
* this is not a real tweet
</span>

---

### Acronyms

<iframe width="560" height="315" src="https://www.youtube.com/embed/Of_fYnsoq2A?si=ucHGN-ZzrlKOwo_5" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>

---

# YAGNI

<span style="font-size: 80%">
you really aren't I promise
</span>

---

# DRY

<span style="font-size: 80%">
so long as it's accessabile and clear
</span>

---

# KISS

<span style="font-size: 80%">
simplest thing that works
</span>

---

### Parallel Change

#### Expand

```
[lang=cs]
// This is lead by the producer, backwards compatible.
public record NewUserEvent(string Name, string FirstName, string LastName)

```

#### Contract

```
[lang=cs]
// This is still consumer lead! Opt in to opt out after some fixed period.
public record NewUserEvent(string FirstName, string LastName)
{
  #if feature_switch
  public string Name {get;set;}
  #endif
}
```

***

# Planning

Make sure you know as early as possible 

how late we are going to be.

<span style="font-size: 80%">
*we will definitely be late
</span>

---

### Gantt Charts 

![Microsoft project is the devil](../images/project.png)

They lie, never put dates on them. 

Critial path analysis is good though.

---

#### Don't accept risk implicitly.

> "I think we can get it done by monday"

If you don't know what are the risks? 

Will it be Tuesday, or next month?

> "It won't take long, I'll make sure it works"

Do you know if it will work? Is there a leap of faith? 

#### Quantify the risk, give optimistic and pessimistic answers.

***

### Complexity is not the problem
### Ambiguity is
### Simplicity is not the answer
### Clarity is

<span style="font-size: 80%">
If not expressed explicity complexity tends to build up in dark places.
</span>