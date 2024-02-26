﻿/*
MIT License

Copyright (c) 2017 David Cassady

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;



namespace csReporter
{
    public enum reportType { HTML, CSV, Excel };

    public enum operation { none, add, replace, update, delete, deleteAdd };

    public enum State { UnappliedExport, EscrowedExport, UnconfirmedExport, PendingImport, Synchronized };

    public enum FilterLevel { State, ObjectType, Operation, AttributeValue };

    class FilterObject
    {
        State filterState;
        List<string> objTypes = new List<string>();
        List<operation> ops = new List<operation>();
        List<string> availableAttribs = new List<string>();
        BindingList<FilterAttribute> attribFilters = new BindingList<FilterAttribute>();
        private FilterLevel lev;

        public FilterObject()
        { }
        public FilterObject(State FilterState, FilterLevel level)
        {
            filterState = FilterState;
            lev = level;
        }
        public FilterObject(State FilterState, FilterLevel level, List<string> objectTypes)
        {
            filterState = FilterState;
            lev = level;
            objTypes = objectTypes;
        }
        public FilterObject(State FilterState, FilterLevel level, List<string> objectTypes, List<operation> operations)
        {
            filterState = FilterState;
            lev = level;
            objTypes = objectTypes;
            ops = operations;
        }
        public FilterObject(State FilterState, FilterLevel level, List<string> objectTypes, List<operation> operations, List<string> attributes)
        {
            filterState = FilterState;
            lev = level;
            objTypes = objectTypes;
            ops = operations;
            availableAttribs = attributes;
        }
        public FilterObject(State FilterState, FilterLevel level, List<string> objectTypes, List<operation> operations, List<string> attributes, BindingList<FilterAttribute> filters)
        {
            filterState = FilterState;
            lev = level;
            objTypes = objectTypes;
            ops = operations;
            availableAttribs = attributes;
            attribFilters = filters;
        }

        public State FilterState
        {
            get
            {
                return filterState;
            }
            set
            {
                filterState = value;
            }
        }

        public List<string> ObjectTypes
        {
            get
            {
                return objTypes;
            }
            set
            {
                objTypes = value;
            }
        }

        public List<operation> Operations
        {
            get
            {
                return ops;
            }
            set
            {
                ops = value;
            }
        }

        public List<string> AvailableAttributes
        {
            get
            {
                return availableAttribs;
            }
            set
            {
                availableAttribs = value;
            }
        }
        
        public BindingList<FilterAttribute> AttributeFilters
        {
            get
            {
                return attribFilters;
            }
            set
            {
                attribFilters = value;
            }
        }

        public FilterLevel Level
        {
            get
            {
                return lev;
            }
            set
            {
                lev = value;
            }
        }

        public void Clear()
        {
            ObjectTypes.Clear();
            ops.Clear();
            availableAttribs.Clear();
            attribFilters.Clear();
            lev = new FilterLevel();
        }
    }

    class ReportObject
    {
        reportType type;
        List<string> reportAttribs = new List<string>();
        bool horizontal = true;
        int fSize = 10;
        bool includeFilter = true;

        public ReportObject()
        { }

        public ReportObject(reportType reportType, List<string> attributes)
        {
            type = reportType;
            reportAttribs = attributes;
            horizontal = true;
        }

        public ReportObject(reportType reportType, List<string> attributes, bool horizontal)
        {
            type = reportType;
            reportAttribs = attributes;
            this.horizontal = horizontal;
        }

        public reportType ReportType
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public List<string> ReportAttributes
        {
            get
            {
                return reportAttribs;
            }
            set
            {
                reportAttribs = value;
            }
        }
        public bool Horizontal
        {
            get
            {
                return horizontal;
            }
            set
            {
                horizontal = value;
            }
        }

        public int FontSize
        {
            get
            {
                return fSize;
            }
            set
            {
                fSize = value;
            }
        }

        public bool IncludeFilter
        {
            get
            {
                return includeFilter;
            }
            set
            {
                includeFilter = value;
            }
        }
    }
    //implements interfaces for binding list and DataGrig control
    class FilterAttribute : INotifyPropertyChanged, IEquatable<FilterAttribute>
    {
        private string attrib;
        private string comparator;
        private string val;

        //required for binding list and DataGrid control
        public event PropertyChangedEventHandler PropertyChanged;


        public FilterAttribute(string attribute, string operation, string value)
        {
            attrib = attribute;
            comparator = operation;
            val = value;
            this.NotifyPropertyChanged(attribute);
        }

        public string Attribute
        {
            get
            {
                return attrib;
            }
        }

        public string Operation
        {
            get
            {
                return comparator;
            }
        }

        public string Value
        {
            get
            {
                return val;
            }
        }

        public bool Equals(FilterAttribute other)
        {
            return this.Attribute == other.Attribute && this.Value == other.Value && this.Operation == other.Operation;
        }

        //required for binding list and DataGrid control
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    static class ExceptionHandler
    {
        private static string getErrorMessage(Exception ex, int depth)
        {
            string erMsg = "\r\n\r\n";
            if (depth > 0)
            {
                erMsg += "****Inner Exception****\r\n";
            }
            if (depth < 10)
            {
                if (ex.Message != string.Empty)
                {
                    erMsg += "Exception message:\r\n" + ex.Message;
                }
                erMsg += "\r\n\r\nException Type: " + ex.GetType().ToString();
                if (ex.StackTrace != null)
                {
                    erMsg += "\r\n\r\nStack trace:\r\n" + ex.StackTrace;
                }
                if (ex.InnerException != null)
                {
                    erMsg += getErrorMessage(ex.InnerException, ++depth);
                }
            }
            else
            {
                erMsg = "\r\n\r\n######## More than 10 exceptions.  Too many to display.########";
            }
            return erMsg;
        }

        public static void handleException(Exception ex, string bannerMsg)
        {
            string errorInfo = "";
            if (ex != null)
            {
                errorInfo = getErrorMessage(ex, 0);
            }
            frmError errorForm = new frmError(bannerMsg, errorInfo);
            errorForm.ShowDialog();
        }
        public static void handleException(string bannerMsg)
        {
            frmError errorForm = new frmError(bannerMsg, "");
            errorForm.ShowDialog();
        }
    }

    public delegate void LoadCompletedEventHandler(object sender, EventArgs e);

    class CustomConcurrentBag<T> : ConcurrentBag<T>
    {
        private bool loadingComplete;
        public event LoadCompletedEventHandler FinishedLoading;

        public bool LoadingComplete
        {
            get
            {
                return loadingComplete;
            }
            set
            {
                loadingComplete = value;
                if (this.FinishedLoading != null)
                {
                    FinishedLoading(this, EventArgs.Empty);
                }
            }
        }
    }

    class StringContainer
    {
        private List<string> list;
        private bool lowMem;

        public StringContainer(int capacity, bool lowMemory)
        {
            list = new List<string>(capacity);
            list.Add("");
            lowMem = lowMemory;
        }

        public int Add(string item)
        {
            switch (lowMem)
            {
                case true:
                    list.Add(item);
                    return list.Count - 1;
                case false:
                    int i = list.IndexOf(item);
                    if (i == -1)
                    {
                        list.Add(item);
                        return list.Count - 1;
                    }
                    else
                    {
                        return i;
                    }
            }
            return list.IndexOf(item);
        }
        public string this[int index]
        {
            get
            {
                return list[index];
            }
        }
        public int Capacity
        {
            get
            {
                return list.Capacity;
            }
        }
        public void Clear()
        {
            list.Clear();
        }
        public int Count
        {
            get
            {
                return list.Count;
            }
        }
        public void TrimExcess()
        {
            list.TrimExcess();
        }
    }
}