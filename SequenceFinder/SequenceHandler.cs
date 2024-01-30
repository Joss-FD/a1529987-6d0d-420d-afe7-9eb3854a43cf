﻿using System;
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
            List<int>? res = null;

            //Quick validation
            if(string.IsNullOrEmpty(listString) || listString.Any(c => !char.IsDigit(c) && !char.IsWhiteSpace(c)))
            {
                return null;
            }

            return listString.Split(" ").Select(int.Parse).ToList();
            
        }


        public List<int> FindLongestSequence(string inputString)
        {
            
            List<int> longestSequence = new List<int>();
            int maxLength = 0;
            int currLength = 0;
            int maxIndex = 0;


            var numbersList = Parse(inputString);


            if (numbersList == null || numbersList.Count == 0) 
            {
                return longestSequence;
            }

            int size = numbersList.Count;

            for (int i = 1; i < size; i++)
            {  

                if (numbersList[i] > numbersList[i-1])
                {
                    currLength++;
                }    
                else
                {
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


            longestSequence = numbersList.GetRange(maxIndex, maxLength);

            
            return longestSequence;
        }

    }
}
