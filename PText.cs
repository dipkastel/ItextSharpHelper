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
                paddingBottom = 0;
            bool
                isRTL = true,
                borderEnable = false;
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
            public PText setTextSize(int size)
            {
                TextSize = size;
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
                f2 = new iTextSharp.text.Font(bf, TextSize, iTextSharp.text.Font.NORMAL, new BaseColor(int.Parse(TextColor, System.Globalization.NumberStyles.HexNumber)));
                table = new PdfPTable(numColumns: 1);

                pdfCell = new PdfPCell(new Phrase(stringText, f2));
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

                pdfCell.PaddingTop = paddingTop;
                pdfCell.PaddingRight = paddingRight;
                pdfCell.PaddingBottom = paddingBottom;
                pdfCell.PaddingLeft = paddingLeft;
                
                table.AddCell(pdfCell);
                document.Add(table);

            }

    }
}
