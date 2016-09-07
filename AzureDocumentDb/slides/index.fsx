(**
- title : Azure Document DB
- description : Azure Document DB and Stuff.
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***

# <div style="font-family: 'SFComicScript' !important; color: #00ABEC;">Azure Document DB</div>

![Azure Document Db](./images/document_db.png)

***

### It's Microsoft's NoSQL document based database...

---

# The End

***

### Ok, that's not the whole story.

***

#### The api is fully RESTful... to level 3!

#### `GET /dbs/SomeDatabase/col/SomeCollection/S0m3-1D`

#### Only it's more like

#### `GET /dbs/Wooian==/col/Wooidnalfe=/S0m3-1D`

#### Your fancy names can be anything, so the 'real' address is a funky base64 version.

---

### What can it do.

1. `.InsertDocumentAsync(id, doc)`	- Insert a doc.
2. `.ReadDocumentAsync(id)`			- Read a doc.
3. `.UpdateDocumentAsync(id, doc)`	- Update a doc.
4. `.DeleteDocumentAsync(id)`		- Delete a doc.

Also

5. `UpsertDocumentAsync(id, doc)` - Awesome.

---

#### You'll notice it's <u>ALL</u> async by default. Awesome for IO.

--- 

### Query

    [lang=cs]
    IQueryable<Document> query = _client.CreateCollectionQuery(collectionId);

#### Not all of the stuff is supported. 

#### For instance, `.Include("")`, makes very little sense with a document based data model.

---

#### Returns type `Document`

#### Which is IDynamicMetaObjectProvider.

    [lang=cs]
    T thing = (T)((dynamic)(await _client.ReadDocumentAsync(id)))

---

#### It even supports SQL! So it really is (N)ot (o)nly SQL!

    [lang=cs]
    IQueryable<Document> query = _client.CreateCollectionQuery(collectionId, 
            "SELECT 
                {\"Name\":f.id, \"Value\":f.subObject.value} AS Thing 
            FROM 
                Collection 
            WHERE 
                id = 'S0m3-1D'"
        );

#### As far as I know is supports a VERY large set of the standard as well. 

---

#### Wait... what? 

Oh yeah... JSON is YOUR SQL! This is coming to the new SQL server as well, SELECT as JSON. 

![OVER 9000!](./images/over_9000.png)

---

### Other Cool Things

1. Automatic indexing.
2. Automatic partioning.
3. Automatic cacheing

#### And with javascript embedded in the DB.

4. Triggers.
5. Stored Procs.

#### This is a really powerful tool when combined with things like messaging and projections.

***

## However.

#### It's not all rosey and amazing just yet.

1. Tooling is lame.
2. No local instance.
3. Not even an emulator.
4. Spent all that time on the SQL though didn't you guys.
5. I can't believe there isn't better tooling.
6. Like, really no local instance?
7. The migration tool is ok.

*)