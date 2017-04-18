using System;
using System.Windows.Forms;
using System.ComponentModel;
using PlaceholderGenerator.Data;

namespace PlaceholderGenerator
{
    public partial class PlaceholderGeneratorForm : Form
    {
        private SectionManager m_manager;
        private SectionPage firstSection;
        private BackgroundWorker m_backgroundWorker;

        public PlaceholderGeneratorForm()
        {
            InitializeComponent();

            m_manager = new SectionManager();

            //
            // firstSection
            //
            this.firstSection = new SectionPage();
            this.tabSections.Controls.Add(this.firstSection);
            this.firstSection.UseVisualStyleBackColor = true;
            this.firstSection.Text = string.Format(PlaceholderGenerator.Properties.Resources.TitleSection, 1);
            firstSection.Section = m_manager[0];
            this.tabSections.ItemRenderer = typeof(SectionPage);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            tabSections.Enabled = false;
            panelGenerator.Visible = false;
            generatorProgress.Visible = true;
            m_backgroundWorker = new BackgroundWorker();
            m_backgroundWorker.WorkerSupportsCancellation = true;
            m_backgroundWorker.WorkerReportsProgress = true;
            m_backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(this.Generation_ProgressChanged);
            m_backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.Generation_RunWorlerCompleted);
            m_manager.GenerateSections(m_backgroundWorker);
        }

        #region Generation
        private void Generation_ProgressChanged(object _sender, ProgressChangedEventArgs _event)
        {
            this.generatorProgress.SetProgress(_event.ProgressPercentage);
        }

        private void Generation_RunWorlerCompleted(object _sender, RunWorkerCompletedEventArgs _event)
        {
            this.generatorProgress.Clear();
            this.generatorProgress.Visible = false;
            this.panelGenerator.Visible = true;
            this.tabSections.Enabled = true;
        }

        private void generatorProgress_Cancel(object _sender, EventArgs _event)
        {
            m_backgroundWorker.CancelAsync();
        }
        #endregion

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            DialogResult result = dlg.ShowDialog(this);
            if(result == DialogResult.OK)
            {
                txtOutputDir.Text = dlg.SelectedPath;
                m_manager.OutputDir = txtOutputDir.Text;
                btnGenerate.Enabled = true;
            }
        }

        private void tabSections_ControlAdded(object sender, ControlEventArgs e)
        {
            if(e.Control is SectionPage && e.Control != firstSection)
            {
                Section newSection = new Section();
                m_manager.AddSection(newSection);
                SectionPage sectionPage = e.Control as SectionPage;
                sectionPage.Text = String.Format(PlaceholderGenerator.Properties.Resources.TitleSection, this.tabSections.TabCount - 1);
                sectionPage.Section = newSection;
            }
        }

        private void tabSections_ControlRemoved(object sender, ControlEventArgs e)
        {
            if(e.Control is SectionPage)
            {
                SectionPage sectionPage = e.Control as SectionPage;
                m_manager.RemoveSection(sectionPage.Section);
            }
        }
    }
}
