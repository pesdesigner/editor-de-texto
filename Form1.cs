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
    }
}
