using DemoAPI.DTOs;
using DemoAPI.DTOs.Requests;
using DemoAPI.DTOs.Responces;
using DemoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Services.StudentService
{
    public class StudentService : IStudentService
    {
        // variable to store application db context
        private readonly ApplicationDbContext context;

        public StudentService(ApplicationDbContext applicationDbContext)
        {
            // get db context through DI
            context = applicationDbContext;
        }

        /// <summary>
        /// This method can be used to add new student to the database
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public BaseResponse CreateStudent(CreateStudentRequest request)
        {
            BaseResponse response;

            try
            {

                // create new instace of student model 
                StudentModel newStudent = new StudentModel();
                newStudent.first_name = request.first_name;
                newStudent.last_name= request.last_name;
                newStudent.address = request.address;
                newStudent.email = request.email;
                newStudent.contact_number = request.contact_number;

                using(context)
                {
                    context.Add(newStudent);
                    context.SaveChanges();
                }

                response = new BaseResponse {
                    status_code = StatusCodes.Status200OK,
                    data = new { message = "Successfully created the new student" }
                };

                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error : "+ex.Message }
                };

                return response;
            }
        }


        /// <summary>
        /// This method can be used to get all students from the database
        /// </summary>
        /// <returns></returns>
        public BaseResponse StudentList()
        {
            BaseResponse response;

            try
            {
                List<StudentDTO> students = new List<StudentDTO>();

                using( context)
                {

                    // get all students from database and add to student list after convert them to student dto
                    context.Students.ToList().ForEach(student => students.Add(new StudentDTO { 
                        id = student.id,
                        first_name = student.first_name,
                        last_name = student.last_name,
                        address = student.address,
                        email = student.email,
                        contact_number = student.contact_number
                    }));
                    
                }

                response = new BaseResponse {
                    status_code = StatusCodes.Status200OK,
                    data = new { students }
                };

                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error : "+ex.Message }
                };

                return response;
            }
        }


        public BaseResponse GetStudentById(long id) { 

            BaseResponse response;

            try {

                StudentDTO student = new StudentDTO();

                using(context)
                {
                    StudentModel filteredStudent = context.Students.Where(student => student.id == id).FirstOrDefault();

                    if(filteredStudent != null)
                    {
                        student.id = filteredStudent.id;
                        student.first_name = filteredStudent.first_name;
                        student.last_name= filteredStudent.last_name;
                        student.address = filteredStudent.address;
                        student.email = filteredStudent.email;
                        student.contact_number = filteredStudent.contact_number;
                    }
                    else
                    {
                        student = null;
                    }
                }

                if (student != null)
                {
                    response = new BaseResponse { 
                        status_code = StatusCodes.Status200OK,
                        data = new { student}
                    };
                }
                else
                {
                    response = new BaseResponse {
                        status_code = StatusCodes.Status400BadRequest,
                        data = new { message = "No student found" }
                    };
                }

                return response;
            }
            catch(Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error : " + ex.Message }
                };

                return response;
            }
        }


        public BaseResponse UpdateStudentById(long id, UpdateStudentRequest request) {

            BaseResponse response;

            try {

                using (context)
                {
                    StudentModel filteredStudent = context.Students.Where(student => student.id == id).FirstOrDefault();

                    if(filteredStudent != null)
                    {
                        filteredStudent.first_name = request.first_name;
                        filteredStudent.last_name = request.last_name;
                        filteredStudent.address = request.address;
                        filteredStudent.email = request.email;
                        filteredStudent.contact_number = request.contact_number;

                        context.SaveChanges();

                        response = new BaseResponse {
                            status_code = StatusCodes.Status200OK,
                            data = new { message = "Student updated successfully" }
                        };
                    }
                    else
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status400BadRequest,
                            data = new { message = "No student found" }
                        };
                    }
                }

                return response;
                
            }
            catch(Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error : " + ex.Message }
                };

                return response;
            }
        }



        public BaseResponse DeleteStudentById(long id)
        {
            BaseResponse response;

            try
            {
                using (context) {

                    StudentModel studentToDelete = context.Students.Where(student => student.id == id).FirstOrDefault();

                    if (studentToDelete != null)
                    {
                        context.Students.Remove(studentToDelete);
                        context.SaveChanges();

                        response = new BaseResponse { 
                        
                            status_code = StatusCodes.Status200OK,
                            data = new { message = "Student deleted successfully"}
                        };
                    }
                    else
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status400BadRequest,
                            data = new { message = "No student found" }
                        };
                    }
                }

                return response;

            }
            catch(Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error : " + ex.Message }
                };

                return response;
            }
        }

    }
}
