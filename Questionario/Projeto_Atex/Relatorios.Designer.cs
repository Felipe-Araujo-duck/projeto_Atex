namespace Projeto_Atex
{
    partial class Relatorios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Relatorios));
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tabCrianca = new MetroFramework.Controls.MetroTabPage();
            this.tabEscola = new MetroFramework.Controls.MetroTabPage();
            this.gridCrianca = new System.Windows.Forms.DataGridView();
            this.txtPesquisa = new MetroFramework.Controls.MetroTextBox();
            this.btnPesquisar = new MetroFramework.Controls.MetroButton();
            this.btnAtualizar = new MetroFramework.Controls.MetroButton();
            this.metroTabControl1.SuspendLayout();
            this.tabCrianca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrianca)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.tabCrianca);
            this.metroTabControl1.Controls.Add(this.tabEscola);
            this.metroTabControl1.Location = new System.Drawing.Point(11, 48);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(780, 405);
            this.metroTabControl1.TabIndex = 0;
            // 
            // tabCrianca
            // 
            this.tabCrianca.Controls.Add(this.btnAtualizar);
            this.tabCrianca.Controls.Add(this.btnPesquisar);
            this.tabCrianca.Controls.Add(this.txtPesquisa);
            this.tabCrianca.Controls.Add(this.gridCrianca);
            this.tabCrianca.HorizontalScrollbarBarColor = true;
            this.tabCrianca.Location = new System.Drawing.Point(4, 35);
            this.tabCrianca.Name = "tabCrianca";
            this.tabCrianca.Size = new System.Drawing.Size(772, 366);
            this.tabCrianca.TabIndex = 0;
            this.tabCrianca.Text = "Criança";
            this.tabCrianca.VerticalScrollbarBarColor = true;
            // 
            // tabEscola
            // 
            this.tabEscola.HorizontalScrollbarBarColor = true;
            this.tabEscola.Location = new System.Drawing.Point(4, 35);
            this.tabEscola.Name = "tabEscola";
            this.tabEscola.Size = new System.Drawing.Size(772, 366);
            this.tabEscola.TabIndex = 1;
            this.tabEscola.Text = "Escola";
            this.tabEscola.VerticalScrollbarBarColor = true;
            // 
            // gridCrianca
            // 
            this.gridCrianca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCrianca.Location = new System.Drawing.Point(22, 45);
            this.gridCrianca.Name = "gridCrianca";
            this.gridCrianca.Size = new System.Drawing.Size(719, 299);
            this.gridCrianca.TabIndex = 2;
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPesquisa.Location = new System.Drawing.Point(22, 11);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(482, 25);
            this.txtPesquisa.TabIndex = 3;
            this.txtPesquisa.Text = "Digite o nome da criança";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(526, 9);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(94, 30);
            this.btnPesquisar.TabIndex = 4;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.Click += new System.EventHandler(this.tbnPesquisar_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(647, 9);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(94, 30);
            this.btnAtualizar.TabIndex = 5;
            this.btnAtualizar.Text = "Atualizar";
            // 
            // Relatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "Relatorios";
            this.Text = "Relatórios";
            this.metroTabControl1.ResumeLayout(false);
            this.tabCrianca.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCrianca)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage tabCrianca;
        private MetroFramework.Controls.MetroButton btnAtualizar;
        private MetroFramework.Controls.MetroButton btnPesquisar;
        private MetroFramework.Controls.MetroTextBox txtPesquisa;
        private System.Windows.Forms.DataGridView gridCrianca;
        private MetroFramework.Controls.MetroTabPage tabEscola;
    }
}