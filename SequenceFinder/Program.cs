// See https://aka.ms/new-console-template for more information
using SequenceFinder;


string fileContent = File.ReadAllText(@"..\..\..\Sample.txt");

SequenceHandler sf = new SequenceHandler();

var seq = sf.FindLongestSequence(fileContent);
Console.WriteLine(seq);