namespace TheCodeJunkie.DevSum2013.Bootstrapping
{
    using System;
    using System.Collections.Generic;

    public interface IBootstrapper
    {
        IValidator GetValidator();
    }

    public abstract class Bootstrapper<TContainer> : IBootstrapper
    {
        private bool isInitialized;

        public IValidator GetValidator()
        {
            if (!this.isInitialized)
            {
                this.Initialize();
            }

            return this.GetValidator(this.ApplicationContainer);
        }

        protected TContainer ApplicationContainer { get; set; }

        protected abstract TContainer GetApplicationContainer();

        protected abstract IValidator GetValidator(TContainer container);

        protected abstract void RegisterValidator(TContainer container, Type validatorType);

        protected abstract void RegisterValidatorRules(TContainer container, IEnumerable<Type> validatorRuleTypes);

        protected virtual void ConfigureApplicationContainer(TContainer container)
        {
        }

        protected virtual Type Validator
        {
            get { return typeof(DefaultValidator); }
        }

        protected virtual IEnumerable<Type> ValidatorRules
        {
            get { return AppDomainScanner.Types<IValidatorRule>(); }
        }

        private void Initialize()
        {
            this.ApplicationContainer = this.GetApplicationContainer();
            this.RegisterValidator(this.ApplicationContainer, this.Validator);
            this.RegisterValidatorRules(this.ApplicationContainer, this.ValidatorRules);      
            this.ConfigureApplicationContainer(this.ApplicationContainer);
            this.isInitialized = true;
        }
    }
}