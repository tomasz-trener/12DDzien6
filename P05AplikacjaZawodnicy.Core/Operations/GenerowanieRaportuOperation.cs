using P05AplikacjaZawodnicy.Core.Domains;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05AplikacjaZawodnicy.Core.Operations
{
    public class GenerowanieRaportuOperation
    {
        public void GenerujRaport(Zawodnik[] zawodnicy, string filename)
        {
            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Raport zawodnicy";

            // Create an empty page
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);

            // Draw the text
            for (int i = 0; i < zawodnicy.Length; i++)
            {
                gfx.DrawString(zawodnicy[i].Imie + " " + zawodnicy[i].Nazwisko, font, XBrushes.Black, 30, 20 + i * 20);
                if (File.Exists($"flagi\\{zawodnicy[i].Kraj.ToLower()}.jpg"))
                {
                    XImage image = XImage.FromFile($"flagi\\{zawodnicy[i].Kraj.ToLower()}.jpg");
                    gfx.DrawImage(image, 10, 20 + i * 20, 10,10);
                }
            }



            // Save the document...
           
            document.Save(filename);
            // ...and start a viewer.
        }


    }
}
