using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;
using UglyToad.PdfPig.DocumentLayoutAnalysis.WordExtractor;

namespace BankStatementScannerLibrary.Input
{
    public class PdfReader
    {
        public static string ExtractPdf(string filename)
        {
            string result = "";
            using PdfDocument document = PdfDocument.Open(filename);
            foreach (Page page in document.GetPages())
            {
                var words = page.GetWords(NearestNeighbourWordExtractor.Instance);

                var options = new RecursiveXYCut.RecursiveXYCutOptions()
                {
                    MinimumWidth = page.Width / 1.25,
                    DominantFontWidthFunc = letters => letters.Select(l => l.GlyphRectangle.Width).Max(),
                    DominantFontHeightFunc = letters => letters.Select(l => l.GlyphRectangle.Height).Average()
                };

                var xyCut = new RecursiveXYCut(options);
                var blocks = xyCut.GetBlocks(words);

                foreach (var block in blocks)
                {
                    result += block.Text + "\n";
                }
            }

            return result;
        }
    }
}
