using MaktabNews.Domain.Core.Contracts.AppServices;
using MaktabNews.Domain.Core.Contracts.AppServifces;
using MaktabNews.Domain.Core.Dtos.News;
using MaktabNews.Domain.Core.Dtos.Reporter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaktabNews.RazorPages.Pages.News
{
    public class DetailsModel : PageModel
    {
        private readonly INewsAppServices _newsAppServices;
        private readonly IReporterAppServices _reporterAppServices;  

        public DetailsModel(INewsAppServices newsAppServices,
            IReporterAppServices reporterAppServices)
        {
            _newsAppServices = newsAppServices;
            _reporterAppServices = reporterAppServices;
        }

        [BindProperty]
        public NewsDetailsDto News { get; set; }

        [BindProperty]
        public ReporterSummeryDto Reporter { get; set; }

        public async Task OnGet(int id,CancellationToken cancellationToken)
        {
            News = await _newsAppServices.GetDetails(id, cancellationToken);
            Reporter = await _reporterAppServices.GetSummery(News.ReporterId, cancellationToken);
        }
    }
}
