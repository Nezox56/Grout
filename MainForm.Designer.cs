namespace Grout
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.UpdateDB = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.panelGrout = new System.Windows.Forms.Panel();
            this.RemoveGrout = new System.Windows.Forms.Button();
            this.AddGrout = new System.Windows.Forms.Button();
            this.labelGrout = new System.Windows.Forms.Label();
            this.dataGridViewGrout = new System.Windows.Forms.DataGridView();
            this.panelStructure = new System.Windows.Forms.Panel();
            this.RemoveStructure = new System.Windows.Forms.Button();
            this.AddStructure = new System.Windows.Forms.Button();
            this.labelStructure = new System.Windows.Forms.Label();
            this.dataGridViewStructure = new System.Windows.Forms.DataGridView();
            this.panelGrout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrout)).BeginInit();
            this.panelStructure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStructure)).BeginInit();
            this.SuspendLayout();
            // 
            // UpdateDB
            // 
            this.UpdateDB.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.UpdateDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateDB.Location = new System.Drawing.Point(7, 5);
            this.UpdateDB.Name = "UpdateDB";
            this.UpdateDB.Size = new System.Drawing.Size(131, 32);
            this.UpdateDB.TabIndex = 0;
            this.UpdateDB.Text = "Обновить";
            this.UpdateDB.UseVisualStyleBackColor = true;
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Save.Location = new System.Drawing.Point(144, 5);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(131, 32);
            this.Save.TabIndex = 1;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = true;
            // 
            // panelGrout
            // 
            this.panelGrout.Controls.Add(this.RemoveGrout);
            this.panelGrout.Controls.Add(this.AddGrout);
            this.panelGrout.Controls.Add(this.labelGrout);
            this.panelGrout.Controls.Add(this.dataGridViewGrout);
            this.panelGrout.Location = new System.Drawing.Point(7, 66);
            this.panelGrout.Name = "panelGrout";
            this.panelGrout.Size = new System.Drawing.Size(767, 218);
            this.panelGrout.TabIndex = 4;
            // 
            // RemoveGrout
            // 
            this.RemoveGrout.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveGrout.Location = new System.Drawing.Point(709, 10);
            this.RemoveGrout.Name = "RemoveGrout";
            this.RemoveGrout.Size = new System.Drawing.Size(50, 39);
            this.RemoveGrout.TabIndex = 7;
            this.RemoveGrout.Text = "-";
            this.RemoveGrout.UseVisualStyleBackColor = true;
            // 
            // AddGrout
            // 
            this.AddGrout.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddGrout.Location = new System.Drawing.Point(653, 10);
            this.AddGrout.Name = "AddGrout";
            this.AddGrout.Size = new System.Drawing.Size(50, 39);
            this.AddGrout.TabIndex = 6;
            this.AddGrout.Text = "+";
            this.AddGrout.UseVisualStyleBackColor = true;
            // 
            // labelGrout
            // 
            this.labelGrout.AutoSize = true;
            this.labelGrout.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGrout.Location = new System.Drawing.Point(27, 15);
            this.labelGrout.Name = "labelGrout";
            this.labelGrout.Size = new System.Drawing.Size(131, 29);
            this.labelGrout.TabIndex = 5;
            this.labelGrout.Text = "Растворы";
            // 
            // dataGridViewGrout
            // 
            this.dataGridViewGrout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGrout.Location = new System.Drawing.Point(3, 55);
            this.dataGridViewGrout.Name = "dataGridViewGrout";
            this.dataGridViewGrout.RowHeadersWidth = 51;
            this.dataGridViewGrout.RowTemplate.Height = 24;
            this.dataGridViewGrout.Size = new System.Drawing.Size(756, 156);
            this.dataGridViewGrout.TabIndex = 4;
            // 
            // panelStructure
            // 
            this.panelStructure.Controls.Add(this.RemoveStructure);
            this.panelStructure.Controls.Add(this.AddStructure);
            this.panelStructure.Controls.Add(this.labelStructure);
            this.panelStructure.Controls.Add(this.dataGridViewStructure);
            this.panelStructure.Location = new System.Drawing.Point(7, 311);
            this.panelStructure.Name = "panelStructure";
            this.panelStructure.Size = new System.Drawing.Size(767, 204);
            this.panelStructure.TabIndex = 5;
            // 
            // RemoveStructure
            // 
            this.RemoveStructure.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveStructure.Location = new System.Drawing.Point(710, 10);
            this.RemoveStructure.Name = "RemoveStructure";
            this.RemoveStructure.Size = new System.Drawing.Size(50, 39);
            this.RemoveStructure.TabIndex = 7;
            this.RemoveStructure.Text = "-";
            this.RemoveStructure.UseVisualStyleBackColor = true;
            // 
            // AddStructure
            // 
            this.AddStructure.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddStructure.Location = new System.Drawing.Point(654, 10);
            this.AddStructure.Name = "AddStructure";
            this.AddStructure.Size = new System.Drawing.Size(50, 39);
            this.AddStructure.TabIndex = 6;
            this.AddStructure.Text = "+";
            this.AddStructure.UseVisualStyleBackColor = true;
            // 
            // labelStructure
            // 
            this.labelStructure.AutoSize = true;
            this.labelStructure.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStructure.Location = new System.Drawing.Point(27, 10);
            this.labelStructure.Name = "labelStructure";
            this.labelStructure.Size = new System.Drawing.Size(100, 29);
            this.labelStructure.TabIndex = 5;
            this.labelStructure.Text = "Состав";
            // 
            // dataGridViewStructure
            // 
            this.dataGridViewStructure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStructure.Location = new System.Drawing.Point(4, 55);
            this.dataGridViewStructure.Name = "dataGridViewStructure";
            this.dataGridViewStructure.RowHeadersWidth = 51;
            this.dataGridViewStructure.RowTemplate.Height = 24;
            this.dataGridViewStructure.Size = new System.Drawing.Size(756, 156);
            this.dataGridViewStructure.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 535);
            this.Controls.Add(this.panelStructure);
            this.Controls.Add(this.panelGrout);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.UpdateDB);
            this.Name = "MainForm";
            this.Text = "Растворы";
            this.panelGrout.ResumeLayout(false);
            this.panelGrout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrout)).EndInit();
            this.panelStructure.ResumeLayout(false);
            this.panelStructure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStructure)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UpdateDB;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Panel panelGrout;
        private System.Windows.Forms.Button RemoveGrout;
        private System.Windows.Forms.Button AddGrout;
        private System.Windows.Forms.Label labelGrout;
        private System.Windows.Forms.DataGridView dataGridViewGrout;
        private System.Windows.Forms.Panel panelStructure;
        private System.Windows.Forms.Button RemoveStructure;
        private System.Windows.Forms.Button AddStructure;
        private System.Windows.Forms.Label labelStructure;
        private System.Windows.Forms.DataGridView dataGridViewStructure;
    }
}

