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
            var imaging = new Imaging();
            while (true)
            {

                Console.WriteLine("Enter Part Number");
                var input = Console.ReadLine();
                if (input == "e" || input == "E")
                { break; }
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
