/**********************************
 * Name: Bobby Carver
 * Student Number: 13170923
 * Software development bug test.
 * *****************************/
 
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thursday_Glazier
{
    class Program
    {
        static void Main(string[] args)
        {
            const int maxWindows = 5; // max size of array needed
            double[] windowCosts = new double[maxWindows];
            string install; // installation required ? y for yes, n for no
            int nWindows = 0; // no. windows required
            double width, height, area; // dimensions of window in metres, area in square metres
            int i;
            int nPanes; // no. of window panes
            int wType; // 1 for standard, 2 for energy-saver and 3 for deluxe
            string customer;
            double windowCost, totalCost = 0.0;
            double totalInstallationCost = 0.0;
            const double instCostPerPane = 100.0; // installation cost per pane 
            double costUnits; // area of window + no. panes + 2
           


            // BUG FIX : fixed program from crashing when Wtype is entered as 3. done by adding an extra value into the base price.
            double[] basePrices = {0.0, 30.0, 35.0, 40.0 }; 



               // prices per cost unit for standard, energy-saver and deluxe
            Console.Write("enter name of customer: ");

            customer = Console.ReadLine();
           


           
            
            Console.Write("\nenter number of windows to quote for: ");

            nWindows = Convert.ToInt32(Console.ReadLine());
            
        
            

           
            


            Console.Write("\nIs installation required (y/n) ? ");
            install = Console.ReadLine().ToLower();
            Console.WriteLine();

            // BUG FIX: the program would ask for an extra window each time. changed <= to < so that it only asks for the required windows and not an extra.

            for (i = 0; i < nWindows; i++)
            {
                Console.Write("Data entry for window {0}: ", i + 1);
                
     
                    Console.Write("enter width in metres: ");
                    width = Convert.ToDouble(Console.ReadLine());
                // BUG FIX : added validation so that the width and height cannot be greater than 2 square meters as per specification.
                    while (width > 2)
                    {
                        Console.WriteLine("error. maximum width length is 2 square meters. try again.");
                        Console.Write("enter width in metres: ");
                        width = Convert.ToDouble(Console.ReadLine());
                    }
                

                Console.Write("\nenter height in metres: ");
                height = Convert.ToDouble(Console.ReadLine());
                // BUG FIX : added validation so that the width and height cannot be greater than 2 square meters as per specification.
                while (height > 2)
                {
                    Console.WriteLine("error. height cannot be greater than 2 square meters. try again.");
                    Console.Write("\nenter height in metres: ");
                    height = Convert.ToDouble(Console.ReadLine());
                }

                area = width * height;
                Console.Write("\nenter no. of panes: ");
                nPanes = Convert.ToInt32(Console.ReadLine());

                //BUG FIX : MISSING CAPITAL LETTER. CHANGE costunits to costUnits

                costUnits = area + nPanes + 2;
                Console.Write("\nEnter window type (1 standard, 2 energy-saver, 3 deluxe): ");

                // BUG FIX : Changed Convert:toInt32 TO Convert.ToInt32. replaced : with .

                wType = Convert.ToInt32(Console.ReadLine());
                
                windowCost = costUnits * basePrices[wType];
                

                // BUG FIX : removed ; from the end of the brackets.

                if (install == "y")
                {
                    // BUG FIX: when a window needed installing it wouldnt add up the cost of the type of window. now the type of window is included into the price.
                    // i have changed: nPanes * instcostperpane  TO the following: (nPanes * basePrices[wType]) + instCostPerPane
                    windowCost = (nPanes * basePrices[wType]) + instCostPerPane ;
                    
                    totalInstallationCost += nPanes * instCostPerPane; // add install cost to total install cost
                }
                windowCosts[i] = windowCost;
                totalCost += windowCost;
            }
           
            // main report heading
            // CHANGED CODE: Changed some format of the text to make it more readable 
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("===============================");
            Console.WriteLine("Windows R US Job Costing Report");
            Console.WriteLine("===============================");
            Console.WriteLine("\nName of customer: {0}\n", customer);
            Console.WriteLine("No. of windows: {0}", nWindows);

            // output subheadings
            Console.WriteLine("Window\tCost\t%of Total");
            // BUG FIX changed < to > as program wasnt looping through the windowCosts 
            for (i = 0; i >= nWindows; i++)

                Console.WriteLine("{0}\t", i + 1);
                Console.Write("£{0:0.00}\t", windowCosts[i]);
                
                
                Console.WriteLine("{0:00.0}%", windowCosts[i] * 100 / totalCost);

            // BUG FIX : CHANGED : install =  "y" TO install == "y" Missing a = 

            if (install == "y")
            {
                // BUG FIX  : Added " to the start of the brackets to quote text.
                Console.WriteLine("Total Supply Cost £{0:0.00}",totalCost - totalInstallationCost);
                Console.WriteLine("Total Installation Cost £{0:0.00}", totalInstallationCost);
            }
            Console.WriteLine("Total Cost £{0:0.00}", totalCost);
            Console.WriteLine("press enter to continue");
            Console.ReadLine();

        }
    }
}
