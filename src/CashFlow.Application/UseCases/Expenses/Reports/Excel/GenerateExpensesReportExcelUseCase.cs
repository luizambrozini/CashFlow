using CashFlow.Domain.Reports;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

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

            var worksheet = workbook.Worksheets.Add($"Report_Expenses_{month.ToString("Y")}");
            AddHeader(worksheet);

            var file = new MemoryStream();
            workbook.SaveAs(file);

            return file.ToArray();
        }

        private void AddHeader(IXLWorksheet worksheet)
        {
            worksheet.Cell("A1").Value = ResourceReportGenerationMessages.TITLE;
            worksheet.Cell("B1").Value = ResourceReportGenerationMessages.DESCRIPTION;
            worksheet.Cell("C1").Value = ResourceReportGenerationMessages.DATE;
            worksheet.Cell("D1").Value = ResourceReportGenerationMessages.AMOUNT;
            worksheet.Cell("E1").Value = ResourceReportGenerationMessages.PAYMENT_TYPE;

            worksheet.Cells("A1:E1").Style.Font.Bold = true;
            worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#F5c2b6");

            worksheet.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

        }
    }
}
