using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BMICalculater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private double heightData;
        private double weightData;

        private void Calculate(object sender, RoutedEventArgs e)
        {
            try
            {
                heightData = Convert.ToDouble(height.Text) / 100;
                weightData = Convert.ToDouble(weight.Text);

                double result = weightData / (heightData * heightData);
                string bmiData = string.Empty;

                if (result <= 18.5)
                    bmiData = "저체중";
                else if (18.5 < result && result <= 23)
                    bmiData = "정상";
                else if (23 < result && result <= 25)
                    bmiData = "과체중";
                else if (25 < result && result <= 30)
                    bmiData = "비만";
                else if (30 < result && result <= 35)
                    bmiData = "고도비만";
                else
                    bmiData = "초고도비만";

                // BMI 현재 체중(kg) ÷  [신장(m) × 신장(m)] 

                bmi.Text = Math.Round(result, 2).ToString() + " " + bmiData;
            }
            catch (Exception err)
            {
                string error = string.Format("[SYSTEM] : 입력 값 오류. 다시 입력해주세요.\n{0}", err.Message);
                MessageBox.Show(error);
            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            height.Text = string.Empty;
            weight.Text = string.Empty;
            bmi.Text = string.Empty;
        }
    }
}
