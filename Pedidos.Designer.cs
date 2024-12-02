namespace WinFormsApp2
{
    partial class Pedidos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            panel2 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            textBox5 = new TextBox();
            label8 = new Label();
            textBox4 = new TextBox();
            label7 = new Label();
            btn_alterar_pedido = new Button();
            btn_remover_pedido = new Button();
            btn_adicionar_pedido = new Button();
            dateTimePicker2 = new DateTimePicker();
            label6 = new Label();
            textBox6 = new TextBox();
            label9 = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            dataGridView1 = new DataGridView();
            tabPage2 = new TabPage();
            textBox9 = new TextBox();
            label14 = new Label();
            textBox8 = new TextBox();
            label13 = new Label();
            textBox7 = new TextBox();
            label12 = new Label();
            dateTimePicker3 = new DateTimePicker();
            btn_alterar_doacao = new Button();
            btn_remover_doacao = new Button();
            btn_adicionar_doacao = new Button();
            dateTimePicker1 = new DateTimePicker();
            label5 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            panel4 = new Panel();
            panel5 = new Panel();
            dataGridView2 = new DataGridView();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(305, 9);
            label1.Name = "label1";
            label1.Size = new Size(184, 28);
            label1.TabIndex = 2;
            label1.Text = "Pedidos e Doações";
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 41);
            panel2.TabIndex = 19;
            panel2.Paint += S;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 41);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 409);
            tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(textBox5);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(textBox4);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(btn_alterar_pedido);
            tabPage1.Controls.Add(btn_remover_pedido);
            tabPage1.Controls.Add(btn_adicionar_pedido);
            tabPage1.Controls.Add(dateTimePicker2);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(textBox6);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 376);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Registros de Pedidos";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(350, 45);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 50;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(350, 22);
            label8.Name = "label8";
            label8.Size = new Size(210, 20);
            label8.TabIndex = 49;
            label8.Text = "Código de alimento de venda:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(189, 45);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 48;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(189, 22);
            label7.Name = "label7";
            label7.Size = new Size(44, 20);
            label7.TabIndex = 47;
            label7.Text = "CNPJ:";
            // 
            // btn_alterar_pedido
            // 
            btn_alterar_pedido.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_alterar_pedido.Location = new Point(584, 91);
            btn_alterar_pedido.Margin = new Padding(3, 4, 3, 4);
            btn_alterar_pedido.Name = "btn_alterar_pedido";
            btn_alterar_pedido.Size = new Size(86, 31);
            btn_alterar_pedido.TabIndex = 46;
            btn_alterar_pedido.Text = "Alterar";
            btn_alterar_pedido.UseVisualStyleBackColor = true;
            btn_alterar_pedido.Visible = false;
            btn_alterar_pedido.Click += btn_alterar_pedido_Click;
            // 
            // btn_remover_pedido
            // 
            btn_remover_pedido.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_remover_pedido.Location = new Point(686, 91);
            btn_remover_pedido.Margin = new Padding(3, 4, 3, 4);
            btn_remover_pedido.Name = "btn_remover_pedido";
            btn_remover_pedido.Size = new Size(86, 31);
            btn_remover_pedido.TabIndex = 45;
            btn_remover_pedido.Text = "Remover";
            btn_remover_pedido.UseVisualStyleBackColor = true;
            btn_remover_pedido.Visible = false;
            btn_remover_pedido.Click += btn_remover_pedido_Click;
            // 
            // btn_adicionar_pedido
            // 
            btn_adicionar_pedido.Location = new Point(21, 91);
            btn_adicionar_pedido.Margin = new Padding(3, 4, 3, 4);
            btn_adicionar_pedido.Name = "btn_adicionar_pedido";
            btn_adicionar_pedido.Size = new Size(182, 31);
            btn_adicionar_pedido.TabIndex = 44;
            btn_adicionar_pedido.Text = "Adicionar novo pedido";
            btn_adicionar_pedido.UseVisualStyleBackColor = true;
            btn_adicionar_pedido.Click += btn_adicionar_pedido_Click;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(523, 45);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 43;
            dateTimePicker2.Value = new DateTime(2024, 11, 11, 0, 0, 0, 0);
            dateTimePicker2.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(523, 22);
            label6.Name = "label6";
            label6.Size = new Size(117, 20);
            label6.TabIndex = 42;
            label6.Text = "Data de entrega";
            label6.Visible = false;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(21, 45);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(125, 27);
            textBox6.TabIndex = 37;
            textBox6.TextChanged += textBox6_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(21, 22);
            label9.Name = "label9";
            label9.Size = new Size(135, 20);
            label9.TabIndex = 36;
            label9.Text = "Código do pedido:";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(panel3);
            panel1.Location = new Point(21, 130);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(751, 225);
            panel1.TabIndex = 35;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlDark;
            panel3.Controls.Add(dataGridView1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(751, 225);
            panel3.TabIndex = 17;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(751, 225);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(textBox9);
            tabPage2.Controls.Add(label14);
            tabPage2.Controls.Add(textBox8);
            tabPage2.Controls.Add(label13);
            tabPage2.Controls.Add(textBox7);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(dateTimePicker3);
            tabPage2.Controls.Add(btn_alterar_doacao);
            tabPage2.Controls.Add(btn_remover_doacao);
            tabPage2.Controls.Add(btn_adicionar_doacao);
            tabPage2.Controls.Add(dateTimePicker1);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(textBox3);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(textBox1);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(panel4);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 376);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Registros de Doações";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(374, 43);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(125, 27);
            textBox9.TabIndex = 58;
            textBox9.TextChanged += textBox9_TextChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(374, 20);
            label14.Name = "label14";
            label14.Size = new Size(44, 20);
            label14.TabIndex = 57;
            label14.Text = "CNPJ:";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(374, 102);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(125, 27);
            textBox8.TabIndex = 56;
            textBox8.TextChanged += textBox8_TextChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(374, 79);
            label13.Name = "label13";
            label13.Size = new Size(143, 20);
            label13.TabIndex = 55;
            label13.Text = "Código de relatorio:";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(545, 102);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(125, 27);
            textBox7.TabIndex = 54;
            textBox7.TextChanged += textBox7_TextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(545, 79);
            label12.Name = "label12";
            label12.Size = new Size(220, 20);
            label12.TabIndex = 53;
            label12.Text = "Código de alimento de doação:";
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.Location = new Point(271, 175);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new Size(250, 27);
            dateTimePicker3.TabIndex = 35;
            dateTimePicker3.Visible = false;
            // 
            // btn_alterar_doacao
            // 
            btn_alterar_doacao.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_alterar_doacao.Location = new Point(584, 136);
            btn_alterar_doacao.Margin = new Padding(3, 4, 3, 4);
            btn_alterar_doacao.Name = "btn_alterar_doacao";
            btn_alterar_doacao.Size = new Size(86, 31);
            btn_alterar_doacao.TabIndex = 34;
            btn_alterar_doacao.Text = "Alterar";
            btn_alterar_doacao.UseVisualStyleBackColor = true;
            btn_alterar_doacao.Click += btn_alterar_doacao_Click;
            // 
            // btn_remover_doacao
            // 
            btn_remover_doacao.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_remover_doacao.Location = new Point(686, 136);
            btn_remover_doacao.Margin = new Padding(3, 4, 3, 4);
            btn_remover_doacao.Name = "btn_remover_doacao";
            btn_remover_doacao.Size = new Size(86, 31);
            btn_remover_doacao.TabIndex = 33;
            btn_remover_doacao.Text = "Remover";
            btn_remover_doacao.UseVisualStyleBackColor = true;
            btn_remover_doacao.Click += btn_remover_doacao_Click;
            // 
            // btn_adicionar_doacao
            // 
            btn_adicionar_doacao.Location = new Point(21, 136);
            btn_adicionar_doacao.Margin = new Padding(3, 4, 3, 4);
            btn_adicionar_doacao.Name = "btn_adicionar_doacao";
            btn_adicionar_doacao.Size = new Size(182, 31);
            btn_adicionar_doacao.TabIndex = 32;
            btn_adicionar_doacao.Text = "Adcionar nova doação";
            btn_adicionar_doacao.UseVisualStyleBackColor = true;
            btn_adicionar_doacao.Click += btn_adicionar_doacao_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(22, 102);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 31;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 79);
            label5.Name = "label5";
            label5.Size = new Size(117, 20);
            label5.TabIndex = 29;
            label5.Text = "Data de entrega";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(545, 43);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 28;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(545, 20);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 27;
            label4.Text = "Endereço:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(194, 43);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 26;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(194, 20);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 25;
            label3.Text = "Destinatário:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(22, 43);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 24;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 20);
            label2.Name = "label2";
            label2.Size = new Size(115, 20);
            label2.TabIndex = 23;
            label2.Text = "Código doação:";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.Controls.Add(panel5);
            panel4.Location = new Point(21, 175);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(751, 180);
            panel4.TabIndex = 22;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ControlDark;
            panel5.Controls.Add(dataGridView2);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(751, 180);
            panel5.TabIndex = 17;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(0, 0);
            dataGridView2.Margin = new Padding(3, 4, 3, 4);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(751, 180);
            dataGridView2.TabIndex = 1;
            // 
            // Pedidos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Pedidos";
            Text = "Pedidos";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox textBox1;
        private Label label2;
        private Panel panel4;
        private Panel panel5;
        private DateTimePicker dateTimePicker1;
        private Label label5;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox2;
        private Label label3;
        private Button btn_alterar_doacao;
        private Button btn_remover_doacao;
        private Button btn_adicionar_doacao;
        private Button btn_alterar_pedido;
        private Button btn_remover_pedido;
        private Button btn_adicionar_pedido;
        private DateTimePicker dateTimePicker2;
        private Label label6;
        private TextBox textBox6;
        private Label label9;
        private Panel panel1;
        private Panel panel3;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DateTimePicker dateTimePicker3;
        private TextBox textBox4;
        private Label label7;
        private TextBox textBox5;
        private Label label8;
        private TextBox textBox7;
        private Label label12;
        private TextBox textBox8;
        private Label label13;
        private TextBox textBox9;
        private Label label14;
    }
}