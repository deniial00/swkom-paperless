using NPaperless.SA.Interfaces;

using System.Text;
using ImageMagick;
using Tesseract;

namespace NPaperless.SA;
public class OCRService : IOCRService
{
    private readonly string _pathToTrainedData;
    private readonly string _language;
    
    public OCRService(string dataPath, string language) {
        _pathToTrainedData = dataPath;
        _language = language;
    }

    public string ScanDocument(Stream file)
    {
        Console.WriteLine("Starting OCR");
        var fileContent = new StringBuilder();

        using (var magickImages = new MagickImageCollection())
        {
            magickImages.Read(file);
            foreach (var magickImage in magickImages)
            {
                // Set the resolution and format of the image (adjust as needed)
                magickImage.Density = new Density(500, 500);
                magickImage.Format = MagickFormat.Png;

                // Perform OCR on the image
                using (var tesseractEngine = new TesseractEngine(_pathToTrainedData, _language, EngineMode.Default))
                {
                    using (var page = tesseractEngine.Process(Pix.LoadFromMemory(magickImage.ToByteArray())))
                    {
                        var extractedText = page.GetText();
                        fileContent.Append(extractedText);
                    }
                }
            }
        }
        Console.WriteLine("Finished OCR");

        return fileContent.ToString();
    }
}