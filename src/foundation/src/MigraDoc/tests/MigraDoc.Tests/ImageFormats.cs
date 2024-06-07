// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

using System.Runtime.InteropServices;
using PdfSharp.Pdf.IO;
using PdfSharp.TestHelper;
using PdfSharp.Pdf;
using PdfSharp.Quality;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Fields;
using MigraDoc.Rendering;
using Xunit;
#if CORE
using PdfSharp.Fonts;
using PdfSharp.Snippets.Font;
#endif
#if WPF
using System.IO;
#endif

namespace MigraDoc.Tests
{
    [Collection("PDFsharp")]
    public class ImageFormats
    {
        [Fact]
#if WPF
        public void Test_Image_Formats_Wpf()
#elif GDI
        public void Test_Image_Formats_Gdi()
#else
        public void Test_Image_Formats()
#endif
        {
            // Create a MigraDoc document.
            var document = CreateDocument(true);

            // ----- Unicode encoding in MigraDoc is demonstrated here. -----

            // Create a renderer for the MigraDoc document.
            var pdfRenderer = new PdfDocumentRenderer()
            {
                // Associate the MigraDoc document with a renderer.
                Document = document
            };

            // Layout and render document to PDF.
            pdfRenderer.RenderDocument();

            // Save the document...
            var filename = PdfFileUtility.GetTempPdfFileName("Image_Formats");
            pdfRenderer.PdfDocument.Save(filename);
            // ...and start a viewer.
            PdfFileUtility.ShowDocumentIfDebugging(filename);
        }

