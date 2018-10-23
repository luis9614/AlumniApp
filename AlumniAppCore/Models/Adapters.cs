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
        private readonly UserDBService _dbUsers;
        public GradesAdapter(){
            _db = AcademicService.GetInstance;
            _dbUsers = UserDBService.GetInstance;
        }

        public GroupGrades GetAllGrades(int UserId)
        {

            GroupGrades GGrades = new GroupGrades();
            DataTable Grades = new DataTable();
            List<UserSubjectDto> Subjects = _db._service.GetSubjectsAndGradesByUser(UserId);
            UserDto Teacher = _dbUsers._service.GetProfile(UserId);
            // datatable filling
            Grades.Clear();
            Grades.Columns.Add("Student");
            Grades.Columns.Add("Subject");
            Grades.Columns.Add("First Term");
            Grades.Columns.Add("Second Term");
            Grades.Columns.Add("Final Term");
            Grades.Columns.Add("Average");

            foreach (var Subject in Subjects)
            {
                DataRow AuxRow = Grades.NewRow();
                UserDto AuxUser = _dbUsers._service.GetProfile(Subject.IdUser);
                AuxRow["Student"] = AuxUser.FullName;
                AuxRow["Subject"] = Subject.SubjectName;
                AuxRow["First Term"] = Subject.Grade1;
                AuxRow["Second Term"] = Subject.Grade2;
                AuxRow["Final Term"] = Subject.Grade2;
                AuxRow["Average"] = Subject.AverageSubject;

                Grades.Rows.Add(AuxRow);
            }
            GGrades.SubjectName = Subjects[0].SubjectName;
            GGrades.Grades = Grades;
            GGrades.TeacherName = Teacher.FullName;
            return GGrades;
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
        GroupGrades GetAllGrades(int UserId);
    }

    public class GroupGrades
    {
        public string SubjectName
        {
            get;
            set;
        }
        public string TeacherName
        {
            get;
            set;
        }
        public DataTable Grades
        {
            get;
            set;
        }
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
