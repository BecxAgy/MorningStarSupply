using FastReport.Export.PdfSimple;
using Microsoft.AspNetCore.Mvc;
using MorningStarSupply.Services;

namespace MorningStarSupply.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly RelatorioService service;
        private readonly IWebHostEnvironment _webHostEnv;

        public RelatorioController(RelatorioService service, IWebHostEnvironment webHostEnv)
        {
            this.service = service;
            _webHostEnv = webHostEnv;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RelatorioEntrada(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }


            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\ReportMvc.frx");
            var reportFile = caminhoReport;
            var freport = new FastReport.Report();
            var entradas = await service.FindByDateAsync(minDate, maxDate);

            freport.Report.Load(reportFile);
            freport.Dictionary.RegisterBusinessObject(entradas, "ListaEntradas", 10, true);
            //freport.Report.Save(reportFile);
            freport.Prepare();

            var pdfExport = new PDFSimpleExport();

            using MemoryStream ms = new MemoryStream();
            pdfExport.Export(freport, ms);
            ms.Flush();

            return File(ms.ToArray(), "application/pdf");



        }

        public async Task<IActionResult> RelatorioSaida(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }



            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\ReportMvc.frx");
            var reportFile = caminhoReport;
            var freport = new FastReport.Report();
            var saidas = await service.FindSaidasByDateAsync(minDate, maxDate);

            freport.Report.Load(reportFile);
            freport.Dictionary.RegisterBusinessObject(saidas, "ListaEntradas", 10, true);
            //freport.Report.Save(reportFile);
            freport.Prepare();

            var pdfExport = new PDFSimpleExport();

            using MemoryStream ms = new MemoryStream();
            pdfExport.Export(freport, ms);
            ms.Flush();

            return File(ms.ToArray(), "application/pdf");


        }
    }
}
