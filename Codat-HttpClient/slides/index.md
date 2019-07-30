- title : HttpClient
- description : An introduction to using HttpClient for RPC
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***
 
# RPC

## Remote Procedure Call

![Moe receives a prak call from Bart in The Simpsons TV show](images/rpc-call.gif)

***

## Necessary Features

1. End to end error handling.
2. Type safe clients.
3. Easy set-up for defaults.
4. Transparent auth.

![Homer ticks off items on a todo list in the TV show The Simpsons](images/list.gif)

---

# Components

## Server 
### Must be able to return to contract

## Client
### Used for de-coding contract

---

# Shared Contract

---

## Errors

#### On the wire
```javascript
{
   "correlationId" : "{for-grouping-logs-for-activiy}",
   "errorMessage" : "{something-machine-or-human-readable}",
   "serviceReference" : "{name-of-originating-service}"
}
```

#### In domain
```fsharp
type Result<'TResult> = 
      ErrorResult   of StatusCode * Error
    | SuccessResult of ResultData:'TResult
```
#### Or
```csharp
throw new DomainExceptionTransformedAtServiceBoundry();
```

---

## Content Negotiation

### Request
```text
Content-Type: application/what-the-server-knows
Accept: application/what-the-client-wants 
```

### Response
```text
Content-Type: application/hopefully-what-you-asked-for
```
<br/>
#### Always have a ubiquitous fallback... JSON or XML.

***

# DIY

## HttpClient

### Great .Net absraction for sending requests. 

## HttpClientFactory

### Builds clients with pooled connection resource.

---

# 1. Error Contract

```csharp
var request = new HttpRequestMessage(HttpMethod.Get, "resource");
var response = await client.SendAsync(request);
var content = await response.ReadAsString();

if (response.IsError) {
   var error = JsonConvert.DeserializeObject<ErrorContract>(
      content)
   return new ErrorResult(response.StatusCode, error);
}

return new SuccessResult(
   JsonConvert.DeserializeObject<TExpectedReturn>(
      content));
```

---

## Pro-tip:

```csharp
// Don't - string allocation is your enemy.
var str = response.ReadAsString();
return JsonConvert.DeserializeObject<T>(str);

// Do - streams all the way down.
var stream = await response.ReadAsStreamAsync();
using (var json = new JsonTextReader(new StreamReader(stream))) {
    return JsonSerializer.Create().Deserialize(json);
}
```

### If you need the `string` for debugging, read it out in `Exception`-al circumstances.

---

# 2. Type safety

```csharp
public interface IMyService {
   Task<DataOut> GetAsync(DataOutId id);
}

public class MyService : IMyService {
   private readonly HttpClient _client;
   public MyService(HttpClient client) {
      _client = client
   }
   public async Task<DataOut> GetAsync(DataOutId id)
   ...
}
```

---

# 3. Set Defaults

```csharp
serviceCollection.AddHttpClient<IMyService,MyService>(client => {

   // Useful to keep as static as possible for connection pooling.
   client.BaseAddress = new Uri(
      ConfigurationManager.AppSettings["MyUri"], UriKind.Absolute);

   // Default headers etc...
   client.DefaultRequestHeaders.Add(
      "x-my-header", 
      ConfigurationManager.AppSettings["MyHeader"])
})
```

---

# 4. Auth handling

```csharp
// You might read a bit of this stuff and think it 
// looks scary...
//
// But it's just a bit of a wrapper around manually 
// adding a header.
.ConfigurePrimaryHttpMessageHandler(() => 
   new MySpecialHttpClientHandler()
   {
      Credentials = new NetworkCredential(
         ConfigurationManager.AppSettings["MyAuthUser"], 
         ConfigurationManager.AppSettings["MyAuthPassword"]),
   };
);
```

***

## What about HttpClientFactory again?

```csharp
serviceCollection.AddHttpClient("MyService", client => {
   // do stuff
})

var myServiceClient = serviceCollection
   .BuildProvider()
   .Get<IHttpClientFactory>()
   .GetService("MyService");
```

### This is very helpful if you want to build your own infrastructure around the HttpClient.

***

# Not DIY

## gRPC

<br/>

[gRPC support for .Net Core 3.0](https://docs.microsoft.com/en-us/aspnet/core/grpc/basics?view=aspnetcore-3.0)

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