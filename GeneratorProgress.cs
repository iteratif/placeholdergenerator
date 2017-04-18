using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaceholderGenerator
{
    public delegate void CancelGeneratorProgess(object _sender, EventArgs _event);

    public partial class GeneratorProgress : UserControl
    {
        public event CancelGeneratorProgess Cancel;

        public GeneratorProgress()
        {
            InitializeComponent();
        }

        public void SetProgress(int _progress)
        {
            this.progressBar.Value = _progress;
        }

        public void Clear()
        {
            this.progressBar.Value = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel(this, new EventArgs());
        }
    }
}
