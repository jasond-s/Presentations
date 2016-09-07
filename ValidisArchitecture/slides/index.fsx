(**
- title : Validis
- description : Validis And How It Works
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***

## The CIA - Accounting

***

### MarketInvoice.Validis

#### Anti-Corruption Layer

---

### Service that interacts with validis

#### IN
- HTTP File upload
- HTTP Status updates

<br/>
<br/>

#### OUT
- Files to blob storage
- Raw data to queryable format in SQL
- Status Events

---

## Moving Parts

- Validis API `mi-accounting-validis.marketinvoice.ninja`
    - Exposed to Validis
    - Exposed to CIS

- Validis FileProcessor
    - F#, does the work

- Service bus `cia-company` topic
    - Subscriptions `cia-company-accounting-fileprocessor`

- Azure blob storage `miaccounting` for zips

- Cia SQL server `mi-company-data-db` for queryable data

***

### MarketInvoice.CompanyInformation

#### Our Core Business Layer

#### The CIS service.

---

### Service that interacts with CIS

#### IN
- HTTP API

<br/>
<br/>

#### OUT
- HTTP API

<br/>
<br/>

## Wooooooooo!

---

## Moving Parts

- Service bus `cia-company` topic
    - Subscriptions `cia-company-accounting-cis`

- Cia SQL server `mi-company-data-db`
    - For event source, schema `akka`
    - For document data
        - Profit and Loss
        - Balance Sheet
        - Debtors
        - Creditors
        - Recievables
        - Payables

---

> "Weight wat, AKKA? Event sauce!?" - You, probably just now... looking at you Karger.

***

# AKKA

---

## I talked about this ages ago... it's amazing, lets look at code maybe?

---

## Andy and Phil totally backed me up on this.

*)