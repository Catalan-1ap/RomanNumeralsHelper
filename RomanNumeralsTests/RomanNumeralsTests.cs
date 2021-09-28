using NUnit.Framework;
using Roman_Numerals_Helper;


namespace Roman_Numerals_Tests
{


	[TestFixture]
	public class RomanNumeralsTests
	{
		[Test]
		[TestCase(1, "I")]
		[TestCase(4, "IV")]
		[TestCase(2225, "MMCCXXV")]
		[TestCase(1199, "MCXCIX")]
		public void ToRomanTest(int input, string expected)
		{
			string actual = RomanNumerals.ToRoman(input);

			Assert.AreEqual(expected, actual);
		}
		
		
		[Test]
		[TestCase("I", 1)]
		[TestCase("IV", 4)]
		[TestCase("MMCCXXV", 2225)]
		[TestCase("MCXCIX", 1199)]
		public void FromRomanTest(string input, int expected)
		{
			int actual = RomanNumerals.FromRoman(input);

			Assert.AreEqual(expected, actual);
		}
	}


}
