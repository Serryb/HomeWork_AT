using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    class Product
    {
        private string ProductName;
        private string CategoryId;
        private string SupplierId;
        private string UnitPrice;
        private string QuantityPerUnit;
        private string UnitsInStock;
        private string UnitsOnOrder;
        private string ReorderLevel;

        public Product(string ProductName, string CategoryId, string SupplierId, string UnitPrice, string QuantityPerUnit, string UnitsInStock, string UnitsOnOrder, string ReorderLevel)
        { 
            this.ProductName = ProductName;
            this.CategoryId = CategoryId;   
            this.SupplierId = SupplierId;
            this.UnitPrice = UnitPrice;
            this.QuantityPerUnit = QuantityPerUnit;
            this.UnitsInStock = UnitsInStock;
            this.UnitsOnOrder = UnitsOnOrder;
            this.ReorderLevel = ReorderLevel;
        }

        public string getProductName()
        {
            return ProductName;
        }
        public string getCategoryId()
        {
            return CategoryId;
        }
        public string getSupplierId()
        {
            return SupplierId;
        }
        public string getUnitPrice()
        {
            return UnitPrice;
        }
        public string getQuantityPerUnit()
        {
            return QuantityPerUnit;
        }
        public string getUnitsInStock()
        {
            return UnitsInStock;
        }
        public string getUnitsOnOrder()
        {
            return UnitsOnOrder;
        }
        public string getReorderLevel()
        {
            return ReorderLevel;
        }
    }
}
