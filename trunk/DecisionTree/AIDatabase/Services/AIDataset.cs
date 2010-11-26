using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AIDT.AIDatabase.Services
{
    public partial class AIDataset
    {
        public static DataTable MakeFullDataSet()
        {
            using (EntitiesDataContext db = new EntitiesDataContext())
            {
                var _data = (from classDetails in db.ClassDetails
                                        from courseDetails in db.CourseDetails
                                        from courseGroups in db.CourseGroups
                                        from classTimes in db.ClassTimes
                                        from teacherDetails in db.TeacherDetails
                                        from courseCertificates in db.CourseCertificates
                                        from customerDetails in db.CustomerDetails
                                        from occupationTypes in db.OccupationTypes
                                        from classArrangements in db.ClassArrangements
                                        where
                                        ((customerDetails.OccupationTypeId == occupationTypes.OccupationTypeId) &&
                                        (customerDetails.CustomerId == classArrangements.CustomerId) &&
                                        (classDetails.ClassId == classArrangements.ClassId) &&
                                        (classDetails.ClassTime == classTimes.ClassTimeId) &&
                                        (classDetails.CourseId == courseDetails.CourseId) &&
                                        (courseDetails.CourseGroup == courseGroups.CourseGroupId) &&
                                        (teacherDetails.TeacherId == classDetails.TeacherId) &&
                                        (courseCertificates.CertificateId == courseDetails.CourseCertificate))
                                        select new
                                        {
                                            courseDetails.CourseName,
                                            CourseCertificate = courseCertificates.CertificateName,
                                            GroupName = courseGroups.Name,
                                            courseDetails.CourseFee,
                                            classTimes.TimeName,
                                            teacherDetails.TeacherName,
                                            IsStudentLearned = (occupationTypes.OccupationName == "Sinh Viên") ? "True" : "False"
                                        });

                DataTable _dataTable = new DataTable("College");

                _dataTable.Columns.Add("CourseName");
                _dataTable.Columns.Add("CourseCertificate");
                _dataTable.Columns.Add("GroupName");
                _dataTable.Columns.Add("CourseFee");
                _dataTable.Columns.Add("TimeName");
                _dataTable.Columns.Add("IsStudentLearned");

                foreach (var p in _data)
                {
                    string[] _tempStr = { p.CourseName, p.CourseCertificate, p.GroupName, p.CourseFee.ToString(), p.TimeName, p.IsStudentLearned };
                    _dataTable.Rows.Add(_tempStr);
                }

                return _dataTable;
            }
        }

        public static DataTable MakeRandomDataset()
        {
            System.Random _random = new System.Random();
            using (EntitiesDataContext db = new EntitiesDataContext())
            {
                var _data = (from classDetails in db.ClassDetails
                             from courseDetails in db.CourseDetails
                             from courseGroups in db.CourseGroups
                             from classTimes in db.ClassTimes
                             from teacherDetails in db.TeacherDetails
                             from courseCertificates in db.CourseCertificates
                             from customerDetails in db.CustomerDetails
                             from occupationTypes in db.OccupationTypes
                             from classArrangements in db.ClassArrangements
                             where
                             ((customerDetails.OccupationTypeId == occupationTypes.OccupationTypeId) &&
                             (customerDetails.CustomerId == classArrangements.CustomerId) &&
                             (classDetails.ClassId == classArrangements.ClassId) &&
                             (classDetails.ClassTime == classTimes.ClassTimeId) &&
                             (classDetails.CourseId == courseDetails.CourseId) &&
                             (courseDetails.CourseGroup == courseGroups.CourseGroupId) &&
                             (teacherDetails.TeacherId == classDetails.TeacherId) &&
                             (courseCertificates.CertificateId == courseDetails.CourseCertificate))
                             orderby _random.Next()
                             select new
                             {
                                 courseDetails.CourseName,
                                 CourseCertificate = courseCertificates.CertificateName,
                                 GroupName = courseGroups.Name,
                                 courseDetails.CourseFee,
                                 classTimes.TimeName,
                                 teacherDetails.TeacherName,
                                 IsStudentLearned = (occupationTypes.OccupationName == "Sinh Viên")?"True":"False"
                             });

                DataTable _dataTable = new DataTable("College");

                _dataTable.Columns.Add("CourseName");
                _dataTable.Columns.Add("CourseCertificate");
                _dataTable.Columns.Add("GroupName");
                _dataTable.Columns.Add("CourseFee");
                _dataTable.Columns.Add("TimeName");
                _dataTable.Columns.Add("IsStudentLearned");

                var _randomData = _data.Take(_data.Count() / 2);

                foreach (var p in _randomData)
                {
                    string[] _tempStr = { p.CourseName, p.CourseCertificate, p.GroupName, p.CourseFee.ToString(), p.TimeName, p.IsStudentLearned };
                    _dataTable.Rows.Add(_tempStr);
                }

                return _dataTable;
            }
        }

        public static string[] MakeRecord(ClassDetail classDetails)
        {
            using (EntitiesDataContext db = new EntitiesDataContext())
            {
                var _data = (from courseDetails in db.CourseDetails
                             from courseGroups in db.CourseGroups
                             from classTimes in db.ClassTimes
                             from teacherDetails in db.TeacherDetails
                             from courseCertificates in db.CourseCertificates
                             where (
                             (classDetails.ClassTime == classTimes.ClassTimeId) &&
                             (classDetails.CourseId == courseDetails.CourseId) &&
                             (courseDetails.CourseGroup == courseGroups.CourseGroupId) &&
                             (teacherDetails.TeacherId == classDetails.TeacherId) &&
                             (courseCertificates.CertificateId == courseDetails.CourseCertificate))
                             select new
                             {
                                 courseDetails.CourseName,
                                 CourseCertificate = courseCertificates.CertificateName,
                                 GroupName = courseGroups.Name,
                                 courseDetails.CourseFee,
                                 classTimes.TimeName,
                                 teacherDetails.TeacherName,
                             }).Single();
                string[] _returnValue = { _data.CourseName, _data.CourseCertificate, _data.GroupName,_data.CourseFee.ToString(), _data.TimeName, _data.TeacherName };

                return _returnValue;
            }
        }

    }
}
