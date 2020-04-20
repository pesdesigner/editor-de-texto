using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Editor_de_Texto
{
    public partial class Form1 : Form
    {
        StreamReader leitura = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_abrir_click(object sender, EventArgs e)
        {

        }
        private void Novo()
        {
            richTextBox1.Clear();
            richTextBox1.Focus();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void Salvar()
        {
            try
            {
                if(this.saveFileDialog1.ShowDialog()== DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter escreva_streamWriter = new StreamWriter(arquivo);
                    escreva_streamWriter.Flush();
                    escreva_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                    escreva_streamWriter.Write(this.richTextBox1.Text);
                    escreva_streamWriter.Flush();
                    escreva_streamWriter.Close();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Erro ao tentar salvar arquivo "+ex.Message, "Erro ao salvar",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salvar();
        }
        private void Abrir()
        {
            this.openFileDialog1.Title = "Abrir Arquivo";
            openFileDialog1.InitialDirectory = @"C:\C#\Application\Editor de Texto\";
            openFileDialog1.Filter = "(*.txt)|*.txt";

            DialogResult dr = this.openFileDialog1.ShowDialog();
            if(dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader leia_streamReader = new StreamReader(arquivo);
                    leia_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.richTextBox1.Text = "";
                    string linha = leia_streamReader.ReadLine();
                    while(linha != null)
                    {
                        this.richTextBox1.Text += linha + "\n";
                        linha = leia_streamReader.ReadLine();
                    }
                    leia_streamReader.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erro ao tentar abrir arquivo " + ex.Message, "Erro ao ler", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btn_abrir_Click_1(object sender, EventArgs e)
        {
            Abrir();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir();
        }
    }
}
