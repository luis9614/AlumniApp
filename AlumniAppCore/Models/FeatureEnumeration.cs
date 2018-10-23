using System;
using System.Collections.Generic;

namespace AlumniAppCore.Models
{
    public enum FeatureEnumeration
    {
        OWN_CALS,       //0
        OWN_PROFILE,    // 1
        BASIC_INFO,     // 2
        ALL_CALS,       // 3
        DOWNLOAD_CALS,  // 4
    }
    public class EnumUtils{
        public static string[] GetOptions(){
            string[] opt = { "own_cals", "own_profile", "basic_info", "all_cals", "download_cals" };
            return opt;
        }
    }

    public class Feature{
        public string Title
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public string Method
        {
            get;
            set;
        }
        public string Controller
        {
            get;
            set;
        }
        public string ImageUrl
        {
            get;
            set;
        }
        public string Button{
            get;
            set;
        }

        public Feature(string title, string description, string method, string controller, string imageUrl, string button)
        {
            Title = title;
            Description = description;
            Method = method;
            Controller = controller;
            ImageUrl = imageUrl;
            Button = button;
        }
    }

    public class FeatureManager{
        public static Feature[] Features = {
            new Feature( "My Grades", "See a detailed view of my semester.", "MyCals", "Academic", "~/images/mycals.jpg", "Check Grades"),
            new Feature( "My Profile", "See a detailed view of my profile.", "MyProfile", "Academic", "~/images/profile.png", "View"),
            new Feature( "My Info", "See a detailed view of my information.", "MyCals", "Academic", "~/images/cals.jpg", "View"),
            new Feature( "Grades", "See a detailed view of the whole group's grades.", "GetAllGrades", "Academic", "~/images/classroom.jpg", "All Grades"),
            new Feature( "Download my Grades", "Download a copy of my semester's grades.", "DownloadGrades", "Academic", "~/images/grades.jpg", "Download")
        };
        public static List<Feature> GetFeatures(Boolean[] options){
            List<Feature> result = new List<Feature>();
            for (int i = 0; i < options.Length;i++){
                if(options[i]){
                    result.Add(Features[i]);
                }
            }
            return result;
        }
    }
}