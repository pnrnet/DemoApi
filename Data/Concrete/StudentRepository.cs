// <copyright file="StudentRepository.cs" company="Demo Company">
// Copyright (c) Demo Company. All rights reserved.
// </copyright>
// <summary>StudentRepository Repository class.</summary>

namespace Demo.Data.Concrete
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Common.DbHelper;
    using Dapper;
    using Data.Abstract;
    using Demo.Data.Entities;
    using Demo.Dto.Models;

    /// <summary>
    /// StudentRepository.
    /// </summary>
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbHelper databaseHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentRepository"/> class.
        /// </summary>
        /// <param name="databaseHelper">databaseHelper.</param>
        public StudentRepository(IDbHelper databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }

        /// <inheritdoc/>
        public async Task<int> CreateStudent(Student student)
        {
            return await databaseHelper.InsertAsync<Student, int>(student);
        }

        /// <inheritdoc/>
        public async Task<int> UpdateStudent(Student student)
        {
            return await databaseHelper.UpdateAsync<Student>(student);
        }
        /// <inheritdoc/>
        public async Task<bool> DeleteStudent(int id)
        {
            var paraSearch = new DynamicParameters();
            paraSearch.Add("@id", id);
            int deleteCout = await databaseHelper.ExecuteAsync("UPDATE Student SET IsActive=0 WHERE Id = @id ", paraSearch);
            return deleteCout > 0;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<StudentDetailsDto>> GetAllStudents()
        {
            return await databaseHelper.SelectDataList<StudentDetailsDto>("SELECT S.Id,S.FirstName,S.LastName,C.Code,C.Title,C.Description FROM Student s(nolock) JOIN Class C(nolock)");
        }

        /// <inheritdoc/>
        public async Task<int> AddStudentClass(StudentClassDto studentClass)
        {
            int insertCOunt = 0;
            if (studentClass.ClassCodes?.Any() == true)
            {
                foreach (var classCode in studentClass.ClassCodes)
                {
                    var paraSearch = new DynamicParameters();
                    paraSearch.Add("@StudentId", studentClass.StudentId);
                    paraSearch.Add("@ClassCode", classCode);
                    insertCOunt += await databaseHelper.ExecuteAsync("INSERT into StudentClass(StudentId,ClassCode) values (@StudentId,@ClassCode)", paraSearch);
                }
            }

            return insertCOunt;
        }

        public async Task<int> RemoveStudentFromClass(StudentClassDto studentClass)
        {
            var queryParams = new DynamicParameters();
            queryParams.Add("@StudentId", studentClass.StudentId);
            queryParams.Add("@ClassCode", studentClass.ClassCodes);
            return await databaseHelper.ExecuteAsync("DELETE FROM  StudentClass WHERE ClassCode in @ClassCode and  StudentId = @StudentId", queryParams);
        }
    }
}
