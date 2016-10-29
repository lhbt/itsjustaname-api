using System.Linq;
using AutoMapper;
using itsjustaname_api.Repositories;
using itsjustaname_api.Services;
using itsjustaname_api.ViewModels;
using Nancy;

namespace itsjustaname_api
{
    public class SummaryModule : NancyModule
    {
        private readonly ISummaryService _summaryService;
        private readonly IMapper _mapper;

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