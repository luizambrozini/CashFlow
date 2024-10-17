using CashFlow.Domain.Reports;
using ClosedXML.Excel;

namespace CashFlow.Application.UseCases.Expenses.Reports.Excel
{
    internal class GenerateExpensesReportExcelUseCase : IGenerateExpensesReportExcelUseCase
    {
        public async Task<byte[]> Execute(DateOnly month)
        {
            var workbook = new XLWorkbook();
            workbook.Author = "LVConsult";
            workbook.Style.Font.FontSize = 12;
            workbook.Style.Font.FontName = "Times New Roman";

            var woeksheet = workbook.Worksheets.Add($"Report_Expenses_{month.ToString("Y")}");


        }

        private void AddHeader(IXLWorksheet worksheet)
        {
            worksheet.Cell("A1").Value = ResourceReportGenerationMessages.TITLE;
            worksheet.Cell("B1").Value = ResourceReportGenerationMessages.DESCRIPTION;
            worksheet.Cell("C1").Value = ResourceReportGenerationMessages.DATE;
            worksheet.Cell("D1").Value = ResourceReportGenerationMessages.AMOUNT;
            worksheet.Cell("E1").Value = ResourceReportGenerationMessages.PAYMENT_TYPE;
        }
    }
}
