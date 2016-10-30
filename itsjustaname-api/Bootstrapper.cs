using itsjustaname_api.Services;
using itsjustaname_api.Services.Interfaces;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace itsjustaname_api
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            var mapper = MapperConfig.Initialise();
            container.Register(mapper);
            container.Register<IEbayService, EbayService>();
        }
    }
}