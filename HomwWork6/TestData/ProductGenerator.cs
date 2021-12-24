using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    class ProductGenerator
    {
        public static Product GenerateProduct()
        {
            return new Product("Test", "Baverages", "Tokyo Traders", "100","1", "2", "3", "4");
        }
    }
}
