- title : Things to remember
- description : Just a placeholder
- author : Jason Dryhurst-Smith
- theme : night
- transition : slide

***
 
# Things 
## to 
# remember

***

## The agile feedback loop

This goes from code to customer, and back around
More specifically it goes from the code in production to a customers wallet

It's like a little water fall, or more like the water cycle that ends in money

![water fall](../images/waterfall.gif)

***

## Moving At Pace

[Sooner, safer, happier](https://www.soonersaferhappier.com/post/reimagining-annual-planning-from-project-wish-lists-to-strategic-flow)

---

![we should be targeting elite](../images/key-metrics.png)

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
4. Draw pictures
5. Shift left:
   - Launch plans and working backwards
   - Testing strategy
   - Observability
   - Operations
   - Analytics

---

### Thinking

![Stop and think. That's it, that's the tweet.](../images/prophet.png)

<span style="font-size: 75%">
* this is not a real tweet
</span>

---

### Parallel Change

- Consumer Lead
- Producer Lead

---

#### Expand

```
[lang=cs]
// This is lead by the producer, backwards compatible.
public record NewUserEvent
{
  public string Name {get;set;}
  // new fields
  public string FirstName {get;set;}
  public string LastName {get;set;}
}

```

#### Contract

```
[lang=cs]
// This is still consumer lead! Opt in to opt out after some fixed period.
public record NewUserEvent
{
  public string FirstName {get;set;}
  public string LastName {get;set;}
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

### Hill Charts 

<iframe src="https://www.drawhillcharts.com/dashboard?token=eyJ1c2VySWQiOiJ1c2VyXzJ5S2VlcGpGU0M5aFZuZDlzeDFScE9KTkdQRiIsInRhZyI6ImRhdGEiLCJleHAiOjE3ODk2NTM1NTQyNTh9.e62892b113cbd07792a51dfc730b0d2435503f22d9db2cf1b155391dc844ed98&userId=user_2yKeepjFSC9hVnd9sx1RpOJNGPF&readonly=true&tag=data" width="100%" height="400" frameborder="0"></iframe>

They aren't accurate

But they can communicate a lot.

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


***

- Direct to bank: @Franz @Ste Pammenter
- Payment Flow: @Chris Pollock @Kev @Calum Rivers
- Robustness and Reliability: @David Paton @Lee
- Pay By Card: 
    - @Zack @Ben Page (orchestration) 
    - @Keir MacDonald @Dom (API and checkout.com service)
- Bank Connection improvements: @Louis Lombardi @Akhilesh Pai
- Pre-Populating Verification: @Peter Gray @Nathan
- Crezco Auth Everywhere: @Jon Heslop (@Nathan in support)
- Developer Experience (and zero downtime deploy): @Tim @GaryH

---