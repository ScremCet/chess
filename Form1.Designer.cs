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
        submit = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        SX = new System.Windows.Forms.ComboBox();
        EX = new System.Windows.Forms.ComboBox();
        SY = new System.Windows.Forms.ComboBox();
        EY = new System.Windows.Forms.ComboBox();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // submit
        // 
        submit.Location = new System.Drawing.Point(1050, 198);
        submit.Name = "submit";
        submit.Size = new System.Drawing.Size(138, 32);
        submit.TabIndex = 0;
        submit.Text = "Submit";
        submit.UseVisualStyleBackColor = true;
        submit.Click += submit_Click_1;
        // 
        // label1
        // 
        label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        label1.ForeColor = System.Drawing.SystemColors.ControlText;
        label1.Location = new System.Drawing.Point(1050, 101);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(138, 26);
        label1.TabIndex = 1;
        label1.Text = "White to Start";
        // 
        // SX
        // 
        SX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        SX.FormattingEnabled = true;
        SX.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F", "G", "H" });
        SX.Location = new System.Drawing.Point(1098, 130);
        SX.Name = "SX";
        SX.Size = new System.Drawing.Size(42, 23);
        SX.TabIndex = 10;
        // 
        // EX
        // 
        EX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        EX.FormattingEnabled = true;
        EX.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F", "G", "H" });
        EX.Location = new System.Drawing.Point(1098, 169);
        EX.Name = "EX";
        EX.Size = new System.Drawing.Size(42, 23);
        EX.TabIndex = 11;
        // 
        // SY
        // 
        SY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        SY.FormattingEnabled = true;
        SY.Items.AddRange(new object[] { "8", "7", "6", "5", "4", "3", "2", "1"});
        SY.Location = new System.Drawing.Point(1146, 130);
        SY.Name = "SY";
        SY.Size = new System.Drawing.Size(42, 23);
        SY.TabIndex = 12;
        // 
        // EY
        // 
        EY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        EY.FormattingEnabled = true;
        EY.Items.AddRange(new object[] { "8", "7", "6", "5", "4", "3", "2", "1"});
        EY.Location = new System.Drawing.Point(1146, 169);
        EY.Name = "EY";
        EY.Size = new System.Drawing.Size(42, 23);
        EY.TabIndex = 13;
        // 
        // label2
        // 
        label2.BackColor = System.Drawing.Color.White;
        label2.Location = new System.Drawing.Point(1050, 130);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(42, 23);
        label2.TabIndex = 14;
        label2.Text = "From";
        // 
        // label3
        // 
        label3.BackColor = System.Drawing.Color.White;
        label3.Location = new System.Drawing.Point(1050, 169);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(42, 23);
        label3.TabIndex = 15;
        label3.Text = "To";
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.DimGray;
        ClientSize = new System.Drawing.Size(1280, 720);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(EY);
        Controls.Add(SY);
        Controls.Add(EX);
        Controls.Add(SX);
        Controls.Add(submit);
        Controls.Add(label1);
        Tag = "";
        Text = "Form1";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.ComboBox SY;
    private System.Windows.Forms.ComboBox EY;

    private System.Windows.Forms.ComboBox EX;

    private System.Windows.Forms.ComboBox SX;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button submit;

    #endregion
}