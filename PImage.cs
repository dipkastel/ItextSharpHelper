using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfHelperLibrary
{
    public class PImage
    {

        Document Document;
        PdfWriter Writer;
        public string 
            ImageUrl = "";
        int 
            marginBottom = 0,
            Left = 0,
            Top=0;
        bool 
            IsHeader = false; 






        public PImage(Document document, PdfWriter writer)
        {

            this.Document = document;
            this.Writer = writer;
        }

        public PImage setImageUrl(string _imageUrl) {
            this.ImageUrl = _imageUrl;
            return this;
        }

        public PImage setAsHeader(bool isHeader) {
            this.IsHeader = isHeader;
            return this;
        }


        public void build()
        {
            try
            {

                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + ImageUrl);
                float x = image.Width;
                float y = image.Height;
                float retio = x / y;
                float pageHeight = Document.PageSize.Height;
                if (IsHeader)
                {

                    marginBottom = (int)(pageHeight - y);
                }
                image.ScaleToFit(x, x / retio);
                image.SetAbsolutePosition(Left, Top);
                PdfContentByte cb = Writer.DirectContent;
                PdfTemplate tp = cb.CreateTemplate(x, x / retio);



                tp.AddImage(image);
                cb.AddTemplate(tp, 0, marginBottom);

            }
            catch (Exception e) { }
           


        }

    }
}
