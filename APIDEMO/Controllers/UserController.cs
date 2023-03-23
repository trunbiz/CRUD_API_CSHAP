using APIDEMO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIDEMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IEnumerable<string> _presidents = new List<string> {
            "Biden", "Trump", "Bush", "Clinton", "1111"
        };
        private List<Users> AllUser()
        {
            List<Users> list = new List<Users>();
            for (int i = 1; i < 6; i++)   // Tạo ra 6 User
            {
                Users u = new Users()   // Tạo ra user mới
                {
                    Username = $"user {i}",
                    Password = $"password {i}",
                    Fullname = $"fullname {i}",
                    IsActive = true
                };
                list.Add(u);   // Thêm vào danh sách User
            }
            return list;
        }

        public List<Users> Index()
        {
            return AllUser();
        }

        // POST api/Users/CreateNew
        [HttpPost]
        public List<Users> CreateNew(Users u)
        {
            var list = AllUser();
            list.Add(u);   // Thêm User đã được truyền ở tham số User u
            return list;
        }

        // PUT api/Users/UpdateUser
        [HttpPut]
        public List<Users> UpdateUser(Users u)
        {
            var list = AllUser();
            // Lấy index của User thông qua username
            int index = list.FindIndex(p => p.Username == u.Username);
            list[index] = u;   // Update user
            return list;
        }

        // DELETE api/Users/DeleteUser
        [HttpDelete]
        public List<Users> DeleteUser(Users u)
        {
            var list = AllUser();
            int index = list.FindIndex(p => p.Username == u.Username);
            list.RemoveAt(index);
            return list;
        }
    }
}
