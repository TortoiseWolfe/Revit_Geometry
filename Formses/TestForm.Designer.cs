namespace Revit_VizForms
{
    partial class TestForm
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
            this.CmbBx_Ctgry_Selection = new System.Windows.Forms.ComboBox();
            this.CkkBx_Available = new System.Windows.Forms.CheckBox();
            this.TxtBx_Value_Extracted = new System.Windows.Forms.TextBox();
            this.PicBox_Drawing = new System.Windows.Forms.PictureBox();
            this.Btn_Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Drawing)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbBx_Ctgry_Selection
            // 
            this.CmbBx_Ctgry_Selection.FormattingEnabled = true;
            this.CmbBx_Ctgry_Selection.Location = new System.Drawing.Point(12, 12);
            this.CmbBx_Ctgry_Selection.Name = "CmbBx_Ctgry_Selection";
            this.CmbBx_Ctgry_Selection.Size = new System.Drawing.Size(207, 21);
            this.CmbBx_Ctgry_Selection.TabIndex = 0;
            // 
            // CkkBx_Available
            // 
            this.CkkBx_Available.AutoSize = true;
            this.CkkBx_Available.Location = new System.Drawing.Point(12, 39);
            this.CkkBx_Available.Name = "CkkBx_Available";
            this.CkkBx_Available.Size = new System.Drawing.Size(80, 17);
            this.CkkBx_Available.TabIndex = 1;
            this.CkkBx_Available.Text = "checkBox1";
            this.CkkBx_Available.UseVisualStyleBackColor = true;
            // 
            // TxtBx_Value_Extracted
            // 
            this.TxtBx_Value_Extracted.Location = new System.Drawing.Point(98, 36);
            this.TxtBx_Value_Extracted.Name = "TxtBx_Value_Extracted";
            this.TxtBx_Value_Extracted.Size = new System.Drawing.Size(121, 20);
            this.TxtBx_Value_Extracted.TabIndex = 2;
            // 
            // PicBox_Drawing
            // 
            this.PicBox_Drawing.Location = new System.Drawing.Point(12, 62);
            this.PicBox_Drawing.Name = "PicBox_Drawing";
            this.PicBox_Drawing.Size = new System.Drawing.Size(207, 164);
            this.PicBox_Drawing.TabIndex = 3;
            this.PicBox_Drawing.TabStop = false;
            // 
            // Btn_Save
            // 
            this.Btn_Save.Location = new System.Drawing.Point(161, 218);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(75, 23);
            this.Btn_Save.TabIndex = 4;
            this.Btn_Save.Text = "Save";
            this.Btn_Save.UseVisualStyleBackColor = true;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 239);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.PicBox_Drawing);
            this.Controls.Add(this.TxtBx_Value_Extracted);
            this.Controls.Add(this.CkkBx_Available);
            this.Controls.Add(this.CmbBx_Ctgry_Selection);
            this.Name = "TestForm";
            this.Text = "Selection of Objects";
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Drawing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbBx_Ctgry_Selection;
        private System.Windows.Forms.CheckBox CkkBx_Available;
        private System.Windows.Forms.TextBox TxtBx_Value_Extracted;
        private System.Windows.Forms.PictureBox PicBox_Drawing;
        private System.Windows.Forms.Button Btn_Save;
    }
}