using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_IT.Services
{
    public class CertificatService
    {
        public class PDFFooter : PdfPageEventHelper
        {
            //write on close of document
            public override void OnCloseDocument(PdfWriter writer, Document document)
            {
                base.OnCloseDocument(writer, document);
            }
        }
        public class SchemaOferta
        {

            #region Declaration
            int _totalColumn = 6;
            float sum = 0;
            float totalSum = 0;
            Document _document;
            Font _fontStyle;
            Font _fontStyle2;
            PdfPTable _pdfTable = new PdfPTable(6);
            PdfPTable _pdfTable1 = new PdfPTable(13);
            PdfPTable _pdfTable2 = new PdfPTable(3);
            PdfPTable _pdfTable3 = new PdfPTable(3);
            PdfPTable _pdfTable4 = new PdfPTable(1);
            PdfPTable _pdfTable5 = new PdfPTable(1);
            PdfPTableFooter _pdfPTableFooter = new PdfPTableFooter();
            PdfPCell _pdfCell;
            MemoryStream _memoryStream = new MemoryStream();
            Image _myImage1, _myImage2, _myImage3, _myImage4, _myImage5;
            string _beneficiar, _denumireOferta, _listaDetalii;
            public static string _nrOferta;
            int i = 0;
            #endregion

            public byte[] PrepareReport(string firstName, string lastName)
            {

                //_myImage1 = myImage1;
                //_myImage2 = myImage2;
                //_myImage3 = myImage3;
                //_myImage4 = myImage4;
                //_myImage5 = myImage5;
                //_myImage1.ScaleAbsoluteWidth(150);
                //_myImage1.ScaleAbsoluteHeight(150);
                //_myImage2.ScaleAbsoluteWidth(295);
                //_myImage2.ScaleAbsoluteHeight(50);
                //_myImage3.ScaleAbsoluteWidth(350);
                //_myImage3.ScaleAbsoluteHeight(70);
                //_myImage4.ScaleAbsoluteWidth(280);
                //_myImage4.ScaleAbsoluteHeight(70);
                //_myImage5.ScaleAbsoluteWidth(300);
                //_myImage5.ScaleAbsoluteHeight(75);
                //_nrOferta = nrOferta;
                //_beneficiar = beneficiar;
                //_denumireOferta = denumireOferta;
                //_listaDetalii = listaDetalii;

                #region
                _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
                _document.SetPageSize(PageSize.A4);
                _document.SetMargins(20f, 20f, 20f, 20f);

                _pdfTable.WidthPercentage = 100;
                _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfTable.SetWidths(new float[] { 20f, 60f, 10f, 20f, 20f, 100f });

                _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
                PdfWriter writer = PdfWriter.GetInstance(_document, _memoryStream);
                writer.PageEvent = new PDFFooter();
                _document.Open();

                #endregion

                FirstPage();
                _pdfTable.HeaderRows = 2;
                _document.Add(_pdfTable);

                _document.Close();
                return _memoryStream.ToArray();
            }

            private void FirstPage()
            {
                PdfPCell blankCell = new PdfPCell(new Phrase(Chunk.NEWLINE));
                blankCell.Border = PdfPCell.NO_BORDER;
                blankCell.Colspan = _totalColumn;
                _pdfTable.AddCell(blankCell);
                _pdfTable.CompleteRow();
                blankCell.Border = PdfPCell.NO_BORDER;
                blankCell.Colspan = _totalColumn;
                _pdfTable.AddCell(blankCell);
                _pdfTable.CompleteRow();
                blankCell.Border = PdfPCell.NO_BORDER;
                blankCell.Colspan = _totalColumn;
                _pdfTable.AddCell(blankCell);
                _pdfTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                _pdfCell = new PdfPCell(_myImage1);
                _pdfCell.Colspan = _totalColumn;
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.Border = 0;
                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _pdfCell.ExtraParagraphSpace = 30;
                _pdfTable.AddCell(_pdfCell);
                _pdfTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Tahoma", 14f, 1);
                _pdfCell = new PdfPCell(new Phrase("Oferta: " + _nrOferta + " / " + DateTime.Today.ToString("dd.MM.yyyy"), _fontStyle));
                _pdfCell.Colspan = _totalColumn;
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.Border = 0;
                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _pdfCell.ExtraParagraphSpace = 20;
                _pdfTable.AddCell(_pdfCell);
                _pdfTable.CompleteRow();


                _fontStyle = FontFactory.GetFont("Tahoma", 14f, 0);
                _pdfCell = new PdfPCell(new Phrase("BENEFICIAR", _fontStyle));
                _pdfCell.Colspan = _totalColumn;
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.Border = 0;
                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _pdfCell.ExtraParagraphSpace = 20;
                _pdfTable.AddCell(_pdfCell);
                _pdfTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Tahoma", 14f, 1);
                _pdfCell = new PdfPCell(new Phrase(_beneficiar, _fontStyle));
                _pdfCell.Colspan = _totalColumn;
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.Border = 0;
                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _pdfCell.ExtraParagraphSpace = 20;
                _pdfTable.AddCell(_pdfCell);
                _pdfTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Tahoma", 16f, 1);
                _pdfCell = new PdfPCell(new Phrase(_denumireOferta, _fontStyle));
                _pdfCell.Colspan = _totalColumn;
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.Border = 0;
                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _pdfCell.ExtraParagraphSpace = 30;
                _pdfTable.AddCell(_pdfCell);
                _pdfTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                _pdfCell = new PdfPCell(_myImage2);
                _pdfCell.Colspan = _totalColumn;
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.Border = 0;
                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _pdfCell.ExtraParagraphSpace = 30;
                _pdfTable.AddCell(_pdfCell);
                _pdfTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                _pdfCell = new PdfPCell(_myImage3);
                _pdfCell.Colspan = _totalColumn;
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.Border = 0;
                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _pdfCell.ExtraParagraphSpace = 30;
                _pdfTable.AddCell(_pdfCell);
                _pdfTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                _pdfCell = new PdfPCell(_myImage5);
                _pdfCell.Colspan = _totalColumn;
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.Border = 0;
                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _pdfCell.ExtraParagraphSpace = 50;
                _pdfTable.AddCell(_pdfCell);
                _pdfTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                _pdfCell = new PdfPCell(_myImage4);
                _pdfCell.Colspan = _totalColumn;
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.Border = 0;
                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfCell);
                _pdfTable.CompleteRow();

            }

        }
    }
}
