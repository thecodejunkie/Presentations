namespace TheCodeJunkie.DevSum2013.Conventions
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    class Program
    {
        static void Main()
        {
            var fwk = new Framework();

            fwk.ViewConventions = new List<Func<string, string>>
            {
                viewName => {
                    return string.Concat("views/shared/", viewName);
                },

                viewName => {
                    return string.Concat("views/", viewName);
                }
            };
            
            Console.WriteLine(fwk.GetView("index.html"));
            Console.WriteLine(fwk.GetView("shared.html"));
            Console.WriteLine(fwk.GetView("foo.html"));

            Console.ReadLine();
        }
    }

    public class Framework
    {
        public Framework()
        {
            this.ViewConventions = new List<Func<string, string>>();
        }

        public IList<Func<string, string>> ViewConventions { get; set; }

        public string GetView(string viewName)
        {
            foreach (var viewConvention in ViewConventions)
            {
                var location = Path.Combine(
                    Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
                    viewConvention.Invoke(viewName));

                if (File.Exists(location))
                {
                    return location;
                }
            }

            return "The view could not be located :(";
        }
    }
}
