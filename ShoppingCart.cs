using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWProject
{
    public class ShoppingCart
    {
        // Fields to store product details
        public int ProductID;
        public string ProductName;
        public string ProductCategory;
        public string ProductDescription;
        public double ProductPrice;
        public int No_of_Units;
        // Constructor to initialize a ShoppingCart object
        public ShoppingCart(int productID, string productName, string productCategory, string productDescription, double productPrice, int no_of_Units)
        {
            ProductID = productID;
            ProductName = productName;
            ProductCategory = productCategory;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            No_of_Units = no_of_Units;

        }
        // Method to display product details
        public void DisplayCatalogue()
        {
            Console.WriteLine($"Product ID:{ProductID}\nName: {ProductName}\nCategory:{ProductCategory}\nDescription:{ProductDescription}\nPrice:{ProductPrice}");
        }
        // Method to calculate the bill for the product based on price and quantity
        public double CalculateBill(double productPrice, int no_of_Units)
        {
            double productBill = productPrice * no_of_Units;
            return productBill;
        }
    }
}
