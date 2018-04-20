using System;
using System.Collections.Generic;

namespace Planner.Models
{
    public class DspacePublicationModel
    {
        public List<String> Authors { get; set; }
        public List<String> Identifiers { get; set; }
        public Language Language { get; set; }
        public String Title { get; set; }
        public List<String> AlternativeTitles { get; set; }
        public ItemType Type { get; set; }
        public String SerialNumber { get; set; }
        public String ReportNumber { get; set; }
        public List<String> UDK { get; set; }
        public List<String> BBK { get; set; }
        public List<String> Keywords { get; set; }
        public String Sponsor { get; set; }
        public List<String> Annotation { get; set; }
        public String Description { get; set; }
        public String Error { get; set; }
    }

    public enum Language
    {
        en = 1,
        ru,
        ua
    }

    public enum ItemType
    {
        Animation = 1,
        Article,
        Chapter,
        Dataset,
        EducationalObject
    }
}