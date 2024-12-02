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
    public partial class Pedidos : Form
    {
        static string connstring = "";
        private SqlConnection conn = new SqlConnection(connstring);
        public Pedidos()
        {
            InitializeComponent();
            carregarPedidos();
            carregarRegistrosDoacao();
            btn_adicionar_pedido.Visible = false;
        }
        private void carregarPedidos()
        {
            string query = "SELECT * FROM pedido";
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

        private void carregarRegistrosDoacao()
        {
            string query = "SELECT * FROM registro_doacao";
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

        private void btn_adicionar_pedido_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql_add_string = "INSERT INTO pedidos (cod_pedido, endereco, data_pedido, data_entrega, valor_pago, cod_ali_vendas, cnpj) VALUES (@cod, @endereco, @datapedido, @dataentrega, @valorpago, @cod_ali_vendas, @cnpj)";
                SqlCommand cmd = new SqlCommand(sql_add_string, conn);
                cmd.Parameters.AddWithValue("@cod", textBox6.Text);
                cmd.Parameters.AddWithValue("@data_pedido", dateTimePicker1.Value);
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
                carregarPedidos();
                MessageBox.Show("Dados inseridos com sucesso");
            }
        }

        private void btn_alterar_pedido_Click(object sender, EventArgs e)
        {

        }

        private void btn_remover_pedido_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                String sql_remove_string = "DELETE FROM pedidos WHERE pedidos.cod_pedido = @cod";

                SqlCommand cmd = new SqlCommand(sql_remove_string, conn);
                cmd.Parameters.AddWithValue("@cod", textBox6.Text);
                cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Alimento cod: " + textBox6.Text + " removido com sucesso");
                conn.Close();
                carregarPedidos();
            }
        }

        private void btn_adicionar_doacao_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql_add_string = "INSERT INTO registro_doacao (cod_doacao, endereco, destinatario, data_entrega, cod_ali_doacao, cod_relatorios, cnpj) VALUES (@cod, @endereco, @destinatario, @data_entrega, @cod_ali_doacao, @cod_relatorios, @cnpj)";
                SqlCommand cmd = new SqlCommand(sql_add_string, conn);
                cmd.Parameters.AddWithValue("@cod", textBox1.Text);
                cmd.Parameters.AddWithValue("@endereco", textBox3.Text);
                cmd.Parameters.AddWithValue("@destinatario", textBox2.Text);
                cmd.Parameters.AddWithValue("@data_entrega", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@cod_ali_doacao", textBox7.Text);
                cmd.Parameters.AddWithValue("@cod_relatorios", textBox8.Text);
                cmd.Parameters.AddWithValue("@cnpj", textBox9.Text);
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
                carregarRegistrosDoacao();
                MessageBox.Show("Dados inseridos com sucesso");
            }
        }

        private void btn_alterar_doacao_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql_add_string = "UPDATE registro_doacao SET endereco = @endereco, destinatario = @destinatario, data_entrega = @data_entrega, cod_ali_doacao = @cod_ali_doacao, cod_relatorios = @cod_relatorios, cnpj = @cnpj WHERE registro_doacao.cod_doacao = @cod";
                SqlCommand cmd = new SqlCommand(sql_add_string, conn);
                cmd.Parameters.AddWithValue("@endereco", textBox3.Text);
                cmd.Parameters.AddWithValue("@destinatario", textBox2.Text);
                cmd.Parameters.AddWithValue("@data_entrega", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@cod_ali_doacao", textBox7.Text);
                cmd.Parameters.AddWithValue("@cod_relatorios", textBox8.Text);
                cmd.Parameters.AddWithValue("@cnpj", textBox9.Text);
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

                conn.Close();
                carregarRegistrosDoacao();
                MessageBox.Show("Dados da doação cod " + textBox1.Text + "atualizados com sucesso");
            }
        }

        private void btn_remover_doacao_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                String sql_remove_string = "DELETE FROM registro_doacao WHERE registros_doacao.cod_doacao = @cod";

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
                carregarRegistrosDoacao();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            String sql_mostrar_no_id_string = "Select * from pedido where cod_pedido like '" + textBox6.Text + "%'";
            if (textBox6.Text is null)
            {
                sql_mostrar_no_id_string = "SELECT * from pedido";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String sql_mostrar_no_id_string = "Select * from registro_doacao where cod_doacao like '" + textBox1.Text + "%'";
            if (textBox6.Text is null)
            {
                carregarRegistrosDoacao();
                return;
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            String sql_mostrar_no_id_string = "Select * from pedido where cnpj like '" + textBox4.Text + "%'";
            if (textBox5.Text is null)
            {
                sql_mostrar_no_id_string = "SELECT * from pedido";
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            String sql_mostrar_no_id_string = "Select * from pedido where cod_alimento like '" + textBox5.Text + "%'";
            if (textBox1.Text is null)
            {
                sql_mostrar_no_id_string = "SELECT * from pedido";
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            String sql_mostrar_no_id_string = "Select * from registro_doacao where destinatario like '" + textBox2.Text + "%'";
            if (textBox6.Text is null)
            {
                carregarRegistrosDoacao();
                return;
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

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            String sql_mostrar_no_id_string = "Select * from registro_doacao where cnpj like '" + textBox9.Text + "%'";
            if (textBox6.Text is null)
            {
                carregarRegistrosDoacao();
                return;
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            String sql_mostrar_no_id_string = "Select * from registro_doacao where endereco like '" + textBox3.Text + "%'";
            if (textBox6.Text is null)
            {
                carregarRegistrosDoacao();
                return;
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

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            String sql_mostrar_no_id_string = "Select * from registro_doacao where cod_relatorios like '" + textBox8.Text + "%'";
            if (textBox6.Text is null)
            {
                carregarRegistrosDoacao();
                return;
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            String sql_mostrar_no_id_string = "Select * from registro_doacao where cod_ali_doacao like '" + textBox7.Text + "%'";
            if (textBox6.Text is null)
            {
                carregarRegistrosDoacao();
                return;
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

        private void S(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
