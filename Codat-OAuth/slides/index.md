- title : OAuth
- description : An introduction to OAuth for a non-tech audience.
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***
 
# OAuth

![smithers and mr burns go through an elaborate security check, only for a stray dog to enter through cat flap](images/security.gif)

---

<div style="background: #fff; padding-top: 20px; padding-bottom: 20px;">
## Agenda

1. What is it?
2. How does it work?
3. Why 2 versions?

## Not

1. Comprehensive technical implimentation discussion
2. Complete history of authorisation protocols
3. Codat implementation specifics

#### See me after class

</div>

***

<div style="background: #fff; padding-top: 20px; padding-bottom: 20px;">
## Three Legged Authorisation

1. Resource Owner
2. Authorising Service
3. Client
</div>

---


<div style="background: #fff; padding-top: 20px; padding-bottom: 20px;">
## 1. Resource Owner
## Or. End User

The individual user that wants to grant access.
</div>

---

<div style="background: #fff; padding-top: 20px; padding-bottom: 20px;">
## 2. Authorising Service 
## Or. Data Holder

The owner or holder of the users data.
</div>

---

<div style="background: #fff; padding-top: 20px; padding-bottom: 20px;">
## 3. Client 
## Or. Requesting Service

The service that wishes to gain access to the users data. 

### This is Codat.
</div>

***

<div style="background: #fff; padding-top: 20px; padding-bottom: 20px;">
### How does that work?

![insane clown posse don't know how magnets works](images/magnets.gif)
</div>

***

#### User clicks link URL

<img src="images/1.gif" style="box-shadow: none; border: none; height: 100%; width: 100%; margin-left: 50px;">

---

#### We redirect to the 3rd party

<img src="images/2.gif" style="box-shadow: none; border: none; height: 100%; width: 100%; margin-left: 50px;">

---

#### The user authorises with username and password

<img src="images/3.gif" style="box-shadow: none; border: none; height: 100%; width: 100%; margin-left: 50px;">

---

#### Authorisation server generates code

<img src="images/4.gif" style="box-shadow: none; border: none; height: 100%; width: 100%; margin-left: 50px;">

---

#### Exchange the code for some tokens.

<img src="images/5.gif" style="box-shadow: none; border: none; height: 100%; width: 100%; margin-left: 50px;">

---

<img src="images/6.gif" style="box-shadow: none; border: none; height: 100%; width: 100%; margin-left: 50px;">

---

<img src="images/8.gif" style="box-shadow: none; border: none; height: 100%; width: 100%; margin-left: 50px;">

***

<div style="background: #fff; padding-top: 20px; padding-bottom: 20px;">
## OAuth 1.0a vs OAuth 2.0

#### Protocols vs Frameworks
</div>

---

<div style="background: #fff; padding-top: 20px; padding-bottom: 20px;">
## OAuth 1.0/1.0a

A complete and internally consistent protocol for authorisation.

### Old
</div>

---

<div style="background: #fff; padding-top: 20px; padding-bottom: 20px;">
## OAuth 2.0

An incomplete framework for building authorisation protocols.

### New
</div>

---

<img src="images/rage-quit.gif" style="box-shadow: none; border: none; height: 100%; width: 100%;">

---

<div style="background: #fff; padding-top: 20px; padding-bottom: 20px;">
#### Eran Hammer resigned his role of lead author for the OAuth 2.0 project, withdrew from the IETF working group, and removed his name from the specification. 
### It is all about enterprise use cases, that is not capable of simple. 
#### A blueprint for an authorization protocol, that is the enterprise way, providing a whole 
## new frontier to sell consulting services and integration solutions.
</div>

---

<div style="background: #fff; padding-top: 20px; padding-bottom: 20px;">
#### The goal of the IETF 

create a authorisation standard that would put the power in the users hand, allow a web standards approach to to granting access for 3rd parties to access data that a user owned... LOL!

![all your data are belong to us](images/data.png)
</div>

***

<div style="background: #fff; padding-top: 20px; padding-bottom: 20px;">
[A complete run through of OAuth to quite a deep level.](https://medium.com/@darutk/diagrams-and-movies-of-all-the-oauth-2-0-flows-194f3c3ade85)

#### https://medium.com/@darutk/diagrams-and-movies-of-all-the-oauth-2-0-flows-194f3c3ade85
</div>

***

<div style="width:33%; height: 100%; display: inline-block; vertical-align: top;">
   <img style="width:50%; display: inline-block; box-shadow: none !important; background: radial-gradient(ellipse farthest-side at 100% 100%,#a1c8d6 10%,#66a9bd 50%,#085078 120%);" src="./images/codat_logo.png" alt="mi logo">
</div>
<div style="width:65%; height: 100%; display: inline-block; text-align: left; padding-top: 10px;">
### <span style="color: #464B4B; font-size: 120%;">Thanks</span>

##### Generation
**[FsReveal](https://github.com/fsprojects/FsReveal)** for slides

##### The Internet
**[the internet](https://google.co.uk)** for all the great gifs

</div>