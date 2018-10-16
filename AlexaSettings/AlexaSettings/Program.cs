using System;

namespace AlexaSettings
{
    class Program
    {
        static void Main(string[] args)
        {
           var alexa = new Alexa();
            Console.WriteLine(alexa.Talk()); //print hello, i am Alexa

            //delegate as a parameter of a method
            alexa.Configure(x=>
            {
                x.GreetingMessage = "Hello {OwnerName}, I'm at your service";
                x.OwnerName = "Bob Marley";
            });

            Console.WriteLine(alexa.Talk()); //print Hello Bob Marley, I'm at your service

            Console.WriteLine("press any key to exit ...");
            Console.ReadKey();
        }
    }

    delegate void delConfigureAlexa(Alexa a); // declare the delegate
    public class Alexa
    {
        public string GreetingMessage = "hello, i am Alexa";
        public string OwnerName;

        public string Talk(){
            var result = GreetingMessage.Replace("{OwnerName}", OwnerName);
            return result;
        }

        internal void Configure(delConfigureAlexa d)
        {
            Alexa a = new Alexa();

            //invoke the delegate, after invoking the delegate it assigns the class variable 
            //with new values inside delegate,string interpolation variable is replaced with
            //the desired value
            d.Invoke(a);

            //newly assigned values of class variable is then set to class variable
            //so that updated values can be accessed inside the Talk()
            GreetingMessage = a.GreetingMessage;
            OwnerName = a.OwnerName;
        }
    }

}
