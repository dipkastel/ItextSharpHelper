using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfHelperLibrary
{
    public class PText
    {
         Document document;
            PdfPTable table;
            PdfPCell pdfCell;
            BaseFont bf;
            Font f2;
            string
                fontAdress = "fonts\\IRAN-Sans.ttf";
            string
                stringText = "",
                TextColor = "ff000000";
            int
                TextSize = 10,
                paddingTop = 0,
                paddingRight = 0,
                paddingLeft = 0,
                paddingBottom = 0,
                spacingBefor = 0,
                spacingAfter = 0;
            bool
                isRTL = true,
                borderEnable = false,
                isTitle =false;
            BaseColor
                BorderColor = BaseColor.BLACK;
            float
                borderWidth = 1f;



            public PText(Document document)
            {
                // TODO: Complete member initialization
                this.document = document;
            }
            public PText setFontAdress(string address)
            {

                fontAdress = address;
                return this;
            }

            public PText setText(string text)
            {
                this.stringText = text;
                return this;
            }

            public PText setTextColor(string color)
            {
                TextColor = color;
                return this;
            }

            public PText setAsTitle(bool _isTitle)
            {
                isTitle = _isTitle;
                return this;
            }
            public PText setTextSize(int size)
            {
                TextSize = size;
                return this;
            }
            public PText setSpacingBefor(int size)
            {
                spacingBefor = size;
                return this;
            }
            public PText setSpacingAfter(int size)
            {
                spacingAfter = size;
                return this;
            }
            public PText setPaddingTop(int size)
            {
                paddingTop = size;
                return this;
            }
            public PText setPaddingRight(int size)
            {
                paddingRight = size;
                return this;
            }
            public PText setPaddingBottom(int size)
            {
                paddingBottom = size;
                return this;
            }
            public PText setPaddingLeft(int size)
            {
                paddingLeft = size;
                return this;
            }


            public void build()
            {

                bf = BaseFont.CreateFont(AppDomain.CurrentDomain.BaseDirectory + fontAdress, BaseFont.IDENTITY_H, true);
                f2 = new iTextSharp.text.Font(bf, TextSize, iTextSharp.text.Font.NORMAL, new BaseColor(int.Parse(TextColor.Replace("#",""), System.Globalization.NumberStyles.HexNumber)));
                table = new PdfPTable(numColumns: 1);
                //------------------------
                Paragraph paragraphTables = new Paragraph();
                PdfPCell pdfCells = new PdfPCell(new Phrase(" ", f2));
                PdfPTable tables = new PdfPTable(numColumns: 1);

                tables.AddCell(pdfCells);
                paragraphTables.Add("");
                document.Add(paragraphTables);
                //------------------------

                Paragraph paragraphTable = new Paragraph();
                paragraphTable.SpacingBefore = spacingBefor;
                paragraphTable.SpacingAfter = spacingAfter;
                paragraphTable.Clear();
                Phrase phrase = new Phrase(stringText, f2);
                pdfCell = new PdfPCell(phrase);
                pdfCell.SetLeading(0, 2);
                if (isRTL)
                {
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    pdfCell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                }
                else
                {
                    table.RunDirection = PdfWriter.RUN_DIRECTION_LTR;
                    pdfCell.RunDirection = PdfWriter.RUN_DIRECTION_LTR;
                }
                if (borderEnable)
                {
                    pdfCell.UseVariableBorders = borderEnable;
                    pdfCell.BorderWidth = borderWidth;
                    pdfCell.BorderColor = BorderColor;
                }
                else {

                    pdfCell.BorderWidth = 0;
                }

                if (isTitle) { 
                
                
                }
                
                pdfCell.PaddingTop = paddingTop;
                pdfCell.PaddingRight = paddingRight;
                pdfCell.PaddingBottom = paddingBottom;
                pdfCell.PaddingLeft = paddingLeft;
                
                table.AddCell(pdfCell);
                paragraphTable.Add(table);
                document.Add(paragraphTable);



                //------------------------
                Paragraph paragraphTables2 = new Paragraph();
                PdfPCell pdfCells2 = new PdfPCell(new Phrase(" ", f2));
                paragraphTables2.Add("");
                document.Add(paragraphTables2);
                //------------------------

            }

    }
}
