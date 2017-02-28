//
//  Question10.cs
//
//  Author:
//       Nathan Windisch <nathan@windisch.co.uk>
//
//  Copyright (c) 2017 
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
//using System.*;
namespace Application {
	public class Question10 {
		int count;
		int[] isbn = new int[13];
		int caculatedDigit;
		
		public void Main(string[] args) {
			for (int i = 0; count >= 1 && count <= 13; i++) {
				Console.Write("Please enter the next digit of ISBN: ");
				isbn[i];
			}

			calculatedDigit = 0;
			count = 1;

			while (count) {
				calculatedDigit = calculatedDigit + isbn[count];
				count++;
				calculatedDigit = calculatedDigit + isbn[count] * 3;
				count++;
			}

			while (calculatedDigit >= 10) {
				calculatedDigit = calculatedDigit - 10;
			}


			calculatedDigit = 10 - calculatedDigit;

			if (calculatedDigit = 10) {
				calculatedDigit = 0;
			}

			if (calculatedDigit = isbn[13]) {
				Console.WriteLine("Valid ISBN");
			} else {
				Console.WriteLine("Invalid ISBN");
			}		
		}
	}
}