- title : Townhall
- description : Just a placeholder
- author : Jason Dryhurst-Smith
- theme : night
- transition : slide

***
 
# Codat.Http

---

# 🦄MAGIC🌈

---

# What is it?

1. Abstraction for making HTTP calls

2. Built around `ServiceCollection` to bind all the right defaults

---

# Design Philosophy

1. Sensible Defaults - Pit of success

2. Performant defaults - Where we can

3. Onion Skins - Adaptation over extension

4. RPC and error handling out of the box via error contract.

---

## IServiceFactory
#### Singleton

1. Builds an `IServiceClient`
2. Defaults are bound during initialisation

---

## IServiceClient
#### Transient

1. Abstration over `HttpClient` for content negotiation
2. Set defaults as you see fit
    - URI handling
    - Headers
    - Supported media types
    - Supported encoding types (gzip + brotli as standard)
    - Error handling
3. Generally wrapped by some domain "client" to provide contract as code

---

## IServiceRequest and IServiceResponse

1. Abstractions for the request response model
2. Deal with all the noise of URLs, headers, and content for you
3. There are a few specialisms made available from various pipelines
    1. retry - contains the retry information
    2. cache - contains cache information

---

## IHttpPipeline
#### Transient

### This is were the fun starts

1. Adapt `IServiceClient` with `HttpPipelineAdapter`
2. Caching
3. Retry
4. Throttling
5. Your limit is you imagination
6. Authorisation

---

## IDefaultHttpPipeline
#### Singleton

1. Just gives you a pipeline with good stuff
2. ?
3. 🦄

***

## Why all the methods?

Allow the implementation to understand calling context.

```csharp
var request = new ServiceRequest<MyModel>(
    HttpMethod.Post,
    "resource-that-returns-data"
    myModel
);

_ = await myServiceClient
    .SendDataAsync<MyModel>(request);

// This will ignore the response stream.
// Great if you don't need it.
```

---

## What is `Raw`

This allows you to just skip the automatic content negotiation and get some streams... or forms

```csharp
var content = new PushStreamContent(stream => {
    await using (stream) 
    {
        await myData.CopyToAsync();
    }
})

// The writting delegate is called lazily 
// right when you are about to send.
// This means you can delegate streams to streams JIT.
var res = await myServiceClient
    .SendAsRawAsync<MyModel>(request, content)
```

---

## How do I do forms?

This uses the raw API, this means that you can `POST` a form, and get an object back.

```csharp
// This is common in OAuth implementations
var formPostAsQueryString = FormPost.UrlEncoded()
    .AddParameter("hello", 1234)
    .AddParameter("world", new MemoryStream(someBytes));

// The streams will be written in the order added to the form.
var formPostAsMultipart = FormPost.MultiPart()
    .AddPart()
        .AddHeader("Content-Type", "text/plain")
        .AddParameter("data", "filename.txt", myFileStream)
    .AddPart()
        .AddHeader("Content-Type", "application/json")
        .AddParameter("metadata", myJsonStream);

var res = await myServiceClient
    .SendAsRawReceiveDataAsync<MyModel>(request, formPostAsMultipart)
```

---

## How does content negotiation work?

It's all just magic, JSON will always be supported, you have to work hard to break it.

```csharp
// add Codat.Http.Serialisation.Client.Protobuf

serviceCollection
    .AddHttpServiceClientProtobufSerialiser(TypeModel.Default);

new ServiceRequest(Http.Post, "")
    .AddProtobufHeaders()

new ServiceRequest(Http.Post, "")
    .AddGzipHeaders()
```