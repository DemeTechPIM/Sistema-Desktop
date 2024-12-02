using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class EstoqueView : Form
    {
        static string connstring = "";
        private SqlConnection conn = new SqlConnection(connstring);
        byte[]? img;
        DataTable alimentosDt = new DataTable();

        DataTable insumosDt = new DataTable();

        public EstoqueView()
        {
            InitializeComponent();
            carregarTipoAli();
            carregarDadosAlimentos();
            insumosDt.Clear();
        }

        private void carregarTipoAli()
        {
            string query = "SELECT DISTINCT tipo_ali FROM alimentos_para_venda UNION SELECT DISTINCT tipo_ali FROM alimentos_para_doacao";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable tipoAliDt = new DataTable();
            adapter.Fill(tipoAliDt);
            comboBox1.DataSource = tipoAliDt;
            comboBox1.DisplayMember = "tipo_ali";
        }
        private void carregarDadosAlimentos()
        {
            string query = "SELECT * FROM alimentos_para_venda";
            try
            {
                DataTable dt = new DataTable();
                alimentosDt = dt;
                if (checkBox1.Checked)
                {
                    query = "SELECT * FROM alimentos_para_doacao";
                }
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(alimentosDt);
                dataGridView1.DataSource = alimentosDt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void carregarDadosAlimentosDoacao()
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM alimentos_para_doacao";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void carregarSafras()
        {
            string query = "SELECT * FROM safra_venda";
            if (checkBox1.Checked)
            {
                query = "SELECT * FROM safra_doacao";
            }
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView3.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void carregarInsumos()
        {
            string query = "SELECT * FROM insumos";
            insumosDt.Clear();
            try
            {

                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                //DataTable dt = new DataTable();
                adapter.Fill(insumosDt);
                dataGridView2.DataSource = insumosDt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked)
            {
                /*
                if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
                {
                    return;
                }*/
                try
                {
                    conn.Open();
                    string sql_add_string = "INSERT INTO alimentos_para_doacao (cod_ali_doacao, nome, quantidade, tipo_ali, descricao, peso) Values(@cod, @nome, @qtd, @tipo_ali, @descricao, @peso)";
                    SqlCommand cmd = new SqlCommand(sql_add_string, conn);
                    if (img is not null)
                    {
                        sql_add_string = "INSERT INTO alimentos_para_doacao (cod_ali_doacao, nome, quantidade, tipo_ali, descricao, peso, imagem) Values(@cod, @nome, @qtd, @tipo_ali, @descricao, @peso, @imagem)";
                    }
                    cmd.Parameters.AddWithValue("@cod", textBox2.Text);
                    cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                    cmd.Parameters.Add("@qtd", SqlDbType.Int);
                    cmd.Parameters["@qtd"].Value = numericUpDown1.Value;
                    cmd.Parameters.AddWithValue("@tipo_ali", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@descricao", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@peso", numericUpDown2.Value);
                    if (img != null)
                    {
                        //imagem
                        cmd.Parameters.Add("@imagem", SqlDbType.VarBinary);
                        cmd.Parameters["@imagem"].Value = img;
                    }

                    cmd.ExecuteNonQuery();
                    cmd.ExecuteNonQueryAsync();

                    img = null;
                    label17.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                    conn.Close();
                    carregarDadosAlimentosDoacao();
                    MessageBox.Show("Dados inseridos com sucesso");
                }
            }
            else
            {
                try
                {
                    /*
                    if (textBox1.Text is null || textBox2.Text is null || comboBox1.Text is null)
                    {
                        return;
                    }
                    */
                    conn.Open();
                    string sql_add_string = "INSERT INTO alimentos_para_venda (cod_ali_vendas, nome, quantidade, tipo_ali, descricao, peso, preco) Values(@cod, @nome, @qtd, @tipo_ali, @descricao, @peso, @preco)";
                    if (img is not null)
                    {
                        sql_add_string = "INSERT INTO alimentos_para_venda (cod_ali_vendas, nome, quantidade, tipo_ali, descricao, peso, preco, imagem) Values(@cod, @nome, @qtd, @tipo_ali, @descricao, @peso, @preco, @imagem)";
                    }
                    SqlCommand cmd = new SqlCommand(sql_add_string, conn);

                    cmd.Parameters.AddWithValue("@cod", textBox2.Text);
                    cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                    cmd.Parameters.AddWithValue("@qtd", Convert.ToInt32(numericUpDown1.Value));
                    cmd.Parameters.AddWithValue("@tipo_ali", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@descricao", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@peso", numericUpDown2.Value);
                    cmd.Parameters.AddWithValue("@preco", numericUpDown3.Value);
                    if (img != null)
                    {
                        //imagem
                        cmd.Parameters.Add("@imagem", SqlDbType.VarBinary);
                        cmd.Parameters["@imagem"].Value = img;
                    }

                    cmd.ExecuteNonQuery();
                    cmd.ExecuteNonQueryAsync();

                    img = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                    conn.Close();
                    carregarDadosAlimentos();
                    MessageBox.Show("Dados inseridos com sucesso");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text is null || textBox2.Text is null || comboBox1.Text is null || numericUpDown1.Value == 0 || numericUpDown2.Value == 0 || /*numericUpDown3.Value == 0 ||*/ richTextBox1.Text is null)
            {
                MessageBox.Show("Digite os valores.");
                return;
            }
            if (checkBox1.Checked)
            {
                try
                {
                    conn.Open();
                    String sql_atualizar_string = "UPDATE alimentos_para_doacao SET nome = @nome, quantidade =@qtd, tipo_ali = @tipo, descricao = @desc WHERE alimentos_para_doacao.cod_ali_doacao= @cod";
                    SqlCommand cmd = new SqlCommand(sql_atualizar_string, conn);
                    cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                    cmd.Parameters.AddWithValue("@qtd", Convert.ToInt32(numericUpDown1.Value));
                    cmd.Parameters.AddWithValue("@tipo", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@desc", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@peso", numericUpDown2.Value);
                    cmd.Parameters.AddWithValue("@cod", textBox2.Text);
                    cmd.ExecuteNonQuery();
                    cmd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    MessageBox.Show("Dados do alimento cod " + textBox2.Text + " atualizados com sucesso");
                    conn.Close();
                    carregarDadosAlimentosDoacao();
                }
            }
            else
            {
                try
                {
                    conn.Open();
                    String sql_atualizar_string = "UPDATE alimentos_para_venda SET nome = @nome, quantidade =@qtd, tipo_ali = @tipo, descricao = @desc, preco = @preco WHERE alimentos_para_venda.cod_ali_vendas= @cod";
                    SqlCommand cmd = new SqlCommand(sql_atualizar_string, conn);
                    
                    cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                    cmd.Parameters.AddWithValue("@qtd", numericUpDown1.Value);
                    cmd.Parameters.AddWithValue("@tipo", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@desc", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@peso", numericUpDown2.Value);
                    cmd.Parameters.AddWithValue("@preco", Convert.ToInt32(numericUpDown3.Value));
                    cmd.Parameters.AddWithValue("@cod", textBox2.Text);

                    cmd.ExecuteNonQuery();
                    cmd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    MessageBox.Show("Dados do alimento cod " + textBox2.Text + " atualizados com sucesso");
                    conn.Close();
                    carregarDadosAlimentos();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text is null)
            {
                MessageBox.Show("Digite os valores.");
                return;
            }
            if (checkBox1.Checked)
            {
                try
                {
                    conn.Open();
                    String sql_remove_string = "DELETE FROM alimentos_para_doacao WHERE alimentos_para_doacao.cod_ali_doacao = @cod";

                    SqlCommand cmd = new SqlCommand(sql_remove_string, conn);
                    cmd.Parameters.AddWithValue("@cod", textBox2.Text);
                    cmd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    MessageBox.Show("Alimento cod: " + textBox2.Text + " removido com sucesso");
                    conn.Close();
                }
            }
            else
            {
                try
                {
                    conn.Open();
                    String sql_remove_string = "DELETE FROM alimentos_para_venda WHERE cod_ali_vendas = @cod";

                    SqlCommand cmd = new SqlCommand(sql_remove_string, conn);
                    cmd.Parameters.AddWithValue("@cod", textBox2.Text);
                    cmd.ExecuteNonQueryAsync();
                    MessageBox.Show("ALimento cod: " + textBox2.Text + " removido com sucesso");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            carregarTipoAli();
            carregarDadosAlimentos();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox3.Text is null || comboBox2.Text is null || textBox6.Text is null || numericUpDown4.Value == 0)
            {
                MessageBox.Show("Digite os valores.");
                return;
            }

            if (comboBox2.Text is null || textBox3.Text is null || numericUpDown4.Value == 0 || textBox6.Text is null)
            {
                return;
            }
            try
            {
                conn.Open();
                String sql_add_string = "INSERT INTO insumos (cod_insumo, tipo_insumo, quantidade, fornecedor) VALUES (@cod, @tipo, @qtd, @fornecedor)";

                SqlCommand cmd = new SqlCommand(sql_add_string, conn);
                cmd.Parameters.AddWithValue("@cod", textBox3.Text);
                cmd.Parameters.AddWithValue("@tipo", comboBox2.Text);
                cmd.Parameters.AddWithValue("@qtd", Convert.ToInt32(numericUpDown4.Value));
                cmd.Parameters.AddWithValue("@fornecedor", textBox6.Text);
                cmd.ExecuteNonQuery();
                cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                conn.Close();
                carregarInsumos();
                MessageBox.Show("Dados inseridos com sucesso");
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox3.Text is null || comboBox2.Text is null || textBox6.Text is null || numericUpDown4.Value == 0)
            {
                MessageBox.Show("Digite os valores;.");
                return;
            }
            try
            {
                conn.Open();
                String sql_atualizar_string = "UPDATE insumos SET tipo_insumo = @tipo, quantidade = @qtd, fornecedor = @fornecedor WHERE cod_insumo =  @cod";
                SqlCommand cmd = new SqlCommand(sql_atualizar_string, conn);
                cmd.Parameters.AddWithValue("@tipo", comboBox2.Text);
                cmd.Parameters.AddWithValue("@qtd", Convert.ToInt32(numericUpDown4.Value));
                cmd.Parameters.AddWithValue("@fornecedor", textBox6.Text);
                cmd.Parameters.AddWithValue("@cod", textBox3.Text);

                cmd.ExecuteNonQuery();
                cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Dados do insumo cod " + textBox3.Text + " atualizados com sucesso");
                conn.Close();
                carregarInsumos();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox3.Text is null)
            {
                MessageBox.Show("Digite os valores.");
                return;
            }
            try
            {
                conn.Open();
                String sql_remove_string = "DELETE FROM insumos WHERE insumos.cod_insumo = @cod";

                SqlCommand cmd = new SqlCommand(sql_remove_string, conn);
                cmd.Parameters.AddWithValue("@cod", textBox3.Text);
                cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Insumo cod: " + textBox3.Text + " removido com sucesso");
                conn.Close();
                carregarInsumos();
            }
        }

        private void comboBox2_TextUpdate(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MemoryStream stream = new MemoryStream();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Selecione a imagem|*.jpeg;*.png;*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PictureBox imageBox = new PictureBox();
                imageBox.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);
                imageBox.Image.Save(stream, imageBox.Image.RawFormat);
                img = stream.ToArray();
                imageBox.Dispose();
            }
            openFileDialog1.Dispose();
            label17.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                String sql_mostrar_no_id_string = "Select * from alimentos_para_doacao where nome like '" + textBox1.Text + "%' ";
                if (textBox1.Text == "")
                {
                    sql_mostrar_no_id_string = "SELECT * FROM alimentos_para_doacao";
                }


                try
                {
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(sql_mostrar_no_id_string, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                String sql_mostrar_no_id_string = "Select * from alimentos_para_venda where nome like '" + textBox1.Text + "%'";
                if (textBox1.Text is null)
                {
                    sql_mostrar_no_id_string = "SELECT * from alimentos_para_venda";
                }
                try
                {
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(sql_mostrar_no_id_string, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                String sql_mostrar_no_id_string = "Select * from alimentos_para_doacao where cod_ali_doacao like '" + textBox2.Text + "%' ";
                if (textBox2.Text is null)
                {
                    sql_mostrar_no_id_string = "SELECT * FROM alimentos_para_doacao";
                }


                try
                {
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(sql_mostrar_no_id_string, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                String sql_mostrar_no_id_string = "Select * from alimentos_para_venda where cod_ali_vendas like '" + textBox2.Text + "%'";
                if (textBox2.Text is null)
                {
                    sql_mostrar_no_id_string = "SELECT * from alimentos_para_venda";
                }
                try
                {
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(sql_mostrar_no_id_string, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            String sql_mostrar_no_id_string = "Select * from insumos where cod_insumo like '" + textBox3.Text + "%'";
            if (textBox3.Text is null)
            {
                sql_mostrar_no_id_string = "SELECT * from insumos";
            }
            try
            {
                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sql_mostrar_no_id_string, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            carregarTipoAli();
            if (checkBox1.Checked)
            {
                numericUpDown3.Value = 0;
                numericUpDown3.Enabled = false;
            }
            else
            {
                numericUpDown3.Enabled = true;
            }
            carregarDadosAlimentos();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM alimentos_para_venda where tipo_ali = '" + comboBox1.Text + "'";
            if (checkBox1.Checked)
            {
                query = "SELECT * FROM alimentos_para_doacao where  tipo_ali = '" + comboBox1.Text + "'";
            }
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM insumos where tipo_insumo = '" + comboBox2.Text + "'";
            if (comboBox2.Text is null)
            {
                query = "select * from insumos";
            }
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM insumos where fornecedor like '" + textBox6.Text + "'";
            if (checkBox1.Checked)
            {
                query = "SELECT * FROM insumos";
            }
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = alimentosDt;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = insumosDt;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                carregarInsumos();
            }
            if (tabControl1.SelectedIndex == 2)
            {
                carregarSafras();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0)
            {
                //declarando variáveis para armazenar os valores
                string cod;
                string nome;
                string tipo;
                int qtd;
                string descricao;

                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value is not null)
                {
                    dataGridView1.CurrentRow.Selected = true;
                    //coletando os valores
                    if (checkBox1.Checked)
                    {
                        cod = dataGridView1.Rows[e.RowIndex].Cells["cod_ali_doacao"].FormattedValue.ToString();
                    }
                    else
                    {
                        cod = dataGridView1.Rows[e.RowIndex].Cells["cod_ali_vendas"].FormattedValue.ToString();
                    }
                    nome = dataGridView1.Rows[e.RowIndex].Cells["nome"].FormattedValue.ToString();
                    qtd = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["quantidade"].FormattedValue.ToString());
                    tipo = dataGridView1.Rows[e.RowIndex].Cells["tipo_ali"].FormattedValue.ToString();
                    numericUpDown2.Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["peso"].FormattedValue.ToString());
                    if (checkBox1.Checked is false)
                    {
                        numericUpDown3.Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["preco"].FormattedValue.ToString());
                    }
                    descricao = dataGridView1.Rows[e.RowIndex].Cells["descricao"].FormattedValue.ToString();

                    //a atribuição é feita separadamente por causa do evento de pesquisar quando o texto das caixas de input é mudado: a tabela da DataGridView muda a cada evendo desencadeado, e consequentemente o índice da célula clicada também, e não é possível fazer a atribuição corretamente.
                    //atribuindo
                    textBox2.Text = cod;
                    textBox1.Text = nome;
                    numericUpDown1.Value = qtd;
                    comboBox1.Text = tipo;
                    richTextBox1.Text = descricao;

                    dataGridView1.DataSource = alimentosDt;
                }
            }
        }
    }
}
