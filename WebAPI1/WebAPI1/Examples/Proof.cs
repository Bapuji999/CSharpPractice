using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace WebAPI1.Examples
{
    public interface IProof
    {
        public string GetProof();
    }
    public class Proof : IProof
    {
        private readonly ISingle single;
        private readonly IScope scope;
        private readonly ITrans trans;
        public Proof(IScope _scop, ITrans _trans, ISingle _single)
        {
            single = _single;
            scope = _scop;
            trans = _trans;
        }
        public string GetProof()
        {
            return $"Single: {single.GetCallNo()}, Scope: {scope.GetCallNo()}, Trans: {trans.GetCallNo()}";
        }
        public void ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.Replace(new ServiceDescriptor(typeof(ISingle), typeof(ITrans), ServiceLifetime.Singleton));
        }
    }
}