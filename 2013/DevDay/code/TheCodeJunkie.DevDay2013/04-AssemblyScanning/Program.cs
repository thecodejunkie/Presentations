namespace TheCodeJunkie.DevDay2013.AssemblyScanning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var fwk = new Framework();

            Console.WriteLine(fwk.Greet("sv-SE"));
            Console.WriteLine(fwk.Greet("en-US"));

            Console.ReadLine();
        }
    }

    public class Framework
    {
        public Framework()
        {
            this.Greeters = AppDomainScanner
                .TypesOf<IGreeter>()
                .Select(type => (IGreeter)Activator.CreateInstance(type));
        }

        public string Greet(string cultureName)
        {
            var greeter = 
                this.Greeters.FirstOrDefault(x => x.HandlesCulture(cultureName));

            if (greeter == null)
            {
                return string.Concat("Únable to provide a greeting for culture ", cultureName);
            }

            return greeter.Greet();
        }

        private IEnumerable<IGreeter> Greeters { get; set; }
    }

    public interface IGreeter
    {
        bool HandlesCulture(string cultureName);

        string Greet();
    }

    public class AppDomainScanner
    {
        public static IEnumerable<Type> TypesOf<T>()
        {
            var locatedTypes =
                from assembly in AppDomain.CurrentDomain.GetAssemblies()
                where !assembly.IsDynamic
                from type in assembly.GetExportedTypes()
                where typeof(T).IsAssignableFrom(type)
                where !type.IsAbstract
                where type.IsPublic
                select type;

            return locatedTypes;
        }
    }

    public class SwedishGreeter : IGreeter
    {
        public bool HandlesCulture(string cultureName)
        {
            return cultureName.Equals("sv-SE");
        }

        public string Greet()
        {
            return "Hej!";
        }
    }

    public class EnglishGreeter : IGreeter
    {
        public bool HandlesCulture(string cultureName)
        {
            return cultureName.Equals("en-US");
        }

        public string Greet()
        {
            return "Hello!";
        }
    }
}
