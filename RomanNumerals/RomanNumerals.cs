using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Roman_Numerals_Helper
{


	public class RomanNumerals
	{
		private static readonly List<(int number, string symbol)> RomansSymbols =
			new List<(int number, string symbol)>
			{
				(1, "I"), (4, "IV"), (5, "V"), (9, "IX"), (10, "X"),
				(40, "XL"), (50, "L"), (90, "XC"), (100, "C"),
				(400, "CD"), (500, "D"), (900, "CM"), (1000, "M")
			}.AsEnumerable().Reverse().ToList();


		public static string ToRoman(int number)
		{
			StringBuilder builder = new StringBuilder();

			while (number != 0)
				number = ProcessRemainNumbers(number, builder);

			return builder.ToString();
		}


		private static int ProcessRemainNumbers(int inputNumber, StringBuilder builder)
		{
			foreach ((int number, string symbol) in RomansSymbols)
				if (inputNumber >= number)
				{
					builder.Append(symbol);
					inputNumber -= number;
					break;
				}

			return inputNumber;
		}


		public static int FromRoman(string romanNumeral)
		{
			var romanNumeralAsSpan = romanNumeral.AsSpan();
			int result = 0;
			
			for (int i = 0; i < romanNumeralAsSpan.Length; i++)
				ProcessRemainRomanNumeral(romanNumeralAsSpan, ref i, ref result);

			return result;
		}


		private static void ProcessRemainRomanNumeral(ReadOnlySpan<char> romanNumeralAsSpan, ref int i, ref int result)
		{
			foreach ((int number, string symbol) in RomansSymbols)
			{
				if (symbol.Length > romanNumeralAsSpan.Length - i ||
					!romanNumeralAsSpan.Slice(i, symbol.Length)
									   .SequenceEqual(symbol))
					continue;

				result += number;
				i += symbol.Length - 1;
				break;
			}
		}
	}


}
