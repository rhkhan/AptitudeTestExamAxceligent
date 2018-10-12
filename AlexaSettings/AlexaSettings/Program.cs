using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaSettings
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }


    public class Alexa : ConfigurationSection
    {
        [ConfigurationProperty("greetingmsg", DefaultValue = "hello, i am Alexa")]
        public string GreeetingMessage
        {
            get
            {
                return (string)this["greetingmsg"];
            }
            set
            {
                this["greetingmsg"] = value;
            }
        }

        [ConfigurationProperty("ownername")]
        public string OwnerName
        {
            get
            {
                return (string)this["ownername"];
            }
            set
            {
                this["ownername"] = value;
            }
        }

        public string Talk()
        {
            return GreeetingMessage;
        }

    }

}
