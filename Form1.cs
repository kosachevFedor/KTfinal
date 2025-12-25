using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TransfersApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
            LoadTransactions();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "Переводы - История транзакций";
            lblTitle.Text = "Новый перевод";
        }

        private void LoadTransactions()
        {
            try
            {
                var transactions = DatabaseHelper.GetAllTransactions();
                dataGridView1.DataSource = transactions;
                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string from = txtFrom.Text.Trim();
                string to = txtTo.Text.Trim();
                decimal amount = decimal.Parse(txtAmount.Text);

                if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
                {
                    MessageBox.Show("Укажите оба счёта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (amount <= 0)
                {
                    MessageBox.Show("Сумма должна быть больше нуля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var transaction = new Transaction
                {
                    FromAccount = from,
                    ToAccount = to,
                    Amount = amount
                };

                DatabaseHelper.SaveTransaction(transaction);
                MessageBox.Show("Транзакция сохранена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFrom.Clear();
                txtTo.Clear();
                txtAmount.Clear();
                LoadTransactions();
                txtFrom.Focus();
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный формат суммы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTransactions();
        }
    }
}
