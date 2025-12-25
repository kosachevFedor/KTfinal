namespace TransfersApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private TextBox txtFrom;
        private TextBox txtTo;
        private TextBox txtAmount;
        private Label lblFrom;
        private Label lblTo;
        private Label lblAmount;
        private Button btnSave;
        private Button btnRefresh;
        private DataGridView dataGridView1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblFrom = new Label();
            lblTo = new Label();
            lblAmount = new Label();
            txtFrom = new TextBox();
            txtTo = new TextBox();
            txtAmount = new TextBox();
            btnSave = new Button();
            btnRefresh = new Button();
            dataGridView1 = new DataGridView();
            lblTitle.Location = new System.Drawing.Point(12, 9);
            lblTitle.Size = new System.Drawing.Size(200, 23);
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            lblFrom.Location = new System.Drawing.Point(12, 45);
            lblFrom.Size = new System.Drawing.Size(100, 20);
            lblFrom.Text = "Счёт отправителя:";

            txtFrom.Location = new System.Drawing.Point(12, 65);
            txtFrom.Size = new System.Drawing.Size(200, 23);

            lblTo.Location = new System.Drawing.Point(12, 95);
            lblTo.Size = new System.Drawing.Size(100, 20);
            lblTo.Text = "Счёт получателя:";

            txtTo.Location = new System.Drawing.Point(12, 115);
            txtTo.Size = new System.Drawing.Size(200, 23);

            lblAmount.Location = new System.Drawing.Point(12, 145);
            lblAmount.Size = new System.Drawing.Size(50, 20);
            lblAmount.Text = "Сумма:";

            txtAmount.Location = new System.Drawing.Point(12, 165);
            txtAmount.Size = new System.Drawing.Size(100, 23);

            btnSave.Location = new System.Drawing.Point(12, 200);
            btnSave.Size = new System.Drawing.Size(90, 30);
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;

            dataGridView1.Location = new System.Drawing.Point(12, 240);
            dataGridView1.Size = new System.Drawing.Size(560, 300);
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(584, 561);
            Controls.Add(dataGridView1);
            Controls.Add(btnRefresh);
            Controls.Add(btnSave);
            Controls.Add(txtAmount);
            Controls.Add(lblAmount);
            Controls.Add(txtTo);
            Controls.Add(lblTo);
            Controls.Add(txtFrom);
            Controls.Add(lblFrom);
            Controls.Add(lblTitle);
            Text = "Переводы";
            Load += Form1_Load;
        }
    }
}
