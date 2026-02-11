namespace chess;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        button1 = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        textBox1 = new System.Windows.Forms.TextBox();
        textBox2 = new System.Windows.Forms.TextBox();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(1103, 628);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(132, 32);
        button1.TabIndex = 0;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click_1;
        // 
        // label1
        // 
        label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        label1.ForeColor = System.Drawing.SystemColors.ControlText;
        label1.Location = new System.Drawing.Point(1103, 541);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(132, 26);
        label1.TabIndex = 1;
        label1.Text = "White to Start";
        // 
        // textBox1
        // 
        textBox1.AcceptsReturn = true;
        textBox1.Location = new System.Drawing.Point(1085, 599);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(150, 23);
        textBox1.TabIndex = 2;
        // 
        // textBox2
        // 
        textBox2.BackColor = System.Drawing.SystemColors.Window;
        textBox2.Location = new System.Drawing.Point(1085, 570);
        textBox2.Name = "textBox2";
        textBox2.Size = new System.Drawing.Size(150, 23);
        textBox2.TabIndex = 3;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.DimGray;
        ClientSize = new System.Drawing.Size(1280, 720);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(button1);
        Controls.Add(label1);
        Tag = "";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox textBox2;

    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button button1;

    #endregion
}