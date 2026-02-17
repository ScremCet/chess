namespace chess;

partial class ChessForm
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
        StatOut = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        label6 = new System.Windows.Forms.Label();
        label7 = new System.Windows.Forms.Label();
        label8 = new System.Windows.Forms.Label();
        label9 = new System.Windows.Forms.Label();
        label10 = new System.Windows.Forms.Label();
        label11 = new System.Windows.Forms.Label();
        label13 = new System.Windows.Forms.Label();
        label12 = new System.Windows.Forms.Label();
        label14 = new System.Windows.Forms.Label();
        label15 = new System.Windows.Forms.Label();
        label16 = new System.Windows.Forms.Label();
        label17 = new System.Windows.Forms.Label();
        label18 = new System.Windows.Forms.Label();
        label19 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // submit
        // 
        submit.Location = new System.Drawing.Point(1040, 302);
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
        label1.Location = new System.Drawing.Point(1040, 205);
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
        SX.Location = new System.Drawing.Point(1088, 234);
        SX.Name = "SX";
        SX.Size = new System.Drawing.Size(42, 23);
        SX.TabIndex = 10;
        // 
        // EX
        // 
        EX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        EX.FormattingEnabled = true;
        EX.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F", "G", "H" });
        EX.Location = new System.Drawing.Point(1088, 273);
        EX.Name = "EX";
        EX.Size = new System.Drawing.Size(42, 23);
        EX.TabIndex = 11;
        // 
        // SY
        // 
        SY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        SY.FormattingEnabled = true;
        SY.Items.AddRange(new object[] { "8", "7", "6", "5", "4", "3", "2", "1" });
        SY.Location = new System.Drawing.Point(1136, 234);
        SY.Name = "SY";
        SY.Size = new System.Drawing.Size(42, 23);
        SY.TabIndex = 12;
        // 
        // EY
        // 
        EY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        EY.FormattingEnabled = true;
        EY.Items.AddRange(new object[] { "8", "7", "6", "5", "4", "3", "2", "1" });
        EY.Location = new System.Drawing.Point(1136, 273);
        EY.Name = "EY";
        EY.Size = new System.Drawing.Size(42, 23);
        EY.TabIndex = 13;
        // 
        // label2
        // 
        label2.BackColor = System.Drawing.Color.White;
        label2.Location = new System.Drawing.Point(1040, 234);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(42, 23);
        label2.TabIndex = 14;
        label2.Text = "From";
        // 
        // label3
        // 
        label3.BackColor = System.Drawing.Color.White;
        label3.Location = new System.Drawing.Point(1040, 273);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(42, 23);
        label3.TabIndex = 15;
        label3.Text = "To";
        // 
        // StatOut
        // 
        StatOut.BackColor = System.Drawing.Color.White;
        StatOut.Location = new System.Drawing.Point(1044, 349);
        StatOut.Name = "StatOut";
        StatOut.Size = new System.Drawing.Size(133, 78);
        StatOut.TabIndex = 16;
        StatOut.Text = "Message";
        // 
        // label4
        // 
        label4.BackColor = System.Drawing.Color.Transparent;
        label4.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label4.Location = new System.Drawing.Point(340, 640);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(75, 75);
        label4.TabIndex = 17;
        label4.Text = "A";
        label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // label5
        // 
        label5.BackColor = System.Drawing.Color.Transparent;
        label5.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label5.Location = new System.Drawing.Point(415, 640);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(75, 75);
        label5.TabIndex = 18;
        label5.Text = "B";
        label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // label6
        // 
        label6.BackColor = System.Drawing.Color.Transparent;
        label6.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label6.Location = new System.Drawing.Point(490, 640);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(75, 75);
        label6.TabIndex = 19;
        label6.Text = "C";
        label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // label7
        // 
        label7.BackColor = System.Drawing.Color.Transparent;
        label7.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label7.Location = new System.Drawing.Point(565, 640);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(75, 75);
        label7.TabIndex = 20;
        label7.Text = "D";
        label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // label8
        // 
        label8.BackColor = System.Drawing.Color.Transparent;
        label8.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label8.Location = new System.Drawing.Point(640, 640);
        label8.Name = "label8";
        label8.Size = new System.Drawing.Size(75, 75);
        label8.TabIndex = 21;
        label8.Text = "E";
        label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // label9
        // 
        label9.BackColor = System.Drawing.Color.Transparent;
        label9.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label9.Location = new System.Drawing.Point(715, 640);
        label9.Name = "label9";
        label9.Size = new System.Drawing.Size(75, 75);
        label9.TabIndex = 22;
        label9.Text = "F";
        label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // label10
        // 
        label10.BackColor = System.Drawing.Color.Transparent;
        label10.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label10.Location = new System.Drawing.Point(790, 640);
        label10.Name = "label10";
        label10.Size = new System.Drawing.Size(75, 75);
        label10.TabIndex = 23;
        label10.Text = "G";
        label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // label11
        // 
        label11.BackColor = System.Drawing.Color.Transparent;
        label11.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label11.Location = new System.Drawing.Point(865, 640);
        label11.Name = "label11";
        label11.Size = new System.Drawing.Size(75, 75);
        label11.TabIndex = 24;
        label11.Text = "H";
        label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // label13
        // 
        label13.BackColor = System.Drawing.Color.Transparent;
        label13.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label13.Location = new System.Drawing.Point(260, 565);
        label13.Name = "label13";
        label13.Size = new System.Drawing.Size(75, 75);
        label13.TabIndex = 26;
        label13.Text = "1";
        label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label12
        // 
        label12.BackColor = System.Drawing.Color.Transparent;
        label12.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label12.Location = new System.Drawing.Point(260, 490);
        label12.Name = "label12";
        label12.Size = new System.Drawing.Size(75, 75);
        label12.TabIndex = 27;
        label12.Text = "2";
        label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label14
        // 
        label14.BackColor = System.Drawing.Color.Transparent;
        label14.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label14.Location = new System.Drawing.Point(260, 415);
        label14.Name = "label14";
        label14.Size = new System.Drawing.Size(75, 75);
        label14.TabIndex = 28;
        label14.Text = "3";
        label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label15
        // 
        label15.BackColor = System.Drawing.Color.Transparent;
        label15.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label15.Location = new System.Drawing.Point(260, 340);
        label15.Name = "label15";
        label15.Size = new System.Drawing.Size(75, 75);
        label15.TabIndex = 29;
        label15.Text = "4";
        label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label16
        // 
        label16.BackColor = System.Drawing.Color.Transparent;
        label16.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label16.Location = new System.Drawing.Point(260, 265);
        label16.Name = "label16";
        label16.Size = new System.Drawing.Size(75, 75);
        label16.TabIndex = 30;
        label16.Text = "5";
        label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label17
        // 
        label17.BackColor = System.Drawing.Color.Transparent;
        label17.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label17.Location = new System.Drawing.Point(260, 190);
        label17.Name = "label17";
        label17.Size = new System.Drawing.Size(75, 75);
        label17.TabIndex = 31;
        label17.Text = "6";
        label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label18
        // 
        label18.BackColor = System.Drawing.Color.Transparent;
        label18.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label18.Location = new System.Drawing.Point(260, 115);
        label18.Name = "label18";
        label18.Size = new System.Drawing.Size(75, 75);
        label18.TabIndex = 32;
        label18.Text = "7";
        label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label19
        // 
        label19.BackColor = System.Drawing.Color.Transparent;
        label19.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label19.Location = new System.Drawing.Point(260, 40);
        label19.Name = "label19";
        label19.Size = new System.Drawing.Size(75, 75);
        label19.TabIndex = 33;
        label19.Text = "8";
        label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // ChessForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.DimGray;
        ClientSize = new System.Drawing.Size(1280, 720);
        Controls.Add(label19);
        Controls.Add(label18);
        Controls.Add(label17);
        Controls.Add(label16);
        Controls.Add(label15);
        Controls.Add(label14);
        Controls.Add(label12);
        Controls.Add(label13);
        Controls.Add(label11);
        Controls.Add(label10);
        Controls.Add(label9);
        Controls.Add(label8);
        Controls.Add(label7);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(StatOut);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(EY);
        Controls.Add(SY);
        Controls.Add(EX);
        Controls.Add(SX);
        Controls.Add(submit);
        Controls.Add(label1);
        Tag = "";
        Text = "Chess by 102206830";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.Label label19;

    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.Label label16;

    private System.Windows.Forms.Label label12;

    private System.Windows.Forms.Label label13;

    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label11;

    private System.Windows.Forms.Label label6;

    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.Label StatOut;

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