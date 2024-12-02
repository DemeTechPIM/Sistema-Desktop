using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp2
{
    public partial class CultivoView : Form
    {
        static string connstring = "";
        private SqlConnection conn = new SqlConnection(connstring);
        DataTable safrasDt = new DataTable();
        DataTable safraDoacaoDt = new DataTable();
        public CultivoView()
        {
            InitializeComponent();
        }

      

        private void carregarDados()
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM safra_venda";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                adapter.Fill(safrasDt);
                dataGridView1.DataSource = dt;
                query = "select tipo_insumo from insumos where tipo_insumo like '%semente%'";
                SqlDataAdapter adapter2 = new SqlDataAdapter(query, conn);
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);
                comboBox1.DataSource = dt2;
                comboBox1.DisplayMember = "tipo_insumo";
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
        private void carregarDadosDoacao()
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM safra_doacao";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                adapter.Fill(safraDoacaoDt);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (textBox1.Text is null || comboBox1.Text is null || numericUpDown1.Value == 0 /*|| dateTimePicker1.Value)|| dateTimePicker2.Value is null||*/)
                {
                    return;
                }
                try
                {
                    conn.Open();
                    string sql_add_string = "INSERT INTO safra_doacao (cod_doacao, colheita, plantio, qtd_lote, alimento) VALUES (@cod, @colheita, @plantio, @qtd_lote, @alimento)";
                    SqlCommand cmd = new SqlCommand(sql_add_string, conn);
                    cmd.Parameters.AddWithValue("@cod", textBox1.Text);
                    cmd.Parameters.AddWithValue("@colheita", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@plantio", dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@qtd_lote", numericUpDown1.Text);
                    cmd.Parameters.AddWithValue("@alimento", comboBox1.Text);
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
                    carregarDadosDoacao();
                    MessageBox.Show("Dados inseridos com sucesso");
                }
            }
            else
            {
                try
                {
                    if (textBox1.Text is null || comboBox1.Text is null || numericUpDown1.Value == 0 /*|| dateTimePicker1.Value)|| dateTimePicker2.Value is null||*/)
                    {
                        return;
                    }

                    conn.Open();
                    string sql_add_string = "INSERT INTO safra_venda (cod_venda, colheita, plantio, qtd_lote, alimento) VALUES (@cod, @colheita, @plantio, @qtd_lote, @alimento)";
                    SqlCommand cmd = new SqlCommand(sql_add_string, conn);
                    cmd.Parameters.AddWithValue("@cod", textBox1.Text);
                    cmd.Parameters.AddWithValue("@colheita", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@plantio", dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@qtd_lote", numericUpDown1.Text);
                    cmd.Parameters.AddWithValue("@alimento", comboBox1.Text);
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
                    carregarDados();
                    MessageBox.Show("Dados inseridos com sucesso");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                String sql_mostrar_no_id_string = "Select * from safra_doacao where cod_doacao like '" + textBox1.Text + "%'";
                if (textBox1.Text == "")
                {
                    sql_mostrar_no_id_string = "SELECT * FROM safra_doacao";

                    //return;
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
                String sql_mostrar_no_id_string = "Select * from safra_venda where cod_venda like '" + textBox1.Text + "%'";
                if (textBox1.Text is null)
                {
                    sql_mostrar_no_id_string = "SELECT * FROM safra_venda";

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

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                try
                {
                    conn.Open();
                    String sql_atualizar_string = "UPDATE safra_doacao SET colheita = @colheita, plantio =@plantio, qtd_lote = @qtd_lote, alimento ='@alimento WHERE safra_doacao.cod_doacao= @cod";
                    SqlCommand cmd = new SqlCommand(sql_atualizar_string, conn);
                    cmd.Parameters.AddWithValue("@colheita", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@plantio", dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@qtd_lote", numericUpDown1.Text);
                    cmd.Parameters.AddWithValue("@alimento", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@cod", textBox1.Text);

                    cmd.ExecuteNonQuery();
                    cmd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    MessageBox.Show("Dados da safra id " + textBox1.Text + " atualizados com sucesso");
                    conn.Close();
                    carregarDadosDoacao();
                }
            }
            else
            {
                try
                {
                    conn.Open();
                    String sql_atualizar_string = "UPDATE safra_venda SET colheita = @colheita, plantio =@plantio, qtd_lote = @qtd_lote, alimento = @alimento WHERE safra_venda.cod_venda= @cod";
                    SqlCommand cmd = new SqlCommand(sql_atualizar_string, conn);

                    cmd.Parameters.AddWithValue("@colheita", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@plantio", dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@qtd_lote", numericUpDown1.Text);
                    cmd.Parameters.AddWithValue("@alimento", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@cod", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    cmd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    MessageBox.Show("Dados da safra id " + textBox1.Text + " atualizados com sucesso");
                    conn.Close();
                    carregarDados();
                }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM safra_doacao";
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
            else
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM safra_venda";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    adapter.Fill(safrasDt);
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                try
                {
                    conn.Open();
                    String sql_remove_string = "DELETE FROM safra_doacao WHERE safra_doacao.id = '@cod'";

                    SqlCommand cmd = new SqlCommand(sql_remove_string, conn);
                    cmd.Parameters.AddWithValue("@cod", textBox1.Text);
                    cmd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    MessageBox.Show("Safra cod: " + textBox1.Text + " removida com sucesso");
                    conn.Close();
                    carregarDadosDoacao();
                }
            }
            else
            {
                try
                {
                    conn.Open();
                    String sql_remove_string = "DELETE FROM safra_venda WHERE safra_doacao.id = '@cod'";

                    SqlCommand cmd = new SqlCommand(sql_remove_string, conn);
                    cmd.Parameters.AddWithValue("@cod", textBox1.Text);
                    cmd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    MessageBox.Show("Safra cod: " + textBox1.Text + " removida com sucesso");
                    conn.Close();
                    carregarDados();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM safra_venda where alimento like " + comboBox1.Text + "";
            if (checkBox1.Checked)
            {
                query = "SELECT * FROM safra_doacao where alimento like " + comboBox1.Text + "";
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            try
            {
                conn.Open();
                
                DateTime datetime = DateTime.Parse(dateTimePicker1.Value.ToString());
                string query = "select * from safra_venda where plantio = '" + datetime.ToString("dd/MM/yyyy")+"'";
                
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //declarando variáveis para armazenar os valores
                string cod;
                string alimento;
                int qtd;
                DateTime data_plantio;
                DateTime data_colheita;

                DataTable d1 = new DataTable();
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value is not null)
                {
                    dataGridView1.CurrentRow.Selected = true;
                    //coletando os valores
                    if (checkBox1.Checked)
                    {
                        cod = dataGridView1.Rows[e.RowIndex].Cells["cod_doacao"].FormattedValue.ToString();
                    }
                    else
                    {
                        cod = dataGridView1.Rows[e.RowIndex].Cells["cod_venda"].FormattedValue.ToString();
                    }
                    alimento = dataGridView1.Rows[e.RowIndex].Cells["alimento"].FormattedValue.ToString();
                    qtd = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["qtd_lote"].FormattedValue.ToString());
                    data_plantio = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["plantio"].FormattedValue.ToString());
                    data_colheita = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["colheita"].FormattedValue.ToString());

                    //a atribuição é feita separadamente por causa do evento de pesquisar quando o texto das caixas de input é mudado: a tabela da DataGridView muda a cada evendo desencadeado, e consequentemente o índice da célula clicada também, e não é possível fazer a atribuição corretamente.
                    //atribuindo
                    textBox1.Text = cod;
                    comboBox1.Text = alimento;
                    numericUpDown1.Value = qtd;
                    dateTimePicker1.Value = data_plantio;
                    dateTimePicker2.Value = data_colheita;

                    dataGridView1.DataSource = safrasDt;
                }

            }
        }

        private void CultivoView_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dataGridView1.DataSource = safraDoacaoDt;
            }
            else
            {
                dataGridView1.DataSource = safrasDt;
            }
        }

        private void CultivoView_Load(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT * FROM safra_venda";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            adapter.Fill(safrasDt);

            query = "SELECT * FROM safra_doacao";
            adapter.Fill(safraDoacaoDt);

            query = "select tipo_insumo from insumos where tipo_insumo like '%semente%'";
            SqlDataAdapter adapter2 = new SqlDataAdapter(query, conn);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);
            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "tipo_insumo";

            dataGridView1.DataSource = dt;

            conn.Close();
        }
    }
}

