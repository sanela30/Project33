using Excel= Microsoft.Office.Interop.Excel;


namespace Project33.libraries
{
    internal class CSVHandlers
    {

        private Excel.Application App;
        private Excel.Workbook Workbook;
        private Excel.Worksheet Sheet;
            
        public CSVHandlers()
        {
            this.App = new Excel.Application();
        }

        public Excel.Worksheet OpetCSV(string CSVFile, string CSVDelimiter = ",")
        {
            this.Workbook=this.App.Workbooks.Open(CSVFile,Format:Excel.XlFileFormat.xlCSV,Delimiter:CSVDelimiter);
            this.Sheet = this.Workbook.ActiveSheet;
            return this.Sheet;
        }
    }
}
