(**
- title : Coding Style
- description : Starting a fight with code style
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***

## Coding Style

### The final rekoning

***

#### Why do we care?

***

#### Increase readability. 

- Increase the consistency of writing. 
- The silhouette rule (moer on this later).

---

#### Increase maintainability. 

- Reduce repeated **business specification** code (where possible).
- Minimise acts of **syntax** condensing.

---

#### Increase quality. 

- Reduce the number of unnecessarily changed lines of code, as this can introduce bugs.

---

### Please wait till the end, this is basically a one way street to 
### Argument Town 
#### north of 
### Religious Flame War Ville 
#### on the river 
### Rage.

***

#### Readability
    
    [lang=cs]    
    /// Simple case is easy
    public class Thing : That
    {
        private readonly ISomething _something;

        public Thing(ISomething something) : base(string.Empty)
        {
            _something = something;
        }
    }

    /// Compex case is messy
    public class DoDah<T> : That, IDoStuff, IDoOtherStuff where T : new, IDooDeep
    {
        private readonly INonsense _nonsense;
        private readonly IOther _other;
        private readonly ISomething _something;

        public DoDah(ISomething something, IOther other, 
                INonsense nonsense) : base("Some string.")
        {
            _nonsense = nonsense;
            _something = something;
            _other = other;
        }
    }

---

    [lang=cs]   
    /// Simple case is unecessary 
    public class Thing : That
    {
        private readonly ISomething _something;

        public Thing(
            ISomething something) 
                : base(
                    string.Empty)
        {
            _something = something;
        }
    }
    
    /// But the complex case is consistent!
    public class DoDah<TSymantic> : That, IDoStuff, IDoOtherStuff
        where TSymantic : new, IDooDeep
    {
        private readonly ISomething _something;
        private readonly IOther _other;
        private readonly INonsense _nonsense;

        public DoDah(
            ISomething something, 
            IOther other, 
            INonsense nonsense) 
                : base(
                    "Some string.")
        {
            _something = something;
            _other = other;
            _nonsense = nonsense;
        }
    }

---

#### The silhouette rule
    
    [lang=python]    
    ####################

        ################

        ########
        ##########
        ##

        ################
            ######
            #########
        #####

        #############

- Can I make a guess on the symantic structure of the code from the physical structure?

---

    [lang=python]    
    #################### Namespace definition

        ################ Class definition

        ########         Constructor
            ######### ####
            #### ####

            ################ Conditional 
                ######
                #########

        #############    Method

***

#### Maintainability

    [lang=cs]    
    /// Harder to maintain
    public class Thing
    {
        public That DoSomething(int something) 
        {
            if (something < 5)
                return new That("Its less than five")

            return something > 10 ? new That("Its greater than ten") : new That();
        }
    }

    /// Easier to maintain
    public class Thing
    {
        public That DoSomething(int something) 
        {
            var answer = string.Empty;

            if (something < 5) {
                answer= "Its less than five";
            }

            if (something > 10) {
                answer= "Its greater than ten";
            }

            return new That(answer);
        }
    }

---

#### Add logging and change the constructor.

    [lang=cs]    
    /// <summary>
    /// New lines = 9
    /// Changed lines = 10
    /// </summary>
    public class Thing : WithLog
    {
        public That DoSomething(int something) 
        {
            if (something < 5) {
                Logger.LogTrace("Found answer, < 5");
                return new That("Its less than five", true)
            }

            if (something > 10) {
                Logger.LogTrace("Found answer, > 10");
                return new That("Its greater than ten", true)
            }

            Logger.LogTrace("Didnt find answer");
            return new That(string.Empty, false);
        }
    }

---

#### Ok, so higher cyclic complexity...

    [lang=cs] 
    /// <summary>
    /// New lines = 6
    /// Changed lines = 5
    /// </summary>
    public class Thing : WithLog
    {
        public That DoSomething(int something) 
        {
            var answer = string.Empty;

            if (something < 5) {
                Logger.LogTrace("Found answer, < 5");
                answer = "Its less than five";
            }

            if (something > 10) {
                Logger.LogTrace("Found answer, > 10");
                answer = "Its greater than ten";
            }

            var noAnswer = string.IsNullOrEmpty(answer);
            if (noAnswer) {
                Logger.LogTrace("Didnt find answer");
            }

            return new That(answer, noAnswer);
        }
    }

***

# So.

---

# Long story short.

---
    [lang=cs] 
    /// <summary>
    /// No new line
    /// </summary>
    public class Thing 
    {
        private static bool prFlipFlop = false;

        public void CompletePullRequest(CodeChange change) 
        {
            if (prFlipFlop) {
                change.AddNewLines();
            } else {
                change.RemoveNewLines();
            }

            prFlipFlop = !prFlipFlop;
        }
    }

---

## OR

---

    [lang=cs] 
    /// <summary>
    /// With new line
    /// </summary>
    public class Thing 
    {
        private static bool prFlipFlop = false;

        public void CompletePullRequest(CodeChange change) 
        {
            if (prFlipFlop) 
            {
                change.AddNewLines();
            } 
            else 
            {
                change.RemoveNewLines();
            }

            prFlipFlop = !prFlipFlop;
        }
    }
*)