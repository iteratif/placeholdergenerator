using System;
using System.Text.RegularExpressions;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using PlaceholderGenerator.Data;

namespace PlaceholderGenerator
{
    public partial class SectionPage : TabPage
    {
        private bool m_isNumber = true;
        private Color m_backgroudDGColor;
        private BindingSource m_bsSection;

        private Section m_section;
        public Section Section
        {
            get
            {
                return m_section;
            }
            set
            {
                m_section = value;
                SetFields();
            }
        }

        public SectionPage()
        {
            InitializeComponent();
            m_bsSection = new BindingSource();
            m_backgroudDGColor = gridFiles.BackgroundColor;

            List<string> fonts = new List<string>();

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                fonts.Add(font.Name);
            }

            cbbFont.DataSource = fonts;
        }

        private void SetFields()
        {
            if(m_section != null)
            {
                rbRectangle.Checked = m_section.Type == PlaceholderType.RECTANGLE;
                cbbFont.SelectedItem = m_section.FontName;

                this.m_bsSection.Add(m_section);
                txtWidth.DataBindings.Clear();
                Binding binding = this.txtWidth.DataBindings.Add("Text", this.m_bsSection, "Width");
                binding.Parse += new ConvertEventHandler(this.SectionPage_SizeParse);

                txtHeight.DataBindings.Clear();
                Binding bdHeight = this.txtHeight.DataBindings.Add("Text", this.m_bsSection, "Height");
                bdHeight.Parse += new ConvertEventHandler(this.SectionPage_SizeParse);

                cpFill.DataBindings.Clear();
                cpFill.DataBindings.Add("ValueColor", m_bsSection, "BackgroundColor", false, DataSourceUpdateMode.OnPropertyChanged);

                cpStroke.DataBindings.Clear();
                cpStroke.DataBindings.Add("ValueColor", m_bsSection, "BorderColor", false, DataSourceUpdateMode.OnPropertyChanged);

                strokeBar.DataBindings.Clear();
                strokeBar.DataBindings.Add("Value", m_bsSection, "Thickness", false, DataSourceUpdateMode.OnPropertyChanged);

                numericStroke.DataBindings.Clear();
                numericStroke.DataBindings.Add("Value", m_bsSection, "Thickness", false, DataSourceUpdateMode.OnPropertyChanged);

                nudTextColor.DataBindings.Clear();
                nudTextColor.DataBindings.Add("Value", m_bsSection, "TextSize", false, DataSourceUpdateMode.OnPropertyChanged);

                cpTextColor.DataBindings.Clear();
                cpTextColor.DataBindings.Add("ValueColor", m_bsSection, "TextColor", false, DataSourceUpdateMode.OnPropertyChanged);

                txtPrefix.DataBindings.Clear();
                txtPrefix.DataBindings.Add("Text", m_bsSection, "Prefix");

                txtSuffix.DataBindings.Clear();
                txtSuffix.DataBindings.Add("Text", m_bsSection, "Suffix");

                txtFile.DataBindings.Clear();
                txtFile.DataBindings.Add("Text", m_bsSection, "Filename");

                txtText.DataBindings.Clear();
                txtText.DataBindings.Add("Text", m_bsSection, "Text");

                nNumber.DataBindings.Clear();
                nNumber.DataBindings.Add("Value", m_bsSection, "NumberOfPlaceholder");

                tnPlaceholder.DataBindings.Clear();
                tnPlaceholder.DataBindings.Add("BackgroundColor", m_bsSection, "BackgroundColor");
                tnPlaceholder.DataBindings.Add("BorderColor", m_bsSection, "BorderColor");
                tnPlaceholder.DataBindings.Add("Thickness", m_bsSection, "Thickness");
                tnPlaceholder.DataBindings.Add("TextColor", m_bsSection, "TextColor");
                tnPlaceholder.DataBindings.Add("FontName", m_bsSection, "FontName");
                tnPlaceholder.DataBindings.Add("SizeText", m_bsSection, "TextSize");

                this.sectionBindingSource.Clear();
                this.sectionBindingSource.DataMember = "Files";
                this.sectionBindingSource.DataSource = this.m_bsSection;
                gridFiles.DataSource = this.sectionBindingSource;
                gridFiles.AutoGenerateColumns = true;
            }
        }

        private void SectionPage_SizeParse(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType != typeof(int)) return;

            e.Value = int.Parse(e.Value.ToString());
        }

        private void rbRectangle_CheckedChanged(object sender, EventArgs e)
        {
            tnPlaceholder.Type = rbRectangle.Checked ? PlaceholderType.RECTANGLE : PlaceholderType.OVAL;
            m_section.Type = tnPlaceholder.Type;
        }

        private void cbbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fontSelected = (String)cbbFont.SelectedValue;
            if(fontSelected != null)
            {
                m_section.FontName = fontSelected;
            }
        }

        private void txtWidth_KeyDown(object sender, KeyEventArgs e)
        {
            m_isNumber = true;

            if(e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        m_isNumber = false;
                    }
                }
            }
        }

        private void txtSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!m_isNumber)
            {
                e.Handled = true;
            }
        }

        private void cbAuto_CheckedChanged(object sender, EventArgs e)
        {
            m_section.Auto = cbAuto.Checked;
            txtFile.Enabled = m_section.Auto;
            txtText.Enabled = m_section.Auto;
            nNumber.Enabled = m_section.Auto;
            gridFiles.Enabled = !m_section.Auto;
            gridFiles.BackgroundColor = m_section.Auto ? SystemColors.Control : m_backgroudDGColor;
            gridFiles.Rows.Clear();
        }
      
        private void contextMenuGridFiles_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataObject o = (DataObject)Clipboard.GetDataObject();
            if(o.GetDataPresent(DataFormats.Text))
            {
                PasteMenuItem.Enabled = true;
            }
        }

        private void PasteMenuItem_Click(object sender, EventArgs e)
        {
            DataObject o = (DataObject)Clipboard.GetDataObject();
            if (o.GetDataPresent(DataFormats.Text))
            {
                string[] lines = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()),"\r\n");
                if(lines.Length > 0)
                {
                    gridFiles.Rows.Clear();
                }

                foreach(string line in lines)
                {

                    string[] columns = line.Split(new char[] { '\t' });
                    if(columns.Length > 1)
                    {
                        FileSection fileSection = new FileSection();
                        fileSection.Filename = columns[0];
                        fileSection.Text = columns[1];
                        sectionBindingSource.Add(fileSection);
                    }
                }
            }
        }
    }
}
