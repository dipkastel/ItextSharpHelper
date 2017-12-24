using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfHelperLibrary
{
    class PTableRow
    {
        Document document;
        PdfPTable table;
        PdfPCell pdfCell;
        string[] inputs;

        PTableRow(Document doc) {
            this.document = doc;
        }
    }
}
