(**
- title : JUST PUSH IT
- description : Pushing data with Codat
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***

# Codat
## Just Push It

---

![](../images/sandp.gif)

***

## What is 'Pull'?

> Retrieving a companies management accounts, by pulling data from the companies accounting software, on behalf of one of our clients.   

---

## What is 'Push'?

> Editing or updating a company's management accounts, via the company's accounting software of behalf of one of our clients.

---

![](../images/peter.gif)

***

### Push Examples

---

### Bank feed

Add transactions from a bank statement, to accounting platform for reconciliation as e.g. debtor and creditor payments.

---

### Point of sale

Create a sales invoice for a customer in accounts recievable, create bank transation to reconcile the reciept of a card payment againt the invoice.   

---

![](../images/pusher.gif)

***

# Process

---

## Limitations

1. Async by nature, in some platforms, therefore must be everywhere.

2. Failure can be hard to track (distributed transaction).

3. Possible that platfrom requirements are a superset of the Codat standardised model.

---

## 1. Options

- Describes the data that the API will expect for any given platform and company.

- Standardised format, based on 'JSON Schema' (draft-07).

- Use in the portal to build a generic UI.

#### API

`GET /companies/{companyId}/connections/{connectionId}/options/{dataType}`

---

![](../images/winslett.gif)

---

## 2. Push operation

- Represents the push action to the end user and internally to Codat.

- Tracks the status of any async operation.

- Once the operation is successful the data will exist in the data for the givven data type.

#### API

Create
`POST /companies/{companyId}/connections/{connectionId:guid}/push/{dataType}`

Retrieve
`GET /companies/{companyId}/push/{pushOperationId}`

---

![](../images/penny.gif)

---

## 2.1 Push status

- **Pending** - This is the initial status for any push operation, waiting for processing. 

- **Unknown** - The push operation has been processed by the platform, but we are unable to communicate the status.

- **Success** - The push operation has been completed and the data is available.

- **Failure** - The push operation failed, usully with some attached human readable reason.

---

## 2.2 Synchronous platforms

- Some of the data types...

- For some of the cloud platforms...

- Can push synchronously, so the status will only be either success of failure for the end users.

- However, conceptually the push operation will have been through the pending status internally.

---

## 2.3 Asynchronous platforms

- The user will have to monitor the status of each of their push operations themselves. 

    - **Long-polling** - Checking the status by calling the API.

    - **Webhook** - Waiting for an event to trigger that says the change of status.

---

![](../images/homer.gif)

***

# Behind the Curtain

---

![](../images/homer2.gif)

---

## Support so far...

- **FreeAgent** - Bank accounts and transactions.

- **Kashflow** - Bank accounts and transactions.

- **Quickbooks Pro** - Chart of accounts, suppliers, bills.

- **Quickbooks Online** - Chart of accounts, suppliers.

- **Reckon** - Bank accounts and transactions.

- **Sage One** & **Sage 50** - Bank transactions.

- **Xero** - Chart of accounts, suppliers.

---

## Quickbooks Pro

1. We are queuing the operations internally.

2. The connector will wake, and check for pull operations.

3. Attempt each push operation in turn.

4. Call home to update the success or failure of the operation.

5. Using the Quickbooks COM SDK to do all of the push and pull.

---

## Sage 50
## Sage One
## Sage Bank Feed

---

![](../images/who-dis.gif)

---

## Sage

1. We are not currently pushing directly to Sage One.

2. We are not currently pushing directly to Sage 50.

3. We do integrate with Sage Bank Feed for Tide.

    - This allows us to push bank transactions to Sage One and Sage 50 accounts.
    
    - This is not, sadly, relavent for pushing other data type. 


***

![](../images/fin.gif)

---

![](../images/applause.gif)

*)