using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitnessBL.Model;

namespace CodeBlogFitnessBL.Controller
{
    /// <summary>
    /// контроллер пользователя
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// пользователь приложения
        /// </summary>
        public List<User> Users { get; }
        private const string USERS_FAIL_NAME = "users.dat";
        public User CurrrentUser { get; set; }
        public bool IsNewUser { get; } = false;
        /// <summary>
        /// создание ного контроллера
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }

            Users = GetUserData();

            CurrrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrrentUser == null)
            {
                CurrrentUser = new User(userName);
                Users.Add(CurrrentUser);
                IsNewUser = true;
                Save();
            }

        }
        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 0, double hight = 0)
        {
            // проверка
            CurrrentUser.Gender = new Gender(genderName);
            CurrrentUser.BirthDay = birthDate;
            CurrrentUser.Weight = weight;
            CurrrentUser.Height = hight;
            Save();
        }

        /// <summary>
        /// получить сохраненный список пользователь
        /// </summary>
        /// <returns></returns>
        private List<User> GetUserData()
        {

            return Load <List<User>>(USERS_FAIL_NAME) ?? new List<User>();
          
        }
        /// <summary>
        /// сохранить данные пользователя
        /// </summary>
        public void Save()
        {
            Save(USERS_FAIL_NAME, Users);
        }
        
    }
   
}

