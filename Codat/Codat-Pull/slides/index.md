- title : Codat - Pull
- description : An overview of the Codat Pull feature.
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***

# ⛅ ➡ 💾

## Codat Pull

#### Collecting data on behalf of our clients

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

</br>

#### 👌 Contributed Data - data that has been contributed to the Codat system by a third party.

</div>

---

# Note 📰

## The word data appears on these slides, like... a lot. 

</br>

## Sorry.

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

### 1.1. Data model
### 1.2. Refreshing
### 1.3. Query

</div>

***

# 👯‍♂️

## 1.1. Data model

### 1.1.1. Data types
### 1.1.2. Data Sources

#### Standardised business information

--- 

### 1.1.1. Data Types


<div style="text-align:justify; padding: 0 50px;">

</br>

#### Our data models are made up from categories of data we call <i style="color: #0F0;">data types</i> each of these categories represents some business activity that our clients are interested in understanding.

</br>

#### A Data Type is an <i style="color: #0F0;">atomic and independent</i> source of data in the Codat system, which means that while it may be related to other data types, is should contain all of the information necessary to understand it.

</div>

---

### 1.1.1. Data Types

#### The model is defined in a number of ways:

</br>

<div style="text-align:left; padding-left: 50px;">

#### 1. Structure

Fields names and data format (text, number, date)

#### 2. Meaning

What does each field represent

#### 3. Dynamics

How do fields relate to each other and why might values change

</div>

--- 

### 1.1.2. Data Sources

<div style="text-align:justify; padding: 0 50px;">

</br>

#### These Data Types are grouped into collections called <i style="color: #0F0;">Data Sources</i>, we currently have Data Sources for <i style="color: #0F0;">Accounting</i>, <i style="color: #0F0;">Commerce</i>, and <i style="color: #0F0;">Banking</i> information. 


</br> 

#### 👽 A given Data Type may be obtained through a connection to a data source other than the owner e.g. bank statements pulled from accounting software, however source designates the true owner, pulling a Data Type through a connection that is not to an owning source increases the possibility of <i style="color: #0F0;">incomplete or inaccurate data</i>.

</div>

***

# 🕺 👬👨‍🦽👩🏼‍🤝‍👩🏽‍🤝‍🧑🏽

## 1.2. Refreshing

#### Refreshing the Contributed Data Cache.

<div style="text-align:left; padding-left: 330px;">

### 1.2.1. Dataset
### 1.2.2. Queue
### 1.2.3. Schedule
### 1.2.4. Alerts

</div>

---

### 1.2.1 Dataset

#### Created when a Client 'queues' a Data Type

<div style="text-align:justify; padding: 0 50px;">

Note: It's a word we made up. 

It comes from the statistical phrase 'data set', which means any collection of data. It's the name we give to any collection of data related to a Data Type e.g. an invoices dataset is a collection of invoices that are mapped to our data model.

</div>

---

### 1.2.1 Dataset - Delta

<div style="text-align:justify; padding: 0 50px;">

Where possible Codat will try and ensure that we are pulling the smallest amount of data possible from the 3rd party and still ensure that the Contributed Data we make available to our Clients is complete and accurate.

One such method of ensuring this to to do `delta syncs`, all we mean by this is that we only ask the 3rd party for the information that has changes since the last time we pulled information from them.

This is not always supported by a 3rd party however. While being an important part of our system behaviour to our Clients, it's operation should be complete opaque to them as all the details are handled by the Codat system.

</div>


---

### 1.2.1 Dataset - Status

<div style="text-align:left; padding-left: 50px; font-size: 80%">

#### 1. Queued

Waiting to be picked up by the system.

#### 2. Fetching

The code that calls the 3rd party is retrieving data.

#### 3. Mapping

We are mapping the data into the Codat data model.

#### 4. Validating

Making sure we have mapped the data correctly.

#### 5. Processing

Merging new data into the database.

#### 6. Complete

New data is ready to query.

</div>

---

### 1.2.2 Queue

#### Creating a Dataset

</br>

```
POST https://api.codat.io/companies/{companyId}
    /data/queue/{dataType}
```

</br>

<div style="text-align:left">

- The Codat identifier for the company you wish refresh data for

</div>

#### Company ID 

<div style="text-align:left">


- The Data Type you wish to refresh

</div>

#### Data Type

---

### 1.2.3 Schedule

#### The sync settings

<div style="text-align:justify; padding: 0 50px;">

This defines a frequency that you wish to queue a Data Type (or create a Dataset). It is a way of telling Codat what the minimal required 'freshness' of data should be.

It can be set per Data Type, we offer a few options; hourly, daily, weekly, monthly. 

Note: It is not a scheduler, you cannot set a Data Type to be queued at a specific time of day for instance. If a client wants this level of control they can use our API.

</div>

---

### 1.2.4 Alerts

#### Rules for pulling data

#### & some notes on data freshness

---

### Understanding data freshness

<div style="text-align:justify; padding: 0 50px;">

Clients that choose to use our API to queue Datasets, to ensure that the contributed data we hold for their Companies is as up-to-date as they require, have a number of ways of verifying the data freshness.

Running from least informative, to most informative:

</div>

---

<div style="text-align:left; padding-left: 50px;">

#### 1. Last Sync

`GET /companies/{companyId}`

Both the Company and the Data Connection record give a date for the last successful sync for any Data Type.

#### 2. Data Status

`GET /companies/{companyId}/dataStatus`

This is a detailed breakdown of the status of the last Dataset for each Data Type supported by the Company's Data Connections.

#### 3. Data History

`GET /companies/{companyId}/data/history/{datasetId}`

The data history can return all, or a single Dataset.

</div>

---

