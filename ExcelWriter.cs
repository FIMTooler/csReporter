using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            foreach (SharedStringItem item in ssp.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text)
                {
                    return i;
                }

                i++;
            }

            // The text does not exist in the part. Create the SharedStringItem and return its index.
            ssp.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(text)));
            ssp.SharedStringTable.Save();

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
            if (sd.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
            {
                row = sd.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
            }
            else
            {
                row = new Row() { RowIndex = rowIndex };
                sd.Append(row);
            }

            // If there is not a cell with the specified column name, insert one.
            //empty string converts columnName to string
            if (row.Elements<Cell>().Where(c => c.CellReference.Value == "" + columnName + rowIndex).Count() > 0)
            {
                return row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).First();
            }
            else
            {
                // Cells must be in sequential order according to CellReference. Determine where to insert the new cell.
                Cell refCell = null;
                foreach (Cell cell in row.Elements<Cell>())
                {
                    //Compare using Enum which is numerics.
                    //String compare causes errors with AA coming before B which is not case in Excel columns
                    string existingCellColumn = Regex.Replace(cell.CellReference.Value, "[0-9]", "");
                    string newCellColumn = Regex.Replace(cellReference, "[0-9]", "");
                    columnNames existingCellCol;
                    Enum.TryParse<columnNames>(existingCellColumn, out existingCellCol);
                    columnNames newCellCol;
                    Enum.TryParse<columnNames>(newCellColumn, out newCellCol);
                    if (existingCellCol > newCellCol)
                    {
                        refCell = cell;
                        break;
                    }
                }

                Cell newCell = new Cell() { CellReference = cellReference };
                row.InsertBefore(newCell, refCell);

                ws.Save();
                return newCell;
            }
        }

        private void WriteCell(string value, columnNames column, uint row)
        {
            int index = InsertSharedStringItem(value);
            Cell cell = InsertCellInWorksheet(column, row);
            cell.CellValue = new CellValue(index.ToString());
            cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
        }
        
        private Attribute GetMatchingAttribute(string inputName, List<Attribute> attribList)
        {
            return attribList.Find(attrib => attrib.Name == inputName);
        }

    }
}
