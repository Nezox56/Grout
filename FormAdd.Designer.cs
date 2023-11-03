namespace Grout
{
    partial class FormAdd
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
            this.btnSaveGrout = new System.Windows.Forms.Button();
            this.labelNameGrout = new System.Windows.Forms.Label();
            this.labelValueGrout = new System.Windows.Forms.Label();
            this.nameGrout = new System.Windows.Forms.TextBox();
            this.valueGrout = new System.Windows.Forms.TextBox();
            this.valueStructure = new System.Windows.Forms.TextBox();
            this.nameStructure = new System.Windows.Forms.TextBox();
            this.labelValueStructure = new System.Windows.Forms.Label();
            this.labelNameStructure = new System.Windows.Forms.Label();
            this.btnSaveStructure = new System.Windows.Forms.Button();
            this.AddStructure = new System.Windows.Forms.TabPage();
            this.AddGrout = new System.Windows.Forms.TabPage();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.AddStructure.SuspendLayout();
            this.AddGrout.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveGrout
            // 
            this.btnSaveGrout.Location = new System.Drawing.Point(134, 90);
            this.btnSaveGrout.Name = "btnSaveGrout";
            this.btnSaveGrout.Size = new System.Drawing.Size(108, 40);
            this.btnSaveGrout.TabIndex = 0;
            this.btnSaveGrout.Text = "Добавить";
            this.btnSaveGrout.UseVisualStyleBackColor = true;
            this.btnSaveGrout.Click += new System.EventHandler(this.btnSaveGrout_Click);
            // 
            // labelNameGrout
            // 
            this.labelNameGrout.AutoSize = true;
            this.labelNameGrout.Location = new System.Drawing.Point(6, 16);
            this.labelNameGrout.Name = "labelNameGrout";
            this.labelNameGrout.Size = new System.Drawing.Size(138, 16);
            this.labelNameGrout.TabIndex = 1;
            this.labelNameGrout.Text = "Название раствора";
            // 
            // labelValueGrout
            // 
            this.labelValueGrout.AutoSize = true;
            this.labelValueGrout.Location = new System.Drawing.Point(6, 44);
            this.labelValueGrout.Name = "labelValueGrout";
            this.labelValueGrout.Size = new System.Drawing.Size(73, 16);
            this.labelValueGrout.TabIndex = 2;
            this.labelValueGrout.Text = "Объем, м3";
            // 
            // nameGrout
            // 
            this.nameGrout.Location = new System.Drawing.Point(161, 13);
            this.nameGrout.Name = "nameGrout";
            this.nameGrout.Size = new System.Drawing.Size(192, 22);
            this.nameGrout.TabIndex = 3;
            // 
            // valueGrout
            // 
            this.valueGrout.Location = new System.Drawing.Point(95, 44);
            this.valueGrout.Name = "valueGrout";
            this.valueGrout.Size = new System.Drawing.Size(100, 22);
            this.valueGrout.TabIndex = 4;
            // 
            // valueStructure
            // 
            this.valueStructure.Location = new System.Drawing.Point(97, 40);
            this.valueStructure.Name = "valueStructure";
            this.valueStructure.Size = new System.Drawing.Size(100, 22);
            this.valueStructure.TabIndex = 9;
            // 
            // nameStructure
            // 
            this.nameStructure.Location = new System.Drawing.Point(163, 9);
            this.nameStructure.Name = "nameStructure";
            this.nameStructure.Size = new System.Drawing.Size(192, 22);
            this.nameStructure.TabIndex = 8;
            // 
            // labelValueStructure
            // 
            this.labelValueStructure.AutoSize = true;
            this.labelValueStructure.Location = new System.Drawing.Point(8, 40);
            this.labelValueStructure.Name = "labelValueStructure";
            this.labelValueStructure.Size = new System.Drawing.Size(73, 16);
            this.labelValueStructure.TabIndex = 7;
            this.labelValueStructure.Text = "Объем, м3";
            // 
            // labelNameStructure
            // 
            this.labelNameStructure.AutoSize = true;
            this.labelNameStructure.Location = new System.Drawing.Point(8, 12);
            this.labelNameStructure.Name = "labelNameStructure";
            this.labelNameStructure.Size = new System.Drawing.Size(129, 16);
            this.labelNameStructure.TabIndex = 6;
            this.labelNameStructure.Text = "Название состава";
            // 
            // btnSaveStructure
            // 
            this.btnSaveStructure.Location = new System.Drawing.Point(136, 86);
            this.btnSaveStructure.Name = "btnSaveStructure";
            this.btnSaveStructure.Size = new System.Drawing.Size(108, 40);
            this.btnSaveStructure.TabIndex = 5;
            this.btnSaveStructure.Text = "Добавить";
            this.btnSaveStructure.UseVisualStyleBackColor = true;
            this.btnSaveStructure.Click += new System.EventHandler(this.btnSaveStructure_Click);
            // 
            // AddStructure
            // 
            this.AddStructure.Controls.Add(this.valueStructure);
            this.AddStructure.Controls.Add(this.nameStructure);
            this.AddStructure.Controls.Add(this.labelValueStructure);
            this.AddStructure.Controls.Add(this.labelNameStructure);
            this.AddStructure.Controls.Add(this.btnSaveStructure);
            this.AddStructure.Location = new System.Drawing.Point(4, 5);
            this.AddStructure.Name = "AddStructure";
            this.AddStructure.Padding = new System.Windows.Forms.Padding(3);
            this.AddStructure.Size = new System.Drawing.Size(370, 172);
            this.AddStructure.TabIndex = 1;
            this.AddStructure.Text = "AddStructure";
            this.AddStructure.UseVisualStyleBackColor = true;
            // 
            // AddGrout
            // 
            this.AddGrout.Controls.Add(this.valueGrout);
            this.AddGrout.Controls.Add(this.nameGrout);
            this.AddGrout.Controls.Add(this.labelValueGrout);
            this.AddGrout.Controls.Add(this.labelNameGrout);
            this.AddGrout.Controls.Add(this.btnSaveGrout);
            this.AddGrout.Location = new System.Drawing.Point(4, 5);
            this.AddGrout.Name = "AddGrout";
            this.AddGrout.Padding = new System.Windows.Forms.Padding(3);
            this.AddGrout.Size = new System.Drawing.Size(370, 172);
            this.AddGrout.TabIndex = 0;
            this.AddGrout.Text = "AddGrout";
            this.AddGrout.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.AddGrout);
            this.tabControl.Controls.Add(this.AddStructure);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(378, 181);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            this.tabControl.TabStop = false;
            // 
            // FormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 181);
            this.Controls.Add(this.tabControl);
            this.Name = "FormAdd";
            this.Text = "Добавление данных";
            this.Load += new System.EventHandler(this.FormAdd_Load);
            this.AddStructure.ResumeLayout(false);
            this.AddStructure.PerformLayout();
            this.AddGrout.ResumeLayout(false);
            this.AddGrout.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelNameGrout;
        private System.Windows.Forms.Button btnSaveGrout;
        private System.Windows.Forms.TextBox valueGrout;
        private System.Windows.Forms.TextBox nameGrout;
        private System.Windows.Forms.Label labelValueGrout;
        private System.Windows.Forms.TextBox valueStructure;
        private System.Windows.Forms.TextBox nameStructure;
        private System.Windows.Forms.Label labelValueStructure;
        private System.Windows.Forms.Label labelNameStructure;
        private System.Windows.Forms.Button btnSaveStructure;
        private System.Windows.Forms.TabPage AddStructure;
        private System.Windows.Forms.TabPage AddGrout;
        private System.Windows.Forms.TabControl tabControl;
    }
}