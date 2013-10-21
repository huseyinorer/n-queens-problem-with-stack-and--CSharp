using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace _10253051HW1
{
    public partial class Form1 : Form
    {
        public int boardsize;
        Button[,] btn2 = new Button[10,10];
       
        ArrayBasedStacks<int> final;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void CreateBoard(int size)
        {
            ArrayBasedStacks<int> temp = new ArrayBasedStacks<int>(size);
            int[] temps = new int[20];
            int t = 0;
            temp = final;
           

            while (t<size)
            {
                temps[t++] = temp.Pop();
            }
            
            for (int i = 0; i < size; i++)
            {
                int flag = 0;

                for (int j = 0; j < size; j++)
                {
                    Button btn = new Button();

                    btn.Text = "" + (j + 1) + "," + (i + 1) + "";
                    btn.Name = "Buton";
                    btn.Size = new Size(45, 45);
                    btn.Location = new Point(40 * i + 50, 40 * j + 50);
                    btn.Enabled = false;
                    this.Controls.Add(btn);
                    btn2[i, j] = btn;
                    flag++;
                    btn.BackColor = Color.White;
                  
                    if (temps[i] == flag)
                        btn.BackColor = Color.Turquoise;


                }

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void clearBoard()
        {
            for (int i = 0; i < 10; i++)
            {

                for (int j = 0; j < 10; j++)
                {
                    Controls.Remove(btn2[i, j]);
                }
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            clearBoard();
            placeQueens(Convert.ToInt32(comboBox1.SelectedItem));
            CreateBoard(Convert.ToInt32(comboBox1.SelectedItem));

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }       
      
        public void placeQueens(int boardSize)
        {
            
            
            ArrayBasedStacks<int> s = new ArrayBasedStacks<int>(boardSize);
            final = new ArrayBasedStacks<int>(boardSize);
            

            Boolean success = false;

            // row =  location within the stack, column = the element placed in the stack
            s.Push(1);

            while (!success && s.top != boardSize)
            {
                int x = 0; // placeholder for when we pop values
                Boolean conflict = false;

                // check for conflicts
                for (int i = 1; i < s.Count(); i++)
                {
                    int deltarows = s.Count() - i;
                    //check if same column or same diagonal 
                   
                    if (s.Peek() == s.get(i) || Convert.ToInt32(s.Peek()) == Convert.ToInt32(s.get(i)) + deltarows || Convert.ToInt32(s.Peek()) == Convert.ToInt32(s.get(i)) - deltarows)
                        conflict = true;
                }

                if (conflict)
                {
                    while (Convert.ToInt32(s.Peek()) == boardSize)
                        x = Convert.ToInt32(s.Pop());
                    if (s.top != boardSize) // if the top is not null we push to the next spot after poping the previous queen
                        s.Push(Convert.ToInt32(s.Pop()) + 1);
                    else
                        s.Push(x + 1);
                }
                else if (!conflict && s.Count() == boardSize)
                {
                    // If there's no more conflict and the stack size is equal to the board size then we're done
                    success = true;
                }
                else
                {
                    // new row, column 1
                    s.Push(1);
                }
            }
          
            final = s;
        }
    }
}