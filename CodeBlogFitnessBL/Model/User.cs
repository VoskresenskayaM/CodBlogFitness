using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitnessBL.Model
{   /// <summary>
    /// Пользователь
    /// </summary>
    [Serializable]
    public class User
    {

        #region Свойства
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDay { get; set; }
        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост
        /// </summary>
        public double Height { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthDay.Year;} }
        #endregion
        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="gender">Пол</param>
        /// <param name="birthDay">Дата рождения</param>
        /// <param name="weight">Вес</param>
        /// <param name="height">Рост</param>
        public User(string name,
                    Gender gender,
                    DateTime birthDay,
                    double weight,
                    double height)
        {

            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null");
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Пол пользователя не может быть null", nameof(gender));
            }
            if (birthDay < DateTime.Parse("01.01.1900") || birthDay >= DateTime.Now)
            {
                throw new ArgumentNullException("Невозможна дата рождения", nameof(birthDay));
            }
            if (weight <= 0)
            {
                throw new ArgumentNullException("Вес не может быть меньше или равег нулю", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentNullException("Рост не может быть меньше или равер нулю", nameof(height));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDay = birthDay;
            Weight = weight;
            Height = height; 
        }

        public User (string name)  
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null");
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name + " " + Age;

        }

    }
}
    

