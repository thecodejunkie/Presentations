namespace TheCodeJunkie.DevDay2013.Dynamics
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;

    class Program
    {
        static void Main(string[] args)
        {
            dynamic helper =
                new Capitalizer();

            helper.name = "Nancy";
            helper.description = "A lightweight framework that will rock your socks!";

            Console.WriteLine(helper.name);
            Console.WriteLine(helper.description);

            Console.ReadLine();
        }
    }
   
    public class Capitalizer : DynamicObject
    {
        private readonly IDictionary<string, string> values;

        public Capitalizer()
        {
            this.values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = this.values[binder.Name].ToUpper();
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            this.values[binder.Name] = (string)value;
            return true;
        }
    }
}
