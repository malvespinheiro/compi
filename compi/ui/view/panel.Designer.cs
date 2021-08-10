namespace compi.ui
{
    partial class panel
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
            System.Windows.Forms.MenuStrip topMenu;
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ediciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deshacerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rehacerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cortarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.seleccionarTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inspeccionarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.árbolDeDerivaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablaDeSímbolosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instruccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gramaticaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabContentEditor = new System.Windows.Forms.Panel();
            this.codeEditor = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.metadataPanel = new System.Windows.Forms.Panel();
            this.derivationTree = new System.Windows.Forms.TreeView();
            topMenu = new System.Windows.Forms.MenuStrip();
            topMenu.SuspendLayout();
            this.tabContentEditor.SuspendLayout();
            this.metadataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topMenu
            // 
            topMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ediciónToolStripMenuItem,
            this.inspeccionarToolStripMenuItem});
            topMenu.Location = new System.Drawing.Point(0, 0);
            topMenu.Name = "topMenu";
            topMenu.Size = new System.Drawing.Size(1382, 28);
            topMenu.TabIndex = 38;
            topMenu.Text = "Top Menu";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.toolStripSeparator3,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.toolStripSeparator4,
            this.cerrarToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.abrirToolStripMenuItem.Text = "Abrir";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(176, 6);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Enabled = false;
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.guardarToolStripMenuItem.Text = "Guardar";
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Enabled = false;
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.guardarComoToolStripMenuItem.Text = "Guardar como";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(176, 6);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.cerrarToolStripMenuItem.Text = "Salir";
            // 
            // ediciónToolStripMenuItem
            // 
            this.ediciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deshacerToolStripMenuItem,
            this.rehacerToolStripMenuItem,
            this.toolStripSeparator1,
            this.cortarToolStripMenuItem,
            this.copiarToolStripMenuItem,
            this.pegarToolStripMenuItem,
            this.toolStripSeparator2,
            this.seleccionarTodoToolStripMenuItem});
            this.ediciónToolStripMenuItem.Name = "ediciónToolStripMenuItem";
            this.ediciónToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.ediciónToolStripMenuItem.Text = "Edición";
            // 
            // deshacerToolStripMenuItem
            // 
            this.deshacerToolStripMenuItem.Name = "deshacerToolStripMenuItem";
            this.deshacerToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.deshacerToolStripMenuItem.Text = "Deshacer";
            // 
            // rehacerToolStripMenuItem
            // 
            this.rehacerToolStripMenuItem.Name = "rehacerToolStripMenuItem";
            this.rehacerToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.rehacerToolStripMenuItem.Text = "Rehacer";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // cortarToolStripMenuItem
            // 
            this.cortarToolStripMenuItem.Name = "cortarToolStripMenuItem";
            this.cortarToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.cortarToolStripMenuItem.Text = "Cortar";
            // 
            // copiarToolStripMenuItem
            // 
            this.copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
            this.copiarToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.copiarToolStripMenuItem.Text = "Copiar";
            // 
            // pegarToolStripMenuItem
            // 
            this.pegarToolStripMenuItem.Name = "pegarToolStripMenuItem";
            this.pegarToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.pegarToolStripMenuItem.Text = "Pegar";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(193, 6);
            // 
            // seleccionarTodoToolStripMenuItem
            // 
            this.seleccionarTodoToolStripMenuItem.Name = "seleccionarTodoToolStripMenuItem";
            this.seleccionarTodoToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.seleccionarTodoToolStripMenuItem.Text = "Seleccionar todo";
            // 
            // inspeccionarToolStripMenuItem
            // 
            this.inspeccionarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.árbolDeDerivaciónToolStripMenuItem,
            this.tablaDeSímbolosToolStripMenuItem,
            this.instruccionesToolStripMenuItem,
            this.gramaticaToolStripMenuItem});
            this.inspeccionarToolStripMenuItem.Name = "inspeccionarToolStripMenuItem";
            this.inspeccionarToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.inspeccionarToolStripMenuItem.Text = "Inspeccionar";
            // 
            // árbolDeDerivaciónToolStripMenuItem
            // 
            this.árbolDeDerivaciónToolStripMenuItem.Name = "árbolDeDerivaciónToolStripMenuItem";
            this.árbolDeDerivaciónToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.árbolDeDerivaciónToolStripMenuItem.Text = "Árbol de Derivación";
            // 
            // tablaDeSímbolosToolStripMenuItem
            // 
            this.tablaDeSímbolosToolStripMenuItem.Name = "tablaDeSímbolosToolStripMenuItem";
            this.tablaDeSímbolosToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.tablaDeSímbolosToolStripMenuItem.Text = "Tabla de Símbolos";
            // 
            // instruccionesToolStripMenuItem
            // 
            this.instruccionesToolStripMenuItem.Name = "instruccionesToolStripMenuItem";
            this.instruccionesToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.instruccionesToolStripMenuItem.Text = "Instrucciones";
            // 
            // gramaticaToolStripMenuItem
            // 
            this.gramaticaToolStripMenuItem.Name = "gramaticaToolStripMenuItem";
            this.gramaticaToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.gramaticaToolStripMenuItem.Text = "Gramatica";
            // 
            // tabContentEditor
            // 
            this.tabContentEditor.Controls.Add(this.metadataPanel);
            this.tabContentEditor.Controls.Add(this.richTextBox1);
            this.tabContentEditor.Controls.Add(this.codeEditor);
            this.tabContentEditor.Location = new System.Drawing.Point(12, 31);
            this.tabContentEditor.Name = "tabContentEditor";
            this.tabContentEditor.Size = new System.Drawing.Size(1358, 655);
            this.tabContentEditor.TabIndex = 39;
            // 
            // codeEditor
            // 
            this.codeEditor.Location = new System.Drawing.Point(16, 21);
            this.codeEditor.Name = "codeEditor";
            this.codeEditor.Size = new System.Drawing.Size(497, 407);
            this.codeEditor.TabIndex = 0;
            this.codeEditor.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(16, 478);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(497, 407);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // metadataPanel
            // 
            this.metadataPanel.Controls.Add(this.derivationTree);
            this.metadataPanel.Location = new System.Drawing.Point(716, 21);
            this.metadataPanel.Name = "metadataPanel";
            this.metadataPanel.Size = new System.Drawing.Size(630, 622);
            this.metadataPanel.TabIndex = 2;
            // 
            // derivationTree
            // 
            this.derivationTree.Location = new System.Drawing.Point(21, 18);
            this.derivationTree.Name = "derivationTree";
            this.derivationTree.Size = new System.Drawing.Size(593, 587);
            this.derivationTree.TabIndex = 0;
            // 
            // panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 698);
            this.Controls.Add(this.tabContentEditor);
            this.Controls.Add(topMenu);
            this.Name = "panel";
            this.Text = "Panel";
            topMenu.ResumeLayout(false);
            topMenu.PerformLayout();
            this.tabContentEditor.ResumeLayout(false);
            this.metadataPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ediciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deshacerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rehacerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cortarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pegarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem seleccionarTodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inspeccionarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem árbolDeDerivaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablaDeSímbolosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instruccionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gramaticaToolStripMenuItem;
        private System.Windows.Forms.Panel tabContentEditor;
        private System.Windows.Forms.Panel metadataPanel;
        private System.Windows.Forms.TreeView derivationTree;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox codeEditor;
    }
}