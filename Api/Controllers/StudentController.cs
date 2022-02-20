// <copyright file="StudentController.cs" company="Demo Company">
// Copyright (c) Demo Company. All rights reserved.
// </copyright>
// <summary>Student Controllerr Class.</summary>

namespace Api.Controllers
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Demo.Dto.Responses;
    using Microsoft.AspNetCore.Mvc;
    using Demo.Service.Abstract;
    using Demo.Dto.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Operation related to Student Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentController"/> class.
        /// </summary>
        /// <param name="studentService">studentService.</param>
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateStudentDto studentDto)
        {
            Response<int> responseDto = new Response<int>();
            responseDto.Data = await studentService.CreateStudent(studentDto);
            responseDto.StatusCode = HttpStatusCode.OK;
            return Ok(responseDto);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(StudentDto studentDto)
        {
            Response<int> responseDto = new Response<int>();
            responseDto.Data = await studentService.UpdateStudent(studentDto);
            responseDto.StatusCode = HttpStatusCode.OK;
            return Ok(responseDto);

        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Response<bool> responseDto = new Response<bool>();

            responseDto.Data = await studentService.DeleteStudent(id);
            responseDto.StatusCode = HttpStatusCode.OK;
            return Ok(responseDto);

        }

        [HttpGet("GetAllStudentClass")]
        public async Task<IActionResult> GetAllStudents()
        {
            Response<IEnumerable<StudentClassResponceDto>> responseDto = new Response<IEnumerable<StudentClassResponceDto>>();

            responseDto.Data = await studentService.GetAllStudents();
            responseDto.StatusCode = HttpStatusCode.OK;
            return Ok(responseDto);

        }

        [HttpPost("AddStudentToClass")]
        public async Task<IActionResult> AddStudentClass(StudentClassDto studentClass)
        {
            Response<int> responseDto = new Response<int>();
            responseDto.Data = await studentService.AddStudentToClass(studentClass);
            responseDto.StatusCode = HttpStatusCode.OK;
            return Ok(responseDto);

        }
        [HttpPost("RemoveStudentFromClass")]
        public async Task<IActionResult> RemoveStudentFromClass(StudentClassDto studentClass)
        {
            Response<int> responseDto = new Response<int>();
            responseDto.Data = await studentService.RemoveStudentFromClass(studentClass);
            responseDto.StatusCode = HttpStatusCode.OK;
            return Ok(responseDto);
        }
    }
}
