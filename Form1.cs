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
        StringReader leitura = null;
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
        private void Copiar()
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }
        private void Colar()
        {
            richTextBox1.Paste();
        }

        private void btn_copiar_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void btn_colar_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colar();
        }
        private void FontBold()
        {
            string fontName = null;
            float fontSize = 0;
            bool b,i,u = false;

            fontName = richTextBox1.Font.Name;
            fontSize = richTextBox1.Font.Size;
            b = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            u = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Regular);
            if (b == false)
            {
                if (i == true & u == true)
                {
                    richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if(i == false & u == true)
                {
                    richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Bold | FontStyle.Underline);
                }
                else if (i == true & u == false)
                {
                    richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Bold | FontStyle.Italic);
                }
                else if (i == false & u == false)
                {
                    richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Bold);
                }
            }
            else
            {
                if (i == true & u == true)
                {
                    richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Italic | FontStyle.Underline);
                }
                else if (i == false & u == true)
                {
                    richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Underline);
                }
                else if(i == true & u == false)
                {
                    richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Italic);
                }
            }

        }
        private void FontItalic()
        {
            string fontName = null;
            float fontSize = 0;
            bool b, i, u = false;

            fontName = richTextBox1.Font.Name;
            fontSize = richTextBox1.Font.Size;
            b = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            u = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Regular);
            if (i == false)
            {
                if (b == true & u == true)
                {
                    richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (b == false & u == true)
                {
                    richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Italic | FontStyle.Underline);
                }
                else if (b == true & u == false)
                {
                    richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Bold | FontStyle.Italic);
                }
                else if (b == false & u == false)
                {
                    richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Italic);
                }
            }
            else
            {
                if (b == true & u == true)
                {
                    richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Bold | FontStyle.Underline);
                }
                else if (i == false & u == true)
                {
                    richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Underline);
                }
                else if (i == true & u == false)
                {
                    richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Bold);
                }
            }

        }
        private void FontUnderline()
        {
            string fontName = null;
            float fontSize = 0;
            bool b, i, u = false;

            fontName = richTextBox1.Font.Name;
            fontSize = richTextBox1.Font.Size;
            b = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            u = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Regular);
            if (u == false)
            {
                if (b == true & i == true)
                {
                    richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (b == false & i == true)
                {
                    richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Italic | FontStyle.Underline);
                }
                else if (b == true & i == false)
                {
                    richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Bold | FontStyle.Underline);
                }
                else if (b == false & i == false)
                {
                    richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Underline);
                }
            }
            else
            {
                if (b == true & i == true)
                {
                    richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Bold | FontStyle.Italic);
                }
                else if (b == false & i == true)
                {
                    richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Italic);
                }
                else if (b == true & i == false)
                {
                    richTextBox1.SelectionFont = new Font(fontName, fontSize, FontStyle.Bold);
                }
            }
        }

        private void AlignLeft()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }
        private void AlignRight()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }
        private void AlignCenter()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void Print()
        {
            printDialog1.Document = printDocument1;
            string text = this.richTextBox1.Text;
            leitura = new StringReader(text);
            if(printDialog1.ShowDialog()== DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }

        private void btn_negrito_Click(object sender, EventArgs e)
        {
            FontBold();
        }

        private void btn_italico_Click(object sender, EventArgs e)
        {
            FontItalic();
        }

        private void btn_sublinhado_Click(object sender, EventArgs e)
        {
            FontUnderline();
        }

        private void negritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontBold();
        }

        private void itálicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontItalic();
        }

        private void sublinhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontUnderline();
        }

        private void btn_esquerda_Click(object sender, EventArgs e)
        {
            AlignLeft();
        }

        private void esquerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlignLeft();
        }

        private void btn_centro_Click(object sender, EventArgs e)
        {
            AlignCenter();
        }

        private void centralizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlignCenter();
        }

        private void btn_direita_Click(object sender, EventArgs e)
        {
            AlignRight();
        }

        private void direitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlignRight();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linhasPagina = 0;
            float PosY = 0;
            int cont = 0;
            float mEsq = e.MarginBounds.Left - 50;
            float mSup = e.MarginBounds.Top - 50;
            if (mEsq < 5)
            {
                mEsq = 20;
            }
            if(mSup < 5)
            {
                mSup = 20;
            }
            string linha = null;
            Font fonte = this.richTextBox1.Font;
            SolidBrush pincel = new SolidBrush(Color.Black);
            linhasPagina = e.MarginBounds.Height / fonte.GetHeight(e.Graphics);
            linha = leitura.ReadLine();
            while (cont < linhasPagina)
            {
                PosY = (mSup + (cont * fonte.GetHeight(e.Graphics)));
                e.Graphics.DrawString(linha, fonte, pincel, mEsq, PosY, new StringFormat());
                cont += 1;
                linha = leitura.ReadLine();
            }
            if(linha != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            pincel.Dispose();
        }
    }
}
