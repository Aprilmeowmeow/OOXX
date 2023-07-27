using System;
using System.Drawing;
using System.Windows.Forms;

namespace _004
{
    public partial class Form1 : Form
    {
        Button[] BtnControls = new Button[9];
        bool isGameOver = false;
        bool isO = true;
        private static readonly int[,] WinGroup = new int[8, 3]
        {
            {0,1,2},
            {3,4,5},
            {6,7,8},
            {0,3,6},
            {1,4,7},
            {2,5,8},
            {0,4,8},
            {2,4,6}
        };
        public Form1()
        {
            InitializeComponent();
            BtnControls = new Button[9]
            {
                OX1, OX2, OX3, OX4, OX5, OX6, OX7, OX8, OX9
            };
        }
        


        private void button1_Click_1(object sender, EventArgs e)
        {
            Button tmpButton = (Button)sender;
            if (isGameOver)
            {
                MessageBox.Show("遊戲結束....請重新開始遊戲!", "遊戲結束", MessageBoxButtons.OK);
                return;
            }
            if(tmpButton.Text != "")
            {
                MessageBox.Show("這個按鍵已經選擇了，請點選其他位置！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (isO)
            {
                tmpButton.Text = "O";
                tmpButton.BackColor = Color.LightPink;
                timer1.Start();
            }
            else
            {
                tmpButton.Text = "X";
                tmpButton.BackColor = Color.LightBlue;
            }

            isO = !isO;

            bool[] GameStatus = CheckWinGrop(BtnControls);
            isGameOver = GameStatus[1];//someone win

            if (GameStatus[0])
            {
                DialogResult result = MessageBox.Show("遊戲結束....\r\n" + tmpButton.Text + " 獲勝\r\n是否重新開始遊戲", "遊戲結束", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                    initButtons();
                return;
            }
            if (GameStatus[1])
            {
                DialogResult result = MessageBox.Show("遊戲結束....\r\n和局\r\n是否重新開始遊戲", "遊戲結束", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                    initButtons();
            }
        }

        private void initButtons()
        {
            isGameOver = false;
            isO = true;
            for(int i = 0; i < BtnControls.Length; i++)
            {
                BtnControls[i].Text = "";
                BtnControls[i].BackColor = Color.LightPink;
                BtnControls[i].Font = new Font("Arial", 50, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)1));
                BtnControls[i].Click += new EventHandler(this.button1_Click_1);
            }
        }

        private bool[] CheckWinGrop(Button[] btnControls)
        {
            bool[] gameWinOver = new bool[2] {false, false};
            int btnIsUse = 1;
            for(int i = 0; i<8; i++)
            {
                int a = WinGroup[i, 0];
                int b = WinGroup[i, 1];
                int c = WinGroup[i, 2];
                Button b1 = btnControls[a];
                Button b2 = btnControls[b];
                Button b3 = btnControls[c];

                if (b1.Text == "" || b2.Text == "" || b3.Text == "")
                    continue;
                if (b1.Text == b2.Text && b3.Text == b2.Text)
                {
                    b1.BackColor = b2.BackColor = b3.BackColor = Color.LightPink;
                    b1.Font = b2.Font = b3.Font = new System.Drawing.Font("Times New Roman", 35, System.Drawing.FontStyle.Italic & System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)1));
                    gameWinOver = new bool[2] { true, true };
                    break;
                }
                if (btnControls[i].Text != "")
                {
                    btnIsUse++;
                    if (btnIsUse == 9)
                    {
                        gameWinOver[1] = true;
                    }
                }
                
            }
            return gameWinOver;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                if (!isO && BtnControls[i].Text == "")
                {
                    BtnControls[i].Text = "X";
                    BtnControls[i].BackColor = Color.LightYellow;
                    isO = !isO;
                    timer1.Stop();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initButtons();
            timer1.Stop();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < BtnControls.Length ; i++)
            {
                BtnControls[i].Text = "";
                BtnControls[i].BackColor = Color.LightPink;
                BtnControls[i].Font = new Font("Arial", 50, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)1));
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
