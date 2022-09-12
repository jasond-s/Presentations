- title : Head of Engineering
- description : Integration Tests Aids
- author : Jason Dryhurst-Smith
- theme : night
- transition : slide

***

# Integration Tests

---

## WebApplicationFactory

This will run a webserver in memory as soon as you call it using a provided `HttpClient`. 
It will also allow you to override behaviours of the application by providing a `IWebHostBuilder`.
The package includes a couple of extensions for test specific activities. 

```csharp
// This just takes a single type argument, which is the startup file for the
// application under test. 
WebApplicationFactory factory = new WebApplicationFactory<Codat.Thing.Api.Startup>();

// This fluent method will allow you to set up overrides for your unit under test.
WebApplicationFactory newFactory = factory.WithWebHostBuilder(b =>
{
    b.ConfigureTestServices((IServiceCollection s) => {
        // adding things to the service collection here 
        // will override the implementation in the running
        // application.
    });
});

// This is the main method on the factory, and it will provide you a client.
HttpClient client = newFactory.CreateClient();
```

---

## Using It

### Simple Case

It's as simple to use as firing up the factory and using the `HttpClient` to make calls to the API!

```csharp
var factory = new ServiceClientWebApplicationFactory<Startup>();

var response = await factory.GetClient()
    .GetAsync(new Uri("api/values"), UriKind.Relative);
    
Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
```

---

## Using It

### Key Vault

Rather than adding skeleton keys to a repo to access the mandatory key vault, you can add a local configuration version.

```csharp
var factory = new ServiceClientWebApplicationFactory<Startup>()
    .WithWebHostBuilder(b =>
    {
        // This essentially delegates to an `IConfigurationProvider`.
        // I will omit this from later slides for brevity. 
        b.AddTestLocalSecretsProvider();
    });

var response = await factory.GetClient()
    .GetAsync(new Uri("api/values"), UriKind.Relative);
    
Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
```

---

## Using It

### Mocking Case

You can easily force behaviour to test all sort of behaviours by injecting mocks to the running service.

```csharp
var myServiceMock = new Mock<IMyService>();
myServiceMock
    .Setup(m => m.DoSomething())
    .Throws(new ValidationException());

var factory = new ServiceClientWebApplicationFactory<Startup>()
    .WithWebHostBuilder(b =>
    {
        b.ConfigureTestServices(s => {
            s.AddTransient<IMyCodatService>(myServiceMock.Object);
        });
    });

var response = await factory.GetClient()
    .GetAsync(new Uri("api/values"), UriKind.Relative);
    
Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
```

---

## Using It

### Codat.MyApi.Client

Testing the whole RPC stack.

```csharp
var myServiceMock = new Mock<IMyService>();
myServiceMock
    .Setup(m => m.DoSomething())
    .Throws(new ValidationException());

var factory = new ServiceClientWebApplicationFactory<Startup>()
    .WithWebHostBuilder(b =>
    {
        b.ConfigureTestServices(s => {
            s.AddTransient<IMyCodatService>(myServiceMock.Object);
        });
    });

IServiceClient client = factory.GetServiceClient();

var myClient = new MyApiClient(client);

var exception = await Assert.ThrowsAsync<CodatApiException>(() => 
    myClient.DoSomethingAsync());
    
Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.StatusCode);
```

---

![](/images/yo_dawg.jpg)

---

## Using It

### ServiceClientWithInMemoryServer

Run your dependant service as an in-memory webserver.

```csharp
var myDependentService = new ServiceClientWithInMemoryServer(
    new RequestHandlerForExternalApi()
);

var factory = new ServiceClientWebApplicationFactory<Startup>()
    .WithWebHostBuilder(b => b.AddServiceFactoryTest( ("ExternalApi", myDependentService) ));

var response = await factory.GetClient()
    .GetAsync(new Uri("api/values"), UriKind.Relative);
    
Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

public sealed class RequestHandlerForExternalApi 
{
    public override string ServiceName => "ExternalApi";

    public override ResponseFromInMemoryWebServer HandleRequest(HttpListenerRequest request)
    {
        return new ResponseFromInMemoryWebServer(
            400, new Dictionary<string, string>(), Array.Empty<byte>());
    }
}
```

---

![wat?](/images/wat.gif)

---

# SHOW ME THE CODE!