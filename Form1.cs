namespace DicaApp
{
    public partial class Form1 : Form
    {
        private int sum;
        private int point;
        private bool _isFirst = true;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

            var dice1 = Roll(this.dice1);
            var dice2 = Roll(this.dice2);

            sum = dice1 + dice2;

            sumLabel.Text = "Cумма: " + sum;
            label1.Text = "Предыдущая сумма: " + point;

            if ((sum == 7 || sum == 11) && _isFirst)
            {
                ResetGame("Победа!!!");
            }
            else if ((sum == 2 || sum == 3 || sum == 12) && _isFirst)
            {
                ResetGame("Поражение");
            }
            else if ((sum == 7) && !_isFirst)
            {
                ResetGame("Поражение");
            }
            else if (point == sum)
            {
                ResetGame("Победа!!!");
            }
            else
            {
                _isFirst = false;

            }
            point = sum;

        }

        private int Roll(PictureBox dice)
        {
            var diceRandom = random.Next(1, 7);

            switch (diceRandom)
            {
                case 1:
                    dice.Image = Image.FromFile("..\\..\\..\\dice_images\\dice_1.png");
                    break;
                case 2:
                    dice.Image = Image.FromFile("..\\..\\..\\dice_images\\dice_2.png");
                    break;
                case 3:
                    dice.Image = Image.FromFile("..\\..\\..\\dice_images\\dice_3.png");
                    break;
                case 4:
                    dice.Image = Image.FromFile("..\\..\\..\\dice_images\\dice_4.png");
                    break;
                case 5:
                    dice.Image = Image.FromFile("..\\..\\..\\dice_images\\dice_5.png");
                    break;
                case 6:
                    dice.Image = Image.FromFile("..\\..\\..\\dice_images\\dice_6.png");
                    break;

            }

            return diceRandom;



        }

        private void ResetGame(string state)
        {
            var result = MessageBox.Show("Хотите продолжить?", state, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                point = 0;
                sum = 0;
                _isFirst = true;
                sumLabel.Text = "Cумма: " + sum;
                label1.Text = "Предыдущая сумма: " + point;
            }
            else
            {
                Application.Exit();
            }
        }

        private void sumLabel_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}