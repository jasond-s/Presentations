(**
- title : FUNctional Programming
- description : Introduction to Functional Programming
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***

# Actor Model

### Holywood Driven Development

</br>

#### Some Other Things I Have Learned 

#### By Jason age 7 and 253 months.

***

### Handling Concurrency

Or basically just trying to do two things at once...

#### C#

    [lang=cs] 
    [ThreadStatic] private IList<bool> _workItems;
    private static readonly object LockObject = new object();

    public IList<bool> WorkItems 
    { 
      get { return _workItems ?? (_workItems = new List<bool>()); } 
    }

    public static void Main(string[] args) {
      // Something about threads.
      var couldItBeQueued = ThreadPool.QueueUserWorkItem(
                              new WaitCallback(DoSomeWorkSomewhereElse));

      // Something about locks.
      lock(LockObject){

        // Something and thread static.
        WorkItems.Add(couldItBeQueued)
      }

      // Something about queues?
    }

---

### What is that?

#### C#

- Crap spaghetti code.

---

### What is that not?

#### C#

- Anything anyone that isn't NUTS wants to ever work with ever again..


***

### Making this a language feature...

--- 

#### Python

    [lang=cs]
    import asyncio
    import http_async

    from some_module import urls

    @asyncio.coroutine
    def access_the_interwebs(urls):
        client = http_async.HttpClient()
        for url in urls:
            result = yield from client.get(url)

    if __name__ == "__main__":
        loop = asyncio.get_event_loop()
        loop.run_until_complete(access_the_interwebs(urls))
        loop.close()

        print "Happy snake related dance."

---

#### Go

    [lang=cs]
    package main

    import "sync"
    import "fmt"
    import "time"

    func accessTheInterwebs(url string, wg *sync.WaitGroup) {
        resp, err := http.Get(url)

        wg.Done()

        return "More happy dancing, but in a go like way."
    }

    func doTheStuff(url []string) {
      var wg sync.WaitGroup

      for _, url := range urls {
        wg.Add(1)
        go accessTheInterwebs(url, &wg)
      }

      goOffAndDoSomethingElseLikeMakeTea()

      wg.Wait()
    }

---

#### Javascript (Node/IO)

    [lang=js]
    var q = require("q"),
        request = require("request");

    var accessTheInterwebs = function(url) {
      var q = q.defer();

      request(url, function(data) {
        q.resolve(data);
      }, function(err) {
        q.reject(err)
      });

      return q.promise;
    }

    var promises = [];
    for (var i = 0; i < urls.length; i++){
      promises.push(accessTheInterwebs("http://www.fancy-pants.net"))
    }

    this.GoOffAndDoSomethingElseLikeMakeTea();

    q.all(promises).then(function(){
      console.log("Happy Dance...")
    })

---

#### C#

    [lang=cs]
    public void AccessTheInterwebsWebAsync(IList<string> urls)
    { 
        var client = new HttpClient();
        var promises = new List<Task<string>>();

        foreach(url in urls) {
          promises.Add(client.GetStringAsync(url));
        }

        this.GoOffAndDoSomethingElseLikeMakeTea();

        Task.WaitAll(promises);

        return "Some kind of happy dance type status";
    }

***

## Solved....... Next!

#### What about two things trying to do things at the same time.

- Looks like we're back to threads?
- Who owns the state of the thing?
- We made it work once with queues?
- Isn't it queues that make node work?
- Yes, it is. 
- And talking between things using events.
- Right, on the queues.
- This is now not a list but a conversation.
- We're both Swedish and mental. Lets do something about this.

***

<iframe width="907" height="680" src="https://www.youtube.com/embed/xrIjfIjssLE?start=540" frameborder="0" allowfullscreen></iframe>

***

### Making this a whole language!

#### Erlang

    [lang=fs]
    -module(temperature).

    -author("jason@jasonds.co.uk").

    -export([temperatureConverter/0]).

    temperatureConverter() ->
     receive
     {toF, C} ->
     io:format("~p C is ~p F~n", [C, 32+C*9/5]),
     temperatureConverter();
     {toC, F} ->
     io:format("~p F is ~p C~n", [F, (F-32)*5/9]),
     temperatureConverter();
     {stop} ->
     io:format("Stopping~n");
     Other ->
     io:format("Unknown: ~p~n", [Other]),
     temperatureConverter()
     end.


    1> Pid = spawn(fun temperature:temperatureConverter/0).
    <0.128.0>
    2> Pid ! {toC, 32}.
    32F is 0.0 C
---

### What is that?

#### Erlang

### The Actor Model Incarnate

- Each module can be spawned as an Actor

- Each Actor has it's own execution context
    - Errors are trapped and no state is shared

- Actors communicate *ONLY* via messages
    - Each actor has a mailbox

- Actors can spawn other Actors
    - Actor parents are responsible for their children

---

#### Under the hood.

Scheduler takes jobs from a work queue, like a JS sort of thing (but 1 logical 'instance' can be multithreaded). 

Where there are multiple OS CPU cores/threads, each of these has it's own scheduler and work list. 

Schedulers steal work if they're starved. The runtime is written in assembler and uses Berkley sockets when talking remotely. 

Modules that are loaded are automagically versioned and can be reloaded while running. 

---

### What is that not?

#### Erlang

- Even remotely readable. 
- The development environment is not fun.
- The tooling is lame.

***

### If only there was some framework that exisited that could help us do this sort of hard and amazing thing in a cool language that we all and I know and love... like C#... or F#.....


***

## <div style="font-family: 'SFComicScript' !important; font-size: 300%;">AKKA.net</div>

#### Stolen from the WILDLY popular java framework, AKKA.

***

## Important Players

#### These folks are all the actors you get to start with.

### / - ... Or Root, for humans.

#### Executive producer.

### System - All the mechanics.

#### Producer

### User - Where your system lives.

#### Director

***

# <div style="font-family: 'SFComicScript' !important;">NOW SOME CODE!</div>

*)