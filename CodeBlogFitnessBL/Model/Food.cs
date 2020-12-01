using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitnessBL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; set; }
        public double Callories { get; }

        /// <summary>
        /// белки
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        ///жиры
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// углеводы
        /// </summary>
        public double Carbohydraits { get; set; }
        /// <summary>
        /// каллории
        /// </summary>
        public double Calore { get; set; }
        private double CaloriesOneGram { get { return Calore / 100; } }
        private double ProteinsOneGram { get { return Proteins / 100;  } }

        private double FatsOneGram { get { return Fats / 100; } }

        private double CarbohydraitsOneGram { get { return Carbohydraits / 100; } }

        public Food (string name) : this (name,0,0,0,0)
        {
        }

        public Food (string name, double callories, double proteins, double fats, double carbohydraits)
        {
            //TODO проверка
            Name = name;
            Callories = callories/100.0;
            Proteins = proteins/100.0;
            Fats = fats/100.0;
            Carbohydraits = carbohydraits/100.0;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
