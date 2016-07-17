using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CableMarkersCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            calculateCableMarkers();

        }

        public void resetControls()
        {
            lblError.Text = "";

        }

        public void calculateCableMarkers()
        {
            try
            {
                int intS = Convert.ToInt32(txtStart.Text);
                int intL = Convert.ToInt32(txtEnd.Text);

                int a0 = 0;
                int a1 = 0;
                int a2 = 0;
                int a3 = 0;
                int a4 = 0;
                int a5 = 0;
                int a6 = 0;
                int a7 = 0;
                int a8 = 0;
                int a9 = 0;

                if (intS <= intL)
                {

                    for (int i = intS; i <= intL; i++)
                    {
                        string str = i.ToString();


                        foreach (Match m in Regex.Matches(str, "0"))
                            a0++;
                        foreach (Match m in Regex.Matches(str, "1"))
                            a1++;
                        foreach (Match m in Regex.Matches(str, "2"))
                            a2++;
                        foreach (Match m in Regex.Matches(str, "3"))
                            a3++;
                        foreach (Match m in Regex.Matches(str, "4"))
                            a4++;
                        foreach (Match m in Regex.Matches(str, "5"))
                            a5++;
                        foreach (Match m in Regex.Matches(str, "6"))
                            a6++;
                        foreach (Match m in Regex.Matches(str, "7"))
                            a7++;
                        foreach (Match m in Regex.Matches(str, "8"))
                            a8++;
                        foreach (Match m in Regex.Matches(str, "9"))
                            a9++;

                    }

                    if (a0 != 0)
                        lblZero.Text = "0s = " + a0;
                    if (a1 != 0)
                        lblOne.Text = "1s = " + a1;
                    if (a2 != 0)
                        lblTwo.Text = "2s = " + a2;
                    if (a3 != 0)
                        lblThree.Text = "3s = " + a3;
                    if (a4 != 0)
                        lblFour.Text = "4s = " + a4;
                    if (a5 != 0)
                        lblFive.Text = "5s = " + a5;
                    if (a6 != 0)
                        lblSix.Text = "6s = " + a6;
                    if (a7 != 0)
                        lblSeven.Text = "7s = " + a7;
                    if (a8 != 0)
                        lblEight.Text = "8s = " + a8;
                    if (a9 != 0)
                        lblNine.Text = "9s = " + a9;

                   
                }
                else
                {
                    lblError.Text = "Start Integer must be lesser than End Integer";
                }
                
            }
            catch(Exception ex)
            {
               lblError.Text=  ex.Message.ToString();
            }

        }

       
    }
}
