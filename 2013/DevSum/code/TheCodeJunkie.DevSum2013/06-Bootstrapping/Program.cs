namespace TheCodeJunkie.DevSum2013.Bootstrapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var result = 
                Framework.Validate(new object());

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }

    public interface IValidatorRule
    {
        bool Evaluate(object source);
    }

    public interface IValidator
    {
       bool Validate(object source);
    }

    public class DefaultValidator : IValidator
    {
        private readonly IEnumerable<IValidatorRule> rules;

        public DefaultValidator(IEnumerable<IValidatorRule> rules)
        {
            this.rules = rules;
        }

        public bool Validate(object source)
        {
            return this.rules.All(x => x.Evaluate(source));
        }
    }

    public class NotNullValidatorRule : IValidatorRule
    {
        public bool Evaluate(object source)
        {
            return source != null;
        }
    }

    //public class CustomValidator : IValidator
    //{
    //    private readonly IFoo foo;

    //    public CustomValidator(IFoo foo)
    //    {
    //        this.foo = foo;
    //    }

    //    public bool Validate(object source)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public interface IFoo
    //{
    //}

    //public class Foo : IFoo
    //{
    //}

    //public class Bootstrapper : DefaultBootstrapper
    //{
    //    protected override Type Validator
    //    {
    //        get
    //        {
    //            return typeof(CustomValidator);
    //        }
    //    }

    //    protected override void ConfigureApplicationContainer(TinyIoC.TinyIoCContainer container)
    //    {
    //        container.Register(typeof (IFoo), typeof (Foo));
    //        base.ConfigureApplicationContainer(container);
    //    }
    //}

    public class Framework
    {
        private static IValidator validator;

        private static IValidator Validator
        {
            get { return validator ?? (validator = BootstrapperLocator.Bootstrapper.GetValidator()); }
        }

        public static bool Validate(object source)
        {
            return Validator.Validate(source);
        }
    }
}
