using Autofac.Extras.Moq;
using Moq;

namespace AzStore.Test
{
    public abstract class FactBase
    {
        private readonly AutoMock _autoMocker;

        public virtual T CreateSut<T>() where T : class
        {
            return _autoMocker.Create<T>();
        }
     
        protected FactBase()
        {
            _autoMocker = AutoMock.GetLoose();
        }
     
        protected Mock<TDependency> MockFor<TDependency>() where TDependency : class
        {
            return _autoMocker.Mock<TDependency>();
        }
      
        protected void RegisterDependency<TDependency>(TDependency dependency) where TDependency : class
        {
            _autoMocker.Provide(dependency);
        }
    }
}