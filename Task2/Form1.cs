using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2 {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();

            textBox1.Text = Properties.Settings.Default.arr.ToString();
		}

		private void button1_Click(object sender, EventArgs e) {
            int[] arr;
            
            try {
                arr = textBox1.Text.Split(" ").Select(x => int.Parse(x)).ToArray();
            } catch (FormatException) {
                MessageBox.Show("Ошибка!");
                return;
            }

            Properties.Settings.Default.arr = textBox1.Text;
            Properties.Settings.Default.Save();

            if (Logic.GetResult(arr).Length != 0) {
                MessageBox.Show("Порядковые номера чисел первой из пар\n" + Logic.GetResult(arr));
            } else {
                MessageBox.Show("Пары не найдены");
            }
        }
	}

    public class Logic {
        public static string GetResult(int[] arr) {
            string str = "";
            int count = 0;
            for (int i = 0; i < arr.Length - 1; i++) {
                if (arr[i] == arr[i + 1]) {
                    count++;
                    if (count <= 1) {
                        str += (i + 1);
                    }
                }
            }
            return str;
        }
    }
}
