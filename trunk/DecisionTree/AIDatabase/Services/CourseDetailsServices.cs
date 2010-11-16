using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIDT.AIDatabase.Services
{
    public class CourseDetailsServices
    {
        public CourseDetail GetByCourseId(int _courseId)
        {
            using (EntitiesDataContext db = new EntitiesDataContext())
            {
                CourseDetail courseDetails = (from p in db.CourseDetails where p.CourseId == _courseId select p).Single();

                return courseDetails;
            }
        }

        public List<CourseDetail> GetAll()
        {
            using (EntitiesDataContext db = new EntitiesDataContext())
            {
                List<CourseDetail> coursesDetails = (from p in db.CourseDetails select p).ToList();

                return coursesDetails;
            }
        }
    }
}
