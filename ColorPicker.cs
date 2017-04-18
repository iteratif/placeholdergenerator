using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaceholderGenerator
{
    public class ColorPickerEventArgs : EventArgs
    {

    }

    public delegate void ColorPickerEventHandler(object s, ColorPickerEventArgs e);

    public partial class ColorPicker : Control, INotifyPropertyChanged, IBindableComponent
    {
        #region Properties
        [Category("Action")]
        public event ColorPickerEventHandler SelectedColor;
        public event PropertyChangedEventHandler PropertyChanged;

        private Color m_color;

        public Color ValueColor
        {
            get
            {
                return m_color;
            }

            set
            {
                m_color = value;
                NotifyPropertyChanged();
            }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(36,16);
            }
        }
        #endregion


        public ColorPicker()
        {
            InitializeComponent();

            Click += new EventHandler(SelectColor);
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Graphics gfx = pe.Graphics;

            Rectangle rect = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            using (Pen borderPen = new Pen(Color.Black, 1))
            {
                using (Brush fillBrush = new SolidBrush(m_color))
                {
                    borderPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                    gfx.FillRectangle(fillBrush, rect);
                    ControlPaint.DrawBorder(gfx, rect, Color.Black, ButtonBorderStyle.Solid);
                    
                    if(this.Focused)
                    {
                        using(Pen pen = new Pen(SystemColors.ControlDarkDark))
                        {
                            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                            rect.X += 2;
                            rect.Y += 2;
                            rect.Width -= 5;
                            rect.Height -= 5;
                            gfx.DrawRectangle(pen, rect);
                        }
                    }
                }
            }
        }

        private void ColorPicker_GotFocus(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Focus Received!!! this.Focused:" + this.Focused.ToString());
            this.Invalidate();
        }

        private void ColorPicker_LostFocus(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Lost Received!!! this.Focused:" + this.Focused.ToString());
            this.Invalidate();
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, 32, 16, specified);
        }

        private void SelectColor(object _sender, EventArgs _event)
        {
            ColorDialog dlg = new ColorDialog();
            DialogResult result = dlg.ShowDialog(this);
            if( result == DialogResult.OK )
            {
                m_color = dlg.Color;
                Invalidate();
                if(SelectedColor != null)
                {
                    SelectedColor(this, new ColorPickerEventArgs());
                }
                NotifyPropertyChanged("ValueColor");
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
