using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BarcodeGenerator
{
class Program
    {
        //TODO:
        //create a file check if the barcode has already been generated
        //change a 




        static void Main(string[] args)
        {
            //create an instance of the Imaging class
            var imaging = new Imaging();
            //program loop to continue running until exit key is pressed
            while (true)
            {
                //Ask the user for the part number to be converted into a barcode
                Console.WriteLine("Enter Part Number");
                //store the user input into the variable input
                var input = Console.ReadLine();
                //check if the input is an exit key
                if (input == "e" || input == "E")
                    //breaks out of the program loop and ends the program if an exit key was pressed
                { break; }
                //runs the code to produce a barcode image if an exit key was not pressed
                else
                {
                    imaging.GetInfo(input, 50);
                    imaging.CreateAndSaveImage(input);
                    Console.WriteLine("{0} Barcode Generated", input);
                }
                //Set C advantages
                //Beginning of Data 4+ numbers
                //End of Data 4+ numbers
                //Middle 6+ nummbers
                //entire dataset 2 or 4, but not 3

            }
        }

    }


   
}
