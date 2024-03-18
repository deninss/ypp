using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Classes
{
    public class PDF
    {
        public static void CreatePDF(string number, string Date, string equipment, string Time, string Materials, string Price)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 16, XFontStyle.Bold);
            XFont font2 = new XFont("Verdana", 14, XFontStyle.Regular);
            gfx.DrawString("Отчёт о выполненной работе", font, XBrushes.Black,
                new XRect(0, 50, page.Width, page.Height), XStringFormats.TopCenter);
            gfx.DrawString($"№{number}", font2, XBrushes.Black,
                new XRect(20, 90, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString(Date, font2, XBrushes.Black,
                new XRect(20, 115, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Отремонтировано оборудование: {equipment}", font2, XBrushes.Black,
                new XRect(20, 140, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Время: {Time}", font2, XBrushes.Black,
                new XRect(20, 165, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Материалы: {Materials}", font2, XBrushes.Black,
                new XRect(20, 190, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Стоимость: {Price}", font2, XBrushes.Black,
                new XRect(20, 215, page.Width, page.Height), XStringFormats.TopLeft);
            string filename = $"Report[{number}].pdf";
            document.Save(filename);
            Process.Start(filename);
        }
    }
}
