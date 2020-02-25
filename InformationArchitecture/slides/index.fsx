(**
- title : Information Architecture
- description : Information Architecture and World IA day 2015
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***

# Information Architecture
## World IA Day 2015

---

#### Version 2: now with Codat related examples!

***

> Intentionally arranging information in all forms, to support usability and discoverability.

---

### Domain Driven Design

![DDD](../images/process-is-bc.png)

#### The system is a specification of the process.

---

#### Our code is just documentation of a business process

![Code as the Spec](../images/space-cat.gif)

##### #trueism

***

### Narrative
#### The narrative arc

![Narrative](../images/Rick-and-Morty-Story-Wheel-Annotated.jpg)

---

## When?
#### Be concious of the task

1. Where are they now.
2. Where are they trying to get to.
3. What context is required to fill in blanks.

---

## Who?
#### Be concious of audience.

1. Errors: All possibly client and company facing
2. Logs: Support and engineering facing
3. Code: Engineer facing
4. Docs: Product and developer facing
5. And so on in this manner

***

### Taxonomy 
#### Classification and order.

![Categories](../images/rick-and-morty-category.jpg)

---

## What?
#### Namespacing

1. Please think about namespacing, it's so helpful.
2. We namespace code (discover, network complex)
    1. Prefix with `Codat` in Azure we are then globally unique
    2. Then, `Environment` (if infrastructure) (oooooooo controversial)
    2. Then, component `group`
    3. Then, `component`
    4. Finally, `subsystem` and other
3. When the namespace isn't enough, tag, tag, tag!

---

### Examples

`Codat.Integrations.FreshBooks.Api`

`codat-integration` -> `quickbooksDesktopPushQueue`

`codat-production-public-api`

---

#### Enterprise Architecture: defining bounded contexts
#### Ubiquitous Language: only for a bounded context

- There is a schema inherent in the language we use, it is rigid therefore requires thought.
</br>
</br>
- The boundry for the language can be around an audience as well as a process, be mindful of when you are crossing a boundary.
</br>
</br>
- Jargon is not bad, but again be mindful of when it becomes ubiquitous for an audience, you might have created a schema and a boundary without realising.

***

### Network
#### How does the information relate to existing information.

![Network](../images/network.gif)

---

## Where?
#### Audience

1. Namespacing: Seriously, this is really helpful.
2. Related links: Be mindful of linking across a boundary, your link may need context.

---

![IA](https://i.stack.imgur.com/iOvrU.png)

---

## Azure Devops

1. Epics (component or component group)
2. Features (component or subsystem) with related features
3. Stories (task in the process) 
4. Bug (should fit in to a story or feature, do tags and that) with related stories

***

#### dead links, dead code... fear of the unknown 💀

![Fear](../images/fear.gif)

#### 💀 Note: This is how you create legacy code.

***

##### Headline take home from the conference, 1.

<ul>
#### **Complexity** is not the problem

#### **Ambiguity** is.

#### **Simplicity** does not solve ambiguity.

#### **Clarity** does.
</ul>

##### Alastair Somerville - @Acuity_Design 

***

##### Headline take home from the conference, 2.

<ul>
#### Design and development are inseparable
#### your business will do better 
#### if it's structure reflects this.
</ul>

##### Nancy Willacy - @nancetron

*)