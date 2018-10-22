using System;
using System.Collections.Generic;
using System.Data;
using Alumni.App.Db;
using Alumni.App.Db.DTO;
using AlumniAppCore.Controllers;
using AlumniAppCore.Models;
namespace AlumniAppCore.Models.Adapters
{
    // Grades Adapter
    public class GradesAdapter : IGrades
    {
        private readonly AcademicService _db;
        public GradesAdapter(){
            _db = AcademicService.GetInstance;
        }

        public DataTable GetGrades(int UserId)
        {
            DataTable Grades = new DataTable();
            List<UserSubjectDto> Subjects = _db._service.GetSubjectsAndGradesByUser(UserId);

            // datatable filling
            Grades.Clear();
            Grades.Columns.Add("Subject");
            Grades.Columns.Add("FirstTerm");
            Grades.Columns.Add("SecondTerm");
            Grades.Columns.Add("FinalTerm");
            Grades.Columns.Add("Average");

            foreach(var Subject in Subjects){
                DataRow AuxRow = Grades.NewRow();

                AuxRow["Subject"] = Subject.SubjectName;
                AuxRow["FirstTerm"] = Subject.Grade1;
                AuxRow["SecondTerm"] = Subject.Grade2;
                AuxRow["FinalTerm"] = Subject.Grade2;
                AuxRow["Average"] = Subject.AverageSubject;

                Grades.Rows.Add(AuxRow);
            }
            return Grades;
        }
    }

    public interface IGrades
    {
        DataTable GetGrades(int UserId);
    }

    // Profile Adapter
    public class ProfileAdapter : IProfile
    {
        private readonly UserDBService _db;
        public ProfileAdapter(){
            _db = UserDBService.GetInstance;
        }
        public DataTable GetProfile(int UserId)
        {
            UserDto LegacyProfile = _db._service.GetProfile(UserId);

            DataTable Profile = new DataTable();
            Profile.Clear();
            Profile.Columns.Add("Key");
            Profile.Columns.Add("Value");

            DataRow AuxRow = Profile.NewRow();
            AuxRow["Key"] = "Full Name";
            AuxRow["Value"] = LegacyProfile.FullName;
            Profile.Rows.Add(AuxRow);

            AuxRow = Profile.NewRow();
            AuxRow["Key"] = "Address";
            AuxRow["Value"] = LegacyProfile.Address;
            Profile.Rows.Add(AuxRow);

            AuxRow = Profile.NewRow();
            AuxRow["Key"] = "e-mail";
            AuxRow["Value"] = LegacyProfile.Email;
            Profile.Rows.Add(AuxRow);

            return Profile;
        }
    }

    public interface IProfile
    {
        DataTable GetProfile(int UserId);
    }
}
