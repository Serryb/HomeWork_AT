using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;

namespace HomeWork6
{
    class ProductLogic : AbstractPage
    {
        public ProductLogic(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void CreateNewProduct(Product product)
        {
            CreateProductPage Page = new CreateProductPage(driver);
            Page.Create(product.getProductName(), 
                        product.getCategoryId(),
                        product.getSupplierId(),
                        product.getUnitPrice(),
                        product.getQuantityPerUnit(),
                        product.getUnitsInStock(),
                        product.getUnitsOnOrder(),
                        product.getReorderLevel());
        }
    }
}
