namespace CoffeeMaker
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pEmptyPot = new System.Windows.Forms.Button();
            this.pFullPot = new System.Windows.Forms.Button();
            this.rPot = new System.Windows.Forms.Button();
            this.offBTN = new System.Windows.Forms.Button();
            this.onBTN = new System.Windows.Forms.Button();
            this.emptyWaterCONT = new System.Windows.Forms.Button();
            this.fillWaterCONT = new System.Windows.Forms.Button();
            this.brew = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.indicatorState = new System.Windows.Forms.Label();
            this.boilerState = new System.Windows.Forms.Label();
            this.warmerState = new System.Windows.Forms.Label();
            this.brewSTS = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusLBL = new System.Windows.Forms.Label();
            this.statusTMR = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkLOGBTN = new System.Windows.Forms.Button();
            this.databaseTMR = new System.Windows.Forms.Timer(this.components);
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pEmptyPot
            // 
            this.pEmptyPot.Location = new System.Drawing.Point(6, 19);
            this.pEmptyPot.Name = "pEmptyPot";
            this.pEmptyPot.Size = new System.Drawing.Size(199, 37);
            this.pEmptyPot.TabIndex = 8;
            this.pEmptyPot.Text = "Place Empty Pot";
            this.pEmptyPot.UseVisualStyleBackColor = true;
            this.pEmptyPot.Click += new System.EventHandler(this.pEmptyPot_Click);
            // 
            // pFullPot
            // 
            this.pFullPot.Location = new System.Drawing.Point(6, 62);
            this.pFullPot.Name = "pFullPot";
            this.pFullPot.Size = new System.Drawing.Size(199, 37);
            this.pFullPot.TabIndex = 6;
            this.pFullPot.Text = "Place Full Pot";
            this.pFullPot.UseVisualStyleBackColor = true;
            this.pFullPot.Click += new System.EventHandler(this.pFullPot_Click);
            // 
            // rPot
            // 
            this.rPot.Location = new System.Drawing.Point(6, 105);
            this.rPot.Name = "rPot";
            this.rPot.Size = new System.Drawing.Size(199, 37);
            this.rPot.TabIndex = 7;
            this.rPot.Text = "Remove Pot";
            this.rPot.UseVisualStyleBackColor = true;
            this.rPot.Click += new System.EventHandler(this.rPot_Click);
            // 
            // offBTN
            // 
            this.offBTN.Location = new System.Drawing.Point(112, 325);
            this.offBTN.Name = "offBTN";
            this.offBTN.Size = new System.Drawing.Size(93, 38);
            this.offBTN.TabIndex = 13;
            this.offBTN.Text = "OFF";
            this.offBTN.UseVisualStyleBackColor = true;
            this.offBTN.Click += new System.EventHandler(this.button1_Click);
            // 
            // onBTN
            // 
            this.onBTN.Location = new System.Drawing.Point(6, 325);
            this.onBTN.Name = "onBTN";
            this.onBTN.Size = new System.Drawing.Size(93, 38);
            this.onBTN.TabIndex = 14;
            this.onBTN.Text = "ON";
            this.onBTN.UseVisualStyleBackColor = true;
            this.onBTN.Click += new System.EventHandler(this.button2_Click);
            // 
            // emptyWaterCONT
            // 
            this.emptyWaterCONT.Location = new System.Drawing.Point(6, 163);
            this.emptyWaterCONT.Name = "emptyWaterCONT";
            this.emptyWaterCONT.Size = new System.Drawing.Size(199, 37);
            this.emptyWaterCONT.TabIndex = 4;
            this.emptyWaterCONT.Text = "Empty Water Container";
            this.emptyWaterCONT.UseVisualStyleBackColor = true;
            this.emptyWaterCONT.Click += new System.EventHandler(this.emptyWaterCONT_Click);
            // 
            // fillWaterCONT
            // 
            this.fillWaterCONT.Location = new System.Drawing.Point(6, 206);
            this.fillWaterCONT.Name = "fillWaterCONT";
            this.fillWaterCONT.Size = new System.Drawing.Size(199, 37);
            this.fillWaterCONT.TabIndex = 3;
            this.fillWaterCONT.Text = "Fill Water Container";
            this.fillWaterCONT.UseVisualStyleBackColor = true;
            this.fillWaterCONT.Click += new System.EventHandler(this.fillWaterCONT_Click);
            // 
            // brew
            // 
            this.brew.Location = new System.Drawing.Point(6, 265);
            this.brew.Name = "brew";
            this.brew.Size = new System.Drawing.Size(199, 38);
            this.brew.TabIndex = 5;
            this.brew.Text = "Brew";
            this.brew.UseVisualStyleBackColor = true;
            this.brew.Click += new System.EventHandler(this.brew_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pEmptyPot);
            this.groupBox3.Controls.Add(this.pFullPot);
            this.groupBox3.Controls.Add(this.rPot);
            this.groupBox3.Controls.Add(this.offBTN);
            this.groupBox3.Controls.Add(this.onBTN);
            this.groupBox3.Controls.Add(this.emptyWaterCONT);
            this.groupBox3.Controls.Add(this.fillWaterCONT);
            this.groupBox3.Controls.Add(this.brew);
            this.groupBox3.Location = new System.Drawing.Point(503, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 369);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buttons";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.indicatorState);
            this.groupBox2.Controls.Add(this.boilerState);
            this.groupBox2.Controls.Add(this.warmerState);
            this.groupBox2.Controls.Add(this.brewSTS);
            this.groupBox2.Location = new System.Drawing.Point(12, 233);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 148);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // indicatorState
            // 
            this.indicatorState.AutoSize = true;
            this.indicatorState.Location = new System.Drawing.Point(6, 34);
            this.indicatorState.Name = "indicatorState";
            this.indicatorState.Size = new System.Drawing.Size(76, 13);
            this.indicatorState.TabIndex = 46;
            this.indicatorState.Text = "Indicator State";
            // 
            // boilerState
            // 
            this.boilerState.AutoSize = true;
            this.boilerState.Location = new System.Drawing.Point(6, 64);
            this.boilerState.Name = "boilerState";
            this.boilerState.Size = new System.Drawing.Size(61, 13);
            this.boilerState.TabIndex = 44;
            this.boilerState.Text = "Boiler State";
            // 
            // warmerState
            // 
            this.warmerState.AutoSize = true;
            this.warmerState.Location = new System.Drawing.Point(4, 93);
            this.warmerState.Name = "warmerState";
            this.warmerState.Size = new System.Drawing.Size(72, 13);
            this.warmerState.TabIndex = 45;
            this.warmerState.Text = "Warmer State";
            // 
            // brewSTS
            // 
            this.brewSTS.AutoSize = true;
            this.brewSTS.Location = new System.Drawing.Point(6, 120);
            this.brewSTS.Name = "brewSTS";
            this.brewSTS.Size = new System.Drawing.Size(67, 13);
            this.brewSTS.TabIndex = 43;
            this.brewSTS.Text = "Brew Status ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.comboBox4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 221);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sensor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Warmer plate";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "Boiler empty",
            "Boiler not empty",
            "Automatic"});
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Items.AddRange(new object[] {
            "Boiler empty",
            "Boiler not empty",
            "Automatic"});
            this.comboBox1.Location = new System.Drawing.Point(82, 95);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 25;
            this.comboBox1.Text = "Automatic";
            // 
            // comboBox4
            // 
            this.comboBox4.AutoCompleteCustomSource.AddRange(new string[] {
            "Pot missing",
            "Pot empty",
            "Pot not empty",
            "Automatic"});
            this.comboBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox4.Items.AddRange(new object[] {
            "Pot missing",
            "Pot empty",
            "Pot not empty",
            "Automatic"});
            this.comboBox4.Location = new System.Drawing.Point(82, 52);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 21);
            this.comboBox4.TabIndex = 35;
            this.comboBox4.Text = "Automatic";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Boiler";
            // 
            // statusLBL
            // 
            this.statusLBL.AutoSize = true;
            this.statusLBL.Location = new System.Drawing.Point(346, 31);
            this.statusLBL.Name = "statusLBL";
            this.statusLBL.Size = new System.Drawing.Size(66, 13);
            this.statusLBL.TabIndex = 42;
            this.statusLBL.Text = "Status : OFF";
            // 
            // statusTMR
            // 
            this.statusTMR.Tick += new System.EventHandler(this.statusTMR_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(260, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(237, 237);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // checkLOGBTN
            // 
            this.checkLOGBTN.Location = new System.Drawing.Point(326, 337);
            this.checkLOGBTN.Name = "checkLOGBTN";
            this.checkLOGBTN.Size = new System.Drawing.Size(108, 38);
            this.checkLOGBTN.TabIndex = 15;
            this.checkLOGBTN.Text = "Check Log";
            this.checkLOGBTN.UseVisualStyleBackColor = true;
            this.checkLOGBTN.Click += new System.EventHandler(this.checkLOGBTN_Click);
            // 
            // databaseTMR
            // 
            this.databaseTMR.Tick += new System.EventHandler(this.databaseTMR_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 393);
            this.Controls.Add(this.checkLOGBTN);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusLBL);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pEmptyPot;
        private System.Windows.Forms.Button pFullPot;
        private System.Windows.Forms.Button rPot;
        private System.Windows.Forms.Button offBTN;
        private System.Windows.Forms.Button onBTN;
        private System.Windows.Forms.Button emptyWaterCONT;
        private System.Windows.Forms.Button fillWaterCONT;
        private System.Windows.Forms.Button brew;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label statusLBL;
        private System.Windows.Forms.Timer statusTMR;
        private System.Windows.Forms.Label brewSTS;
        private System.Windows.Forms.Label boilerState;
        private System.Windows.Forms.Label warmerState;
        private System.Windows.Forms.Label indicatorState;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button checkLOGBTN;
        private System.Windows.Forms.Timer databaseTMR;

    }
}

