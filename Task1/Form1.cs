using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1 {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();

			textBox1.Text = Properties.Settings.Default.a.ToString();
			textBox2.Text = Properties.Settings.Default.b.ToString();
			textBox3.Text = Properties.Settings.Default.c.ToString();
			textBox4.Text = Properties.Settings.Default.d.ToString();
			textBox5.Text = Properties.Settings.Default.n.ToString();
			textBox6.Text = Properties.Settings.Default.m.ToString();

			pictureBox1.Location = new Point(x, 12);
		}

		int x = -450;
		int speed = 10;
		bool trainIsGone = false;

		private void timer1_Tick(object sender, EventArgs e) {
			pictureBox1.Location = new Point(x, 12);

			if (textBox1.TextLength > 0 && textBox2.TextLength > 0 && speed != 0) {
				x += speed;
				if (x % 15 == 0) {
					speed -= 1;
				}
			}

			if (trainIsGone) {
				if (x % 5 == 0) {
					speed += 1;
				}
			}

			if (x >= 500) {
				timer1.Enabled = false;
				x = -450;
				MessageBox.Show("Поезд не стоит на платформе");
				trainIsGone = false;
				speed = 10;
				timer1.Enabled = true;
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e) {
			try {
				if (int.Parse(textBox1.Text) > 23) {
					textBox1.Text = 23.ToString();
				}
			} catch (FormatException) {
				return;
			}
		}

		private void textBox2_TextChanged(object sender, EventArgs e) {
			try {
				if (int.Parse(textBox2.Text) > 59) {
					textBox2.Text = 59.ToString();
				}
			} catch (FormatException) {
				return;
			}
		}

		private void textBox3_TextChanged(object sender, EventArgs e) {
			try {
				if (int.Parse(textBox3.Text) > 23) {
					textBox3.Text = 23.ToString();
				}
			} catch (FormatException) {
				return;
			}
		}

		private void textBox4_TextChanged(object sender, EventArgs e) {
			try {
				if (int.Parse(textBox4.Text) > 59) {
					textBox4.Text = 59.ToString();
				}
			} catch (FormatException) {
				return;
			}
		}

		private void textBox5_TextChanged(object sender, EventArgs e) {
			try {
				if (int.Parse(textBox5.Text) > 23) {
					textBox5.Text = 23.ToString();
				}
			} catch (FormatException) {
				return;
			}
		}

		private void textBox6_TextChanged(object sender, EventArgs e) {
			try {
				if (int.Parse(textBox6.Text) > 59) {
					textBox6.Text = 59.ToString();
				}
			} catch (FormatException) {
				return;
			}
		}

		private void button1_Click(object sender, EventArgs e) {
			timer1.Enabled = true;
			int a, b, c, d, n, m;

			try {
				a = int.Parse(textBox1.Text);
				b = int.Parse(textBox2.Text);
				c = int.Parse(textBox3.Text);
				d = int.Parse(textBox4.Text);
				n = int.Parse(textBox5.Text);
				m = int.Parse(textBox6.Text);
			} catch (FormatException) {
				return;
			}

			Properties.Settings.Default.a = a;
			Properties.Settings.Default.b = b;
			Properties.Settings.Default.c = c;
			Properties.Settings.Default.d = d;
			Properties.Settings.Default.n = n;
			Properties.Settings.Default.m = m;
			Properties.Settings.Default.Save();

			if (Logic.GetResult(a, b, c, d, n, m)) {
				MessageBox.Show("Поезд стоит на платформе");
			} else {
				trainIsGone = true;
			}
		}
	}

	public class Logic {
		public static bool GetResult(int a, int b, int c, int d, int n, int m) {
			if ((a < n && n < c) ||
				((a < n || n < c) && (c < a)) ||
				(((a >= n && n > c) && (c < a) && !(n < a)) && !(m <= b)) ||
				((a > n && c == n) && (m < d)) ||
				((a == n && c > n) && (m > b)) ||
				((a < n && c == n) && (m < d)) ||
				((a == n && c < n) && (m > b))) {
				return true;
			}

			return false;
		}
	}
}
