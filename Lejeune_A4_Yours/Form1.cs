using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Name: Rajal Patel
        //Date: 11/28/2022
        //Descritpion: Functions and Loops

        //3.class level const initialize with declartion
        const string PROGRAMMER = "Rajal Patel";
        const int MINRAND = 100000, MAXRAND = 200000, SEED= 733, MAXCOUNT= 3, MINNUMBER=1000, MAXNUMBER=5000;
        int count = 0;
        //4.function GetRandom
        /*Name: GetRandom 
         *Sent: 2 ints (min and max)
         *Return: int
         *This function genrate random number between the mentioned range*/
        private int GetRandom(int min, int max)
        {
            //create random object with no seed value
            Random rand = new Random();

            //generate random number with min and max value sent in
            int ranNum = rand.Next(MINRAND, MAXRAND+1);
            lblCode.Text= ranNum.ToString();

            //return random number
            return ranNum;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //5a. formload event
            //add name to the form title
            Text += " " + PROGRAMMER;
            //hide all group box except login and put cursor on code textbox
            grpChoose.Hide();
            grpText.Hide();
            grpStats.Hide();
            txtCode.Focus();

            //call the fuction to get the random number
          GetRandom(MINRAND, MAXRAND+1);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           

            //bool goodData = int.TryParse(txtCode.Text, out code);
            //5b.login click event

            if (lblCode.Text == txtCode.Text && count<=MAXCOUNT)
            {

                //show choose grpbox and disable login grp
                grpChoose.Show();
                grpLogin.Enabled = false;

            }
            if (lblCode.Text != txtCode.Text && count<MAXCOUNT)
            {
                count++;
                
                txtCode.SelectAll();
                txtCode.Focus();
  
                if (count==MAXCOUNT)
                {
                    MessageBox.Show("3 attempts to login+\nAccount Locked-Closing program", PROGRAMMER);
                    Close();
                }
                else
                {
                    MessageBox.Show(count + " incorrect code(s) entered\nTry again- only 3 attempts allowed", PROGRAMMER);
                }
            }
        }
        //6a.create function ResetTextGrp
        //4.function ResetTextGrp
        /*Name: ResetTextGrp
         *Sent: none
         *Return: none
         *This function reset the text group*/

        private void ResetTextGrp()
        {
            txtString1.Text = "";
            txtString2.Text = "";
            chkSwap.Checked = false;
            txtString1.Focus();
            lblResults.Text = "";
            this.AcceptButton = btnJoin;
            this.CancelButton = btnReset;
        }

        //6b.create function ResetStatsGrp
        //4.function ResetStatsGrp
        /*Name: ResetStatsGrp
         *Sent: none
         *Return: none
         *This function reset the stats group*/

        private void ResetStatsGrp()
        {
            lstNumbers.Items.Clear();
            lblSum.Text = "";
            lblMean.Text = "";
            lblOdd.Text = "";
            nudHowMany.Value = 10;
            this.AcceptButton = btnGenerate;
            this.CancelButton = btnClear;
        }

        //6c.create function SetUpOption
        //function SetUpOption
        /*Name: SetUpOption
         *Sent: none
         *Return: none
         *This function show and hide the appropriate groupbx*/
        private void SetUpOption()
        {
            if (radText.Checked)
            { // if text radiobutton checked visible the text grpbx and call the function ResetTextGrp 
                grpText.Visible = true;
                grpStats.Visible = false;
                ResetTextGrp();
            }
            if (radStats.Checked)
            {
                // if stats radio checked visible the stats grpbx and call the function ResetStatsGrp
                grpStats.Visible = true;
                grpText.Visible = false;
                ResetStatsGrp();
            }
        }

        private void radText_CheckedChanged(object sender, EventArgs e)
        {
            //7a.call the function SetUpOption
            SetUpOption();
        }

        private void radStats_CheckedChanged(object sender, EventArgs e)
        {
            //7a.call the function SetUpOption
            SetUpOption();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //7b. call the function ResetTextGrp
            ResetTextGrp();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //7c. call the function ResetStatsGrp
            ResetStatsGrp();
        }
        //8a.create function Swap
        //function Swap
        /*Name: Swap
         *Sent: 2 strings
         *Return: none
         *This function swap strings*/
        private void Swap(string text1, string text2)
        {
            string temp = text1;
            text1=text2;
            text2=temp;
            txtString1.Text=text1;
            txtString2.Text=text2;  
        }

        //8a.create function CheckInput
        //function CheckInput
        /*Name: CheckInput
         *Sent: none
         *Return: bool*/
        private bool CheckInput()
        {
            bool isValid = false;
            if (true)
            {
                isValid = true;
            }
            return isValid;
        }

        private void chkSwap_CheckedChanged(object sender, EventArgs e)
        {
            string text1=txtString2.Text, text2=txtString2.Text;
            //9a.swap data in the textbox and update the message in label
            if (chkSwap.Checked)
            {
                Swap(text1,text2);
                lblResults.Text = "Strings have been swapped!";
            }

        }


        private void btnJoin_Click(object sender, EventArgs e)
        { 
            //9b.join click
            string text1 = txtString1.Text;
            string text2 = txtString2.Text;
            lblResults.Text = "First string = " + text1 + "\nSecond string = " + text2 + "\nJoined = " + text1 + "-->" + text2;
        }
        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            //9c. analyze click
            string text1=txtString1.Text;
            string text2=txtString2.Text;   
            lblResults.Text= "First string = " + text1 +"\nCharacter = "+ text1.Length+"\nSecond string= " + text2 + "\nCharacter= " + text2.Length;
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //9d. create random object with seed value
            Random rand = new Random(SEED);
            lstNumbers.Items.Clear();
            for (int i = 0; i < nudHowMany.Value; i++)
            {
                int ranNum = rand.Next(MINNUMBER, MAXNUMBER + 1);
                lstNumbers.Items.Add(ranNum.ToString());
            }
            // call the function Addlist
            int sum = AddList();
            lblSum.Text = sum.ToString("n0");

            //calculate the mean
            double mean;
            mean = sum / Convert.ToDouble(nudHowMany.Value);
            lblMean.Text = mean.ToString("n2");

            //call the function CountOdd
            int oddcount = CountOdd();
            // display odd to label
            lblOdd.Text = oddcount.ToString();
        }
        //10a.create function AddList
        //function AddList
        /*Name: AddList
         *Sent: none
         *Return: int
         *This function sum the numbers*/
        private int AddList()
        {
            int count=lstNumbers.Items.Count; int sum = 0;
            while (count>0)
            {
             int number= Convert.ToInt32(lstNumbers.Items[count-1]);
                sum = sum + number;
                count--;    
            }
            return sum;
        }
        //10b.create function CountOdd
        //function CountOdd
        /*Name: CountOdd
         *Sent: none
         *Return: int
         *This function Count Odd*/
        private int CountOdd()
        {
            // count start from bottom (backward loop)
            int count = lstNumbers.Items.Count; int oddcount = 0;
            do
            {
                count--;
                int number = Convert.ToInt32(lstNumbers.Items[count]);
                if (number%2!=0)
                {
                    oddcount++;
                }
            } while (count>0);
            return oddcount;
        }


    }
}
