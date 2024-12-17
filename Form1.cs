using System;
using System.Windows.Forms;

namespace Работа_за_16._12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Mnojestvo = textBox1.Text; // храним значение
            string[] str = Mnojestvo.Split(' '); // через пробел вводим числа
            int[] iMnojestvo = new int[str.Length]; // преобразуем в целочисленный
            if (!int.TryParse(textBox2.Text, out int r) || r <= 0) // проверка размера комбинации 
            {
                MessageBox.Show("Введите корректный размер комбинации");
                return;
            }
            Proverka(iMnojestvo, str, r);

            
            listBox1.Items.Clear();
            listBox1.Items.Add("Без повторения");

            
            for (int i = 0; i < iMnojestvo.Length; i++) // вывод всех пар без повторений
            { 
                for (int j = i + 1; j < iMnojestvo.Length; j++)
                {
                    listBox1.Items.Add($"{iMnojestvo[i]}, {iMnojestvo[j]}");
                }
            }

            listBox1.Items.Add("C повторением");


            for (int i = 0; i < iMnojestvo.Length; i++) // Вывод всех пар с повторениями
            {
                for (int j = i; j < iMnojestvo.Length; j++)
                {
                    listBox1.Items.Add($"{iMnojestvo[i]}, {iMnojestvo[j]}");
                }
            }

            //вывод результатов
            listBox1.Items.Add($"Сочетание ({iMnojestvo.Length}, {r}) {Sochetanie(iMnojestvo.Length, r)}");
            listBox1.Items.Add($"Размещение ({iMnojestvo.Length}, {r}) {Razmechenie(iMnojestvo.Length, r)}");
            listBox1.Items.Add($"Перестановка ({iMnojestvo.Length}) {Perestanovka(iMnojestvo.Length)}");
        }

        private long Factorial(int n) // метод для вычислния факториала
        {
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result; // сюда записываются результат одного из метода  Sochetanie Razmechenie Perestanovka
        }

        private long Sochetanie(int Sum, int r)
        {
            if (r > Sum) return 0;
            return Factorial(Sum) / (Factorial(r) * Factorial(Sum - r));
        }

        private long Razmechenie(int Sum, int r)
        {
            if (r > Sum) return 0;
            return Factorial(Sum) / Factorial(Sum - r);
        }

        private long Perestanovka(int Sum)
        {
            return Factorial(Sum);
        }

        private void Proverka(int[] iMnojestvo, string[] str, int r) // проверка на корректный ввод данных
        {
            if (iMnojestvo.Length == 0)
            {
                MessageBox.Show("Введите хотя бы одно число!");
                return;
            }

            for (int i = 0; i < str.Length; i++) // пробегается по каждой для проверки правильности
            {
                if (!int.TryParse(str[i], out iMnojestvo[i]))
                {
                    MessageBox.Show("Введите корректные числа, разделенные пробелом");
                    return;
                }
            }

            if (r > iMnojestvo.Length)
            {
                MessageBox.Show("Размер комбинации не может быть больше кол-ва элементов");
                return;
            }
        }

        private void button1_MouseMove(object sender, MouseEventArgs e) // наведя на кнопку "Считать" всплывает фамилия
        {
            ToolTip message = new ToolTip();
            message.SetToolTip(button1, "Выполнил Добрынин Дмитрий");
        }
    }
}