### 1.2.4 Alerts - Rules

#### Notifications for changes in a Dataset

</br>

<div style="text-align:justify; padding: 0 50px;">

While the endpoints above can give a complete picture for the current state of the Contributed Data we hold for a given Client about a Company, it's not very pleasant to build a system on top of them.

If a Client wanted to react to changing information they would have to keep coming back to use to ask if there was anything new (called long polling in the API world). Rather than expect a Client to do this, we have a notifications system we call Rules (for historical reasons that you can ask me about another time).

</div>

---

### 1.2.4 Alerts - Rule Types

</br>

<div style="text-align:left; padding-left: 50px;">

#### 1. Data sync completed

Fired whenever a Dataset moves to the status of `Complete`

#### 2. Dataset status has changed to An Error State

Fired whenever a Dataset moves to any error status; `FetchError`, `MapError`, `ValidationError`, `ProcessingError`, and `InternalError`.

</div>

---

### 1.3. Query

</br>

```
https://api.codat.io/companies/{companyId}
    /data/{dataType}?query={query}
```

</br>

<div style="text-align:left">

- A query to specify a filter for the data a Client is retrieving from the system.

</div>

#### Query

---

### 1.3. Query - DSL (a domain specific language)

# or

### 1.3. Query - DHQL (the david hoare query language)

---

#### 1. Greater than - >

`amountDue > 10`

#### 2. Less than - <

`amountDue < 10`

#### 3. Equals - =

`status = Paid`

#### 4. AND - &&

`amountDue > 10 && status = Paid`

#### 5. OR - ||

`status = PartiallyPaid || status = Paid`

***

# 🏭

<div style="text-align:left; padding-left: 150px;">

## 2. Internally Facing 

### 2.1. Monitoring
### 2.2. Data model Validation
### 2.3. Sync Settings

</div>

---

# 👁

### 2.2. Monitoring

#### Monitoring a Dataset as it moves through the system can be easily done through the webjobs dashboard

</br>

```
https://webjobs.codat.io
```

</br>

<div style="text-align:justify; padding: 0 50px;">

⚠ You can use the search function to find all the contextual logging information about a Dataset here. Observability and monitoring is a whole separate topic though and we don't have time to cover that completely now.

</div>

---

### 2.2. Data Model Validation

#### Validating the map output

<div style="text-align:left; padding-left: 150px;">

#### 2.2.1. The Rules
#### 2.2.2. Validation Output

</div>

---

### 2.2.1. Rule #1: No data >> Bad data

<div style="text-align:justify; padding: 0 50px;">

We are looking for inconsistencies in the mapping of the data in regards to the Codat data model. These are usually coding errors. 

Examples include:

- Are there duplicate IDs for invoices?

- Does a payment have a customer?

- Does the balance sheet balance assets, liabilities, and equity?

We call these `Data Model Invariants`.

</div>

---

### 2.2.1. Rule #2: 💩 in -> 💩 out

</br>

<div style="text-align:justify; padding: 0 50px;">

The purpose of our validation stage is <i style="color: #0F0;">not to make a decision about the quality of the data</i> we are mapping in relation to the business information it represents.

We are trying to be sure that we have <i style="color: #0F0;">accurately mapped the intent</i> of the information from the source. 

If the Company keeps bad books, we need to ensure that the map output shows a Company that keeps bad books.

</div>

---

### 2.2.1. Rule #1 always beats Rule #2

This is about a balance of probability; how likely is the invariant we are validating due to a mapping error, or data quality issue.

Example:

- Does the balance sheet balance assets, liabilities, and equity? 99% of the time if they do not, it's a coding error not a quality issue (who would buy accounting software that failed to account properly for things).

---

### 2.2.2. Validation Output

</br>

<div style="text-align:justify; padding: 0 50px;">

We store the results of validation in `codatjobsproduction` in a blob container called `integrations-validation`.

This can also easily be retrieved from the `webjobs.codat.io` dashboard for that Dataset.

</div>

---

### 2.3. Sync Settings

#### Can be added to a sync setting for a Data Type to limit the data that has to be retrieved. 

#### Can help with performance.

<div style="text-align:left; padding-left: 150px;">

#### 2.3.1. SyncFromUtc
#### 2.3.2. SyncWindow
#### 2.3.3. MonthsToSync

</div>

---

# Ask John Hicks 😏

---

#### 2.3.1. SyncFromUtc

Only retrieve data for any Dataset that was created in the 3rd party after this date.

---

#### 2.3.2. SyncWindow

This acts a bit like a fixed delta sync, e.g. only pull information that was created or changed in the last 6 months, but leave historical data as it is. This is predicated on the assumption that data that might be older than the `SyncWindow` is not likely to change.

---

#### MonthToSync

For reports only. Specifies the number of months back from today that you would like to aggregate financial reports, this is supported by `balanceSheets`, `profitAndLoss` etc.

***

# 🐱‍💻

<div style="text-align:left; padding-left: 30%;">

## 3. Technical 

</div>

---

# 👩‍💻
# SHOW ME 
# THE CODE!

***

<div style="width:33%; height: 100%; display: inline-block; vertical-align: top;">
   <img style="width:50%; display: inline-block; box-shadow: none !important; background: radial-gradient(ellipse farthest-side at 100% 100%,#a1c8d6 10%,#66a9bd 50%,#085078 120%);" src="./images/codat_logo.png" alt="codat logo">
</div>
<div style="width:65%; height: 100%; display: inline-block; text-align: left; padding-top: 10px;">
### <span style="color: #464B4B; font-size: 120%;">Thanks</span>
### <span style="color: #416F85; text-shadow: none; font-size: 75%;">Email: jason@codat.io</span>

</div>