        [Fact]
#if WPF
        public void Test_Image_BASE64_Wpf()
#elif GDI
        public void Test_Image_BASE64_Gdi()
#else
        public void Test_Image_BASE64()
#endif
        {
            // Create a MigraDoc document.
            var document = CreateDocument(false);

            // Associate the MigraDoc document with a renderer.
            var pdfRenderer = new PdfDocumentRenderer
            {
                Document = document,
                PdfDocument =
                {
                    PageLayout = PdfPageLayout.SinglePage
                }
            };

            //The string from my memorystream, as it was generated by function: static string MigraDocFilenameFromByteArray(byte[] image)
            string StrFromMS = @"base64:Qk3GMwAAAAAAADYAAAAoAAAAQgAAAEIAAAABABgAAAAAAJAzAADEDgAAxA4AAAAAAAAAAAAA////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////AAD///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////8AAP///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////wAA////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////AAD///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////8AAP///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////wAA////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////AAD///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////8AAP///////////////////////////////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///////wAAAAAAAAAAAAAAAAAAAAAAAP///////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///////////////////////////////wAA////////////////////////////////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////////AAAAAAAAAAAAAAAAAAAAAAAA////////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////////////////////////////////AAD///////////////////////////////8AAAAAAAD///////////////////////////////////////8AAAAAAAD///////////////8AAAAAAAAAAAAAAAD///////8AAAAAAAAAAAAAAAD///////////////////////////////8AAAAAAAAAAAAAAAD///////////////////////8AAAAAAAD///////////////////////////////////////8AAP///////////////////////////////wAAAAAAAP///////////////////////////////////////wAAAAAAAP///////////////wAAAAAAAAAAAAAAAP///////wAAAAAAAAAAAAAAAP///////////////////////////////wAAAAAAAAAAAAAAAP///////////////////////wAAAAAAAP///////////////////////////////////////wAA////////////////////////////////AAAAAAAA////////AAAAAAAAAAAAAAAAAAAAAAAA////////AAAAAAAA////////AAAAAAAA////////AAAAAAAAAAAAAAAAAAAAAAAA////////AAAAAAAA////////AAAAAAAA////////AAAAAAAAAAAAAAAAAAAAAAAA////////////////////////AAAAAAAA////////////////////////////////AAD///////////////////////////////8AAAAAAAD///////8AAAAAAAAAAAAAAAAAAAAAAAD///////8AAAAAAAD///////8AAAAAAAD///////8AAAAAAAAAAAAAAAAAAAAAAAD///////8AAAAAAAD///////8AAAAAAAD///////8AAAAAAAAAAAAAAAAAAAAAAAD///////////////////////8AAAAAAAD///////////////////////////////8AAP///////////////////////////////wAAAAAAAP///////wAAAAAAAAAAAAAAAAAAAAAAAP///////wAAAAAAAP///////////////////////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///////wAAAAAAAP///////////////////////////////////////wAAAAAAAP///////////////////////////////////////////////wAA////////////////////////////////AAAAAAAA////////AAAAAAAAAAAAAAAAAAAAAAAA////////AAAAAAAA////////////////////////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////////AAAAAAAA////////////////////////////////////////AAAAAAAA////////////////////////////////////////////////AAD///////////////////////////////8AAAAAAAD///////8AAAAAAAAAAAAAAAAAAAAAAAD///////8AAAAAAAD///////8AAAAAAAD///////////////////////8AAAAAAAAAAAAAAAAAAAAAAAD///////8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD///////8AAAAAAAAAAAAAAAAAAAAAAAD///////////////////////////////8AAP///////////////////////////////wAAAAAAAP///////wAAAAAAAAAAAAAAAAAAAAAAAP///////wAAAAAAAP///////wAAAAAAAP///////////////////////wAAAAAAAAAAAAAAAAAAAAAAAP///////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///////wAAAAAAAAAAAAAAAAAAAAAAAP///////////////////////////////wAA////////////////////////////////AAAAAAAA////////////////////////////////////////AAAAAAAA////////////////////////////////AAAAAAAA////////AAAAAAAAAAAAAAAA////////AAAAAAAA////////////////////////AAAAAAAA////////////////////////AAAAAAAA////////////////////////////////AAD///////////////////////////////8AAAAAAAD///////////////////////////////////////8AAAAAAAD///////////////////////////////8AAAAAAAD///////8AAAAAAAAAAAAAAAD///////8AAAAAAAD///////////////////////8AAAAAAAD///////////////////////8AAAAAAAD///////////////////////////////8AAP///////////////////////////////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///////////////wAAAAAAAAAAAAAAAP///////////////////////////////////////wAAAAAAAP///////wAAAAAAAP///////wAAAAAAAAAAAAAAAP///////wAAAAAAAAAAAAAAAP///////////////////////////////wAA////////////////////////////////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////////////////AAAAAAAAAAAAAAAA////////////////////////////////////////AAAAAAAA////////AAAAAAAA////////AAAAAAAAAAAAAAAA////////AAAAAAAAAAAAAAAA////////////////////////////////AAD///////////////////////////////////////////////////////////////////////////////////////////////8AAAAAAAD///////8AAAAAAAAAAAAAAAD///////8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD///////////////////////8AAAAAAAD///////8AAAAAAAD///////////////////////////////////////////////8AAP///////////////////////////////////////////////////////////////////////////////////////////////wAAAAAAAP///////wAAAAAAAAAAAAAAAP///////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///////////////////////wAAAAAAAP///////wAAAAAAAP///////////////////////////////////////////////wAA////////////////////////////////AAAAAAAA////////////////AAAAAAAA////////////////AAAAAAAAAAAAAAAAAAAAAAAA////////AAAAAAAAAAAAAAAA////////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////////AAAAAAAA////////AAAAAAAA////////////////////////////////AAD///////////////////////////////8AAAAAAAD///////////////8AAAAAAAD///////////////8AAAAAAAAAAAAAAAAAAAAAAAD///////8AAAAAAAAAAAAAAAD///////8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD///////8AAAAAAAD///////8AAAAAAAD///////////////////////////////8AAP///////////////////////////////////////wAAAAAAAP///////////////wAAAAAAAAAAAAAAAP///////wAAAAAAAP///////////////wAAAAAAAP///////wAAAAAAAAAAAAAAAP///////////////wAAAAAAAP///////wAAAAAAAP///////////////////////////////wAAAAAAAAAAAAAAAP///////////////////////////////wAA////////////////////////////////////////AAAAAAAA////////////////AAAAAAAAAAAAAAAA////////AAAAAAAA////////////////AAAAAAAA////////AAAAAAAAAAAAAAAA////////////////AAAAAAAA////////AAAAAAAA////////////////////////////////AAAAAAAAAAAAAAAA////////////////////////////////AAD///////////////////////////////8AAAAAAAD///////8AAAAAAAAAAAAAAAD///////////////8AAAAAAAAAAAAAAAD///////8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD///////8AAAAAAAD///////8AAAAAAAD///////////////8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD///////////////////////////////8AAP///////////////////////////////wAAAAAAAP///////wAAAAAAAAAAAAAAAP///////////////wAAAAAAAAAAAAAAAP///////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///////wAAAAAAAP///////wAAAAAAAP///////////////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///////////////////////////////wAA////////////////////////////////////////AAAAAAAA////////////////////////AAAAAAAA////////AAAAAAAA////////////////////////AAAAAAAAAAAAAAAA////////AAAAAAAAAAAAAAAAAAAAAAAA////////AAAAAAAA////////////////////////AAAAAAAA////////////////////////////////////////////////AAD///////////////////////////////////////8AAAAAAAD///////////////////////8AAAAAAAD///////8AAAAAAAD///////////////////////8AAAAAAAAAAAAAAAD///////8AAAAAAAAAAAAAAAAAAAAAAAD///////8AAAAAAAD///////////////////////8AAAAAAAD///////////////////////////////////////////////8AAP///////////////////////////////////////wAAAAAAAP///////wAAAAAAAAAAAAAAAP///////wAAAAAAAP///////////////////////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///////////////////////wAAAAAAAP///////wAAAAAAAP///////wAAAAAAAAAAAAAAAAAAAAAAAP///////////////////////////////wAA////////////////////////////////////////AAAAAAAA////////AAAAAAAAAAAAAAAA////////AAAAAAAA////////////////////////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////////////////////////AAAAAAAA////////AAAAAAAA////////AAAAAAAAAAAAAAAAAAAAAAAA////////////////////////////////AAD///////////////////////////////////////8AAAAAAAAAAAAAAAAAAAAAAAD///////8AAAAAAAD///////8AAAAAAAAAAAAAAAAAAAAAAAD///////////////////////8AAAAAAAAAAAAAAAD///////////////8AAAAAAAAAAAAAAAD///////////////////////////////////////8AAAAAAAD///////////////////////////////8AAP///////////////////////////////////////wAAAAAAAAAAAAAAAAAAAAAAAP///////wAAAAAAAP///////wAAAAAAAAAAAAAAAAAAAAAAAP///////////////////////wAAAAAAAAAAAAAAAP///////////////wAAAAAAAAAAAAAAAP///////////////////////////////////////wAAAAAAAP///////////////////////////////wAA////////////////////////////////////////AAAAAAAA////////////////AAAAAAAAAAAAAAAAAAAAAAAA////////AAAAAAAA////////AAAAAAAAAAAAAAAA////////AAAAAAAAAAAAAAAA////////AAAAAAAA////////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////////////////////////////////AAD///////////////////////////////////////8AAAAAAAD///////////////8AAAAAAAAAAAAAAAAAAAAAAAD///////8AAAAAAAD///////8AAAAAAAAAAAAAAAD///////8AAAAAAAAAAAAAAAD///////8AAAAAAAD///////8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD///////////////////////////////8AAP///////////////////////////////////////////////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///////////////wAAAAAAAP///////////////////////////////wAAAAAAAAAAAAAAAP///////////////wAAAAAAAP///////////////////////////////wAAAAAAAAAAAAAAAP///////////////////////////////////////wAA////////////////////////////////////////////////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////////////////AAAAAAAA////////////////////////////////AAAAAAAAAAAAAAAA////////////////AAAAAAAA////////////////////////////////AAAAAAAAAAAAAAAA////////////////////////////////////////AAD///////////////////////////////8AAAAAAAD///////8AAAAAAAD///////8AAAAAAAD///////8AAAAAAAD///////////////8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD///////////////////////////////8AAAAAAAD///////////////8AAAAAAAD///////////////////////////////////////8AAP///////////////////////////////wAAAAAAAP///////wAAAAAAAP///////wAAAAAAAP///////wAAAAAAAP///////////////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///////////////////////////////wAAAAAAAP///////////////wAAAAAAAP///////////////////////////////////////wAA////////////////////////////////////////////////////////////////////////////////////////////////////////AAAAAAAA////////////////AAAAAAAAAAAAAAAA////////AAAAAAAAAAAAAAAA////////////////////////////////////////////////////////////////////////////////////////////////AAD///////////////////////////////////////////////////////////////////////////////////////////////////////8AAAAAAAD///////////////8AAAAAAAAAAAAAAAD///////8AAAAAAAAAAAAAAAD///////////////////////////////////////////////////////////////////////////////////////////////8AAP///////////////////////////////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///////wAAAAAAAP///////wAAAAAAAP///////wAAAAAAAP///////wAAAAAAAP///////wAAAAAAAP///////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///////////////////////////////wAA////////////////////////////////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////////AAAAAAAA////////AAAAAAAA////////AAAAAAAA////////AAAAAAAA////////AAAAAAAA////////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////////////////////////////////AAD///////////////////////////////8AAAAAAAD///////////////////////////////////////8AAAAAAAD///////////////8AAAAAAAD///////////////8AAAAAAAAAAAAAAAD///////8AAAAAAAAAAAAAAAD///////8AAAAAAAD///////////////////////////////////////8AAAAAAAD///////////////////////////////8AAP///////////////////////////////wAAAAAAAP///////////////////////////////////////wAAAAAAAP///////////////wAAAAAAAP///////////////wAAAAAAAAAAAAAAAP///////wAAAAAAAAAAAAAAAP///////wAAAAAAAP///////////////////////////////////////wAAAAAAAP///////////////////////////////wAA////////////////////////////////AAAAAAAA////////AAAAAAAAAAAAAAAAAAAAAAAA////////AAAAAAAA////////AAAAAAAAAAAAAAAA////////AAAAAAAAAAAAAAAA////////////////AAAAAAAAAAAAAAAA////////AAAAAAAA////////AAAAAAAAAAAAAAAAAAAAAAAA////////AAAAAAAA////////////////////////////////AAD///////////////////////////////8AAAAAAAD///////8AAAAAAAAAAAAAAAAAAAAAAAD///////8AAAAAAAD///////8AAAAAAAAAAAAAAAD///////8AAAAAAAAAAAAAAAD///////////////8AAAAAAAAAAAAAAAD///////8AAAAAAAD///////8AAAAAAAAAAAAAAAAAAAAAAAD///////8AAAAAAAD///////////////////////////////8AAP///////////////////////////////wAAAAAAAP///////wAAAAAAAAAAAAAAAAAAAAAAAP///////wAAAAAAAP///////////////////////wAAAAAAAP///////////////////////////////wAAAAAAAAAAAAAAAP///////wAAAAAAAP///////wAAAAAAAAAAAAAAAAAAAAAAAP///////wAAAAAAAP///////////////////////////////wAA////////////////////////////////AAAAAAAA////////AAAAAAAAAAAAAAAAAAAAAAAA////////AAAAAAAA////////////////////////AAAAAAAA////////////////////////////////AAAAAAAAAAAAAAAA////////AAAAAAAA////////AAAAAAAAAAAAAAAAAAAAAAAA////////AAAAAAAA////////////////////////////////AAD///////////////////////////////8AAAAAAAD///////8AAAAAAAAAAAAAAAAAAAAAAAD///////8AAAAAAAD///////////////8AAAAAAAAAAAAAAAAAAAAAAAD///////////////8AAAAAAAAAAAAAAAAAAAAAAAD///////8AAAAAAAD///////8AAAAAAAAAAAAAAAAAAAAAAAD///////8AAAAAAAD///////////////////////////////8AAP///////////////////////////////wAAAAAAAP///////wAAAAAAAAAAAAAAAAAAAAAAAP///////wAAAAAAAP///////////////wAAAAAAAAAAAAAAAAAAAAAAAP///////////////wAAAAAAAAAAAAAAAAAAAAAAAP///////wAAAAAAAP///////wAAAAAAAAAAAAAAAAAAAAAAAP///////wAAAAAAAP///////////////////////////////wAA////////////////////////////////AAAAAAAA////////////////////////////////////////AAAAAAAA////////AAAAAAAA////////////////AAAAAAAAAAAAAAAA////////////////AAAAAAAA////////////////AAAAAAAA////////////////////////////////////////AAAAAAAA////////////////////////////////AAD///////////////////////////////8AAAAAAAD///////////////////////////////////////8AAAAAAAD///////8AAAAAAAD///////////////8AAAAAAAAAAAAAAAD///////////////8AAAAAAAD///////////////8AAAAAAAD///////////////////////////////////////8AAAAAAAD///////////////////////////////8AAP///////////////////////////////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///////////////wAAAAAAAAAAAAAAAP///////////////////////////////wAAAAAAAAAAAAAAAP///////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///////////////////////////////wAA////////////////////////////////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////////////////AAAAAAAAAAAAAAAA////////////////////////////////AAAAAAAAAAAAAAAA////////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////////////////////////////////AAD///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////8AAP///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////wAA////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////AAD///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////8AAP///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////wAA////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////AAD///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////8AAP///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////wAA";
            var s = document.LastSection;
            var p = s.AddParagraph();
            //Add the image
            p.AddImage(StrFromMS);

            // Layout and render document to PDF.
            pdfRenderer.RenderDocument();

            // Save the document...
            var filename = PdfFileUtility.GetTempPdfFileName("Image_Base64");
            pdfRenderer.PdfDocument.Save(filename);
            // ...and start a viewer.
            PdfFileUtility.ShowDocumentIfDebugging(filename);
        }

