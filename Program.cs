using HWProject;

// Initialize an array of ShoppingCart objects to hold the products
ShoppingCart[] Products = new ShoppingCart[5];
Products[0] = new ShoppingCart(10001, "Pen", "Stationery", "0.7mm tip size, Twist mechanism, Golden and Ivory Plating, Premium German Ink Pen, Refillable Ink", 156, 0);
Products[1] = new ShoppingCart(10002, "Fitness Mantra Socks", "Clothing", "These ankle socks are made with high-quality materials that are soft, breathable, and durable, ensuring long-lasting wear and maximum comfort.", 188, 0);
Products[2] = new ShoppingCart(10003, "MATTERHORN Wooden Coffee Table", "Furniture", " Elevate your living room with our meticulously crafted coffee table, constructed from high-quality engineered wood boasting a rich, Modern Distressed Teak Finish.", 1990, 0);
Products[3] = new ShoppingCart(10004, "GIVA 925 Silver Beatiful Butterfly Studs Earrings", "Jewelry", "Made of 925 Silver Perfect for sensitive skin Earring Size: Height - 0.8 cm, Width - 0.9 cm", 967, 0);
Products[4] = new ShoppingCart(10005, "Qpets® Cat Teaser Toy with Bell", "Pet Toys", " The cat teaser wand toy features a fiberglass wand that is both lightweight and sturdy.", 427, 0);

int c = 0;// Variable to store the user's menu choice
double totalBill = 0;// Variable to store the total bill

Console.WriteLine("\t\t\t\t\t******************CATALOGUE******************");
Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

// Main loop to handle user interaction
for (int i = 0; i < 5; i++)
{
    Products[i].DisplayCatalogue();
    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
}

do
{

    try
    {
        Console.WriteLine("\nChoose one of the following:\n1.Add Item to Cart\n2.Remove item from cart\n3.Empty Cart\n4.Display Cart & Total Bill\n5.Display Catalogue\n6.Exit\n\nEnter your choice:");
        c = int.Parse(Console.ReadLine());// Read and parse user choice


        switch (c)
        {
            case 1:
                // Add item to cart
                Console.WriteLine("Enter the Product ID:");
                int productIDinput = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the number of units:");
                int quantity = int.Parse(Console.ReadLine());
                int checkProductIDExists = -1;
                for (int i = 0; i < 5; i++)
                {
                    if (Products[i].ProductID == productIDinput)
                    {
                        checkProductIDExists = i;
                        Products[i].No_of_Units = quantity;
                        break;

                    }
                }
                if (checkProductIDExists == -1)
                {
                    Console.WriteLine("This Product ID does not exist. Please enter a valid ID.");
                }

                break;
            case 2:
                // Remove item from cart
                Console.WriteLine("Enter the Product ID:");
                productIDinput = int.Parse(Console.ReadLine());
                checkProductIDExists = -1;
                for (int i = 0; i < 5; i++)
                {
                    if (Products[i].ProductID == productIDinput)
                    {
                        checkProductIDExists = 1;
                        if(Products[i].No_of_Units == 0)
                        {
                            Console.WriteLine("\nThis item is not in your cart!\n");
                            break;
                        }
                        else 
                        {
                            Products[i].No_of_Units = 0;// Set units to 0 to remove item
                            Console.WriteLine(Products[i].ProductID + " has been removed from your cart!");
                            break;
                        }
                       

                    }
                }
                if (checkProductIDExists == -1)
                {
                    Console.WriteLine("This Product ID does not exist. Please enter a valid ID.");
                }
                break;

            case 3:
                //Empty Existing Cart
                foreach (var product in Products)
                {
                    product.No_of_Units = 0; // Set all items' units to 0
                }
                totalBill = 0;// Reset the total bill
                Console.WriteLine("\nCart Empty!!\n");
                break;

            case 4:
                //Display Existing Cart items and Bill
                Console.Clear();
                Console.WriteLine("\n\n--*--Bill Summary--*--\n\n");
                totalBill = 0;
                for (int i = 0; i < 5; i++)
                {
                    double billamount = Products[i].CalculateBill(Products[i].ProductPrice, Products[i].No_of_Units);//Calculate Bill
                    if (Products[i].No_of_Units != 0)//Summary of bill
                        Console.WriteLine($"{Products[i].ProductName}  {Products[i].ProductPrice}  X  {Products[i].No_of_Units}  =  {billamount}\n");

                    totalBill += billamount;
                }
                Console.WriteLine($"\nTotal Bill - {totalBill}\n");//Display Total Bill
                Console.ReadLine();
                if(totalBill==0)
                {
                    Console.WriteLine("\nCART EMPTY!!!\n");
                }
                Console.WriteLine("Enter OK to proceed to payment(Press any key to modify Cart):");//Proceeding to payment
                string userChoice = Console.ReadLine();
                if (userChoice.ToUpper() == "OK")
                {
                    Console.Clear();
                    Console.WriteLine("\nChoose your payment method\n\n1.Cash on Delivery\n\nCredit/Debit Card\n\n3.UPI\n\n4.Net Banking");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("\n\n\n\t\t\t\t\tYOUR ORDER HAS BEEN PLACED!!!\n\n");
                    Environment.Exit(0);
                }
                break;
            case 5:
                Console.WriteLine("\t\t\t\t\t******************CATALOGUE******************");//Display Catalogue
                for (int i = 0; i < 5; i++)
                {
                    Products[i].DisplayCatalogue();
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                }
                break;
            case 6:
                Environment.Exit(0);//Exit
                break;
            default: Console.WriteLine("Wrong Option!"); break;
        }
    }
    catch (FormatException ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please enter a valid number!");
        Console.ResetColor();

    }
    catch (IndexOutOfRangeException ex)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("An error occurred while accessing an element in the array.");
        Console.ResetColor();

    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        Console.ResetColor();
    }
} while (c != 6);
