using System.Resources;

namespace PlaceholderGenerator
{
    partial class PlaceholderGeneratorForm
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaceholderGeneratorForm));
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOutputDir = new System.Windows.Forms.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.panelGenerator = new System.Windows.Forms.Panel();
            this.generatorProgress = new PlaceholderGenerator.GeneratorProgress();
            this.tabSections = new PlaceholderGenerator.itTabControl();
            this.panelGenerator.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Enabled = false;
            this.btnGenerate.Location = new System.Drawing.Point(464, 5);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate...";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Output Dir";
            // 
            // txtOutputDir
            // 
            this.txtOutputDir.Location = new System.Drawing.Point(67, 7);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.Size = new System.Drawing.Size(310, 20);
            this.txtOutputDir.TabIndex = 1;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(383, 5);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnBrowser.TabIndex = 2;
            this.btnBrowser.Text = "&Browser...";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // panelGenerator
            // 
            this.panelGenerator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGenerator.Controls.Add(this.label1);
            this.panelGenerator.Controls.Add(this.btnGenerate);
            this.panelGenerator.Controls.Add(this.btnBrowser);
            this.panelGenerator.Controls.Add(this.txtOutputDir);
            this.panelGenerator.Location = new System.Drawing.Point(93, 546);
            this.panelGenerator.Name = "panelGenerator";
            this.panelGenerator.Size = new System.Drawing.Size(545, 35);
            this.panelGenerator.TabIndex = 22;
            // 
            // generatorProgress
            // 
            this.generatorProgress.Location = new System.Drawing.Point(130, 546);
            this.generatorProgress.Name = "generatorProgress";
            this.generatorProgress.Size = new System.Drawing.Size(503, 29);
            this.generatorProgress.TabIndex = 23;
            this.generatorProgress.Visible = false;
            this.generatorProgress.Cancel += new PlaceholderGenerator.CancelGeneratorProgess(this.generatorProgress_Cancel);
            // 
            // tabSections
            // 
            this.tabSections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSections.ItemRenderer = typeof(object);
            this.tabSections.Location = new System.Drawing.Point(12, 12);
            this.tabSections.Name = "tabSections";
            this.tabSections.SelectedIndex = 0;
            this.tabSections.ShowTabCloser = true;
            this.tabSections.Size = new System.Drawing.Size(621, 532);
            this.tabSections.TabIndex = 0;
            this.tabSections.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.tabSections_ControlAdded);
            this.tabSections.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.tabSections_ControlRemoved);
            // 
            // PlaceholderGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 581);
            this.Controls.Add(this.panelGenerator);
            this.Controls.Add(this.generatorProgress);
            this.Controls.Add(this.tabSections);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PlaceholderGeneratorForm";
            this.Text = "PNG Placeholder Generator";
            this.panelGenerator.ResumeLayout(false);
            this.panelGenerator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PlaceholderGenerator.itTabControl/*System.Windows.Forms.TabControl*/ tabSections;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOutputDir;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Panel panelGenerator;
        private GeneratorProgress generatorProgress;
    }
}

