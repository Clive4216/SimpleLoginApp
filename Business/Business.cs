using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Login.Repository;

namespace Login.Business
{
    public class business
    {
        private readonly IRepository<Student> _studentRepo;
        private readonly IRepository<Teacher> _teacherRepo;
        private readonly IRepository<Staff> _staffRepo;

        public business(DB_Entities context)
        {
            _studentRepo = new Repository<Student>(context);
            _teacherRepo = new Repository<Teacher>(context);
            _staffRepo = new Repository<Staff>(context);
        }

        public IEnumerable<Student> DisplayAllStudents()
        {
            return _studentRepo.GetAll();
        }

        public List<Student> GetStudents()
        {
            return _studentRepo.GetAll().ToList();
        }

        public Student GetStudentById(int id)
        {
            return _studentRepo.GetById(id);
        }

        public void AddStudent(Student student)
        {
            _studentRepo.Add(student);
            _studentRepo.Save();
        }

        public void UpdateStudent(Student student)
        {
             _studentRepo.Update(student);
             _studentRepo.Save();
        }

        public void DeleteStudent(int id)
        {
            var student = _studentRepo.GetById(id);

            if(student !=  null)
            {
                _studentRepo.Delete(student);
                _studentRepo.Save();
            }
        }

        //Teacher
        public List<Teacher> GetTeachers()
        {
            return _teacherRepo.GetAll().ToList();
        }

        public Teacher GetTeacherById(int id)
        {
            return _teacherRepo.GetById(id);
        }

        public void AddTeacher(Teacher teacher)
        {
            _teacherRepo.Add(teacher);
            _teacherRepo.Save();
        }

        public void UpdateTeacher(Teacher teacher)
        {
            _teacherRepo.Update(teacher);
            _teacherRepo.Save();
        }

        public void DeleteTeacher(int id)
        {
            var teacher = _teacherRepo.GetById(id);

            if (teacher != null)
            {
                _teacherRepo.Delete(teacher);
                _teacherRepo.Save();
            }
        }


        //Staff
        public List<Staff> GetStaff()
        {
            return _staffRepo.GetAll().ToList();
        }

        public Staff GetStaffById(int id)
        {
            return _staffRepo.GetById(id);
        }

        public void AddStaff(Staff staff)
        {
            _staffRepo.Add(staff);
            _staffRepo.Save();
        }

        public void UpdateStaff(Staff staff)
        {
            _staffRepo.Update(staff);
            _staffRepo.Save();
        }

        public void DeleteStaff(int id)
        {
            var staff = _staffRepo.GetById(id);

            if (staff != null)
            {
                _staffRepo.Delete(staff);
                _staffRepo.Save();
            }
        }
    }
}