        [Fact]
#if WPF
        public void Test_Image_Interpolate_Wpf()
#elif GDI
        public void Test_Image_Interpolate_Gdi()
#else
        public void Test_Image_Interpolate()
#endif
        {
            // Create a MigraDoc document.
            var document = CreateDocument(false);

            // Associate the MigraDoc document with a renderer.
            var pdfRenderer = new PdfDocumentRenderer
            {
                Document = document,
                PdfDocument =
                {
                    PageLayout = PdfPageLayout.SinglePage
                }
            };

            var imageFolder = IOUtility.GetAssetsPath("pdfsharp/images/samples/png");
            var imageFile = Path.Combine(imageFolder ?? throw new InvalidOperationException("Call Download-Assets.ps1 before running the tests."), "blackwhiteA.png");
            var data = File.ReadAllBytes(imageFile);
            var imageString = "base64:" + Convert.ToBase64String(data);

            var s = document.LastSection;
            // For this section, four PdfImage objects should be inserted into the PDF.
            var p = s.AddParagraph("BASE64: Interpolate is false: ");
            //Add the image
            var img = p.AddImage(imageString);
            img.Interpolate = false;
            p = s.AddParagraph();
            p = s.AddParagraph("BASE64: Interpolate is true: ");
            //Add the image
            img = p.AddImage(imageString);
            img.Interpolate = true;

            s.AddParagraph();

            p = s.AddParagraph("File: Interpolate is false: ");
            //Add the image
            img = p.AddImage(imageFile);
            img.Interpolate = false;
            p = s.AddParagraph();
            p = s.AddParagraph("File: Interpolate is true: ");
            //Add the image
            img = p.AddImage(imageFile);
            img.Interpolate = true;

            s = document.AddSection();
            // For this section, no new PdfImage objects should be inserted into the PDF. Images from the previous section should be re-used.
            p = s.AddParagraph("BASE64: Interpolate is false: ");
            //Add the image
            img = p.AddImage(imageString);
            img.Interpolate = false;
            p = s.AddParagraph();
            p = s.AddParagraph("BASE64: Interpolate is false: ");
            //Add the image
            img = p.AddImage(imageString);
            img.Interpolate = false;

            s.AddParagraph();

            p = s.AddParagraph("File: Interpolate is false: ");
            //Add the image
            img = p.AddImage(imageFile);
            img.Interpolate = false;
            p = s.AddParagraph();
            p = s.AddParagraph("File: Interpolate is false: ");
            //Add the image
            img = p.AddImage(imageFile);
            img.Interpolate = false;

            // Layout and render document to PDF.
            pdfRenderer.RenderDocument();

            // Save the document...
            var filename = PdfFileUtility.GetTempPdfFileName("Image_Interpolate");
            pdfRenderer.PdfDocument.Save(filename);
            // ...and start a viewer.
            PdfFileUtility.ShowDocumentIfDebugging(filename);
        }

