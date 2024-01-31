using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceFinder
{
    public class SequenceHandler
    {     
        public SequenceHandler()
        { 
                   
        }

        private List<int>? Parse(string listString)
        {

            //Quick validation to ensure Parsing doesn't fail
            if(string.IsNullOrEmpty(listString) || listString.Any(c => !char.IsDigit(c) && !char.IsWhiteSpace(c)))
            {
                return null;
            }

            return listString.Split(" ").Select(int.Parse).ToList();
            
        }

        /// <summary>
        /// This method takes a list of number and find the largest sequence of incremental number in a row, save its size and index to 
        /// then return the sequence of number itself as a list. The list is then converted to a string separated by whitespaces.
        /// </summary>
        /// <param name="inputString">The list of numbers in string format</param>
        /// <returns>A string representing the longest incremental sequence</returns>
        public string FindLongestSequence(string inputString)
        {
            int maxLength = 0;
            // currLength is set to 1 to include the very first element of the iput list
            int currLength = 1;
            int maxIndex = 0;

            var numbersList = Parse(inputString);

            if (numbersList == null || numbersList.Count == 0) 
            {
                return "";
            }

            int size = numbersList.Count;

            for (int i = 1; i < size; i++)
            {  
                // Moving through the list comparing the current number with the next number
                if (numbersList[i] > numbersList[i-1])
                {
                    currLength++;
                }    
                else
                {
                    // We keep track of the current largest sequence's size and index
                    if (maxLength < currLength)
                    {
                        maxLength = currLength;
                        maxIndex = i - currLength;
                    }

                    currLength = 1;
                }

            }
            if (maxLength < currLength)
            {
                maxLength = currLength;
                maxIndex = size - currLength;
            }

            // Return value as a string seperated by whitespaces
            var result = String.Join(" ", numbersList.GetRange(maxIndex, maxLength));
            return result;
        }

    }
}
