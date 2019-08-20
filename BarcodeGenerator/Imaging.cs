using System;
using System.Collections.Generic;
using System.Drawing;

namespace BarcodeGenerator
{
    /// <summary>
    /// Class that creates a barcode image from a string
    /// </summary>
    class Imaging
    {
        #region Private Members
        //list of boolean values that represent the bars in the barcode
        private bool[] binary;
        //the height of the generated barcode
        private int _height;

        Dictionary<string, int> DictCodeA = new Dictionary<string, int>();
        Dictionary<string, int> DictCodeB = new Dictionary<string, int>();
        Dictionary<string, int> DictCodeC = new Dictionary<string, int>();
        Dictionary<int, string> DictBinary = new Dictionary<int, string>();

        #endregion

        #region Constructor
        public Imaging()
        {
            // [ ] Need to find a way not to load this on every class instansce
            LoadDictionaries();
        }
        #endregion

        public void GetInfo(string input, int height)
        { 
            _height = height;
            var binaryString = FormatToBinary(input);
            binary = new bool[binaryString.Length];
            for (int i = 0; i < binaryString.Length; i++)
            {
                if (binaryString[i] == '1')
                { binary[i] = true; }
                else
                { binary[i] = false; }
            }

        }
        /// <summary>
        /// Creates a barcode by looping through an array of bools with 2px per bool
        /// </summary>
        /// <param name="name">filename of png</param>
        public void CreateAndSaveImage(string name)
        {

            var bitmap = new Bitmap(binary.Length * 2, _height);
            for (int x = 0; x < binary.Length; x++)
            {
                Color col = BarColorLogic(binary[x]);
                for (int y = 0; y < _height; y++)
                {
                    bitmap.SetPixel(x * 2, y, col);
                    bitmap.SetPixel(x * 2 + 1, y, col);

                }
            }
            //var bitmap = new Bitmap(_width, _height, _width*3);
            var formattedName = name.Replace('*', ' ');
            string filename = formattedName + ".jpg";
            bitmap.Save(filename);

        }
        public Color BarColorLogic(bool b)
        {
            if (b == true)
                return Color.Black;
            return Color.White;
        }
        public bool LoadDictionaries()
        {
            #region Code Characters
            //characters in the 128A Code Set
            string CodeA = " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_";
            //characters in the 128B Code Set
            string CodeB = " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
            //Code 128 Binary values for index 0-108
            string[] binaryValues = new string[109]
            {
                "11011001100",
                "11001101100",
                "11001100110",
                "10010011000",
                "10010001100",
                "10001001100",
                "10011001000",
                "10011000100",
                "10001100100",
                "11001001000",
                "11001000100",
                "11000100100",
                "10110011100",
                "10011011100",
                "10011001110",
                "10111001100",
                "10011101100",
                "10011100110",
                "11001110010",
                "11001011100",
                "11001001110",
                "11011100100",
                "11001110100",
                "11101101110",
                "11101001100",
                "11100101100",
                "11100100110",
                "11101100100",
                "11100110100",
                "11100110010",
                "11011011000",
                "11011000110",
                "11000110110",
                "10100011000",
                "10001011000",
                "10001000110",
                "10110001000",
                "10001101000",
                "10001100010",
                "11010001000",
                "11000101000",
                "11000100010",
                "10110111000",
                "10110001110",
                "10001101110",
                "10111011000",
                "10111000110",
                "10001110110",
                "11101110110",
                "11010001110",
                "11000101110",
                "11011101000",
                "11011100010",
                "11011101110",
                "11101011000",
                "11101000110",
                "11100010110",
                "11101101000",
                "11101100010",
                "11100011010",
                "11101111010",
                "11001000010",
                "11110001010",
                "10100110000",
                "10100001100",
                "10010110000",
                "10010000110",
                "10000101100",
                "10000100110",
                "10110010000",
                "10110000100",
                "10011010000",
                "10011000010",
                "10000110100",
                "10000110010",
                "11000010010",
                "11001010000",
                "11110111010",
                "11000010100",
                "10001111010",
                "10100111100",
                "10010111100",
                "10010011110",
                "10111100100",
                "10011110100",
                "10011110010",
                "11110100100",
                "11110010100",
                "11110010010",
                "11011011110",
                "11011110110",
                "11110110110",
                "10101111000",
                "10100011110",
                "10001011110",
                "10111101000",
                "10111100010",
                "11110101000",
                "11110100010",
                "10111011110",
                "10111101110",
                "11101011110",
                "11110101110",
                "11010000100",
                "11010010000",
                "11010011100",
                "11000111010",
                "11010111000",
                "1100011101011"
            };

            #endregion
            //take previous strings and load into dictionaries to convert for char to index values and index values to binary values
            try
            {
                //uses CodeA string chars and assigns index values
                Console.WriteLine("Loading Dictionary A");
                for (int i = 0; i < CodeA.Length; i++)
                {
                    var s = Convert.ToString(CodeA[i]);
                    DictCodeA.Add(s, i);
                }
                //uses CodeB string chars and assigns index values
                Console.WriteLine("Loading Dictionary B");
                for (int i = 0; i < CodeB.Length; i++)
                {
                    var s = Convert.ToString(CodeB[i]);
                    DictCodeB.Add(s, i);
                }
                //Add other dictionaries [ ]Code C [ ]Value to Binary strings
                //uses BinaryValues string array and assigns index values to the Code 128 binary values
                Console.WriteLine("Loading Binary Values");
                for (int i = 0; i < binaryValues.Length; i++)
                {
                    DictBinary.Add(i, binaryValues[i]);
                }
                Console.WriteLine("Dictionaries Loaded");
                return true;
            }
            catch
            {
                Console.WriteLine("Error Location:");
                return false;
                //throw new Exception("Dictionaries failed to load");
            }



        }

        /// <summary>
        /// Converts a string paramerter into the binary string equivalent based on 128Code
        /// </summary>
        /// <param name="input">string to be converted</param>
        /// <returns></returns>
        public string FormatToBinary(string input)
        {
            //create an array of ints to store the temporary values before converting into the bool[]
            //look at converting the input string to a string[] for less processing
            int[] values = new int[input.Length + 3];
            string binary = "";
            //Code A
            /*
            try
            {
                for (int i = 0; i < input.Length; i++)
                {
                    values[i] = DictCodeA[Convert.ToString(input[i])];
                }
                foreach (var item in values)
                {
                    binary = binary + DictBinary[item];
                }
                return binary;
            }
            catch
            {
                Console.WriteLine("Message not supported in CodeA");
            }
            */
            //Code B
            try
            {
                for (int i = 0; i < input.Length; i++)
                {
                    values[i + 1] = DictCodeB[Convert.ToString(input[i])];
                }
                //Add StartCode, Checksum, Termination Code
                values[0] = 104;
                values[input.Length + 1] = GenerateCheckSum(values);
                values[input.Length + 2] = 108;
                foreach (var item in values)
                {
                    binary = binary + DictBinary[item];
                }


                return binary;
            }
            catch
            {
                Console.WriteLine("Message not supported in CodeB");
                throw new Exception("Failed to convert to binary string");
            }
        }
        /// <summary>
        /// Calculates the check sum value for the barcode. The check sum is the part of the barcode after the information and before the termination
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        int GenerateCheckSum(int[] values)
        {
            int total = values[0];
            for (int i = 1; i < values.Length - 2; i++)
            {
                total += values[i] * i;
            }
            return total % 103;
        }

        public void GenerateBarcode()
        {

        }

    }
}
