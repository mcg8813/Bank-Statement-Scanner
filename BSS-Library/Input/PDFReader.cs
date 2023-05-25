using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;
using UglyToad.PdfPig.DocumentLayoutAnalysis.WordExtractor;

namespace BankStatementScannerLibrary.Input
{
    public class PdfReader
    {
        /// <summary>
        /// Extracts Pdf's text using UglyToad.PdfPig. 
        /// </summary>
        /// <param name="filename">Name of Pdf file</param>
        /// <returns>String containing Pdf text</returns>
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

                result = blocks.Aggregate(result, (current, block) => current + (block.Text + "\n"));
            }

            return result;
        }
    }
}
