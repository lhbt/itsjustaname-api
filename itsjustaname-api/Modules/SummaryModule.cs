using AutoMapper;
using itsjustaname_api.Services.Interfaces;
using itsjustaname_api.ViewModels;
using Nancy;

namespace itsjustaname_api.Modules
{
    public class SummaryModule : NancyModule
    {
        private readonly IMapper _mapper;
        private readonly ISummaryService _summaryService;

        public SummaryModule(ISummaryService summaryService, IMapper mapper)
        {
            _summaryService = summaryService;
            _mapper = mapper;

            Get["/summary"] = _ =>
            {
                var summaryModel = _summaryService.GetSummary();

                var summaryViewModel = new SummaryViewModel();

                _mapper.Map(summaryModel, summaryViewModel);

                return Response.AsJson(summaryViewModel);
            };
        }
    }
}