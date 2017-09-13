using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
//Namespaces needed for Excel processing
using System.Reflection;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace csReporter
{
    class ExcelReport
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
        private columnNames currentColumn;
        private uint currentRow;

        public ExcelReport(string filePath)
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
            currentColumn = columnNames.A;
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

        public void WriteReportFilter(FilterObject filter, int matchCount)
        {
            WriteNextRow(new List<string> { "Criterial" });
            //WriteCell("Criteria", columnNames.A, currentRow++);
            WriteNextRow(columnNames.B, new List<string> { "Data Type:", filter.FilterState.ToString() });
            //WriteCell("Data Type:", columnNames.B, currentRow);
            //WriteCell("" + filter.FilterState, columnNames.C, currentRow++);
            WriteNextRow(columnNames.B, new List<string> { "Object Type:", String.Join("\n", filter.ObjectTypes) });
            //WriteCell("Object Types:", columnNames.B, currentRow);
            //WriteCell(String.Join("\n", filter.ObjectTypes), columnNames.C, currentRow++);
            WriteNextRow(columnNames.B, new List<string> { "Operations:", String.Join("\n", filter.Operations) });
            //WriteCell("Operations:", columnNames.B, currentRow);
            //WriteCell(String.Join("\n", filter.Operations), columnNames.C, currentRow++);
            //WriteCell("Attribute Filters:", columnNames.B, currentRow);
            if (filter.AttributeFilters.Count > 0)
            {
                string strFilters = "";
                foreach (FilterAttribute FA in filter.AttributeFilters)
                {
                    strFilters += FA.Attribute + " " + FA.Operation + " " + FA.Value + "\n";
                }
                strFilters.Remove(strFilters.Length - 1, 1);
                //WriteCell(strFilters, columnNames.C, currentRow++);
                WriteNextRow(columnNames.B, new List<string> { "Attribute Filters:", });
            }
            WriteNextRow(columnNames.B, new List<string> { "Report Attributes:", String.Join("\n", filter.ReportAttributes) });
            //WriteCell("Report Attributes:", columnNames.B, currentRow);
            //WriteCell(String.Join("\n", filter.ReportAttributes), columnNames.C, currentRow++);
            WriteNextRow(columnNames.B, new List<string> { "Object Count:", matchCount.ToString() });
            //WriteCell("Object Count:", columnNames.B, currentRow);
            //WriteCell(matchCount.ToString(), columnNames.C, currentRow);

            //empty row before report headers
            currentRow += 2;
            // Save the new worksheet.
            ws.Save();
            wbp.Workbook.Save();
        }

        public void WriteReportHeader(FilterObject filter, List<string> sysAttribs, List<string> errorAttribs)
        {
            List<string> dataValues = new List<string>();
            dataValues.Add("CS distinguished name");
            dataValues.Add("Object Type");
            //WriteCell("CS distinguished name", columnNames.A, currentRow);
            //WriteCell("Object Type", columnNames.B, currentRow);
            currentColumn = columnNames.C;
            if (filter.FilterState == State.Synchronized)
            {
                foreach (string Attrib in filter.ReportAttributes)
                {
                    if (Attrib != "<DN>")
                    {
                        //WriteCell(Attrib, currentColumn++, currentRow);
                        dataValues.Add(Attrib);
                    }
                }
            }
            else
            {
                WriteCell("Operation", currentColumn++, currentRow);
                foreach (string Attrib in filter.ReportAttributes)
                {
                    if (Attrib != "<DN>" && (sysAttribs.Contains(Attrib) || errorAttribs.Contains(Attrib)))
                    {
                        //WriteCell(Attrib, currentColumn++, currentRow);
                        dataValues.Add(Attrib);
                    }
                    else
                    {
                        //WriteCell("current " + Attrib, currentColumn++, currentRow);
                        dataValues.Add("current " + Attrib);
                        //WriteCell("new " + Attrib, currentColumn++, currentRow);
                        dataValues.Add("new " + Attrib);
                    }
                }
            }
            WriteNextRow(dataValues);
            // Save the new worksheet.
            ws.Save();
            wbp.Workbook.Save();
        }

        public void WriteCSObject(csObject obj, FilterObject filter, List<string> sysAttribs, List<string> errorAttribs, bool ADdata, List<string> knownADattribs)
        {
            List<string> rowValues = new List<string>();

            if (filter.FilterState == State.Synchronized)
            {
                rowValues.Add(obj.csDN);
                rowValues.Add(obj.ObjectType);

                foreach (string attrib in filter.ReportAttributes)
                {
                    try
                    {
                        if (sysAttribs.Contains(attrib))
                        {
                            switch (attrib)
                            {
                                case "<Connector>":
                                    if (obj.Connector != null)
                                    {
                                        rowValues.Add(obj.Connector.ToString());
                                    }
                                    break;
                                case "<Connect Time>":
                                    if (obj.ConnectionTime != null)
                                    {
                                        rowValues.Add(obj.ConnectionTime.ToString("g"));
                                    }
                                    break;
                                case "<Connector Operation>":
                                    if (obj.ConnectionOperation != "")
                                    {
                                        rowValues.Add(obj.ConnectionOperation);
                                    }
                                    break;
                                case "<Disconnect Time>":
                                    if (obj.DisconnectionTime != null)
                                    {
                                        rowValues.Add(obj.DisconnectionTime.ToString("g"));
                                    }
                                    break;
                                case "<Connector State>":
                                    if (obj.ConnectorState != "")
                                    {
                                        rowValues.Add(obj.ConnectorState);
                                    }
                                    break;
                            }
                        }
                        else if (obj.ExportError != null && errorAttribs.Contains(attrib))
                        {
                            switch (attrib)
                            {
                                case "<ExportErrorDetails>":
                                    StringBuilder errorInfo = new StringBuilder();
                                    if (obj.ExportError.DateOccurred != null)
                                    {
                                        errorInfo.Append("Date Occurred: " + obj.ExportError.DateOccurred + "\n");
                                    }
                                    if (obj.ExportError.FirstOccurred != null)
                                    {
                                        errorInfo.Append("First Occurred: " + obj.ExportError.FirstOccurred + "\n");
                                    }
                                    if (obj.ExportError.RetryCount != null)
                                    {
                                        errorInfo.Append("Retry Count: " + obj.ExportError.RetryCount + "\n");
                                    }
                                    if (obj.ExportError.ErrorType != null)
                                    {
                                        errorInfo.Append("Error Type: " + obj.ExportError.ErrorType + "\n");
                                    }
                                    if (obj.ExportError.ErrorCode != null)
                                    {
                                        errorInfo.Append("Error Code: " + obj.ExportError.ErrorCode + "\n");
                                    }
                                    if (obj.ExportError.ErrorLiteral != null)
                                    {
                                        errorInfo.Append("Error Literal: " + obj.ExportError.ErrorLiteral + "\n");
                                    }
                                    if (obj.ExportError.ServerErrorDetail != null)
                                    {
                                        errorInfo.Append("Server Error Detail: " + obj.ExportError.ServerErrorDetail + "\n");
                                    }
                                    errorInfo.Replace("\r\n", "");
                                    errorInfo.Replace("\"", "'");
                                    errorInfo.Insert(0, "\"");
                                    errorInfo.Append("\"");
                                    rowValues.Add(errorInfo.ToString());
                                    break;
                            }
                        }
                        else
                        {
                            Attribute shAttrib = GetMatchingAttribute(attrib, obj.SynchronizedHologram.Attributes);
                            rowValues.AddRange((AddAttribToReportCSV(shAttrib, ADdata, knownADattribs)).ToArray());
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.handleException(ex, "Error occurred processing an attribute on a object for Excel file.\r\n\r\nDN=" + obj.csDN + "\r\n\r\nAttributeName=" + attrib);
                    }
                }
            }
            //IF should not be necessary.  Operation cannot be none (no longer allowing combined import/export reports)
            else //if (obj.Delta(filter.FilterState).Operation != operation.none)
            {
                rowValues.AddRange(new List<string> { obj.csDN, obj.ObjectType, filter.FilterState.ToString() + "-" + obj.Delta(filter.FilterState).Operation });
                foreach (string attrib in filter.ReportAttributes)
                {
                    try
                    {
                        if (sysAttribs.Contains(attrib))
                        {
                            switch (attrib)
                            {
                                case "<Connector>":
                                    if (obj.Connector != null)
                                    {
                                        rowValues.Add(obj.Connector.ToString());
                                    }
                                    break;
                                case "<Connect Time>":
                                    if (obj.ConnectionTime != null)
                                    {
                                        rowValues.Add(obj.ConnectionTime.ToString("g"));
                                    }
                                    break;
                                case "<Connector Operation>":
                                    if (obj.ConnectionOperation != "")
                                    {
                                        rowValues.Add(obj.ConnectionOperation);
                                    }
                                    break;
                                case "<Disconnect Time>":
                                    if (obj.DisconnectionTime != null)
                                    {
                                        rowValues.Add(obj.DisconnectionTime.ToString("g"));
                                    }
                                    break;
                                case "<Connector State>":
                                    if (obj.ConnectorState != "")
                                    {
                                        rowValues.Add(obj.ConnectorState);
                                    }
                                    break;
                            }
                        }
                        else if (obj.ExportError != null && errorAttribs.Contains(attrib))
                        {
                            switch (attrib)
                            {
                                case "<ExportErrorDetails>":
                                    StringBuilder errorInfo = new StringBuilder();
                                    if (obj.ExportError.DateOccurred != null)
                                    {
                                        errorInfo.Append("Date Occurred: " + obj.ExportError.DateOccurred + "\n");
                                    }
                                    if (obj.ExportError.FirstOccurred != null)
                                    {
                                        errorInfo.Append("First Occurred: " + obj.ExportError.FirstOccurred + "\n");
                                    }
                                    if (obj.ExportError.RetryCount != null)
                                    {
                                        errorInfo.Append("Retry Count: " + obj.ExportError.RetryCount + "\n");
                                    }
                                    if (obj.ExportError.ErrorType != null)
                                    {
                                        errorInfo.Append("Error Type: " + obj.ExportError.ErrorType + "\n");
                                    }
                                    if (obj.ExportError.ErrorCode != null)
                                    {
                                        errorInfo.Append("Error Code: " + obj.ExportError.ErrorCode + "\n");
                                    }
                                    if (obj.ExportError.ErrorLiteral != null)
                                    {
                                        errorInfo.Append("Error Literal: " + obj.ExportError.ErrorLiteral + "\n");
                                    }
                                    if (obj.ExportError.ServerErrorDetail != null)
                                    {
                                        errorInfo.Append("Server Error Detail: " + obj.ExportError.ServerErrorDetail + "\n");
                                    }
                                    errorInfo.Replace("\r\n", "");
                                    errorInfo.Replace("\"", "'");
                                    errorInfo.Insert(0, "\"");
                                    errorInfo.Append("\"");
                                    rowValues.Add(errorInfo.ToString());
                                    break;
                            }
                        }
                        else
                        {
                            Attribute pihAttrib = null;
                            Attribute shAttrib = null;
                            if (obj.Hologram(filter.FilterState) != null)
                            {
                                pihAttrib = GetMatchingAttribute(attrib, obj.Hologram(filter.FilterState).Attributes);
                            }
                            if (obj.SynchronizedHologram != null)
                            {
                                shAttrib = GetMatchingAttribute(attrib, obj.SynchronizedHologram.Attributes);
                            }
                            if (obj.Delta(filter.FilterState).AttributeNames.Contains(attrib))
                            {
                                rowValues.AddRange((AddAttribToReportCSV(pihAttrib, shAttrib, ADdata, knownADattribs)).ToArray());
                            }
                            else if (shAttrib != null)
                            {
                                rowValues.AddRange((AddAttribToReportCSV("(No Change)", shAttrib, ADdata, knownADattribs)).ToArray());
                            }
                            else
                            {
                                rowValues.Add("");
                                rowValues.Add("");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.handleException(ex, "Error occurred processing an attribute on an object for Excel file.\r\n\r\nDN=" + obj.csDN + "\r\n\r\nAttributeName=" + attrib);
                    }
                }
            }
            WriteNextRow(rowValues);
        }

        public void WriteNextRow(List<string> dataValues)
        {
            WriteNextRow(columnNames.A, dataValues);
        }

        private void WriteNextRow(columnNames startColumn, List<string> dataValues)
        {
            foreach (string val in dataValues)
            {
                InsertSharedStringItem(val);
                WriteCell(val, startColumn++, currentRow);
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

        private List<string> AddAttribToReportCSV(Attribute attribute, Attribute syncdAttrib, bool ADdata, List<string> knownADattribs)
        {
            List<string> dataValues = new List<string>();
            StringBuilder strOutput = new StringBuilder("");

            try
            {
                if (syncdAttrib != null && attribute != null)
                {
                    if (ADdata && knownADattribs.Contains(attribute.Name))
                    {
                        //strOutput.Append(syncdAttrib.ADStringValues[0] + "," + attribute.ADStringValues[0]);
                        dataValues.Add(syncdAttrib.ADStringValues[0]);
                        dataValues.Add(attribute.ADStringValues[0]);
                    }
                    else
                    {
                        foreach (string val in syncdAttrib.StringValues)
                        {
                            string strTemp = val;
                            if (Regex.IsMatch(strTemp, @"^[^A-Za-z]"))//(Regex.IsMatch(strTemp, @"^\d"))
                            {
                                strTemp = strTemp.Insert(0, "'");
                            }
                            strOutput.Append(strTemp + "\n");
                        }
                        strOutput.Remove(strOutput.Length - 1, 1);
                        dataValues.Add(strOutput.ToString());
                        strOutput = new StringBuilder();

                        foreach (string val in attribute.StringValues)
                        {
                            string strTemp = val;
                            if (Regex.IsMatch(strTemp, @"^[^A-Za-z]"))//(Regex.IsMatch(strTemp, @"^\d"))
                            {
                                strTemp = strTemp.Insert(0, "'");
                            }
                            strOutput.Append(strTemp + "\n");
                        }
                        strOutput.Remove(strOutput.Length - 1, 1);
                        dataValues.Add(strOutput.ToString());
                    }
                }
                else if (syncdAttrib == null && attribute != null)
                {
                    if (ADdata && knownADattribs.Contains(attribute.Name))
                    {
                        //strOutput.Append("," + attribute.ADStringValues[0]);
                        dataValues.Add("");
                        dataValues.Add(attribute.ADStringValues[0]);
                    }
                    else
                    {
                        foreach (string val in attribute.StringValues)
                        {
                            string strTemp = val;
                            if (Regex.IsMatch(strTemp, @"^[^A-Za-z]"))//(Regex.IsMatch(strTemp, @"^\d"))
                            {
                                strTemp = strTemp.Insert(0, "'");
                            }
                            strOutput.Append(strTemp + "\n");
                        }
                        strOutput.Remove(strOutput.Length - 1, 1);
                        dataValues.Add(strOutput.ToString());
                        strOutput = new StringBuilder();
                    }
                }
                else if (syncdAttrib != null && attribute == null)
                {
                    if (ADdata && knownADattribs.Contains(syncdAttrib.Name))
                    {
                        //strOutput.Append(syncdAttrib.ADStringValues[0] + ",(Deleted)");
                        dataValues.Add(syncdAttrib.ADStringValues[0]);
                        dataValues.Add("(Deleted)");
                    }
                    else
                    {
                        foreach (string val in syncdAttrib.StringValues)
                        {
                            string strTemp = val;
                            if (Regex.IsMatch(strTemp, @"^[^A-Za-z]"))//(Regex.IsMatch(strTemp, @"^\d"))
                            {
                                strTemp = strTemp.Insert(0, "'");
                            }
                            strOutput.Append(strTemp + "\n");
                        }
                        strOutput.Remove(strOutput.Length - 1, 1);
                        dataValues.Add(strOutput.ToString());
                        strOutput = new StringBuilder();
                        //strOutput.Append("\",(Deleted)");
                        dataValues.Add("(Deleted)");
                    }
                }
                else if (syncdAttrib == null && attribute == null)
                {
                    //strOutput.Append(",");
                    dataValues.Add("");
                    dataValues.Add("");
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "";
                if (attribute != null)
                {
                    errorMessage = "Error getting attribute values\r\nAttributeName=" + attribute.Name;
                }
                else if (syncdAttrib != null)
                {
                    errorMessage = "Error getting attribute values\r\nAttributeName=" + syncdAttrib.Name;
                }
                ExceptionHandler.handleException(ex, errorMessage);
                //Application.Exit();
            }
            //return strOutput.ToString();
            return dataValues;
        }

        private List<string> AddAttribToReportCSV(string attribValue, Attribute syncdAttrib, bool ADdata, List<string> knownADattribs)
        {
            List<string> dataValues = new List<string>();
            StringBuilder strOutput = new StringBuilder("");

            try
            {
                if (ADdata && knownADattribs.Contains(syncdAttrib.Name))
                {
                    //strOutput.Append(syncdAttrib.ADStringValues[0] + "," + attribValue);
                    dataValues.Add(syncdAttrib.ADStringValues[0]);
                    dataValues.Add(attribValue);
                }
                else
                {
                    string strTemp = "";
                    foreach (string val in syncdAttrib.StringValues)
                    {
                        strTemp = val;
                        if (Regex.IsMatch(strTemp, @"^[^A-Za-z]"))//(Regex.IsMatch(strTemp, @"^\d"))
                        {
                            strTemp = strTemp.Insert(0, "'");
                        }
                        strOutput.Append(strTemp + "\n");
                    }
                    strOutput.Remove(strOutput.Length - 1, 1);
                    dataValues.Add(strOutput.ToString());
                    strOutput = new StringBuilder();

                    strTemp = attribValue;
                    if (Regex.IsMatch(strTemp, @"^[^A-Za-z]"))//(Regex.IsMatch(strTemp, @"^\d"))
                    {
                        strTemp = strTemp.Insert(0, "'");
                    }
                    dataValues.Add(strOutput.ToString());
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "";
                if (attribValue != null)
                {
                    errorMessage = "Error getting attribute values\r\nAttribValue=" + attribValue;
                }
                else if (syncdAttrib != null)
                {
                    errorMessage = "Error getting attribute values\r\nAttributeName=" + syncdAttrib.Name;
                }
                ExceptionHandler.handleException(ex, errorMessage);
                //Application.Exit();
            }
            //return strOutput.ToString();
            return dataValues;
        }

        private List<string> AddAttribToReportCSV(Attribute syncdAttrib, bool ADdata, List<string> knownADattribs)
        {
            List<string> dataValues = new List<string>();
            StringBuilder strOutput = new StringBuilder("");

            try
            {
                if (syncdAttrib != null)
                {
                    if (ADdata && knownADattribs.Contains(syncdAttrib.Name))
                    {
                        //strOutput.Append(syncdAttrib.ADStringValues[0]);
                        dataValues.Add(syncdAttrib.ADStringValues[0]);
                    }
                    else
                    {
                        foreach (string val in syncdAttrib.StringValues)
                        {
                            string strTemp = val;
                            if (Regex.IsMatch(strTemp, @"^[^A-Za-z]"))//(Regex.IsMatch(strTemp, @"^\d"))
                            {
                                strTemp = strTemp.Insert(0, "'");
                            }
                            //strTemp = strTemp.Replace("\\,", ",");
                            strOutput.Append(strTemp + "\n");
                        }
                        strOutput.Remove(strOutput.Length - 1, 1);
                        dataValues.Add(strOutput.ToString());
                    }
                }
                else
                {
                    dataValues.Add("");
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Error getting attribute values";
                if (syncdAttrib != null)
                {
                    errorMessage = "\r\nAttributeName=" + syncdAttrib.Name;
                }
                ExceptionHandler.handleException(ex, errorMessage);
                //Application.Exit();
            }
            //return strOutput.ToString();
            return dataValues;
        }
    }
}
