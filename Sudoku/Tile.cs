using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
	internal class Tile
	{

		public int index { get; set; }
		public int number { get; set; }

		public int manualNumber { get; set; }
		public bool isGiven { get; set; }
		public bool isManual { get; set; }
		
	}
}
