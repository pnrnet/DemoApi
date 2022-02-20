// <copyright file="IStudentService.cs" company="Demo Company">
// Copyright (c) Demo Company. All rights reserved.
// </copyright>
// <summary> IStudentService Interface Class.</summary>
namespace Demo.Service.Abstract
{
    using Demo.Data.Entities;
    using Demo.Dto.Responses;
    using Dto.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface contains methods definitions for the Student Service.
    /// </summary>
    public interface IStudentService
    {
        Task<int> CreateStudent(CreateStudentDto student);
        Task<int> UpdateStudent(StudentDto student);
        Task<bool> DeleteStudent(int id);
        Task<IEnumerable<StudentClassResponceDto>> GetAllStudents();
        Task<int> AddStudentToClass(StudentClassDto studentClass);
        Task<int> RemoveStudentFromClass(StudentClassDto studentClass);
    }
}
