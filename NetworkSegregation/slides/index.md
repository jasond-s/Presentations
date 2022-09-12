- title : Security
- description : Just a placeholder
- author : Jason Dryhurst-Smith
- theme : night
- transition : slide

***
 
# Cyber
# Security

![](../images/hacking.gif)

***

# Surface Area

#### How large is your system

#### How complex is your system

---

# Vectors

#### Routes for attack

---

# Blast Area

#### At the end of any vector what can be damaged, lost, or stolen

---

# Hate or Aggro

#### Posture in the world -

#### Positive PR

#### Negative PR

***

# Machines

![](../images/machines.gif)

#### Penetration testing + scanning

---

# Humans

![](../images/human.jpg)

#### Security awareness training + 🍳

---

# Circles of Trust

#### In any group there is an understanding of the balance between being open or closed. There is a connection to the systems and people that own those systems. Trust is built on mutual understanding of risk and reward. The subtleties of each system demand understanding the subtleties of each persons ability to be trusted with an open door. 

### Everyone can't know and control everything. In fact, nobody can.

---

# Least Privilege 
# &
# Least Power

#### These are general rules to limit risks.

***

```javascript
/*







 _______          __                       __    
 \      \   _____/  |___  _  _____________|  | __
 /   |   \_/ __ \   __\ \/ \/ /  _ \_  __ \  |/ /
/    |    \  ___/|  |  \     (  <_> )  | \/    < 
\____|__  /\___  >__|   \/\_/ \____/|__|  |__|_ \
        \/     \/                              \/
       
 _________                                         __  .__               
 /   _____/ ____   ___________   ____   _________ _/  |_|__| ____   ____  
 \_____  \_/ __ \ / ___\_  __ \_/ __ \ / ___\__  \\   __\  |/  _ \ /    \ 
 /        \  ___// /_/  >  | \/\  ___// /_/  > __ \|  | |  (  <_> )   |  \
/_______  /\___  >___  /|__|    \___  >___  (____  /__| |__|\____/|___|  /
        \/     \/_____/             \/_____/     \/                    \/

Network Segregation              







*/   
```
---

# Least Privilege

### Reducing network access

1. VPN access only in integration.
2. Jump box with break glass access in production.

---

### What does it look like?

![](../images/unix.jpg)

---
```javascript
/* What does it look like?

  Each of these boxes is a VNET (vitual network)
 ┌────────────────────────────────────────────────────┐
 │ DMZ                                                │
 │       ┌────────────────┐       ┌──────────────┐    │
 │       │                │       │              │    │
 │       │ Public         │       │ api.codat.io │    │
 │       │ Anonymous      │       │              │ ◄──┼───────────
 │       │                │       │              │    │
 │       │ Link Mostly    │       │              │    │
 │       │                │       │              │    │        ┌──────────────┐
 │       │                │       │              │    │        │              │
 │       └────────────────┘       └──────────────┘    │        │              │
 │            Comms goes through the DMZ              │        │              │
 │            ┌───────────────────────────┐           │        │ The Internet │
 ├────────────┼───────────────────────────┼───────────┤        │              │
 │            │           │  │            │           │        │              │
 │ Spoke 1    │           │  │ Spoke 2    │           │        │              │
 │            │           │  │            │           │        └──────────────┘
 │            │           │  │            │           │
 │   ┌────────┼───────┐   │  │   ┌────────│──────┐    │
 │   │        │       │   │  │   │        ▼      │    │x◄───────────────────
 │   │ Integration    │   │  │   │ Clients Api   │    │
 │   │                │   │  │   │               │    │
 │   │                │   │  │   │               │    │
 │   │                │   │  │   │               │    │
 │   │                │   │  │   │               │    │
 │   └────────────────┘   │  │   └───────────────┘    │
 └────────────────────────┘  └────────────────────────┘
 https://codatdocs.atlassian.net/wiki/spaces/TECH/
 pages/1982201972/RFC+-+Azure+Network+Topology+-+Hub+and+Spoke
*/   
```
---

# Least Power

### Segregating monoliths 

1. Azure Storage `codatjobsprod`
2. Service Bus
3. Key Vault

***

### Compliance Obligations

![](../images/gameover.gif)