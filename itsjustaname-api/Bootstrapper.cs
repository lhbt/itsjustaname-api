using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace itsjustaname_api
{
    using Nancy;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            
        }
    }
}