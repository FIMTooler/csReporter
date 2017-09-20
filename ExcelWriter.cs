using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
//Namespaces needed for Excel processing
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace csReporter
{
    class ExcelWriter
    {
        private SpreadsheetDocument doc;
        private WorkbookPart wbp;
        private WorksheetPart wsp;
        private Sheets shts;
        private Sheet sht;
        private SharedStringTablePart ssp;
        SheetData sd;
        Worksheet ws;
        private enum columnNames { A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, X, Y, Z, AA, AB, AC, AD, AE, AF, AG, AH, AI, AJ, AK, AL, AM, AN, AO, AP, AQ, AR, AS, AT, AU, AV, AW, AX, AY, AZ, BA, BB, BC, BD, BE, BF, BG, BH, BI, BJ, BK, BL, BM, BN, BO, BP, BQ, BR, BS, BT, BU, BV, BW, BX, BY, BZ, CA, CB, CC, CD, CE, CF, CG, CH, CI, CJ, CK, CL, CM, CN, CO, CP, CQ, CR, CS, CT, CU, CV, CW, CX, CY, CZ, DA, DB, DC, DD, DE, DF, DG, DH, DI, DJ, DK, DL, DM, DN, DO, DP, DQ, DR, DS, DT, DU, DV, DW, DX, DY, DZ }
        private uint currentRow;
        Cell lastCell;
        Row curRow;
        List<string> sharedString;
        Stylesheet ss;

        public ExcelWriter(string filePath)
        {
            doc = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook);
            wbp = doc.AddWorkbookPart();
            wbp.Workbook = new Workbook();
            wsp = wbp.AddNewPart<WorksheetPart>();
            wsp.Worksheet = new Worksheet(new SheetData());
            shts = doc.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
            sht = new Sheet() { Id = doc.WorkbookPart.GetIdOfPart(wsp), SheetId = 1, Name = "test" };
            shts.Append(sht);
            ws = wsp.Worksheet;
            sd = ws.GetFirstChild<SheetData>();
            ssp = doc.WorkbookPart.AddNewPart<SharedStringTablePart>();
            currentRow = 1;
            sharedString = new List<string>();
            
            ss = GenerateStylesheet();
            wbp.AddNewPart<WorkbookStylesPart>();
            wbp.WorkbookStylesPart.Stylesheet = ss;
            wbp.WorkbookStylesPart.Stylesheet.Save();
        }

        public void Dispose()
        {
            // Save the new worksheet.
            ws.Save();
            wbp.Workbook.Save();
            doc.Close();
            doc.Dispose();
        }
        
        public void WriteNextRow(List<string> dataValues)
        {
            columnNames col = columnNames.A;
            foreach (string val in dataValues)
            {
                if (val == "")
                {
                    col++;
                }
                else
                {
                    InsertSharedStringItem(val);
                    WriteCell(val, col++, currentRow);
                }
            }
            currentRow++;
        }

        public void WriteNextRow(string dataValue)
        {
            columnNames col = columnNames.A;
            if (dataValue == "")
            {
                currentRow++;
            }
            else
            {
                InsertSharedStringItem(dataValue);
                WriteCell(dataValue, col++, currentRow);
            }
        }

        // Given text and a SharedStringTablePart, creates a SharedStringItem with the specified text 
        // and inserts it into the SharedStringTablePart. If the item already exists, returns its index.
        private int InsertSharedStringItem(string text)
        {
            // If the part does not contain a SharedStringTable, create one.
            if (ssp.SharedStringTable == null)
            {
                ssp.SharedStringTable = new SharedStringTable();
            }

            int i = 0;

            // Iterate through all the items in the SharedStringTable. If the text already exists, return its index.
            //foreach (SharedStringItem item in ssp.SharedStringTable.Elements<SharedStringItem>())
            //{
            //    if (item.InnerText == text)
            //    {
            //        return i;
            //    }
            //    i++;
            //}
            
            //looking up in List<string> is faster than above foreach
            i = sharedString.IndexOf(text);
            if (i == -1)
            {
                sharedString.Add(text);
                // The text does not exist in the part. Create the SharedStringItem and return its index.
                ssp.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(text)));
                ssp.SharedStringTable.Save();

                return sharedString.Count;
            }

            return i;
        }
        // Given a column name, a row index, and a WorksheetPart, inserts a cell into the worksheet. 
        // If the cell already exists, returns it. 
        private Cell InsertCellInWorksheet(columnNames columnName, uint rowIndex)
        {
            //empty string converts columnName to string
            string cellReference = "" + columnName + rowIndex;

            // If the worksheet does not contain a row with the specified row index, insert one.
            Row row;
            //Writing only forward, no need to look for existing row object
            //after initializing curRow, either existing row or new row
            if (curRow == null || curRow.RowIndex < currentRow)
            {
                row = new Row() { RowIndex = rowIndex };
                sd.Append(row);
                curRow = row;
            }
            else
            {
                row = curRow;
            }
            //No need to check for overwrite existing cell
            Cell newCell = new Cell() { CellReference = cellReference };
            newCell.StyleIndex = 1;
            row.InsertBefore(newCell, lastCell);
            
            return newCell;
        }

        private void WriteCell(string value, columnNames column, uint row)
        {
            int index = InsertSharedStringItem(value);
            Cell cell = InsertCellInWorksheet(column, row);
            cell.CellValue = new CellValue(index.ToString());
            cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
        }
        
        private Stylesheet GenerateStylesheet()
        {
            Stylesheet styleSheet = null;
            Fonts fonts = new Fonts(new Font(new FontSize() { Val = 10 }));
            Fills fills = new Fills(new Fill(new PatternFill() { PatternType = PatternValues.None }));
            Borders borders = new Borders(new Border());
            CellFormat cf = new CellFormat() { FontId = 0, FillId = 0, BorderId = 0 };
            CellFormat cfW = new CellFormat() { FontId = 0, FillId = 0, BorderId = 0, ApplyAlignment = true };
            cfW.Append(new Alignment() { WrapText = true });
            CellFormats cellFormats = new CellFormats(cf, cfW);
            styleSheet = new Stylesheet(fonts, fills, borders, cellFormats);
            return styleSheet;
        }
    }
}
