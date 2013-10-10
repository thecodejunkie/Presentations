namespace TheCodeJunkie.Leetspeak.Bootstrapping
{
    using System;
    using System.Collections.Generic;
    using TinyIoC;

    public class DefaultBootstrapper : Bootstrapper<TinyIoCContainer>
    {
        protected override TinyIoCContainer GetApplicationContainer()
        {
            return new TinyIoCContainer();
        }

        protected override IValidator GetValidator(TinyIoCContainer container)
        {
            return container.Resolve<IValidator>();
        }

        protected override void RegisterValidator(TinyIoCContainer container, Type validatorType)
        {
            container.Register(typeof(IValidator), validatorType).AsSingleton();
        }

        protected override void RegisterValidatorRules(TinyIoCContainer container, IEnumerable<Type> validatorRuleTypes)
        {
            container.RegisterMultiple(typeof(IValidatorRule), validatorRuleTypes);
        }
    }
}