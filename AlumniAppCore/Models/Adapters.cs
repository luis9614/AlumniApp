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
            return new DataTable();
        }
    }

    public interface IGrades
    {
        DataTable GetGrades(int UserId);
    }

    // Profile Adapter
}
