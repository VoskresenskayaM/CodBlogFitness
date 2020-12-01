using CodeBlogFitnessBL.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitnessBL.Model
{
    public class EatingController : ControllerBase
    {
        private readonly User user;
        private const string FOODS_FAIL_NAME = "foods.dat";
        private const string IATINF_FAIL_NAME = "eatings.dat";
        public List<Food> Foods { get; }
        public Eating Eating { get; }
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            Foods = GetAllFood();
            Eating = GetEating();
        }

  
        public void Add(Food food, double weight  )
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if(product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }
        private Eating GetEating()
        {
            return Load<Eating>(IATINF_FAIL_NAME) ?? new Eating(user);
        }

        private List<Food> GetAllFood()
        {
            return Load<List<Food>>(FOODS_FAIL_NAME) ?? new List<Food>();
        }
        private  void Save()
        {
            Save(FOODS_FAIL_NAME, Foods);
            Save(IATINF_FAIL_NAME, Eating);
        }
    }
}
