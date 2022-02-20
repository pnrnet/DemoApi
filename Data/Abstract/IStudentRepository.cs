// <copyright file="IStudentRepository.cs" company="Demo Company">
// Copyright (c) Demo Company. All rights reserved.
// </copyright>
// <summary>IStudentRepository </summary>
namespace Demo.Data.Abstract
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Demo.Data.Entities;
    using Demo.Dto.Models;

    /// <summary>
    /// Interface contains methods definitions for the IStudentRepository.
    /// </summary>
    public interface IStudentRepository
    {
        Task<int> CreateStudent(Student student);
        Task<int> UpdateStudent(Student student);
        Task<bool> DeleteStudent(int id);
        Task<IEnumerable<StudentDetailsDto>> GetAllStudents();
        Task<int> AddStudentClass(StudentClassDto studentClass);
        Task<int> RemoveStudentFromClass(StudentClassDto studentClass);
    }
}
