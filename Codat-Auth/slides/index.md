- title : Codat - Auth
- description : An overview of the Codat Auth feature.
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***

# 🔐 ➡ 🔓

## Codat Link

#### A workflow for 3rd party authorisation

---

<div style="text-align:justify; padding: 30px; font-size: 90%;">

## There is a lot to get through, so I would ask that you hold questions until the end, or speak to me after this session. If a few people have similar questions, it might be better to arrange for a session on that topic.

## <b style="color:#47113D">Thank.</b>

</div>

---

### Nomenclature Refresher

</br>
<div style="text-align:left; padding-left: 30px;">

#### 🤝 Client - our customer

</br>

#### 🙌 Company - our client's customers

</br>

#### 👐 Data Connection - link between a company and a 3rd party

</div>

---

<div style="text-align:left; padding-left: 150px;">

## 1. Client Facing
## 2. Internal 
## 3. Technical 

</div>

***

# 🏪

<div style="text-align:left; padding-left: 150px;">

## 1. Client Facing 

### 1.1. Link API
### 1.2. Link Site

</div>

***

# 🤖

## 1.1. Link API

#### Stadardised 3rd Party Authorisation Flow

</br>

<div style="text-align:left; padding-left: 150px;">

### 1.1.1. Credentials
### 1.1.2. Start
### 1.1.3. Redirect

</div>

--- 

### 1.1.1. Credentials

</br>

#### We are asking a <i style="color: #0F0;">user</i> for <i style="color: #0F0;">authorisation</i> to their data held by a <i style="color: #0F0;">software vendor</i> on <i style="color: #0F0;">behalf of our client</i>.

</br>

#### This means that we have to borrow our <i style="color: #0F0;">client's identification</i> to get through the front door. 

</br>

#### For us to get authoristion, a user will typically will be asked to <i style="color: #0F0;">authenticate</i> by the software vendor, this is called a challenge.

---

### 1.1.2. Start

#### Start the linking process with the third party, agnostic of the technical method of authorisation or authentication.

```
link.codat.io/link/start
    /{companyId}
    /{dataConnectionId}
```

</br>


<div style="text-align:left">

- The Codat identifier for the company you wish to link

</div>

#### Company ID 

<div style="text-align:left">


- The connection between the Company and the 3rd party system

</div>

#### Data Connection ID 

---

### 1.1.3. Redirect

#### Signals the end of a linking process with a 3rd party, used to notify the Client of success or failure.

```
https://{verified-host-name}/anything-you-like?
    statusCode={statusCode}&
    statusText={statusText}
```

</br>

<div style="text-align:left">

- Security - Only notify known parties via host name ownership

</div>

####  Verified Host Name 

<div style="text-align:left">

- Machines - A number that corresponds to the status of the link

</div>

####  Status Code 

<div style="text-align:left">

- Humans - Some text that corresponds to the status of the link

</div>

#### Status Text

---

# 🍟🍔🥤

## Bonus Features

<div style="text-align:left; padding-left: 30px;">


#### 1. Open ID Connect

Share the identity of the authorising user, where supported by the integration or enable one-click sign-up.

#### 2. Parameter Passing

Any parameters passed during the `start` process will be securely stored and passed back in the `redirect`. This allows for sharing internal information such as IDs with Codat, but not the 3rd party.

</div>

***

# 🐱‍💻

## 1.2. Link Site

#### No code, white labelled implementation of the Link API

</br>

<div style="text-align:left; padding-left: 150px;">

### 1.2.1. White-Labelling
### 1.2.2. Integration Selection
### 1.2.3. Offline Licence
### 1.2.4. Success Page

</div>

---

## 1.2.1. White-Labelling

![white-labelling colour selection screen](./images/white-labelling.png)

---

### White-Labelling

</br>
#### All of the link UI pages use a set of variables to allow customisation of the look of the Link Site for a given Client.

</br>

<div style="text-align:left; padding-left: 30px;">

### 1. Text and titles

### 2. Background and text colours

### 3. Company logo

</br>

Note: That's all we support, it's not powerful enough to support native looking integration with a Client's app. It's a good tool for non tech Clients and a stop-gap for tech ones.

</div>

---

## 1.2.2. Integration Selection

![integration selection screen](./images/integration-selection.png)

---

#### Integration Selection

</br>

- Takes a Company ID and creates a Data Connection without the Client needing to know what software the user has selected.

</br>
</br>

```
link.codat.io/{companyId}/link
```

---

## 1.2.3. Offline Licence

![integration selection screen](./images/offline-licence.png)

---

#### Offline Licence

</br>

- Displays a helpful prompt to the user about how to install the offline connector.

</br>
</br>

```
link.codat.io/{companyId}/licence/{dataConnectionId}
```

---

## 1.2.4. Success

![integration selection screen](./images/link-success.png)

---

#### Success

</br>

- Displays a helpful prompt to the user to inform them they have completed the linking process.

</br>
</br>

```
link.codat.io/{companyId}/success?
    redirect={redirect}
```


<div style="text-align:left">

- Allows the Client to specify a URL that the user can be sent to after the link is complete. Typically the home page of the Client or their app.

</div>

#### Redirect

***

# 🏭

<div style="text-align:left; padding-left: 150px;">

## 2. Internally Facing 

### 2.1. Parameter Passing
### 2.2. Integration Specific Phishing
### 2.3. Credentials and Tokens

</div>

***


<div style="text-align:left; padding-left: 150px;">

## 2.1. Parameter Passing 

### 2.1.1. Open ID Connect
### 2.1.2. Limitations and Reserved Keys

</div>

---

## 2.2. Integration Specific Phishing

---

## 2.3. Credentials and Tokens

***

# 🐱‍💻

## 3. Technical Underpinning 

### 3.1. Link Site Client
### 3.2. Proto-Buf

---

## 3.1. Link Site Client

```
Codat.LinkSite.Contract
Codat.LinkSite.HttpClient
Codat.LinkSite.Error
```

---

## 3.2. Proto-Buf

***

<div style="width:33%; height: 100%; display: inline-block; vertical-align: top;">
   <img style="width:50%; display: inline-block; box-shadow: none !important; background: radial-gradient(ellipse farthest-side at 100% 100%,#a1c8d6 10%,#66a9bd 50%,#085078 120%);" src="./images/codat_logo.png" alt="codat logo">
</div>
<div style="width:65%; height: 100%; display: inline-block; text-align: left; padding-top: 10px;">
### <span style="color: #464B4B; font-size: 120%;">Thanks</span>
### <span style="color: #416F85; text-shadow: none; font-size: 75%;">Email: jason@codat.io</span>

</div>