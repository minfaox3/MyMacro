namespace MyMacro
{
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            comboBoxWindowNames = new ComboBox();
            buttonWCUpdate = new Button();
            buttonSelectWindow = new Button();
            pictureBoxWindowThumb = new PictureBox();
            label2 = new Label();
            dataGridViewActions = new DataGridView();
            buttonPlay = new Button();
            comboBoxTerminateKey = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            comboBoxKeyStroke = new ComboBox();
            textBoxMouseX = new TextBox();
            label5 = new Label();
            comboBoxMacroKey = new ComboBox();
            buttonAddKeyMacro = new Button();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            textBoxMouseY = new TextBox();
            buttonAddMouseMacro = new Button();
            label9 = new Label();
            textBoxDelayMSec = new TextBox();
            label10 = new Label();
            buttonAddDelayMSec = new Button();
            buttonDelete = new Button();
            buttonUp = new Button();
            buttonDown = new Button();
            textBoxDelaySec = new TextBox();
            label11 = new Label();
            buttonAddDelaySec = new Button();
            textBoxMacroText = new TextBox();
            label12 = new Label();
            buttonAddTextMacro = new Button();
            checkBoxLoop = new CheckBox();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            comboBoxClickButton = new ComboBox();
            label13 = new Label();
            buttonAddClickMacro = new Button();
            comboBoxClickMotion = new ComboBox();
            textBoxScrollAmount = new TextBox();
            comboBoxScrollDirection = new ComboBox();
            label14 = new Label();
            buttonAddScroll = new Button();
            label15 = new Label();
            textBoxLoopSpan = new TextBox();
            label16 = new Label();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            importToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWindowThumb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewActions).BeginInit();
            statusStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 33);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 0;
            label1.Text = "TargetWindow";
            // 
            // comboBoxWindowNames
            // 
            comboBoxWindowNames.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxWindowNames.FormattingEnabled = true;
            comboBoxWindowNames.Location = new Point(103, 30);
            comboBoxWindowNames.Name = "comboBoxWindowNames";
            comboBoxWindowNames.Size = new Size(265, 23);
            comboBoxWindowNames.TabIndex = 0;
            // 
            // buttonWCUpdate
            // 
            buttonWCUpdate.Location = new Point(374, 30);
            buttonWCUpdate.Name = "buttonWCUpdate";
            buttonWCUpdate.Size = new Size(75, 23);
            buttonWCUpdate.TabIndex = 1;
            buttonWCUpdate.Text = "Update";
            buttonWCUpdate.UseVisualStyleBackColor = true;
            buttonWCUpdate.Click += buttonWCUpdate_Click;
            // 
            // buttonSelectWindow
            // 
            buttonSelectWindow.Location = new Point(14, 59);
            buttonSelectWindow.Name = "buttonSelectWindow";
            buttonSelectWindow.Size = new Size(435, 23);
            buttonSelectWindow.TabIndex = 2;
            buttonSelectWindow.Text = "Select";
            buttonSelectWindow.UseVisualStyleBackColor = true;
            buttonSelectWindow.Click += buttonSelectWindow_Click;
            // 
            // pictureBoxWindowThumb
            // 
            pictureBoxWindowThumb.BackgroundImageLayout = ImageLayout.None;
            pictureBoxWindowThumb.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxWindowThumb.Location = new Point(456, 48);
            pictureBoxWindowThumb.Name = "pictureBoxWindowThumb";
            pictureBoxWindowThumb.Size = new Size(335, 226);
            pictureBoxWindowThumb.TabIndex = 4;
            pictureBoxWindowThumb.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(455, 30);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 5;
            label2.Text = "Selected window :";
            // 
            // dataGridViewActions
            // 
            dataGridViewActions.AllowUserToAddRows = false;
            dataGridViewActions.AllowUserToDeleteRows = false;
            dataGridViewActions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewActions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewActions.ImeMode = ImeMode.Disable;
            dataGridViewActions.Location = new Point(14, 338);
            dataGridViewActions.MultiSelect = false;
            dataGridViewActions.Name = "dataGridViewActions";
            dataGridViewActions.ReadOnly = true;
            dataGridViewActions.RowHeadersWidth = 62;
            dataGridViewActions.Size = new Size(434, 189);
            dataGridViewActions.TabIndex = 21;
            // 
            // buttonPlay
            // 
            buttonPlay.Location = new Point(455, 338);
            buttonPlay.Name = "buttonPlay";
            buttonPlay.Size = new Size(336, 189);
            buttonPlay.TabIndex = 28;
            buttonPlay.Text = "Play";
            buttonPlay.UseVisualStyleBackColor = true;
            buttonPlay.Click += buttonPlay_Click;
            // 
            // comboBoxTerminateKey
            // 
            comboBoxTerminateKey.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTerminateKey.FormattingEnabled = true;
            comboBoxTerminateKey.Location = new Point(538, 310);
            comboBoxTerminateKey.Name = "comboBoxTerminateKey";
            comboBoxTerminateKey.Size = new Size(253, 23);
            comboBoxTerminateKey.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(455, 313);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 9;
            label3.Text = "TerminateKey";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 87);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 10;
            label4.Text = "MacroSettings";
            // 
            // comboBoxKeyStroke
            // 
            comboBoxKeyStroke.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxKeyStroke.FormattingEnabled = true;
            comboBoxKeyStroke.Location = new Point(71, 105);
            comboBoxKeyStroke.Name = "comboBoxKeyStroke";
            comboBoxKeyStroke.Size = new Size(141, 23);
            comboBoxKeyStroke.TabIndex = 3;
            // 
            // textBoxMouseX
            // 
            textBoxMouseX.ImeMode = ImeMode.Disable;
            textBoxMouseX.Location = new Point(91, 134);
            textBoxMouseX.Name = "textBoxMouseX";
            textBoxMouseX.Size = new Size(121, 23);
            textBoxMouseX.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 108);
            label5.Name = "label5";
            label5.Size = new Size(26, 15);
            label5.TabIndex = 13;
            label5.Text = "Key";
            // 
            // comboBoxMacroKey
            // 
            comboBoxMacroKey.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMacroKey.FormattingEnabled = true;
            comboBoxMacroKey.Location = new Point(227, 105);
            comboBoxMacroKey.Name = "comboBoxMacroKey";
            comboBoxMacroKey.Size = new Size(141, 23);
            comboBoxMacroKey.TabIndex = 4;
            // 
            // buttonAddKeyMacro
            // 
            buttonAddKeyMacro.Location = new Point(374, 105);
            buttonAddKeyMacro.Name = "buttonAddKeyMacro";
            buttonAddKeyMacro.Size = new Size(75, 23);
            buttonAddKeyMacro.TabIndex = 5;
            buttonAddKeyMacro.Text = "Add";
            buttonAddKeyMacro.UseVisualStyleBackColor = true;
            buttonAddKeyMacro.Click += buttonAddKeyMacro_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 137);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 16;
            label6.Text = "Mouse";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(71, 137);
            label7.Name = "label7";
            label7.Size = new Size(14, 15);
            label7.TabIndex = 17;
            label7.Text = "X";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(218, 137);
            label8.Name = "label8";
            label8.Size = new Size(14, 15);
            label8.TabIndex = 18;
            label8.Text = "Y";
            // 
            // textBoxMouseY
            // 
            textBoxMouseY.ImeMode = ImeMode.Disable;
            textBoxMouseY.Location = new Point(238, 135);
            textBoxMouseY.Name = "textBoxMouseY";
            textBoxMouseY.Size = new Size(130, 23);
            textBoxMouseY.TabIndex = 7;
            // 
            // buttonAddMouseMacro
            // 
            buttonAddMouseMacro.Location = new Point(374, 134);
            buttonAddMouseMacro.Name = "buttonAddMouseMacro";
            buttonAddMouseMacro.Size = new Size(75, 23);
            buttonAddMouseMacro.TabIndex = 8;
            buttonAddMouseMacro.Text = "Add";
            buttonAddMouseMacro.UseVisualStyleBackColor = true;
            buttonAddMouseMacro.Click += buttonAddMouseMacro_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(14, 255);
            label9.Name = "label9";
            label9.Size = new Size(36, 15);
            label9.TabIndex = 21;
            label9.Text = "Delay";
            // 
            // textBoxDelayMSec
            // 
            textBoxDelayMSec.ImeMode = ImeMode.Disable;
            textBoxDelayMSec.Location = new Point(71, 252);
            textBoxDelayMSec.Name = "textBoxDelayMSec";
            textBoxDelayMSec.Size = new Size(258, 23);
            textBoxDelayMSec.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(334, 255);
            label10.Name = "label10";
            label10.Size = new Size(34, 15);
            label10.TabIndex = 23;
            label10.Text = "msec";
            // 
            // buttonAddDelayMSec
            // 
            buttonAddDelayMSec.Location = new Point(374, 251);
            buttonAddDelayMSec.Name = "buttonAddDelayMSec";
            buttonAddDelayMSec.Size = new Size(75, 23);
            buttonAddDelayMSec.TabIndex = 18;
            buttonAddDelayMSec.Text = "Add";
            buttonAddDelayMSec.UseVisualStyleBackColor = true;
            buttonAddDelayMSec.Click += buttonAddDelayMSec_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(16, 308);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(140, 23);
            buttonDelete.TabIndex = 22;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonUp
            // 
            buttonUp.Location = new Point(162, 308);
            buttonUp.Name = "buttonUp";
            buttonUp.Size = new Size(140, 23);
            buttonUp.TabIndex = 23;
            buttonUp.Text = "Up";
            buttonUp.UseVisualStyleBackColor = true;
            buttonUp.Click += buttonUp_Click;
            // 
            // buttonDown
            // 
            buttonDown.Location = new Point(308, 308);
            buttonDown.Name = "buttonDown";
            buttonDown.Size = new Size(140, 23);
            buttonDown.TabIndex = 24;
            buttonDown.Text = "Down";
            buttonDown.UseVisualStyleBackColor = true;
            buttonDown.Click += buttonDown_Click;
            // 
            // textBoxDelaySec
            // 
            textBoxDelaySec.ImeMode = ImeMode.Disable;
            textBoxDelaySec.Location = new Point(71, 279);
            textBoxDelaySec.Name = "textBoxDelaySec";
            textBoxDelaySec.Size = new Size(258, 23);
            textBoxDelaySec.TabIndex = 19;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(334, 282);
            label11.Name = "label11";
            label11.Size = new Size(24, 15);
            label11.TabIndex = 29;
            label11.Text = "sec";
            // 
            // buttonAddDelaySec
            // 
            buttonAddDelaySec.Location = new Point(374, 278);
            buttonAddDelaySec.Name = "buttonAddDelaySec";
            buttonAddDelaySec.Size = new Size(75, 23);
            buttonAddDelaySec.TabIndex = 20;
            buttonAddDelaySec.Text = "Add";
            buttonAddDelaySec.UseVisualStyleBackColor = true;
            buttonAddDelaySec.Click += buttonAddDelaySec_Click;
            // 
            // textBoxMacroText
            // 
            textBoxMacroText.Location = new Point(71, 223);
            textBoxMacroText.Name = "textBoxMacroText";
            textBoxMacroText.Size = new Size(297, 23);
            textBoxMacroText.TabIndex = 15;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(14, 226);
            label12.Name = "label12";
            label12.Size = new Size(28, 15);
            label12.TabIndex = 33;
            label12.Text = "Text";
            // 
            // buttonAddTextMacro
            // 
            buttonAddTextMacro.Location = new Point(374, 222);
            buttonAddTextMacro.Name = "buttonAddTextMacro";
            buttonAddTextMacro.Size = new Size(75, 23);
            buttonAddTextMacro.TabIndex = 16;
            buttonAddTextMacro.Text = "Add";
            buttonAddTextMacro.UseVisualStyleBackColor = true;
            buttonAddTextMacro.Click += buttonAddTextMacro_Click;
            // 
            // checkBoxLoop
            // 
            checkBoxLoop.AutoSize = true;
            checkBoxLoop.Location = new Point(455, 282);
            checkBoxLoop.Name = "checkBoxLoop";
            checkBoxLoop.Size = new Size(53, 19);
            checkBoxLoop.TabIndex = 25;
            checkBoxLoop.Text = "Loop";
            checkBoxLoop.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 545);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(803, 22);
            statusStrip.TabIndex = 36;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(10, 17);
            toolStripStatusLabel.Text = " ";
            // 
            // comboBoxClickButton
            // 
            comboBoxClickButton.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClickButton.FormattingEnabled = true;
            comboBoxClickButton.Location = new Point(71, 163);
            comboBoxClickButton.Name = "comboBoxClickButton";
            comboBoxClickButton.Size = new Size(140, 23);
            comboBoxClickButton.TabIndex = 9;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(14, 166);
            label13.Name = "label13";
            label13.Size = new Size(32, 15);
            label13.TabIndex = 38;
            label13.Text = "Click";
            // 
            // buttonAddClickMacro
            // 
            buttonAddClickMacro.Location = new Point(373, 162);
            buttonAddClickMacro.Name = "buttonAddClickMacro";
            buttonAddClickMacro.Size = new Size(75, 23);
            buttonAddClickMacro.TabIndex = 11;
            buttonAddClickMacro.Text = "Add";
            buttonAddClickMacro.UseVisualStyleBackColor = true;
            buttonAddClickMacro.Click += buttonAddClickMacro_Click;
            // 
            // comboBoxClickMotion
            // 
            comboBoxClickMotion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClickMotion.FormattingEnabled = true;
            comboBoxClickMotion.Location = new Point(227, 163);
            comboBoxClickMotion.Name = "comboBoxClickMotion";
            comboBoxClickMotion.Size = new Size(141, 23);
            comboBoxClickMotion.TabIndex = 10;
            // 
            // textBoxScrollAmount
            // 
            textBoxScrollAmount.ImeMode = ImeMode.Disable;
            textBoxScrollAmount.Location = new Point(227, 193);
            textBoxScrollAmount.Margin = new Padding(2);
            textBoxScrollAmount.Name = "textBoxScrollAmount";
            textBoxScrollAmount.Size = new Size(141, 23);
            textBoxScrollAmount.TabIndex = 13;
            // 
            // comboBoxScrollDirection
            // 
            comboBoxScrollDirection.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxScrollDirection.FormattingEnabled = true;
            comboBoxScrollDirection.Location = new Point(71, 193);
            comboBoxScrollDirection.Margin = new Padding(2);
            comboBoxScrollDirection.Name = "comboBoxScrollDirection";
            comboBoxScrollDirection.Size = new Size(140, 23);
            comboBoxScrollDirection.TabIndex = 12;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(15, 195);
            label14.Name = "label14";
            label14.Size = new Size(36, 15);
            label14.TabIndex = 41;
            label14.Text = "Scroll";
            // 
            // buttonAddScroll
            // 
            buttonAddScroll.Location = new Point(374, 191);
            buttonAddScroll.Name = "buttonAddScroll";
            buttonAddScroll.Size = new Size(75, 23);
            buttonAddScroll.TabIndex = 14;
            buttonAddScroll.Text = "Add";
            buttonAddScroll.UseVisualStyleBackColor = true;
            buttonAddScroll.Click += buttonAddScroll_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(515, 283);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(60, 15);
            label15.TabIndex = 43;
            label15.Text = "LoopSpan";
            // 
            // textBoxLoopSpan
            // 
            textBoxLoopSpan.ImeMode = ImeMode.Disable;
            textBoxLoopSpan.Location = new Point(584, 281);
            textBoxLoopSpan.Margin = new Padding(2);
            textBoxLoopSpan.Name = "textBoxLoopSpan";
            textBoxLoopSpan.Size = new Size(165, 23);
            textBoxLoopSpan.TabIndex = 26;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(752, 283);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(34, 15);
            label16.TabIndex = 45;
            label16.Text = "msec";
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(4, 1, 0, 1);
            menuStrip.Size = new Size(803, 24);
            menuStrip.TabIndex = 46;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importToolStripMenuItem, exportToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 22);
            fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(109, 22);
            importToolStripMenuItem.Text = "Import";
            importToolStripMenuItem.Click += importToolStripMenuItem_Click;
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(109, 22);
            exportToolStripMenuItem.Text = "Export";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 567);
            Controls.Add(label16);
            Controls.Add(textBoxLoopSpan);
            Controls.Add(label15);
            Controls.Add(buttonAddScroll);
            Controls.Add(label14);
            Controls.Add(comboBoxScrollDirection);
            Controls.Add(textBoxScrollAmount);
            Controls.Add(comboBoxClickMotion);
            Controls.Add(buttonAddClickMacro);
            Controls.Add(label13);
            Controls.Add(comboBoxClickButton);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            Controls.Add(checkBoxLoop);
            Controls.Add(buttonAddTextMacro);
            Controls.Add(label12);
            Controls.Add(textBoxMacroText);
            Controls.Add(buttonAddDelaySec);
            Controls.Add(label11);
            Controls.Add(textBoxDelaySec);
            Controls.Add(buttonDown);
            Controls.Add(buttonUp);
            Controls.Add(buttonDelete);
            Controls.Add(buttonAddDelayMSec);
            Controls.Add(label10);
            Controls.Add(textBoxDelayMSec);
            Controls.Add(label9);
            Controls.Add(buttonAddMouseMacro);
            Controls.Add(textBoxMouseY);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(buttonAddKeyMacro);
            Controls.Add(comboBoxMacroKey);
            Controls.Add(label5);
            Controls.Add(textBoxMouseX);
            Controls.Add(comboBoxKeyStroke);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBoxTerminateKey);
            Controls.Add(buttonPlay);
            Controls.Add(dataGridViewActions);
            Controls.Add(label2);
            Controls.Add(pictureBoxWindowThumb);
            Controls.Add(buttonSelectWindow);
            Controls.Add(buttonWCUpdate);
            Controls.Add(comboBoxWindowNames);
            Controls.Add(label1);
            MaximizeBox = false;
            MaximumSize = new Size(819, 606);
            MinimumSize = new Size(819, 606);
            Name = "Form1";
            Text = "MyMacro - Please select target window.";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxWindowThumb).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewActions).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBoxWindowNames;
        private Button buttonWCUpdate;
        private Button buttonSelectWindow;
        private PictureBox pictureBoxWindowThumb;
        private Label label2;
        private DataGridView dataGridViewActions;
        private Button buttonPlay;
        private ComboBox comboBoxTerminateKey;
        private Label label3;
        private Label label4;
        private ComboBox comboBoxKeyStroke;
        private TextBox textBoxMouseX;
        private Label label5;
        private ComboBox comboBoxMacroKey;
        private Button buttonAddKeyMacro;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBoxMouseY;
        private Button buttonAddMouseMacro;
        private Label label9;
        private TextBox textBoxDelayMSec;
        private Label label10;
        private Button buttonAddDelayMSec;
        private Button buttonDelete;
        private Button buttonUp;
        private Button buttonDown;
        private TextBox textBoxDelaySec;
        private Label label11;
        private Button buttonAddDelaySec;
        private TextBox textBoxMacroText;
        private Label label12;
        private Button buttonAddTextMacro;
        private CheckBox checkBoxLoop;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ComboBox comboBoxClickButton;
        private Label label13;
        private Button buttonAddClickMacro;
        private ComboBox comboBoxClickMotion;
        private TextBox textBoxScrollAmount;
        private ComboBox comboBoxScrollDirection;
        private Label label14;
        private Button buttonAddScroll;
        private Label label15;
        private TextBox textBoxLoopSpan;
        private Label label16;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
    }
}
