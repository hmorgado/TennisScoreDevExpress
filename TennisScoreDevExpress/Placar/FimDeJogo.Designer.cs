namespace TennisScoreDevExpress.Placar
{
  partial class FimDeJogo
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
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
      this.SuspendLayout();
      // 
      // labelControl1
      // 
      this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.MenuHighlight;
      this.labelControl1.Appearance.Options.UseFont = true;
      this.labelControl1.Appearance.Options.UseForeColor = true;
      this.labelControl1.Location = new System.Drawing.Point(52, 31);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(385, 77);
      this.labelControl1.TabIndex = 0;
      this.labelControl1.Text = "FIM DE JOGO";
      // 
      // simpleButton1
      // 
      this.simpleButton1.Location = new System.Drawing.Point(160, 129);
      this.simpleButton1.Name = "simpleButton1";
      this.simpleButton1.Size = new System.Drawing.Size(142, 55);
      this.simpleButton1.TabIndex = 1;
      this.simpleButton1.Text = "Fechar";
      this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
      // 
      // FimDeJogo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(479, 215);
      this.Controls.Add(this.simpleButton1);
      this.Controls.Add(this.labelControl1);
      this.Name = "FimDeJogo";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.SimpleButton simpleButton1;
  }
}