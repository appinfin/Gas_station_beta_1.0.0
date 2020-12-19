using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2_1
{
    public partial class Form1 : Form
    {
        readonly Fuel fuel = new Fuel();

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)

        {
            //устанавливает марку топлива
            Fuel.Mark = comboBox1.Items[comboBox1.SelectedIndex].ToString();

            // Смотрим, какое по счету значение в списке нами выбрано:
            switch (comboBox1.SelectedIndex)
            {
                case 0: Fuel.Price = 43.5; break; //аи-92
                case 1: Fuel.Price = 45.5; break; //аи-95
                case 2: Fuel.Price = 47.0; break; //аи-98
                case 3: Fuel.Price = 45; break;   //дт
            }

            Fuel.Volume = Kassa.FuelToAmountOfMoney / Fuel.Price;             //объём на необходимую сумму денег
            if (Fuel.Volume == 0)
            {
                numericUpDown1.Value = numericUpDown1.Value;
                Fuel.Volume = Convert.ToDouble(numericUpDown1.Value);
            }
            else
            {
                //установка значения объема в поле кол-во топлива
                numericUpDown1.Value = Convert.ToDecimal(Fuel.Volume.ToString());
            }
            
            Kassa.Cost = Math.Round(Fuel.Price * Fuel.Volume, 2);             //стоимость итого 

            label5.Text = "Сумма: " + Kassa.Cost + " руб.";
            label6.Text = "Сдача: " + Kassa.GetBalance(Kassa.Сontribution, Kassa.Cost) + " руб.";  
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
            Fuel.Volume = Convert.ToDouble(numericUpDown1.Value);
            Kassa.Cost = Math.Round(Fuel.Price * Fuel.Volume, 2);
            label5.Text = "Сумма: " + Kassa.Cost + " руб.";
            label6.Text = "Сдача: " + Kassa.GetBalance(Kassa.Сontribution, Kassa.Cost) + " руб.";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                Kassa.FuelToAmountOfMoney = 0;
            }
            else
            {
                Kassa.FuelToAmountOfMoney = Convert.ToDouble(textBox1.Text);
            }
            Fuel.Volume = Kassa.FuelToAmountOfMoney / Fuel.Price;
            numericUpDown1.Value = Convert.ToDecimal(Fuel.Volume.ToString());
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                Kassa.Сontribution = 0;
            }
            else
            {
                Kassa.Сontribution = Convert.ToDouble(textBox2.Text);
            }

            Kassa.Cost = Math.Round(Fuel.Price * Fuel.Volume, 2);
            label6.Text = "Сдача: " + Kassa.GetBalance(Kassa.Сontribution, Kassa.Cost) + " руб.";
        }
    }
}
