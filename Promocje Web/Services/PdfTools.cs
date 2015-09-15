using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Hosting;

namespace Promocje_Web.Services
{
    public class PdfTools
    {
        static public void PDFToImages(string file, string outputDirectory, int dpi)
        {
            //string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            //path + @"\libs\gsdll32.dll"
            Ghostscript.NET.Rasterizer.GhostscriptRasterizer rasterizer = null;
            Ghostscript.NET.GhostscriptVersionInfo vesion = new Ghostscript.NET.GhostscriptVersionInfo(new Version(0, 0, 0), HostingEnvironment.MapPath("~/Libs/gsdll32.dll") , string.Empty, Ghostscript.NET.GhostscriptLicense.GPL);

            using (rasterizer = new Ghostscript.NET.Rasterizer.GhostscriptRasterizer())
            {
                rasterizer.Open(file, vesion, false);

                for (int i = 1; i <= rasterizer.PageCount; i++)
                {
                    string pageFilePath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + "-p" + i.ToString() + ".jpg");

                    Image img = rasterizer.GetPage(dpi, dpi, i);
                    img.Save(pageFilePath, ImageFormat.Jpeg);
                }

                rasterizer.Close();
            }
        }
    }
}