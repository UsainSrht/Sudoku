﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
	public partial class Form2 : Form
	{
		int debugValue = 0;

		int tileWidth = 40;
		int tileHeight = 40;
		int openTiles;
		int focusedTile;

		bool appClosing = false;

		Color blank = Color.White;
		Color guessed = Color.White;
		Color given = Color.Gray;
		Color hover = Color.Red;
		Color hoverRow = Color.FromArgb(100, Color.Blue);
		Color hoverColumn = Color.FromArgb(100, Color.Green);
		Color hover3by3Square = Color.FromArgb(100, Color.Purple);

		public Form2(int openTiles)
		{
			InitializeComponent();

			this.openTiles = openTiles;

		}

		private void Form2_Load(object sender, EventArgs e)
		{

		}

		private void Form2_Shown(object sender, EventArgs e)
		{
			createTiles();
		}


		private async void createTiles()
		{
			Dictionary<int, int> keyMap = getKeyMap(openTiles);
			for (int i = 0; i < 81; i++)
			{
				Button dynamicButton = new Button();
				dynamicButton.Name = "dynamicButton" + i;
				dynamicButton.Size = new Size(tileWidth, tileHeight);
				int x = ((i % 9) * tileWidth);
				int y = ((i / 9) * tileHeight);
				dynamicButton.Location = new Point(x, y);
				dynamicButton.BackColor = blank;
				dynamicButton.MouseDown += new MouseEventHandler(this.Button_MouseClick);
				dynamicButton.GotFocus += new EventHandler(this.Button_GotFocus);
				dynamicButton.MouseEnter += new EventHandler(this.Button_MouseEnter);
				dynamicButton.MouseLeave += new EventHandler(this.Button_MouseLeave);
				Tile tile = new Tile();
				tile.index = i;
				tile.number = keyMap.ContainsKey(i) ? keyMap[i] : 0;
				dynamicButton.Tag = tile;
				dynamicButton.Text = keyMap.ContainsKey(i) ? keyMap[i].ToString() : "0";
				if (tile.number == 0) dynamicButton.BackColor = Color.DarkRed;
				Controls.Add(dynamicButton);
				//await Task.Run(() => new System.Threading.ManualResetEvent(false).WaitOne(3));
			}

		}

		private Dictionary<int, int> getKeyMap(int givenTiles)
		{
			Dictionary<int, int> keyMap = new Dictionary<int, int>();
			Random random = new Random();

			for (int row = 1; row < 10; row++)
			{
				for (int column = 1; column < 10; column++)
				{
					List<int> numbers = getAcceptableNumbers(keyMap, row, column);
					int index = random.Next(numbers.Count);
					int selected = numbers.Count > index ? numbers[index] : 0;
					numbers.Remove(selected);
					keyMap.Add(getIndex(row, column), selected);

				}
			}

			return keyMap;
		}

		private bool isNumberAcceptable(int index, int number)
		{
			double x = index / 9;
			int row = (int)Math.Ceiling(x);
			int column = index % 9;
			List<int> rownumbers = new List<int>();
			foreach (int i in getRowNumbers(row))
			{
				if (rownumbers.Contains(i)) return false;
				rownumbers.Add(i);
			}
			List<int> columnnumbers = new List<int>();
			foreach (int i in getColumnNumbers(column))
			{
				if (columnnumbers.Contains(i)) return false;
				rownumbers.Add(i);
			}
			return true;
		}

		private int getRow(int index)
		{
			double x = index / 9;
			return (int)Math.Ceiling(x) + 1;
		}

		private int getColumn(int index)
		{
			return index % 9 + 1;
		}

		private int[] getRowAndColumn(int index)
		{
			int row = getRow(index);
			int column = getColumn(index);
			int[] ints = new int[2];
			ints[0] = row;
			ints[1] = column;
			return ints;
		}

		private int getIndex(int row, int column)
		{
			return (row - 1) * 9 + column - 1;
		}

		private List<int> getAcceptableNumbers(int index)
		{
			int[] ints = getRowAndColumn(index);
			return getAcceptableNumbers(ints[0], ints[1]);
		}

		private List<int> getAcceptableNumbers(int row, int column)
		{
			List<int> acceptableNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			foreach (int i in getRowNumbers(row)) { acceptableNumbers.Remove(i); }
			foreach (int i in getColumnNumbers(column)) { acceptableNumbers.Remove(i); }
			foreach (int i in get3by3SquareNumbers(getIndex(row, column))) { acceptableNumbers.Remove(i); }
			return acceptableNumbers;
		}

		private List<int> getAcceptableNumbers(Dictionary<int, int> keyMap, int row, int column)
		{
			List<int> acceptableNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			foreach (int i in getRowNumbers(keyMap, row)) { acceptableNumbers.Remove(i); }
			foreach (int i in getColumnNumbers(keyMap, column)) { acceptableNumbers.Remove(i); }
			foreach (int i in get3by3SquareNumbers(keyMap, getIndex(row, column))) { acceptableNumbers.Remove(i); }
			return acceptableNumbers;
		}

		private int[] getRowNumbers(int row)
		{
			int[] numbers = new int[9];
			int j = -1;
			foreach (int i in getRowIndexes(row))
			{
				j++;
				Control[] controlArray = Controls.Find("dynamicButton" + i, false);
				if (controlArray.Length == 0) continue;
				Button button = (Button)controlArray[0];
				numbers[j] = ((Tile)button.Tag).number;
			}
			return numbers;
		}

		private int[] getRowNumbers(Dictionary<int, int> keyMap, int row)
		{
			int[] numbers = new int[9];
			int j = -1;
			foreach (int i in getRowIndexes(row))
			{
				j++;
				if (!keyMap.ContainsKey(i)) continue;
				numbers[j] = keyMap[i];
			}
			return numbers;
		}

		private int[] getColumnNumbers(int column)
		{
			int[] numbers = new int[9];
			int j = -1;
			foreach (int i in getColumnIndexes(column))
			{
				j++;
				Control[] controlArray = Controls.Find("dynamicButton" + i, false);
				if (controlArray.Length == 0) continue;
				Button button = (Button)controlArray[0];
				numbers[j] = ((Tile)button.Tag).number;
			}
			return numbers;
		}

		private int[] getColumnNumbers(Dictionary<int, int> keyMap, int row)
		{
			int[] numbers = new int[9];
			int j = -1;
			foreach (int i in getColumnIndexes(row))
			{
				j++;
				if (!keyMap.ContainsKey(i)) continue;
				numbers[j] = keyMap[i];
			}
			return numbers;
		}

		private int[] get3by3SquareNumbers(int index)
		{
			int[] numbers = new int[9];
			int j = -1;
			foreach (int i in get3by3SquareIndexes(index))
			{
				j++;
				Control[] controlArray = Controls.Find("dynamicButton" + i, false);
				if (controlArray.Length == 0) continue;
				Button button = (Button)controlArray[0];
				numbers[j] = ((Tile)button.Tag).number;
			}
			return numbers;
		}

		private int[] get3by3SquareNumbers(Dictionary<int, int> keyMap, int index)
		{
			int[] numbers = new int[9];
			int j = -1;
			foreach (int i in get3by3SquareIndexes(index))
			{
				j++;
				if (!keyMap.ContainsKey(i)) continue;
				numbers[j] = keyMap[i];
			}
			return numbers;
		}

		private int[] getRowIndexes(int row)
		{
			int[] numbers = new int[9];
			for (int i = 0; i < 9; i++)
			{
				numbers[i] = ((row - 1) * 9 + i);
			}
			return numbers;
		}

		private int[] getColumnIndexes(int column)
		{
			int[] numbers = new int[9];
			for (int i = 0; i < 9; i++)
			{
				numbers[i] = (i * 9 + column - 1);
			}
			return numbers;
		}

		private int[] get3by3SquareIndexes(int index)
		{
			int[] numbers = new int[9];
			int column = getColumn(index);
			int row = getRow(index);
			double y = row / 3f;
			int startRow = (int)Math.Ceiling(y) * 3 - 2;
			double x = column / 3f;
			int startColumn = (int)Math.Ceiling(x) * 3 - 2;
			int startIndex = getIndex(startRow, startColumn);
			numbers[0] = startIndex;
			numbers[1] = startIndex + 1;
			numbers[2] = startIndex + 2;
			numbers[3] = startIndex + 9;
			numbers[4] = startIndex + 10;
			numbers[5] = startIndex + 11;
			numbers[6] = startIndex + 18;
			numbers[7] = startIndex + 19;
			numbers[8] = startIndex + 20;
			/*label1.Text = "x: " + x + " y: " + y + "\n"
				+ "row: " + row + " column: " + column + "\n"
				+ "startRow: " + startRow + " startColumn: " + startColumn + "\n"
				+ "startIndex: " + startIndex;*/
			return numbers;
		}

		private void Button_MouseClick(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			Tile tile = (Tile)button.Tag;
			int index = tile.index;
			List<int> numbers = getAcceptableNumbers(index);
			int[] rownumbers = getRowNumbers(getRow(index));
			int[] columnnumbers = getColumnNumbers(getColumn(index));
			MessageBox.Show("number: " + tile.number + "\n"
				+ "isGiven: " + tile.isGiven + "\n"
				+ "index: " + index + "\n"
				+ "row: " + getRow(index) + " column: " + getColumn(index) + "\n"
				+ "acceptableNumbers: " + String.Join(' ', numbers) + "\n"
				+ "rowNumbers: " + String.Join(' ', rownumbers) + "\n"
				+ "columnNumbers: " + String.Join(' ', columnnumbers) + "\n"
				+ "3by3SquareNumbers: " + String.Join(' ', get3by3SquareNumbers(index)) + "\n"
				);
		}

		private void Button_MouseEnter(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			Tile tile = (Tile)button.Tag;
			int index = tile.index;
			int row = getRow(index);
			int column = getColumn(index);
			foreach (int i in getRowIndexes(row))
			{
				Control[] controlArray = Controls.Find("dynamicButton" + i, false);
				if (controlArray.Length == 0) continue;
				Button btn = (Button)controlArray[0];
				btn.BackColor = hoverRow;
			}
			foreach (int i in getColumnIndexes(column))
			{
				Control[] controlArray = Controls.Find("dynamicButton" + i, false);
				if (controlArray.Length == 0) continue;
				Button btn = (Button)controlArray[0];
				btn.BackColor = hoverColumn;
			}
			foreach (int i in get3by3SquareIndexes(index))
			{
				Control[] controlArray = Controls.Find("dynamicButton" + i, false);
				if (controlArray.Length == 0) continue;
				Button btn = (Button)controlArray[0];
				btn.BackColor = hover3by3Square;
			}
			button.BackColor = hover;
		}

		private void Button_MouseLeave(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			Tile tile = (Tile)button.Tag;
			int index = tile.index;
			int row = getRow(index);
			int column = getColumn(index);
			foreach (int i in getRowIndexes(row))
			{
				Control[] controlArray = Controls.Find("dynamicButton" + i, false);
				if (controlArray.Length == 0) continue;
				Button btn = (Button)controlArray[0];
				btn.BackColor = getButtonColor(btn, false);
			}
			foreach (int i in getColumnIndexes(column))
			{
				Control[] controlArray = Controls.Find("dynamicButton" + i, false);
				if (controlArray.Length == 0) continue;
				Button btn = (Button)controlArray[0];
				btn.BackColor = getButtonColor(btn, false);
			}
			foreach (int i in get3by3SquareIndexes(index))
			{
				Control[] controlArray = Controls.Find("dynamicButton" + i, false);
				if (controlArray.Length == 0) continue;
				Button btn = (Button)controlArray[0];
				btn.BackColor = getButtonColor(btn, false);
			}
			button.BackColor = getButtonColor(button, false);
		}

		private Color getButtonColor(Button button, bool hover)
		{
			Tile tile = (Tile)button.Tag;
			if (tile.isGiven) return given;
			else if (tile.isManual) return guessed;
			return blank;
		}

		private void Button_GotFocus(object sender, EventArgs e)
		{
			Button button = sender as Button;
			if (button.Name.Contains("dynamic"))
			{
				this.focusedTile = ((Tile)button.Tag).index;
			}
		}

		private void Form2_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing && !appClosing)
			{
				Application.OpenForms[0].Show();
			}
		}

		public void newGame()
		{
			Form newForm = new Form2(openTiles);
			newForm.Show();
			appClosing = true;
			this.Close();
		}

		private void Form2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (focusedTile > 0)
			{
				int key = -1;
				try
				{
					key = Int32.Parse(e.KeyChar.ToString());
				}
				catch { }
				if (key > 0)
				{
					putNumber(focusedTile, key);
				}
			}
		}

		private void putNumber(int index, int number)
		{
			Button button = (Button)Controls.Find("dynamicButton" + index, false)[0];
			button.Text = number.ToString();
			Tile tile = (Tile)button.Tag;
			//tile.number = number;
			tile.isManual = true;
		}

		private void Button_PutNumber(object sender, MouseEventArgs e)
		{
			if (focusedTile > 0)
			{
				Button button = (Button)sender;
				int key = Int32.Parse((String)button.Tag);
				if (key > 0)
				{
					putNumber(focusedTile, key);
				}
			}
		}
	}
}
