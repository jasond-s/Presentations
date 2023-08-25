- title : Security
- description : Just a placeholder
- author : Jason Dryhurst-Smith
- theme : night
- transition : slide

***
 
# Cyber
# Security

![](../images/hacking.gif)

---

# I am not a certified expert 🤷

## Pro-am

---

## tech-wg-security
### ultimately it's dave
### practically it's all snr eng leaders
## Operations
### Josephine
### Luke

***

# Attack Surface

#### How large is your system

#### How complex is your system

---

# Attack Vectors

#### Routes for attack:

#### APIs

#### Infrastructure

---

# Blast Area

#### At the end of any vector 

#### what can be damaged, lost, or stolen

---

# Aggro

#### Posture in the world:

#### Positive PR

#### Negative PR

***

# Mitigation 
# of 
# Risk

---

# Machines

![](../images/machines.gif)

#### Penetration testing + scanning

---

# Humans

![](../images/human.jpg)

#### Security awareness training + 🍳

---

# Least Privilege 
# &
# Least Power

#### These are general rules to limit risks.

---

# Circles of Trust

#### In any group there is an understanding of the balance between being open or closed. There is a connection to the systems and people that own those systems. 

#### Trust is built on mutual understanding of risk and reward. The subtleties of each system demand understanding the subtleties of each persons ability to be trusted with an open door. 

### Everyone can't know and control everything. In fact, nobody can.

---

# Separation of Powers

#### Nobody should have the power to act and the ability to grant that power to others.

### Elevating your own permissions is very naughty indeed.

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

1. Limiting service to service access.
2. Single point of entry, WAF
3. Caller identity based authorization
4. VPN access only to the running system.

</br>
</br>

#### Virtual Private Network - put your machine 'inside' the cloud.

---

### What does it look like?

![](../images/unix.gif)

#### not this, but also, a bit this?

---

[If you care about it you can go and look here](https://codatdocs.atlassian.net/wiki/spaces/TECH/pages/2471002176/Platform+-+Azure+Network)

---

# Least Power

### Segregating monoliths of power

#### If everyone has access to everything the blast radius can be large

1. Storage - all the data corrupted at once
2. Messaging - false information propagated quickly
3. Secret management - skeleton keys

***

# Y Tho m8?

#### [The better we are has obvious downside protection.](https://www.oneadvanced.com/cyber-incident/#block454814)

#### The better we are allows us to sail through legals and technical pre-sales. 

#### Security is a feature we can sell.

--- 

![](../images/gameover.gif)