        [Theory]
        [InlineData(SecurityTestHelper.TestOptionsEnum.None)]
        [InlineData(SecurityTestHelper.TestOptionsEnum.V5)] // We only want to ensure image filters are not affected by crypt filters, so testing encryption version 5 should do it.
#if WPF
        public void Test_Image_Formats_Encrypted_Wpf(SecurityTestHelper.TestOptionsEnum optionsEnum)
#elif GDI
        public void Test_Image_Formats_Encrypted_Gdi(SecurityTestHelper.TestOptionsEnum optionsEnum)
#else
        public void Test_Image_Formats_Encrypted(SecurityTestHelper.TestOptionsEnum optionsEnum)
#endif
        {
            // Attempt to avoid "image file locked" under .NET 4.7.2.
            GC.Collect();
            GC.WaitForFullGCComplete();

            {
                var options = SecurityTestHelper.TestOptions.ByEnum(optionsEnum);
                options.SetDefaultPasswords(true, true);

                // Write encrypted file.
                var filename = SecurityTestHelper.AddSuffixToFilename("Image_Formats_write.pdf", options);

                var document = CreateDocument(true);

                var pdfRenderer = SecurityTestHelper.RenderSecuredDocument(document, options);
                pdfRenderer.Save(filename);
                // ReSharper disable once RedundantAssignment
                pdfRenderer = null;

                PdfFileUtility.ShowDocumentIfDebugging(filename);

                // Read encrypted file and write it without encryption.
                var pdfDocRead = PdfReader.Open(filename, SecurityTestHelper.PasswordOwnerDefault);

                var pdfRendererRead = new PdfDocumentRenderer { PdfDocument = pdfDocRead };

                var filenameRead = SecurityTestHelper.AddSuffixToFilename("Image_Formats_read.pdf", options);
                pdfRendererRead.Save(filenameRead);
                // ReSharper disable once RedundantAssignment
                pdfRendererRead = null;

                PdfFileUtility.ShowDocumentIfDebugging(filenameRead);
            }

            // Attempt to avoid "image file locked" under .NET 4.7.2.
            GC.Collect();
            GC.WaitForFullGCComplete();
        }

