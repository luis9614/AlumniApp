using System;
using System.Collections.Generic;
using System.Data;
using Alumni.App.Db;
using Alumni.App.Db.DTO;
namespace AlumniAppCore.Controllers
{
    public class AcademicService
    {
        protected static AcademicService _academicDB;
        public AcademicInfoService _service;

        /// <summary>
        /// Initializes a new instance of the DBConnection class.
        /// </summary>
        protected AcademicService()
        {
            this._service = new AcademicInfoService();
        }

        /// <summary>
        /// Gets the single instance for the DB interface.
        /// </summary>
        /// <value>The get instance.</value>
        public static AcademicService GetInstance
        {
            get
            {
                if (_academicDB == null)
                {
                    _academicDB = new AcademicService();
                }
                return _academicDB;
            }
        }

        public virtual List<UserSubjectDto> GetGrades(int UserId)
        {
            List<UserSubjectDto> Subjects = this._service.GetSubjectsAndGradesByUser(UserId);
            return this._service.GetSubjectsAndGradesByUser(UserId);
        }
    }
}
