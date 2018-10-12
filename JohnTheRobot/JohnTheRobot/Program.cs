using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnTheRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            //Defined code in the question
        }
    }


    public abstract class Skill
    {
        public abstract string ShowSkill();
    }

    public class Dancing : Skill
    {
        public override string ShowSkill()
        {
            return "dancing";
        }
    }

    public class Cooking : Skill
    {
        public override string ShowSkill()
        {
            return "cooking";
        }
    }

    class Humanoid
    {
        public Skill skill;

        public Humanoid(Skill s)
        {
            skill = s;
        }

        public Humanoid()
        { }

        public string ShowSkill()
        {
            if (skill == null)
                return "no skill is defined";
            return skill.ShowSkill();
        }
    }

}
