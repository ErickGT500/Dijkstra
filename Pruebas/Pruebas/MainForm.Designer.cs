/*
 * Creado por SharpDevelop.
 * Usuario: erick
 * Fecha: 06/10/2020
 * Hora: 3:55 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace Dijkstra
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttoAn1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.AlgoritmoDijkstra = new System.Windows.Forms.Button();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Aristas = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Camino = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PesoDelRecorrido = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// buttoAn1
			// 
			this.buttoAn1.Location = new System.Drawing.Point(1182, 306);
			this.buttoAn1.Margin = new System.Windows.Forms.Padding(4);
			this.buttoAn1.Name = "buttoAn1";
			this.buttoAn1.Size = new System.Drawing.Size(296, 28);
			this.buttoAn1.TabIndex = 0;
			this.buttoAn1.Text = "Seleccionar imagen";
			this.buttoAn1.UseVisualStyleBackColor = true;
			this.buttoAn1.Click += new System.EventHandler(this.ButtoAn1Click);
			// 
			// button2
			// 
			this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button2.Location = new System.Drawing.Point(1182, 342);
			this.button2.Margin = new System.Windows.Forms.Padding(4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(296, 28);
			this.button2.TabIndex = 1;
			this.button2.Text = "Dibujar Grafo";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.pictureBox1.Location = new System.Drawing.Point(16, 15);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(797, 452);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// AlgoritmoDijkstra
			// 
			this.AlgoritmoDijkstra.Location = new System.Drawing.Point(1182, 434);
			this.AlgoritmoDijkstra.Margin = new System.Windows.Forms.Padding(4);
			this.AlgoritmoDijkstra.Name = "AlgoritmoDijkstra";
			this.AlgoritmoDijkstra.Size = new System.Drawing.Size(296, 28);
			this.AlgoritmoDijkstra.TabIndex = 4;
			this.AlgoritmoDijkstra.Text = "Dijkstra";
			this.AlgoritmoDijkstra.UseVisualStyleBackColor = true;
			this.AlgoritmoDijkstra.Click += new System.EventHandler(this.AlgoritmoDijkstraClick);
			// 
			// treeView1
			// 
			this.treeView1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.treeView1.Location = new System.Drawing.Point(1182, 15);
			this.treeView1.Margin = new System.Windows.Forms.Padding(4);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(296, 283);
			this.treeView1.TabIndex = 5;
			// 
			// dataGridView1
			// 
			this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.HighlightText;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.Aristas,
									this.Camino,
									this.PesoDelRecorrido});
			this.dataGridView1.Location = new System.Drawing.Point(821, 15);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(353, 452);
			this.dataGridView1.TabIndex = 8;
			// 
			// Aristas
			// 
			this.Aristas.HeaderText = "Aristas ";
			this.Aristas.Name = "Aristas";
			this.Aristas.Width = 80;
			// 
			// Camino
			// 
			this.Camino.HeaderText = "Origen --> Destino";
			this.Camino.Name = "Camino";
			this.Camino.Width = 67;
			// 
			// PesoDelRecorrido
			// 
			this.PesoDelRecorrido.HeaderText = "Peso (distancia euclidiana)";
			this.PesoDelRecorrido.Name = "PesoDelRecorrido";
			this.PesoDelRecorrido.Width = 67;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(1182, 404);
			this.textBox2.Margin = new System.Windows.Forms.Padding(4);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(296, 22);
			this.textBox2.TabIndex = 11;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Black;
			this.label2.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Crimson;
			this.label2.Location = new System.Drawing.Point(1182, 374);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(296, 26);
			this.label2.TabIndex = 12;
			this.label2.Text = "Ingresa el vértice (en mayúsculas)\r\n";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Snow;
			this.ClientSize = new System.Drawing.Size(1495, 475);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.AlgoritmoDijkstra);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.buttoAn1);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Actividad 4 - Dijkstra";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.DataGridViewTextBoxColumn PesoDelRecorrido;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Camino;
		private System.Windows.Forms.DataGridViewTextBoxColumn Aristas;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Button AlgoritmoDijkstra;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button buttoAn1;
	}
}
