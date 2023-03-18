namespace Sudoku
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int openTiles;

			switch (comboBox1.SelectedIndex)
			{
				case 0:
					openTiles = 49;
					break;
				case 1:
					openTiles = 40;
					break;
				case 2:
					openTiles = 30;
					break;
				case 3:
					openTiles = 20;
					break;
				default: 
					openTiles = 49; 
					break;
			}

			Form theGame = new Form2(openTiles);
			this.Hide();
			theGame.ShowDialog();
		}
	}
}