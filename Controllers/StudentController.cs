using DemoAPI.DTOs.Requests;
using DemoAPI.DTOs.Responces;
using DemoAPI.Services.StudentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;


        // constructor
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }


        // endpoints

        [HttpPost("save")]
        public BaseResponse CreateStudent(CreateStudentRequest request)
        {
            return studentService.CreateStudent(request);
        }

        [HttpGet("list")]
        public BaseResponse StudentList()
        {
            return studentService.StudentList();
        }

        [HttpGet("{id}")]
        public BaseResponse GetStudentById(long id)
        {
            return studentService.GetStudentById(id);
        }

        [HttpPut("{id}")]
        public BaseResponse UpdateStudentById(long id, UpdateStudentRequest request)
        {
            return studentService.UpdateStudentById(id, request);
        }

        [HttpDelete("{id}")]
        public BaseResponse DeleteStudentById(long id)
        {
            return studentService.DeleteStudentById(id);
        }
    }
}
