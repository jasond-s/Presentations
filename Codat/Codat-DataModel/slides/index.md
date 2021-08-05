- title : Codat - Data Model
- description : An overview of the Codat Data model feature.
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***

</br>
</br>

# 👷‍♂️

## Codat Data Model

#### Standardising Business Reporting

##### Secret Source

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

<div style="text-align:left; padding-left: 150px;">

## 1. Client Facing
## 2. Internal 
## 3. Technical 

</div>

***

# 🏪

<div style="text-align:left; padding-left: 150px;">

## 1. Client Facing 

### 1.1. Accounting 
### 1.2. Commerce
### 1.3. Banking

</div>

---

# 📝📝

<div style="text-align:left; padding-left: 150px;">

## 1.1. Accounting

### 1.1.1. AR and AP
### 1.1.2. Reports
### 1.1.3. Lookups
### 1.1.4. Journal Entries

</div>

---

<div style="text-align:left; padding-left: 100px;">

### 1.1.1. Accounts Receivable

**Gives a picture of the sales side of the business.**

The account and all the related details.
#### Customers

Goods and services sold to the customers.
#### Invoices

A promise of credit to a given customer.
#### Credit Notes

Payment for the sold good or services.
#### Payments

</div>

---

<div style="text-align:left; padding-left: 100px; padding-right: 30px;">

### 1.1.1. Accounts Payable

**Gives a picture of the costs side of the business.**

The account and all the related details.
#### Suppliers

Goods and services bought from suppliers, including overheads like utilities and the cost of goods sold.
#### Bills

A promise of credit from a supplier.
#### Credit Notes

Payment for the provided good or services.
#### Payments

</div>

---

<div style="text-align:left; padding-left: 100px; padding-right: 30px;">

### 1.1.2. Reports

Owns in assets, owes in liabilities, and invested in equity
#### Balance Sheet

Create profit by increasing revenue and reducing costs
#### Profit and Loss

Amount of cash entering and leaving a company 
#### Cashflow Statement

When was money owed to the company and by who
#### Aged Debt

When was money owed by the company and to whom
#### Aged Credit

</div>

---

<div style="text-align:left; padding-left: 100px;">

### 1.1.3. Lookups

Nominal codes for ledger accounts, and their place in the balance sheet
#### Chart of Accounts

Products and services sold
#### Items

Tax jurisdictions and applicable rates
#### Tax Rates

Arbitrary groupings for transactions
#### Tracking Categories

</div>

---

<div style="text-align:left; padding-left: 100px;">

### 1.1.4. Journal Entries

</div>

<div style="text-align:justify; padding-left: 100px; padding-right: 100px;">

This is the actual ledger, where our double entry is done. Each entry will balance to zero. 

All `transactional business activities` will generate a corresponding line the journals for an account.

If we total up all of the transactions in a ledger, we end up with a balance. This is the `trial balance` and represents the current balance sheet.

</div>

---

# 🛒

<div style="text-align:left; padding-left: 150px;">

## 1.2. Commerce

### 1.2.1. Merchant Details
### 1.2.2. Orders

</div>

---

<div style="text-align:left; padding-left: 100px; padding-right: 30px;">

### 1.2.1. Merchant Details

A customer of the merchant and their contact details
#### Customers

Products and services as well as variants for catalogues and product description pages
#### Products and Services

</div>

---

<div style="text-align:left; padding-left: 100px; padding-right: 30px;">

### 1.2.2. Orders

Products or services that have been bought as part of a checkout activity
#### Orders

Payment related to a given order, might be deferred or delayed
#### Payments

</div>

<div style="text-align:left; padding-left: 100px; padding-top: 10px; padding-right: 80px;">

Note: Invoices and customers are not required by orders, this model is built around ECOM not ERP.

</div>

---

## 🏧

</br>

<div style="text-align:left; padding-left: 150px; padding-right: 100px;">

## 1.3. Banking 

A bank account and associated balances
#### Accounts

Transactions as they appear on the bank statement for the account, cleared transactions only
#### Transactions

</div>

***

# 🏭

<div style="text-align:left; padding-left: 150px;">

## 2. Internally Facing 

### 2.1. Reports
### 2.2. Data Model Committee

</div>

---

### 2.1. Reports - Pre-cache

</br>

<div style="text-align:justify; padding: 0 50px;">

Reports that are `pulled directly from the 3rd party`, in the format or layout dictated by the end user: 

Balance sheet, profit and loss, cashflow statement.

These are the `most likely to be accurate`, but also the least comparable as they reflect how the end user and the integration choose to structure this data. This is generally ok as the summary lines of the reports in the PnL and cashflow are well understood.

It becomes harder however if a client wants to display a `common ratio that requires specific values that might be nested in the structure`, such as EBITDA.

</div>

---

### 2.1. Reports - Post-cache

</br>

<div style="text-align:justify; padding: 0 50px;">

Reports `built from contributed data` pulled into the Codat system:

Aged debt, aged credit, co-vision.

These reports are built on top of the Codat standard for the data and are therefore `more easily comparable`. They are only as good as the data that we have in the cache though and often require multiple Data Types to be pulled, that means if the corresponding Datasets complete at different times or the company uses push a lot, `they may be inconsistent`.

</div>

---

### 2.2. Data Model Committee

</br>

<div style="text-align:justify; padding: 0 50px;">

Changes to the data model need to be considered and analysed to ensure that they standardise well.

We have a cross functional team that deals with this. Please see confluence.

</div>

***

# 🐱‍💻

<div style="text-align:left; padding-left: 15%;">

## 3. Technical 

### 3.1. Data Model Annotations
### 3.2. 🕵️‍♀️ Secret Source

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