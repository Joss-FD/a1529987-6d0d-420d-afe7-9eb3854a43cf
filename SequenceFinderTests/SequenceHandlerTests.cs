using SequenceFinder;

namespace SequenceFinderTests
{
    [TestClass]
    public class SequenceHandlerTests
    {
        [TestMethod]
        public void SearchFrom_ValidInput_ReturnsValidSequence()
        {
            
            string inputString = "923 11613 30483 19569 24201 13461 1189 30793 8848 16914 16053 21700 22116 3852 20909 5231 31469 3862 16353 22813 28735 4421 3618 32303 9932 31892 7823 22547 28888 11143 11695 3339 2094 11023 9661 27440 7186 24750 15427 24502 31606 23515 3563 29553 12145 22184 11409 28824 6636 10658 21404 5578 27807 14073 13967 31310 3132 4321 7643 1951 13289 24375 17912 11304";
            List<int> expected = new List<int>() { 3862, 16353, 22813, 28735 };
            SequenceHandler sf = new SequenceHandler();

            
            var actual = sf.FindLongestSequence(inputString);


            CollectionAssert.AreEqual(expected, actual, "Sequence returned doesn't match expected sequence");
        }


        [TestMethod]
        public void SearchFrom_InvalidInput_ReturnsEmpty()
        {
            
            string inputString = "7fradfg643 1951 132459 52667 703 22364";
            List<int> expected = new List<int>();
            SequenceHandler sf = new SequenceHandler();

            
            var actual = sf.FindLongestSequence(inputString);

            
            CollectionAssert.AreEqual(expected, actual, "Sequence returned doesn't match expected sequence");
        }
    }
}