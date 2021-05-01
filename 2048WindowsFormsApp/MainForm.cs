using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace _2048WindowsFormsApp
{
   
    public partial class MainForm : System.Windows.Forms.Form
    {
        private string highScorePath = "HighScore.txt";
        public static int mapSize = 1;
        private Label[,] labelsMap;
        private static Random random = new Random();
        
        private int score = 0;
        private int highScore = 0;
        private Label label;
        public MainForm()
        {

            InitializeComponent();
            
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {

            var userForm = new UserForm();
            var resultInfo = userForm.ShowDialog(this);
            if (resultInfo != DialogResult.OK)
            {
                MessageBox.Show("Вы уверены?", "Закрыть приложение?");
                Hide();
               
            }
           
            var gameTypeForm = new GameTypeForm();
            var resultGame = gameTypeForm.ShowDialog(this);
            if (resultGame != DialogResult.OK)
            {
                
                Close();
            }
            else
            {
                highScore = GetHighScore();

                InitMap();
                GenerateNumber();
                ShowScore();
            }

        }

        private int GetHighScore()
        {
            if (File.Exists(highScorePath))
            {
                var reader = new StreamReader(highScorePath);
                var highScore = int.Parse(reader.ReadToEnd());
                reader.Close();
                return highScore;
            }
            else
            {
                return 0;
            }

        }

        private void ShowScore()
        {
            scoreLabel.Text = score.ToString();
            highScoreLabel.Text = highScore.ToString();

        }
     
        private void InitMap()
        {
            labelsMap = new Label[mapSize, mapSize];
            for(int i = 0; i<mapSize; i++)
            {
                for(int j = 0; j<mapSize; j++)
                {
                    var newLabel = CreateLabel(i, j);
                    Controls.Add(newLabel);
                    labelsMap[i, j] = newLabel;
                }
            }
        }

        private Label CreateLabel(int indexRow, int indexColumn)
        {
            label = new Label();
            
                label.BackColor = Color.Gray;
                label.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
                label.Size = new Size(70, 70);
                label.TabIndex = 0;
                label.TextAlign = ContentAlignment.MiddleCenter;
                int x = 20 + indexColumn * 76;
                int y = 150 + indexRow * 76;
                label.Location = new Point(x, y);
                label.TextChanged += Label_TextChanged;//Нажать Tab
            
                return label;
        }

        private void Label_TextChanged(object sender, EventArgs e)
        {
            var label = (Label)sender;//Приводим тип object к типу Label
            RefreshLabelsBackColor(label);
        }        

        private void RefreshLabelsBackColor(Label label)
        {
            switch(label.Text)
            {
                case "":
                    label.BackColor = Color.Gray;
                    break;

                case "2":
                    label.BackColor = Color.SlateGray;
                    break;

                case "4":
                    label.BackColor = Color.Green;
                    break;

                case "8":
                    label.BackColor = Color.YellowGreen;
                    break;

                case "16":
                    label.BackColor = Color.Yellow;
                    break;

                case "32":
                    label.BackColor = Color.Orange;
                    break;

                case "64":
                    label.BackColor = Color.Red;                    
                    break;
                case "128":
                    label.BackColor = Color.Violet;
                    break;

                case "256":
                    label.BackColor = Color.Blue;
                    break;

                case "512":
                    label.BackColor = Color.LightBlue;
                    break;

                case "1024":
                    label.BackColor = Color.Aquamarine;
                    break;

                case "2048":
                    label.BackColor = Color.White;
                    break;
            }
            
        }

        private void GenerateNumber()
        {
            while(true)
            {
                var randomNumberIndex = random.Next(0, mapSize * mapSize);
                var indexRow = randomNumberIndex / mapSize;
                var indexColumn = randomNumberIndex % mapSize;
                var randomeNumberLabel = random.Next(1, 5);
                if(randomeNumberLabel < 4)
                {
                    randomeNumberLabel = 2;
                }
                if (labelsMap[indexRow, indexColumn].Text == string.Empty)
                {
                    labelsMap[indexRow, indexColumn].Text = Convert.ToString(randomeNumberLabel);
                    break;
                }

            }
            
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            bool isMerged = false;
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {

                if (e.KeyCode == Keys.Right)
                {

                    for (int i = 0; i < mapSize; i++)//Идём по строкам сверху вниз 
                    {
                        for (int j = mapSize - 1; j >= 0; j--)//Идём справа налево по столбцам
                        {
                            if (labelsMap[i, j].Text != string.Empty)//Если в ячейке есть цифра. Встречаем первую цифру и выполняем цикл.
                            {
                                for (int k = j - 1; k >= 0; k--)//Идём дальше справа налево по столбцам
                                {
                                    if (labelsMap[i, k].Text != string.Empty)//Если в оставшихся ячейках слева есть цифра
                                    {
                                        if (labelsMap[i, j].Text == labelsMap[i, k].Text)//Если значения заполненых ячеек совпадают
                                        {
                                            var number = int.Parse(labelsMap[i, j].Text);//Переводим строку в число

                                            score = score + (number * 2);//Увеличиваем счёт 
                                            isMerged = true;
                                            labelsMap[i, j].Text = (number * 2).ToString();//Записываем новое значение в ячейку 

                                            labelsMap[i, k].Text = string.Empty;
                                        }
                                        break; //Когда нашёл заполненые ячейки и слил их - надо остановиться
                                    }

                                }
                            }
                        }
                    }

                    for (int i = 0; i < mapSize; i++)//Идём по строкам сверху вниз
                    {
                        for (int j = mapSize - 1; j >= 0; j--)//Идём справа налево по столбцам
                        {
                            if (labelsMap[i, j].Text == string.Empty)//Ищем первую свободную ячейку
                            {
                                for (int k = j - 1; k >= 0; k--)//Идём дальше справа налево по столбцам
                                {
                                    if (labelsMap[i, k].Text != string.Empty)//Дошли до первой заполненой ячейки
                                    {
                                        labelsMap[i, j].Text = labelsMap[i, k].Text;//Нужно перезаписать содержимое ячейки

                                        labelsMap[i, k].Text = string.Empty;

                                        break; //Когда нашёл заполненые ячейки и слил их - надо остановиться
                                    }

                                }
                            }
                        }
                    }
                }
                if (e.KeyCode == Keys.Left)
                {

                    for (int i = 0; i < mapSize; i++)
                    {
                        for (int j = 0; j < mapSize; j++)
                        {
                            if (labelsMap[i, j].Text != string.Empty)
                            {
                                for (int k = j + 1; k < mapSize; k++)
                                {
                                    if (labelsMap[i, k].Text != string.Empty)
                                    {
                                        if (labelsMap[i, j].Text == labelsMap[i, k].Text)
                                        {
                                            var number = int.Parse(labelsMap[i, j].Text);
                                            score = score + (number * 2);
                                            isMerged = true;
                                            labelsMap[i, j].Text = (number * 2).ToString();
                                            labelsMap[i, k].Text = string.Empty;
                                        }
                                        break;
                                    }

                                }
                            }
                        }
                    }

                    for (int i = 0; i < mapSize; i++)
                    {
                        for (int j = 0; j < mapSize; j++)
                        {
                            if (labelsMap[i, j].Text == string.Empty)
                            {
                                for (int k = j + 1; k < mapSize; k++)
                                {
                                    if (labelsMap[i, k].Text != string.Empty)
                                    {
                                        labelsMap[i, j].Text = labelsMap[i, k].Text;
                                        labelsMap[i, k].Text = string.Empty;

                                        break;
                                    }

                                }
                            }
                        }
                    }
                }
                if (e.KeyCode == Keys.Up)
                {

                    for (int j = 0; j < mapSize; j++)
                    {
                        for (int i = 0; i < mapSize; i++)
                        {
                            if (labelsMap[i, j].Text != string.Empty)
                            {
                                for (int k = i + 1; k < mapSize; k++)
                                {
                                    if (labelsMap[k, j].Text != string.Empty)
                                    {
                                        if (labelsMap[i, j].Text == labelsMap[k, j].Text)
                                        {
                                            var number = int.Parse(labelsMap[i, j].Text);
                                            score = score + (number * 2);
                                            isMerged = true;
                                            labelsMap[i, j].Text = (number * 2).ToString();
                                            labelsMap[k, j].Text = string.Empty;
                                        }
                                        break;
                                    }

                                }
                            }
                        }
                    }

                    for (int j = 0; j < mapSize; j++)
                    {
                        for (int i = 0; i < mapSize; i++)
                        {
                            if (labelsMap[i, j].Text == string.Empty)
                            {
                                for (int k = i + 1; k < mapSize; k++)
                                {
                                    if (labelsMap[k, j].Text != string.Empty)
                                    {
                                        labelsMap[i, j].Text = labelsMap[k, j].Text;
                                        labelsMap[k, j].Text = string.Empty;

                                        break;
                                    }

                                }
                            }
                        }
                    }
                }
                if (e.KeyCode == Keys.Down)
                {

                    for (int j = 0; j < mapSize; j++)
                    {
                        for (int i = mapSize - 1; i >= 0; i--)
                        {
                            if (labelsMap[i, j].Text != string.Empty)
                            {
                                for (int k = i - 1; k >= 0; k--)
                                {
                                    if (labelsMap[k, j].Text != string.Empty)
                                    {
                                        if (labelsMap[i, j].Text == labelsMap[k, j].Text)
                                        {
                                            var number = int.Parse(labelsMap[i, j].Text);
                                            score = score + (number * 2);
                                            isMerged = true;
                                            labelsMap[i, j].Text = (number * 2).ToString();
                                            labelsMap[k, j].Text = string.Empty;
                                        }
                                        break;
                                    }

                                }
                            }
                        }
                    }

                    for (int j = 0; j < mapSize; j++)
                    {
                        for (int i = mapSize - 1; i >= 0; i--)
                        {
                            if (labelsMap[i, j].Text == string.Empty)
                            {
                                for (int k = i - 1; k >= 0; k--)
                                {
                                    if (labelsMap[k, j].Text != string.Empty)
                                    {
                                        labelsMap[i, j].Text = labelsMap[k, j].Text;
                                        labelsMap[k, j].Text = string.Empty;

                                        break;
                                    }

                                }
                            }
                        }
                    }
                }
            }
            else
            {
                return;
            }

            TryUpdateHighScore();

            ShowScore();

            if(IsFullMap() == true && isMerged == true || Exist2048() == true)
            {
                MessageBox.Show("Конец игры!");
            }

            GenerateNumber();
 
        }

        private void TryUpdateHighScore()
        {
            if(score > highScore)
            {
                highScore = score;
            }
            
        }

        private void правилаИгрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ПРАВИЛА ИГРЫ" + "\n" + "\n" +
"В каждом раунде появляется плитка номинала «2» или «4»." + "\n" +
"Нажатием стрелки игрок может скинуть все плитки игрового" + "\n" +
"поля в одну из 4 сторон." + "\n" +
"Если при сбрасывании две плитки одного номинала «налетают»" + "\n" +
"одна на другую, то они превращаются в одну, номинал которой" + "\n" +
"равен сумме соединившихся плиток." + "\n" +
"После каждого хода на свободной секции поля появляется" + "\n" +
"новая плитка номиналом «2» или «4». Если при нажатии кнопки" + "\n" +
"местоположение плиток или их номинал не изменится, то ход" + "\n" +
"не совершается." + "\n" +
"Если в одной строчке или в одном столбце находится более" + "\n" +
"двух плиток одного номинала, то при сбрасывании они начинают" + "\n" +
"соединяться с той стороны, в которую были направлены." + "\n" +
"Например, находящиеся в одной строке плитки(4, 4, 4) после" + "\n" +
"хода влево превратятся в(8, 4), а после хода вправо — в(4, 8)." + "\n" +
"За каждое соединение игровые очки увеличиваются на номинал" + "\n" +
"получившейся плитки." + "\n" +
"Игра заканчивается поражением, если после очередного хода" + "\n" +
"невозможно совершить действие." + "\n" );
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool IsFullMap()
        {
            for(int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (labelsMap[i, j].Text == string.Empty)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool Exist2048()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (labelsMap[i, j].Text == "2048")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(highScorePath))
            {
                var writer = new StreamWriter(highScorePath, false);
                writer.WriteLine(highScore);
                writer.Close();
            }
            else
            {
                var writer = new StreamWriter(highScorePath, true);
                writer.WriteLine(highScore);
                writer.Close();
            }
        }
    }
}
