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
            //Utilities.ResetAllControls(this);
            int isNumber;

            if (int.TryParse(txtStartNW.Text, out isNumber) && int.TryParse(txtEndNW.Text, out isNumber) && int.TryParse(txtPack.Text, out isNumber))
            {
                calculateCableMarkers(Convert.ToInt32(txtStartNW.Text), Convert.ToInt32(txtEndNW.Text));
            }
            else
            {
                lblError.Text = "Please enter Numeric value only";
            }
          
        }

        public void resetControls()
        {
            lblError.Text = "";

        }

        public void calculateCableMarkers(int networkStart, int networkEnd)
        {
            try
            {

                lblOne.Text = lblTwo.Text = lblThree.Text = lblFour.Text = lblFive.Text = lblSix.Text = lblSeven.Text = lblEight.Text = lblNine.Text = lblZero.Text = lblError.Text = "";

                int intS = Convert.ToInt32(txtStartNW.Text);
                int intL = Convert.ToInt32(txtEndNW.Text);

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

                    // Multiply (0s to 9s) with 2 as each cable needs two markers for both ends.
                    if (a0 != 0)
                        lblZero.Text = "0s = " + a0 * 2;
                    if (a1 != 0)
                        lblOne.Text = "1s = " + a1 * 2;
                    if (a2 != 0)
                        lblTwo.Text = "2s = " + a2 * 2;
                    if (a3 != 0)
                        lblThree.Text = "3s = " + a3  * 2;
                    if (a4 != 0)
                        lblFour.Text = "4s = " + a4 * 2;
                    if (a5 != 0)
                        lblFive.Text = "5s = " + a5 * 2;
                    if (a6 != 0)
                        lblSix.Text = "6s = " + a6 * 2;
                    if (a7 != 0)
                        lblSeven.Text = "7s = " + a7 * 2;
                    if (a8 != 0)
                        lblEight.Text = "8s = " + a8 * 2;
                    if (a9 != 0)
                        lblNine.Text = "9s = " + a9 * 2;

                    calculateOrderingInfo(a0 * 2, a1 * 2, a2 * 2, a3 * 2, a4 * 2, a5 * 2, a6 * 2, a7 * 2, a8 * 2, a9 * 2);

                }
                else
                {
                    lblError.Text = "Start Integer must be less than End Integer";
                }
                
            }
            catch(Exception ex)
            {
               lblError.Text=  ex.Message.ToString();
            }

        }

        public void calculateOrderingInfo(int zero, int one, int two, int three, int four, int five, int six, int seven, int eight, int nine)
        {
            try 
            {
                lblPackZero.Text = lblPackOne.Text = lblPackTwo.Text = lblPackThree.Text = lblPackFour.Text = lblPackFive.Text = lblPackSix.Text = lblPackSeven.Text = lblPackEight.Text = lblPackNine.Text = "";

                int packValue = Convert.ToInt32(txtPack.Text);

               

                if (zero != 0)
                    lblPackZero.Text = ((float)zero / packValue).ToString() + " packs of 0s";
                if(one != 0)
                    lblPackOne.Text = ((float)one / packValue).ToString() + " packs of 1s";
                if (two != 0)
                   lblPackTwo.Text = ((float)two / packValue).ToString() + " packs of 2s";
                if (three != 0)
                    lblPackThree.Text = ((float)three / packValue).ToString() + " packs of 3s";
                if (four != 0)
                    lblPackFour.Text = ((float)four / packValue).ToString() + " packs of 4s";
                if (five != 0)
                    lblPackFive.Text = ((float)five / packValue).ToString() + " packs of 5s";
                if (six != 0)
                    lblPackSix.Text = ((float)six / packValue).ToString() + " packs of 6s";
                if (seven != 0)
                    lblPackSeven.Text = ((float)seven / packValue).ToString() + " packs of 7s";
                if (eight != 0)
                    lblPackEight.Text = ((float)eight / packValue).ToString() + " packs of 8s";
                if (nine != 0)
                    lblPackNine.Text = ((float)nine / packValue).ToString() + " packs of 9s";


                if (packValue == 0)
                {
                    lblError.Text = "Pack value cannot be zero.";
                    lblPackZero.Text = lblPackOne.Text = lblPackTwo.Text = lblPackThree.Text = lblPackFour.Text = lblPackFive.Text = lblPackSix.Text = lblPackSeven.Text = lblPackEight.Text = lblPackNine.Text = "";
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3); 
            tabControl1.TabPages.Remove(tabPage4);

        }

          
    }

    public class Utilities
    {
        public static void ResetAllControls(Control form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                }

                if (control is Label)
                {
                    Label label = (Label)control;
                    label.Text = null;
                }
            }
        }
    }
}
