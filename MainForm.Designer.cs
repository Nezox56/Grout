using System.Windows.Forms;

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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelGrout = new System.Windows.Forms.Panel();
            this.btnRemoveRowGrout = new System.Windows.Forms.Button();
            this.btnAddRowGrout = new System.Windows.Forms.Button();
            this.labelGrout = new System.Windows.Forms.Label();
            this.dataGridViewGrout = new System.Windows.Forms.DataGridView();
            this.panelStructure = new System.Windows.Forms.Panel();
            this.btnRemoveRowStructure = new System.Windows.Forms.Button();
            this.btnAddRowStructure = new System.Windows.Forms.Button();
            this.labelStructure = new System.Windows.Forms.Label();
            this.dataGridViewStructure = new System.Windows.Forms.DataGridView();
            this.panelGrout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrout)).BeginInit();
            this.panelStructure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStructure)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRefresh.Location = new System.Drawing.Point(7, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(131, 32);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.Location = new System.Drawing.Point(144, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 32);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // panelGrout
            // 
            this.panelGrout.Controls.Add(this.btnRemoveRowGrout);
            this.panelGrout.Controls.Add(this.btnAddRowGrout);
            this.panelGrout.Controls.Add(this.labelGrout);
            this.panelGrout.Controls.Add(this.dataGridViewGrout);
            this.panelGrout.Location = new System.Drawing.Point(7, 66);
            this.panelGrout.Name = "panelGrout";
            this.panelGrout.Size = new System.Drawing.Size(767, 218);
            this.panelGrout.TabIndex = 4;
            // 
            // btnRemoveRowGrout
            // 
            this.btnRemoveRowGrout.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRemoveRowGrout.Location = new System.Drawing.Point(709, 10);
            this.btnRemoveRowGrout.Name = "btnRemoveRowGrout";
            this.btnRemoveRowGrout.Size = new System.Drawing.Size(50, 39);
            this.btnRemoveRowGrout.TabIndex = 7;
            this.btnRemoveRowGrout.Text = "-";
            this.btnRemoveRowGrout.UseVisualStyleBackColor = true;
            this.btnRemoveRowGrout.Click += new System.EventHandler(this.btnRemoveRowGrout_Click);
            // 
            // btnAddRowGrout
            // 
            this.btnAddRowGrout.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddRowGrout.Location = new System.Drawing.Point(653, 10);
            this.btnAddRowGrout.Name = "btnAddRowGrout";
            this.btnAddRowGrout.Size = new System.Drawing.Size(50, 39);
            this.btnAddRowGrout.TabIndex = 6;
            this.btnAddRowGrout.Text = "+";
            this.btnAddRowGrout.UseVisualStyleBackColor = true;
            this.btnAddRowGrout.Click += new System.EventHandler(this.btnAddRowGrout_Click);
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
            this.dataGridViewGrout.AllowUserToAddRows = false;
            this.dataGridViewGrout.AllowUserToDeleteRows = false;
            this.dataGridViewGrout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGrout.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewGrout.Location = new System.Drawing.Point(3, 55);
            this.dataGridViewGrout.MultiSelect = false;
            this.dataGridViewGrout.Name = "dataGridViewGrout";
            this.dataGridViewGrout.ReadOnly = true;
            this.dataGridViewGrout.RowHeadersWidth = 51;
            this.dataGridViewGrout.RowTemplate.Height = 24;
            this.dataGridViewGrout.Size = new System.Drawing.Size(756, 156);
            this.dataGridViewGrout.TabIndex = 4;
            this.dataGridViewGrout.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGrout_CellClick);
            this.dataGridViewGrout.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGrout_CellContentDoubleClick);
            // 
            // panelStructure
            // 
            this.panelStructure.Controls.Add(this.btnRemoveRowStructure);
            this.panelStructure.Controls.Add(this.btnAddRowStructure);
            this.panelStructure.Controls.Add(this.labelStructure);
            this.panelStructure.Controls.Add(this.dataGridViewStructure);
            this.panelStructure.Location = new System.Drawing.Point(7, 311);
            this.panelStructure.Name = "panelStructure";
            this.panelStructure.Size = new System.Drawing.Size(767, 244);
            this.panelStructure.TabIndex = 5;
            // 
            // btnRemoveRowStructure
            // 
            this.btnRemoveRowStructure.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRemoveRowStructure.Location = new System.Drawing.Point(710, 10);
            this.btnRemoveRowStructure.Name = "btnRemoveRowStructure";
            this.btnRemoveRowStructure.Size = new System.Drawing.Size(50, 39);
            this.btnRemoveRowStructure.TabIndex = 7;
            this.btnRemoveRowStructure.Text = "-";
            this.btnRemoveRowStructure.UseVisualStyleBackColor = true;
            this.btnRemoveRowStructure.Click += new System.EventHandler(this.btnRemoveRowStructure_Click);
            // 
            // btnAddRowStructure
            // 
            this.btnAddRowStructure.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddRowStructure.Location = new System.Drawing.Point(654, 10);
            this.btnAddRowStructure.Name = "btnAddRowStructure";
            this.btnAddRowStructure.Size = new System.Drawing.Size(50, 39);
            this.btnAddRowStructure.TabIndex = 6;
            this.btnAddRowStructure.Text = "+";
            this.btnAddRowStructure.UseVisualStyleBackColor = true;
            this.btnAddRowStructure.Click += new System.EventHandler(this.btnAddRowStructure_Click);
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
            this.dataGridViewStructure.AllowUserToAddRows = false;
            this.dataGridViewStructure.AllowUserToDeleteRows = false;
            this.dataGridViewStructure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStructure.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewStructure.Location = new System.Drawing.Point(4, 55);
            this.dataGridViewStructure.MultiSelect = false;
            this.dataGridViewStructure.Name = "dataGridViewStructure";
            this.dataGridViewStructure.ReadOnly = true;
            this.dataGridViewStructure.RowHeadersWidth = 51;
            this.dataGridViewStructure.RowTemplate.Height = 24;
            this.dataGridViewStructure.Size = new System.Drawing.Size(756, 186);
            this.dataGridViewStructure.TabIndex = 4;
            this.dataGridViewStructure.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStructure_CellClick);
            this.dataGridViewStructure.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStructure_CellContentDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(789, 590);
            this.Controls.Add(this.panelStructure);
            this.Controls.Add(this.panelGrout);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRefresh);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Растворы";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelGrout.ResumeLayout(false);
            this.panelGrout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrout)).EndInit();
            this.panelStructure.ResumeLayout(false);
            this.panelStructure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStructure)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panelGrout;
        private System.Windows.Forms.Button btnRemoveRowGrout;
        private System.Windows.Forms.Button btnAddRowGrout;
        private System.Windows.Forms.Label labelGrout;
        private System.Windows.Forms.DataGridView dataGridViewGrout;
        private System.Windows.Forms.Panel panelStructure;
        private System.Windows.Forms.Button btnRemoveRowStructure;
        private System.Windows.Forms.Button btnAddRowStructure;
        private System.Windows.Forms.Label labelStructure;
        private System.Windows.Forms.DataGridView dataGridViewStructure;
    }
}