        /// <summary>
        /// Creates an absolutely minimalistic document.
        /// </summary>
        Document CreateDocument(bool addImages)
        {
            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();

            // Add test images.
            if (addImages)
                AddImages(document);

            // Create the primary footer.
            var footer = section.Footers.Primary;

            // Add content to footer.
            var paragraph = footer.AddParagraph();
            paragraph.Add(new DateField { Format = "yyyy/MM/dd HH:mm:ss" });
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            return document;
        }

        void AddImages(Document document)
        {
            var root = IOUtility.GetAssetsPath(@"pdfsharp\images\samples\");
            var images = _testImages;
            var x = GetType();
            var section = document.LastSection;
            section.AddParagraph(x.Assembly.GetOriginalLocation());
            var workingDir = Environment.CurrentDirectory;
            section.AddParagraph(workingDir);

            foreach (var image in images)
            {
                var path = root + image.Path;

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    path = path.Replace('\\', '/');

                var file = Path.GetFileName(image.Path);
                var header = $"{image.Comment} ({file})";
                var paragraph = section.AddParagraph(header);
                paragraph.AddLineBreak();
                var img = paragraph.AddImage(path);
                if (image.Width.HasValue)
                    img.Width = image.Width.Value;
                section.AddParagraph(header);
                img = section.AddImage(path);
                if (image.Width.HasValue)
                    img.Width = image.Width.Value;
                section.AddPageBreak();
            }
        }

        struct TestImage
        {
            public string Comment { get; set; }

            public string Path { get; set; }

            public Unit? Width { get; set; }
        }

        readonly TestImage[] _testImages = {
            // JPEG
            new() { Path = @"jpeg\windows7problem.jpg", Comment = "JPEG image", Width = "12cm" },
            new() { Path = @"jpeg\TruecolorNoAlpha.jpg", Comment = "JPEG image" },
            new() { Path = @"jpeg\truecolorA.jpg", Comment = "JPEG image" },
            new() { Path = @"jpeg\PowerBooks_CMYK.jpg", Comment = "JPEG with EXIF header" },
            new() { Path = @"jpeg\indexedmonoA.jpg", Comment = "JPEG image" },
            new() { Path = @"jpeg\grayscaleNoAlpha.jpg", Comment = "JPEG image" },
            new() { Path = @"jpeg\grayscaleA.jpg", Comment = "JPEG image" },
            new() { Path = @"jpeg\color8A.jpg", Comment = "JPEG image" },
            new() { Path = @"jpeg\color4A.jpg", Comment = "JPEG image" },
            new() { Path = @"jpeg\blackwhiteA.jpg", Comment = "JPEG image" },
            new() { Path = @"jpeg\Balloons_CMYK.jpg", Comment = "CMYK" },
            new() { Path = @"jpeg\Balloons_CMYK - Copy.jpg", Comment = "CMYK?" },

            // BMP
            new() { Path = @"bmp\BlackwhiteA.bmp", Comment = "BMP image" },
            new() { Path = @"bmp\BlackwhiteA2.bmp", Comment = "BMP image" },
            new() { Path = @"bmp\BlackwhiteTXT.bmp", Comment = "BMP image", Width = "8cm" },
            new() { Path = @"bmp\Color4A.bmp", Comment = "BMP image" },
            new() { Path = @"bmp\Color8A.bmp", Comment = "BMP image" },
            new() { Path = @"bmp\GrayscaleA.bmp", Comment = "BMP image" },
            new() { Path = @"bmp\IndexedmonoA.bmp", Comment = "BMP image" },
            new() { Path = @"bmp\Test_OS2.bmp", Comment = "OS/2 bitmap, not supported by Core build" },
            new() { Path = @"bmp\TruecolorA.bmp", Comment = "BMP image" },
            new() { Path = @"bmp\TruecolorMSPaint.bmp", Comment = "BMP image" },

            // PNG
            new() { Path = @"png\windows7problem.png", Comment = "PNG", Width = "12cm" },
            new() { Path = @"png\truecolorAlpha.png", Comment = "PNG" },
            new() { Path = @"png\truecolorA.png", Comment = "PNG" },
            new() { Path = @"png\indexedmonoA.png", Comment = "PNG" },
            new() { Path = @"png\grayscaleAlpha.png", Comment = "PNG" },
            new() { Path = @"png\grayscaleA.png", Comment = "PNG" },
            new() { Path = @"png\color8A.png", Comment = "PNG" },
            new() { Path = @"png\color4A.png", Comment = "PNG" },
            new() { Path = @"png\blackwhiteA.png", Comment = "PNG" },

            // BMP & PNG
            new() { Path = @"MigraDoc.bmp", Comment = "BMP image", Width = "8cm" },
            new() { Path = @"Logo landscape.bmp", Comment = "BMP", Width = "12cm" },
            new() { Path = @"Logo landscape MS Paint.bmp", Comment = "BMP", Width = "12cm" },
            new() { Path = @"Logo landscape 256.bmp", Comment = "BMP image", Width = "12cm" },
            new() { Path = @"MigraDoc.png", Comment = "PNG image", Width = "8cm" },
            new() { Path = @"Logo landscape.png", Comment = "PNG image", Width = "12cm" },
            new() { Path = @"Logo landscape 256.png", Comment = "PNG image", Width = "12cm" },

            // GIF, TIFF, PNG
            new() { Path = @"misc\image009.gif", Comment = "GIF, not supported by Core build" },
            new() { Path = @"misc\Rose (RGB 8).tif", Comment = "TIFF, not supported by Core build" },
            new() { Path = @"misc\Test.gif", Comment = "GIF, not supported by Core build" },
            new() { Path = @"misc\Test.png", Comment = "PNG image" }
        };
    }
}
