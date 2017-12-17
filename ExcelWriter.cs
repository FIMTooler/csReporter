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
        Dictionary<string, int> sharedString;
        Dictionary<uint, Row> myRows;
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
            sharedString = new Dictionary<string, int>();
            myRows = new Dictionary<uint, Row>();
            
            ss = GenerateStylesheet();
            wbp.AddNewPart<WorkbookStylesPart>();
            wbp.WorkbookStylesPart.Stylesheet = ss;
            wbp.WorkbookStylesPart.Stylesheet.Save();
        }

        public void Dispose()
        {
            Save();
            doc.Close();
            doc.Dispose();
        }

        public void Save()
        {
            // Save the new worksheet
            ssp.SharedStringTable.Save();
            ws.Save();
            wbp.Workbook.Save();
        }
        
        public void WriteNextRow(List<string> dataValues)
        {
            columnNames col = columnNames.A;
            //needed to reset row when there's multiple rows for single cs object
            //any columns after large multivalue column needs to be back on top row.
            uint startRow = currentRow;
            uint lastRow = currentRow;
            foreach (string val in dataValues)
            {
                if (val != "")
                {
                    //greater than 600-700 seems to cause issues with string table and opening in Excel
                    //if greater than 250, break into multiple rows
                    if (val.Count(f => f == '\n') > 250)
                    {
                        string[] vals = val.Split(new char[] { '\n' }, StringSplitOptions.None);
                        for (int i = 0; i < vals.Length; i++)
                        {
                            //prevents Cells A and B from getting re-written
                            //Re-writing Cells means extra lookups and time
                            if (i != 0)
                            {
                                //dataValues[0] should always be DN unless >250 attributes in report
                                WriteCell(dataValues[0], columnNames.A, currentRow);
                                //dataValues[1] should always be object type unless >250 attributes in report
                                WriteCell(dataValues[1], columnNames.B, currentRow);
                            }
                            WriteCell(vals[i], col, currentRow++);
                        }
                        //save last row for later
                        //don't need advance, added below
                        lastRow = currentRow - 1;
                        currentRow = startRow;
                    }
                    else
                    {
                        WriteCell(val, col, currentRow);
                    }
                }
                col++;
            }
            //advance and reset
            currentRow = ++lastRow;
        }

        public void WriteNextRow(string dataValue)
        {
            columnNames col = columnNames.A;
            if (dataValue != "")
            {
                WriteCell(dataValue, col++, currentRow);
            }
            currentRow++;
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
            //i = sharedString.IndexOf(text);
            //if (i == -1)
            //{
            //    sharedString.Add(text);
            //    // The text does not exist in the part. Create the SharedStringItem and return its index.
            //    ssp.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(text)));
            //    //ssp.SharedStringTable.Save();

            //    return sharedString.Count - 1;
            //}

            //Dictionary is fastest
            if (sharedString.Keys.Contains(text))
            {
                return sharedString[text];
            }
            else
            {
                i = sharedString.Count;
                sharedString.Add(text, i);
                ssp.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(text)));
            }

            return i;
        }
        // Given a column name, a row index, and a WorksheetPart, inserts a cell into the worksheet. 
        // If the cell already exists, returns it. 
        private Cell InsertCellInWorksheet(columnNames columnName, uint rowIndex)
        {
            //empty string converts columnName to string
            string cellReference = columnName.ToString() + rowIndex;

            // If the worksheet does not contain a row with the specified row index, insert one.
            Row row;

            // If the worksheet does not contain a row with the specified row index, insert one.
            if (myRows.Keys.Contains(rowIndex))
            {
                row = myRows[rowIndex];
            }
            else
            {
                row = new Row() { RowIndex = rowIndex };
                sd.Append(row);
                myRows.Add(rowIndex, row);
            }

        //Avoid re-writing Cells. Means extra lookups and time.  Lookups vary by row length/number of columns
            //if (row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).Count() > 0)
            //{
            //    string a = cellReference;
            //    return row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).First();
            //}
            //else
            //{
            Cell newCell = new Cell() { CellReference = cellReference };
                newCell.StyleIndex = 1;
                row.InsertAfter(newCell, row.LastChild);
                return newCell;
            //}
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
            cfW.Append(new Alignment() { Vertical = VerticalAlignmentValues.Top, Horizontal = HorizontalAlignmentValues.Left, WrapText = true });
            CellFormats cellFormats = new CellFormats(cf, cfW);
            styleSheet = new Stylesheet(fonts, fills, borders, cellFormats);
            return styleSheet;
        }
    }
}
