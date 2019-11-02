namespace FaceDetection
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cameraBox = new Emgu.CV.UI.ImageBox();
            this.btnIniciaDetection = new System.Windows.Forms.Button();
            this.btnSalvarRosto = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cameraBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cameraBox
            // 
            this.cameraBox.Location = new System.Drawing.Point(28, 26);
            this.cameraBox.Name = "cameraBox";
            this.cameraBox.Size = new System.Drawing.Size(367, 339);
            this.cameraBox.TabIndex = 2;
            this.cameraBox.TabStop = false;
            // 
            // btnIniciaDetection
            // 
            this.btnIniciaDetection.Location = new System.Drawing.Point(544, 35);
            this.btnIniciaDetection.Name = "btnIniciaDetection";
            this.btnIniciaDetection.Size = new System.Drawing.Size(109, 32);
            this.btnIniciaDetection.TabIndex = 3;
            this.btnIniciaDetection.Text = "Iniciar Detecção";
            this.btnIniciaDetection.UseVisualStyleBackColor = true;
            this.btnIniciaDetection.Click += new System.EventHandler(this.btnIniciaDetection_Click);
            // 
            // btnSalvarRosto
            // 
            this.btnSalvarRosto.Location = new System.Drawing.Point(598, 240);
            this.btnSalvarRosto.Name = "btnSalvarRosto";
            this.btnSalvarRosto.Size = new System.Drawing.Size(109, 32);
            this.btnSalvarRosto.TabIndex = 4;
            this.btnSalvarRosto.Text = "Salvar rosto";
            this.btnSalvarRosto.UseVisualStyleBackColor = true;
            this.btnSalvarRosto.Click += new System.EventHandler(this.btnSalvarRosto_Click);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(544, 202);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(163, 20);
            this.txtNome.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nome";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.btnSalvarRosto);
            this.Controls.Add(this.btnIniciaDetection);
            this.Controls.Add(this.cameraBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.cameraBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox cameraBox;
        private System.Windows.Forms.Button btnIniciaDetection;
        private System.Windows.Forms.Button btnSalvarRosto;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label1;
    }
}

