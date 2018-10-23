using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

using GemBox.Document;

namespace AlumniAppCore.Models.Exporter
{
    public abstract class IExporter
    {
        protected ExporterImplementor _exporter;

        public IExporter(ExporterImplementor exporter)
        {
            _exporter = exporter;
        }
        public abstract DownloadableGrades Export(DataTable dataTable);
    }

    public abstract class ExporterImplementor
    {
        public abstract DownloadableGrades Export(DataTable Grades);
    }

    public class Exporter : IExporter
    {
        public Exporter(ExporterImplementor exporter) : base(exporter)
        {
        }

        public override DownloadableGrades Export(DataTable dataTable)
        {
            return _exporter.Export(dataTable);
        }
    }

    public class TXTExporter : ExporterImplementor
    {
        public override DownloadableGrades Export(DataTable Grades)
        {
            var TempPath = System.IO.Path.GetTempFileName();
            StreamWriter writer = new StreamWriter(TempPath);

            foreach (DataRow row in Grades.Rows)
            {
                List<string> items = new List<string>();
                foreach (DataColumn col in Grades.Columns)
                {
                    items.Add(row[col.ColumnName].ToString());
                }
                string Line = string.Join(",", items.ToArray());
                writer.Write(Line);
                writer.WriteLine();
            }
            writer.Close();
            
            DownloadableGrades DGrades = new DownloadableGrades();


            DGrades.FileName = "grades.txt";
            DGrades.Data = File.ReadAllBytes(TempPath);
            writer.Dispose();
            return DGrades;

        }
    }

    public class WordExporter : ExporterImplementor
    {
        public override DownloadableGrades Export(DataTable Grades)
        {
            var TempPath = System.IO.Path.GetTempFileName() + Guid.NewGuid().ToString() + ".docx"; ;
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            var doc = new DocumentModel();

            foreach (DataRow row in Grades.Rows)
            {
                List<string> items = new List<string>();
                foreach (DataColumn col in Grades.Columns)
                {
                    items.Add(row[col.ColumnName].ToString());
                }
                string Line = string.Join(",", items.ToArray());
                doc.Sections.Add(new Section(doc, new Paragraph(doc, Line)));
            }
            doc.Save(TempPath);
            DownloadableGrades DGrades = new DownloadableGrades();


            DGrades.FileName = "grades.docx";
            DGrades.Data = File.ReadAllBytes(TempPath);
            return DGrades;
        }
    }

    public class DownloadableGrades
    {
        public byte[] Data
        {
            get;
            set;
        }
        public string FileName
        {
            get;
            set;
        }
    }

}
