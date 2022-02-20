// <copyright file="StudentService.cs" company="Demo Company">
// Copyright (c) Demo Company. All rights reserved.
// </copyright>
// <summary> StudentService </summary>

namespace Demo.Service.Concrete
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Demo.Data.Abstract;
    using Demo.Data.Entities;
    using Demo.Dto.Models;
    using Demo.Dto.Responses;
    using Demo.Service.Abstract;

    /// <summary>
    /// Service contains methods definitions for the Student Service.
    /// </summary>
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository repository;

        public StudentService(IStudentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> CreateStudent(CreateStudentDto student)
        {
            Student _student = new Student { FirstName = student.FirstName, LastName = student.LastName };
            return await repository.CreateStudent(_student);
        }

        public async Task<bool> DeleteStudent(int id)
        {
            return await repository.DeleteStudent(id);
        }

        public async Task<IEnumerable<StudentClassResponceDto>> GetAllStudents()
        {
            var students = await repository.GetAllStudents();
            IEnumerable<StudentClassResponceDto> studentClasses = null;
            if (students?.Any() == true)
            {
                studentClasses = students.GroupBy(x => new
                {
                    x.Id,
                    x.FirstName,
                    x.LastName,
                },
             (key, elements) =>
                new StudentClassResponceDto
                {
                    Id = key.Id,
                    FirstName = key.FirstName,
                    LastName = key.LastName,
                    Classs = elements.Select(x => new ClassDto
                    {
                        Code = x.Code,
                        Description = x.Description,
                        Title = x.Title
                    }).ToList()
                })
             .ToList();
            }
            return studentClasses;
        }

        public async Task<int> UpdateStudent(StudentDto student)
        {
            Student _student = new Student { FirstName = student.FirstName, LastName = student.LastName, Id = student.Id };
            return await repository.UpdateStudent(_student);
        }



        public async Task<int> AddStudentToClass(StudentClassDto studentClass)
        {
            return await repository.AddStudentClass(studentClass);
        }

        public async Task<int> RemoveStudentFromClass(StudentClassDto studentClass)
        {
            return await repository.RemoveStudentFromClass(studentClass);
        }
    }
}
