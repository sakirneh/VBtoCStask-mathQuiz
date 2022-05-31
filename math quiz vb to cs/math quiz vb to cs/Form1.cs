using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace math_quiz_vb_to_cs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

           
                
        }
        
        //use "random" object to create pseudo random numbers.
        private Random randomizer = new Random();

        public int timeLeft = 6;

        //ints for addition problem.
        private int addend1, addend2;

        //ints for subtraction problem.
        private int minuend2, subtrahend;

        //ints for multiplication problem.
        private int multiplicand, multiplier;

        //ints for division problem.
        private int dividend, divisor;

        public int subtractproblem()
        {
            int minuend = randomizer.Next(51);
            return minuend;
        }


        // Start the quiz by filling in all of the problems
        //and starting the timer.

        public void StartTheQuiz()
        {
            //Fill in the addition problem.
           addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            sum.Value = 0;

            
            //timer start.
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer2.Start();


            //' Fill in the subtraction problem.
            minuend2 = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend2);

            minusLeftLabel.Text = minuend2.ToString();
            minusRightLabel.Text = subtrahend.ToString();

            difference.Value = 0;

            //' Fill in the multiplication problem.
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            //' Fill in the division problem.
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;



        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            CheckAnswers();
            



        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();

            timer2_Tick(sender, e);
            //timer2.Enabled = true;
            startButton.Enabled = false;


        }

        
        
        private bool CheckifAnswertrue()
        {
           

            if ((addend1 + addend2 == sum.Value) && (minuend2 - subtrahend == difference.Value) && (multiplicand * multiplier == product.Value) && (dividend / divisor == quotient.Value))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        private void answer_enter(object sender, EventArgs e)
        {
            //' Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if(answerBox != null)
            {
                int lengthofanswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthofanswer);
            }

        }

        private void CheckAnswers()
        {
            if (CheckifAnswertrue() == true)
            {
                //' statements that will get executed
                //' if the answer is correct 

                timer2.Stop();
                MessageBox.Show("You got all of the answers right!", "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                //' Display the new time left
                //' by updating the Time Left label.
                timeLeft -= 1;
                timeLabel.Text = timeLeft + " Seconds";
                if (timeLeft < 10)
                {
                    timeLabel.BackColor = Color.Red;
                }

            }
            else
            {
                //' If the user ran out of time, stop the timer, show
                //' a MessageBox, and fill in the answers.
                timer2.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry");
                sum.Value = addend1 + addend2;
                difference.Value = minuend2 - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;

            }
        }



    }
}
