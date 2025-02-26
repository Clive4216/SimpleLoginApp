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
    }
}