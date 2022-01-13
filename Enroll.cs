using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem
{
    public class SameCourse : Exception
    {
        public SameCourse(String message)
            : base(message)
        {

        }
    }
    class Enroll: AppEngine
    {
        public Student student;
        public Course course;
        private DateTime enrollmentDate;
        public  int count;
        public int coursecount;
        public int enrollmentcount;
        public List<Course> CourseArr = new List<Course>();
        public List<Student> StudentArr = new List<Student>();
        public List<Enroll> EnrollArr = new List<Enroll>();

        public Enroll()
        {
            count = 0;
            coursecount = 0;
            enrollmentcount = 0;
        }
        Enroll(Student student, Course course, DateTime enrollmentDate)
        {
            this.student = student;
            this.course = course;
            this.enrollmentDate = enrollmentDate;
        }

        public DateTime EnrollmentDate
        {
            get { return enrollmentDate; }
            set { enrollmentDate = value; }
        }

        public void introduce(Course course)
        {
            CourseArr.Add(course);
            coursecount++;

        }

        public List<Course> listOfCourses()
        {

            return CourseArr;
        }

        public void register(Student student)
        {
            StudentArr.Add(student);
            count++;

        }

        public List<Student> listOfStudents()
        {
            return StudentArr;
        }

        public void enroll(Student student, Course course, DateTime enrollmentdate)
        {

            EnrollArr.Add(new Enroll(student, course, enrollmentdate));
            enrollmentcount++;
        }

        public List<Enroll> listOfEnrollments()
        {
            return EnrollArr;
        }

        public int getId(int id)
        {
            int ccid = (from en in EnrollArr
                       where int.Parse(en.student.Id) == id
                       select int.Parse(en.course.CourseId)).SingleOrDefault();
            return ccid;
        }
        public override string ToString()
        {
            return string.Format("\n" + student.Id + "\t\t" + student.Name + "\t\t" + course.CourseName + "\t\t" + EnrollmentDate.ToShortDateString() + "\n");
        }

    }

}
