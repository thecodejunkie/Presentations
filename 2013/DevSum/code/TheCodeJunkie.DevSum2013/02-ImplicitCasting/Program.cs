namespace TheCodeJunkie.DevSum2013.ImplicitCasting
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var app =
                new Framework();

            Console.WriteLine(app.ReturnContentResult());
            Console.WriteLine(app.ReturnStatusCodeResult());

            Console.ReadLine();
        }
    }

    public class Framework
    {
        public Result ReturnContentResult()
        {
            return "Hello world!";
        }

        public Result ReturnStatusCodeResult()
        {
            return 200;
        }
    }

    public class Result
    {
        public int StatusCode { get; set; }

        public string Content { get; set; }

        public override string ToString()
        {
            return string.Concat("StatusCode: ", this.StatusCode, ", Content: ", this.Content);
        }

        public static implicit operator Result(int statusCode)
        {
            return new Result { StatusCode = statusCode };
        }

        public static implicit operator Result(string content)
        {
            return new Result { Content = content };
        }
    }
}
