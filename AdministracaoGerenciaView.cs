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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp2
{
    public partial class Gerencia_Administracao : Form
    {
        //static string connstring = "Server=tcp:demetech-server.database.windows.net,1433;Initial Catalog=demetech;Persist Security Info=False;User ID=demeterAzureSA;Password=@tecnova123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static string connstring = "Server=tcp:gabrielcandido.database.windows.net,1433;Initial Catalog=DEMETECH;Persist Security Info=False;User ID=gabrielcandido;Password=@123tech;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=true;Connection Timeout=30;";
        private SqlConnection conn = new SqlConnection(connstring);
        DataTable funcionarioDt = new DataTable();
        DataTable tipoAlimentoDt = new DataTable();
        DataTable departamentoDt = new DataTable();
        DataTable loteDt = new DataTable();

        public Gerencia_Administracao()
        {
            InitializeComponent();
            carregarFuncionario();
            carregarDepartamento();
            carregarTipoAlimentos();
            carregarLote();
        }

        private void carregarFuncionario()
        {
            string query = "SELECT * FROM funcionario";
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                funcionarioDt.Clear();
                adapter.Fill(funcionarioDt);
                dataGridView1.DataSource = funcionarioDt;
                //query = "select "
                /*
                comboBox1.Items.Clear();
                if (dt.Rows[0][4].ToString() != null)
                    comboBox1.Items.Add(dt.Rows[0][4].ToString());
                comboBox1.Text = "";
                */
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

        private void carregarDepartamento()
        {
            string query = "SELECT * FROM departamento";
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                departamentoDt.Clear();
                adapter.Fill(departamentoDt);
                dataGridView2.DataSource = departamentoDt;
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
        private void carregarTipoAlimentos()
        {
            string query = "SELECT * FROM alimentos_para_venda";
            try
            {
                if (checkBox1.Checked)
                {
                    query = "SELECT * FROM alimentos_para_doacao";
                }
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                tipoAlimentoDt.Clear();
                adapter.Fill(tipoAlimentoDt);
                dataGridView2.DataSource = tipoAlimentoDt;
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
        private void carregarLote()
        {
            string query = "SELECT * FROM lote";
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                loteDt.Clear();
                adapter.Fill(loteDt);
                dataGridView3.DataSource = loteDt;
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

        private void btn_cadastrar_funcionario_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql_add_string = "INSERT INTO funcionario (cod_funcionario, salario, cargo, nome, data_entrada, senha, email) VALUES (@cod, @salario, @cargo, @nome, @data_entrada, @senha, @email)";
                SqlCommand cmd = new SqlCommand(sql_add_string, conn);
                //@cod, @salario, @cargo, @nome, @data_entrada, @senha, @email
                cmd.Parameters.AddWithValue("@cod", textBox1.Text);
                cmd.Parameters.AddWithValue("@salario", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@nome", textBox2.Text);
                cmd.Parameters.AddWithValue("@cargo", comboBox1.Text);
                cmd.Parameters.AddWithValue("@data_entrada", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@email", textBox3.Text);
                cmd.Parameters.AddWithValue("@senha", textBox5.Text);
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
                carregarFuncionario();
                MessageBox.Show("Dados inseridos com sucesso");
            }
        }

        private void btn_alterar_cadastro_funcionario_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                String sql_atualizar_string = "UPDATE funcionario SET salario = @salario, cargo = @cargo, nome = @nome, data_entrada = @data_entrada, senha = @senha, email = @email WHERE funcionario.cod_funcionario = @cod";
                SqlCommand cmd = new SqlCommand(sql_atualizar_string, conn);
                cmd.Parameters.AddWithValue("@cod", textBox1.Text);
                cmd.Parameters.AddWithValue("@salario", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@nome", textBox2.Text);
                cmd.Parameters.AddWithValue("@cargo", comboBox1.Text);
                cmd.Parameters.AddWithValue("@data_entrada", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@email", textBox3.Text);
                cmd.Parameters.AddWithValue("@senha", textBox5.Text);
                cmd.ExecuteNonQuery();
                cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Dados do funcionario cod " + textBox4.Text + " atualizados com sucesso");
                conn.Close();
                carregarFuncionario();
            }
        }

        private void btn_remover_cadastro_funcionario_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                String sql_remove_string = "DELETE FROM funcionario WHERE cod_funcionario = @cod";

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
                MessageBox.Show("Alimento cod: " + textBox1.Text + " removido com sucesso");
                conn.Close();
                carregarFuncionario();
            }
        }

        private void btn_cadastrar_tipo_alimento_Click(object sender, EventArgs e)
        {
            /*
            if(checkBox1.Checked = true)
            {
                try
                {
                    conn.Open();
                    string sql_add_string = "INSERT INTO alimentos_para_doacao (cod_funcionario, salario, cargo, nome, data_entrada, senha, email) VALUES (@cod, @salario, @cargo, @nome, @data_entrada, @senha, @email)";
                    SqlCommand cmd = new SqlCommand(sql_add_string, conn);
                    //@cod, @salario, @cargo, @nome, @data_entrada, @senha, @email
                    cmd.Parameters.AddWithValue("@cod", textBox1.Text);
                    cmd.Parameters.AddWithValue("@salario", numericUpDown1.Value);
                    cmd.Parameters.AddWithValue("@nome", textBox2.Text);
                    cmd.Parameters.AddWithValue("@cargo", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@data_entrada", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@email", textBox3.Text);
                    cmd.Parameters.AddWithValue("@senha", textBox5.Text);
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
                    carregarFuncionario();
                    MessageBox.Show("Dados inseridos com sucesso");
                }
                else
                {
                    try
                    {
                        conn.Open();
                        string sql_add_string = "INSERT INTO (cod_funcionario, salario, cargo, nome, data_entrada, senha, email) VALUES (@cod, @salario, @cargo, @nome, @data_entrada, @senha, @email)";
                        SqlCommand cmd = new SqlCommand(sql_add_string, conn);
                        //@cod, @salario, @cargo, @nome, @data_entrada, @senha, @email
                        cmd.Parameters.AddWithValue("@cod", textBox1.Text);
                        cmd.Parameters.AddWithValue("@salario", numericUpDown1.Value);
                        cmd.Parameters.AddWithValue("@nome", textBox2.Text);
                        cmd.Parameters.AddWithValue("@cargo", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@data_entrada", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@email", textBox3.Text);
                        cmd.Parameters.AddWithValue("@senha", textBox5.Text);
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
                        carregarFuncionario();
                        MessageBox.Show("Dados inseridos com sucesso");
                    }
                }
            }*/
            
        }

        private void btn_alterar_tipo_alimento_Click(object sender, EventArgs e)
        {

        }

        private void btn_remover_tipo_alimento_Click(object sender, EventArgs e)
        {

        }

        private void btn_cadastar_lote_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                String sql_add_string = "INSERT INTO lote (cod_lote, max_lote, tamanho, lote_dis) VALUES (@cod, @qtd, @max, @dis)";
                SqlCommand cmd = new SqlCommand(sql_add_string, conn);
                cmd.Parameters.AddWithValue("@cod", textBox11.Text);
                cmd.Parameters.AddWithValue("@qtd", numericUpDown3.Value);
                cmd.Parameters.AddWithValue("@max", numericUpDown4.Value);
                cmd.Parameters.AddWithValue("@dis", checkBox3.Checked);
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
                carregarLote();
                MessageBox.Show("Dados inseridos com sucesso");
            }
        }

        private void btn_alterar_lote_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String sql_mostrar_no_id_string = "Select * from funcionario where cod_funcionario like '" + textBox1.Text + "%'";

            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql_mostrar_no_id_string, conn);
                funcionarioDt.Clear();
                adapter.Fill(funcionarioDt);
                dataGridView1.DataSource = funcionarioDt;
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            String sql_mostrar_no_id_string = "Select * from funcionario where nome like '" + textBox2.Text + "%'";

            try
            {
                conn.Open();
                //SqlCommand cmd = new SqlCommand(sql_mostrar_no_id_string, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(sql_mostrar_no_id_string, conn);
                funcionarioDt.Clear();
                adapter.Fill(funcionarioDt);
                dataGridView1.DataSource = funcionarioDt;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sql_mostrar_no_id_string = "Select * from funcionario where cargo like '" + comboBox1.Text + "%'";

            try
            {
                conn.Open();
                //SqlCommand cmd = new SqlCommand(sql_mostrar_no_id_string, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(sql_mostrar_no_id_string, conn);
                funcionarioDt.Clear();
                adapter.Fill(funcionarioDt);
                dataGridView1.DataSource = funcionarioDt;
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

        private void btn_adcionar_departamento_Click(object sender, EventArgs e)
        {

        }

        private void btn_alterar_departamento_Click(object sender, EventArgs e)
        {

        }

        private void btn_remover_departamento_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            String sql_mostrar_no_id_string = "Select * from departamento where cod_departamento like '" + textBox10.Text + "%'";

            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql_mostrar_no_id_string, conn);
                funcionarioDt.Clear();
                adapter.Fill(funcionarioDt);
                dataGridView1.DataSource = funcionarioDt;
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

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            String sql_mostrar_no_id_string = "Select * from departamento where nome like '" + textBox9.Text + "%'";

            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql_mostrar_no_id_string, conn);
                funcionarioDt.Clear();
                adapter.Fill(funcionarioDt);
                dataGridView1.DataSource = funcionarioDt;
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
}