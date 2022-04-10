using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class Product
    {
        private double _Price;
        public void SetPrice(double value)
        {
            if (value>0)
            {
                _Price = value;
            }
            else
            {
                throw new ArgumentException("Fiyat negatif olamaz");
            }
        }

        public double GetPrice()
        {
            return _Price;
        }

        private string _Name;
        public string Name 
        {
            get { return _Name; }
            set { _Name = value; }
        }


        private int _Stock;
        public int StockCount
        {
            get
            {
                return _Stock;
            }
            set
            {
                if (value<0)
                {
                    _Stock = 0;
                    IsproductFoundInStock = false;
                }
            }
        }
        public bool IsproductFoundInStock { get; private set; } //readonly , yazılması yani set olması sadece içerden oldu
        public string Description { get; set; }
    }
}
