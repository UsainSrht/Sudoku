using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
	public partial class Form2 : Form
	{
		int tileWidth = 40;
		int tileHeight = 40;
		int openTiles;
		int focusedTile;

		bool appClosing = false;

		Color blank = Color.White;
		Color guessed = Color.White;
		Color given = Color.Gray;

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
			for (int i = 0; i < 81; i++) {
				Button dynamicButton = new Button();
				dynamicButton.Name = "dynamicButton" + i;
				dynamicButton.Size = new Size(tileWidth, tileHeight);
				int x = ((i % 9) * tileWidth);
				int y = ((i / 9) * tileHeight);
				dynamicButton.Location = new Point(x, y);
				dynamicButton.BackColor = blank;
				dynamicButton.MouseDown += new MouseEventHandler(this.Button_MouseClick);
				dynamicButton.GotFocus += new EventHandler(this.Button_GotFocus);
				Tile tile = new Tile();
				tile.index = i;
				try {
				tile.number = keyMap[i] > -1 ? keyMap[i] : 0;
				}
				catch { }
				dynamicButton.Tag = tile;
				dynamicButton.Text = keyMap[i].ToString();
				Controls.Add(dynamicButton);
				await Task.Run(() => new System.Threading.ManualResetEvent(false).WaitOne(3));
			}

		}

		private Dictionary<int, int> getKeyMap(int givenTiles)
		{
			Dictionary<int, int> keyMap = new Dictionary<int, int>();
			List<int> integers = new List<int>();
			for (int i = 1; i < 9; i++)
			{
				integers.Add(i);
			}
			Random random = new Random();
			List<int> copy = new List<int>(integers);
			Dictionary<int, int> row1 = new Dictionary<int, int>();
			for (int i = 0; i < 9; i++)
			{
				int selected = random.Next(0, copy.Count);
				copy.Remove(selected);
				row1.Add(i, copy[selected]);
			}

			return row1;
		}

		private void Button_MouseClick(object sender, EventArgs e)
		{

		}
		
		private void Button_GotFocus(object sender, EventArgs e)
		{
			this.focusedTile = ((Tile)((Button)sender).Tag).index;
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
				if (key > -1)
				{
					Button button = (Button)Controls.Find("dynamicButton" + focusedTile, false)[0];
					button.Text = key.ToString();
				}
			}
		}
	}
}
