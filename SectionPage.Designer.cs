using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PlaceholderGenerator
{
    partial class SectionPage
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupSize = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.rbRectangle = new System.Windows.Forms.RadioButton();
            this.rbOval = new System.Windows.Forms.RadioButton();
            this.groupType = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.strokeBar = new System.Windows.Forms.TrackBar();
            this.numericStroke = new System.Windows.Forms.NumericUpDown();
            this.cbbFont = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudTextColor = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gridFiles = new System.Windows.Forms.DataGridView();
            this.contextMenuGridFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nNumber = new System.Windows.Forms.NumericUpDown();
            this.cbAuto = new System.Windows.Forms.CheckBox();
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_table = new System.Data.DataTable();
            this.sectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cpTextColor = new PlaceholderGenerator.ColorPicker();
            this.cpStroke = new PlaceholderGenerator.ColorPicker();
            this.cpFill = new PlaceholderGenerator.ColorPicker();
            this.tnPlaceholder = new PlaceholderGenerator.ThumbnailPlaceholder();
            this.groupSize.SuspendLayout();
            this.groupType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.strokeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStroke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTextColor)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFiles)).BeginInit();
            this.contextMenuGridFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupSize
            // 
            this.groupSize.Controls.Add(this.label4);
            this.groupSize.Controls.Add(this.txtHeight);
            this.groupSize.Controls.Add(this.label3);
            this.groupSize.Controls.Add(this.txtWidth);
            this.groupSize.Location = new System.Drawing.Point(4, 60);
            this.groupSize.Name = "groupSize";
            this.groupSize.Size = new System.Drawing.Size(348, 53);
            this.groupSize.TabIndex = 1;
            this.groupSize.TabStop = false;
            this.groupSize.Text = "Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "x &Height";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(228, 19);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 20);
            this.txtHeight.TabIndex = 6;
            this.txtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSize_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "&Width";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(56, 19);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(100, 20);
            this.txtWidth.TabIndex = 5;
            this.txtWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWidth_KeyDown);
            this.txtWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSize_KeyPress);
            // 
            // rbRectangle
            // 
            this.rbRectangle.AutoSize = true;
            this.rbRectangle.Checked = true;
            this.rbRectangle.Location = new System.Drawing.Point(25, 19);
            this.rbRectangle.Name = "rbRectangle";
            this.rbRectangle.Size = new System.Drawing.Size(74, 17);
            this.rbRectangle.TabIndex = 0;
            this.rbRectangle.TabStop = true;
            this.rbRectangle.Text = "Rectangle";
            this.rbRectangle.UseVisualStyleBackColor = true;
            this.rbRectangle.CheckedChanged += new System.EventHandler(this.rbRectangle_CheckedChanged);
            // 
            // rbOval
            // 
            this.rbOval.AutoSize = true;
            this.rbOval.Location = new System.Drawing.Point(105, 19);
            this.rbOval.Name = "rbOval";
            this.rbOval.Size = new System.Drawing.Size(47, 17);
            this.rbOval.TabIndex = 1;
            this.rbOval.Text = "Oval";
            this.rbOval.UseVisualStyleBackColor = true;
            // 
            // groupType
            // 
            this.groupType.Controls.Add(this.rbOval);
            this.groupType.Controls.Add(this.rbRectangle);
            this.groupType.Location = new System.Drawing.Point(4, 4);
            this.groupType.Name = "groupType";
            this.groupType.Size = new System.Drawing.Size(347, 50);
            this.groupType.TabIndex = 0;
            this.groupType.TabStop = false;
            this.groupType.Text = "Type";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PlaceholderGenerator.Properties.Resources.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(217, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::PlaceholderGenerator.Properties.Resources.Stroke;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(67, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Stroke";
            // 
            // strokeBar
            // 
            this.strokeBar.BackColor = System.Drawing.SystemColors.Window;
            this.strokeBar.Location = new System.Drawing.Point(48, 42);
            this.strokeBar.Maximum = 100;
            this.strokeBar.Name = "strokeBar";
            this.strokeBar.Size = new System.Drawing.Size(233, 45);
            this.strokeBar.TabIndex = 4;
            this.strokeBar.TickFrequency = 10;
            // 
            // numericStroke
            // 
            this.numericStroke.Location = new System.Drawing.Point(287, 42);
            this.numericStroke.Name = "numericStroke";
            this.numericStroke.Size = new System.Drawing.Size(53, 20);
            this.numericStroke.TabIndex = 5;
            // 
            // cbbFont
            // 
            this.cbbFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFont.FormattingEnabled = true;
            this.cbbFont.Location = new System.Drawing.Point(49, 19);
            this.cbbFont.Name = "cbbFont";
            this.cbbFont.Size = new System.Drawing.Size(198, 21);
            this.cbbFont.TabIndex = 1;
            this.cbbFont.SelectedIndexChanged += new System.EventHandler(this.cbbFont_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Font";
            // 
            // nudTextColor
            // 
            this.nudTextColor.Location = new System.Drawing.Point(288, 20);
            this.nudTextColor.Name = "nudTextColor";
            this.nudTextColor.Size = new System.Drawing.Size(53, 20);
            this.nudTextColor.TabIndex = 3;
            this.nudTextColor.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cpStroke);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.cpFill);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.strokeBar);
            this.groupBox1.Controls.Add(this.numericStroke);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 90);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stroke && Fill";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbbFont);
            this.groupBox2.Controls.Add(this.cpTextColor);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.nudTextColor);
            this.groupBox2.Location = new System.Drawing.Point(5, 215);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 51);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Text";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtText);
            this.groupBox3.Controls.Add(this.txtFile);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.gridFiles);
            this.groupBox3.Controls.Add(this.nNumber);
            this.groupBox3.Controls.Add(this.cbAuto);
            this.groupBox3.Controls.Add(this.txtSuffix);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtPrefix);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(5, 272);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(603, 196);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fichiers";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(535, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Number";
            // 
            // txtText
            // 
            this.txtText.Enabled = false;
            this.txtText.Location = new System.Drawing.Point(385, 31);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(147, 20);
            this.txtText.TabIndex = 8;
            // 
            // txtFile
            // 
            this.txtFile.Enabled = false;
            this.txtFile.Location = new System.Drawing.Point(144, 31);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(156, 20);
            this.txtFile.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(144, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "File (without extension)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(385, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Text";
            // 
            // gridFiles
            // 
            this.gridFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridFiles.ContextMenuStrip = this.contextMenuGridFiles;
            this.gridFiles.Location = new System.Drawing.Point(10, 58);
            this.gridFiles.Name = "gridFiles";
            this.gridFiles.Size = new System.Drawing.Size(587, 132);
            this.gridFiles.TabIndex = 11;
            // 
            // contextMenuGridFiles
            // 
            this.contextMenuGridFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PasteMenuItem});
            this.contextMenuGridFiles.Name = "contextMenuGridFiles";
            this.contextMenuGridFiles.Size = new System.Drawing.Size(103, 26);
            this.contextMenuGridFiles.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuGridFiles_Opening);
            // 
            // PasteMenuItem
            // 
            this.PasteMenuItem.Enabled = false;
            this.PasteMenuItem.Name = "PasteMenuItem";
            this.PasteMenuItem.Size = new System.Drawing.Size(102, 22);
            this.PasteMenuItem.Text = "Paste";
            this.PasteMenuItem.Click += new System.EventHandler(this.PasteMenuItem_Click);
            // 
            // nNumber
            // 
            this.nNumber.Enabled = false;
            this.nNumber.Location = new System.Drawing.Point(538, 32);
            this.nNumber.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nNumber.Name = "nNumber";
            this.nNumber.Size = new System.Drawing.Size(59, 20);
            this.nNumber.TabIndex = 10;
            // 
            // cbAuto
            // 
            this.cbAuto.AutoSize = true;
            this.cbAuto.Location = new System.Drawing.Point(12, 33);
            this.cbAuto.Name = "cbAuto";
            this.cbAuto.Size = new System.Drawing.Size(48, 17);
            this.cbAuto.TabIndex = 0;
            this.cbAuto.Text = "Auto";
            this.cbAuto.UseVisualStyleBackColor = true;
            this.cbAuto.CheckedChanged += new System.EventHandler(this.cbAuto_CheckedChanged);
            // 
            // txtSuffix
            // 
            this.txtSuffix.Location = new System.Drawing.Point(306, 31);
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(73, 20);
            this.txtSuffix.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(306, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Suffix";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(65, 31);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(73, 20);
            this.txtPrefix.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Prefix";
            // 
            // cpTextColor
            // 
            this.cpTextColor.ValueColor = System.Drawing.Color.Empty;
            this.cpTextColor.Location = new System.Drawing.Point(251, 22);
            this.cpTextColor.Name = "cpTextColor";
            this.cpTextColor.Size = new System.Drawing.Size(32, 16);
            this.cpTextColor.TabIndex = 2;
            this.cpTextColor.Text = "colorPicker1";
            // 
            // cpStroke
            // 
            this.cpStroke.ValueColor = System.Drawing.Color.Empty;
            this.cpStroke.Location = new System.Drawing.Point(88, 19);
            this.cpStroke.Name = "cpStroke";
            this.cpStroke.Size = new System.Drawing.Size(32, 16);
            this.cpStroke.TabIndex = 0;
            this.cpStroke.Text = "colorPicker2";
            // 
            // cpFill
            // 
            this.cpFill.ValueColor = System.Drawing.Color.Empty;
            this.cpFill.Location = new System.Drawing.Point(239, 19);
            this.cpFill.Name = "cpFill";
            this.cpFill.Size = new System.Drawing.Size(32, 16);
            this.cpFill.TabIndex = 2;
            this.cpFill.Text = "colorPicker1";
            // 
            // tnPlaceholder
            // 
            this.tnPlaceholder.BackgroundColor = System.Drawing.Color.Empty;
            this.tnPlaceholder.BorderColor = System.Drawing.Color.Empty;
            this.tnPlaceholder.DefaultText = "Text";
            this.tnPlaceholder.FontName = "Arial";
            this.tnPlaceholder.Location = new System.Drawing.Point(358, 10);
            this.tnPlaceholder.Name = "tnPlaceholder";
            this.tnPlaceholder.Size = new System.Drawing.Size(250, 250);
            this.tnPlaceholder.SizeText = 12F;
            this.tnPlaceholder.TabIndex = 5;
            this.tnPlaceholder.Text = "thumbnailPlaceholder1";
            this.tnPlaceholder.TextColor = System.Drawing.Color.Black;
            this.tnPlaceholder.Thickness = 0;
            this.tnPlaceholder.Type = PlaceholderGenerator.PlaceholderType.RECTANGLE;
            // 
            // SectionPage
            // 
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupType);
            this.Controls.Add(this.tnPlaceholder);
            this.Controls.Add(this.groupSize);
            this.Size = new System.Drawing.Size(612, 471);
            this.groupSize.ResumeLayout(false);
            this.groupSize.PerformLayout();
            this.groupType.ResumeLayout(false);
            this.groupType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.strokeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStroke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTextColor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFiles)).EndInit();
            this.contextMenuGridFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private ColorPicker cpFill;
        private ColorPicker cpStroke;
        private System.Windows.Forms.GroupBox groupSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWidth;
        private ThumbnailPlaceholder tnPlaceholder;
        private System.Windows.Forms.RadioButton rbRectangle;
        private System.Windows.Forms.RadioButton rbOval;
        private System.Windows.Forms.GroupBox groupType;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar strokeBar;
        private System.Windows.Forms.NumericUpDown numericStroke;
        private System.Windows.Forms.ComboBox cbbFont;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudTextColor;
        private System.Windows.Forms.GroupBox groupBox1;
        private ColorPicker cpTextColor;
        private System.Windows.Forms.GroupBox groupBox2;
        private GroupBox groupBox3;
        private TextBox txtSuffix;
        private Label label6;
        private TextBox txtPrefix;
        private Label label5;
        private NumericUpDown nNumber;
        private CheckBox cbAuto;
        private DataGridView gridFiles;
        private TextBox txtFile;
        private Label label7;
        private TextBox txtText;
        private Label label8;

        private DataTable m_table;
        private Label label9;
        private ContextMenuStrip contextMenuGridFiles;
        private ToolStripMenuItem PasteMenuItem;
        private BindingSource sectionBindingSource;
    }
}
