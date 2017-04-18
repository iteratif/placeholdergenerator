using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaceholderGenerator
{
    public enum PlaceholderType
    {
        RECTANGLE,
        OVAL
    }

    public partial class ThumbnailPlaceholder : Control
    {
        #region Properties

        private PlaceholderType m_type;
        public PlaceholderType Type
        {
            get
            {
                return m_type;
            }

            set
            {
                if( m_type != value)
                {
                    m_type = value;
                    Invalidate();
                }
            }
        }

        private Color m_backgroundColor;
        public Color BackgroundColor
        {
            get
            {
                return m_backgroundColor;
            }

            set
            {
                if(m_backgroundColor != value)
                {
                    m_backgroundColor = value;
                    Invalidate();
                }
            }
        }

        private Color m_borderColor;
        public Color BorderColor
        {
            get
            {
                return m_borderColor;
            }

            set
            {
                if(m_borderColor != value)
                {
                    m_borderColor = value;
                    Invalidate();
                }
            }
        }

        private int m_thickness;
        public int Thickness
        {
            get
            {
                return m_thickness;
            }

            set
            {
                if(m_thickness != value)
                {
                    m_thickness = value;
                    Invalidate();
                }
            }
        }

        private String m_text;
        public String DefaultText
        {
            get
            {
                return m_text;
            }

            set
            {
                if(m_text != value)
                {
                    m_text = value;
                    Invalidate();
                }
            }
        }

        private Color m_textColor;
        public Color TextColor
        {
            get
            {
                return m_textColor;
            }
            set
            {
                if(m_textColor != value)
                {
                    m_textColor = value;
                    Invalidate();
                }
            }
        }

        private float m_sizeText;
        public float SizeText
        {
            get
            {
                return m_sizeText;
            }
            set
            {
                if(m_sizeText != value)
                {
                    m_sizeText = value;
                    Invalidate();
                }
            }
        }

        private String m_fontName;
        public string FontName
        {
            get
            {
                return m_fontName;
            }

            set
            {
                if(m_fontName != value)
                {
                    m_fontName = value;
                    Invalidate();
                }
            }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(250,250);
            }
        }
        #endregion

        public ThumbnailPlaceholder()
        {
            m_type = PlaceholderType.RECTANGLE;
            m_text = "Placeholder";
            m_sizeText = 12.0F;
            m_textColor = Color.Black;
            m_fontName = "Arial";

            InitializeComponent();
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Rectangle rect = new Rectangle(0, 0, this.Size.Width, this.Size.Height);

            Graphics gfx = pe.Graphics;
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DrawThumbnailPlaceholder(gfx);

            Pen pen = new Pen(m_borderColor, m_thickness);
            pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            Brush brush = new SolidBrush(m_backgroundColor);

            if(m_type == PlaceholderType.RECTANGLE)
            {
                gfx.FillRectangle(brush, rect);
                gfx.DrawRectangle(pen, rect);
            }
            else if(m_type == PlaceholderType.OVAL)
            {
                gfx.FillEllipse(brush, rect);
                gfx.DrawEllipse(pen, rect);
            }
            brush.Dispose();
            pen.Dispose();

            Brush textBrush = new SolidBrush(m_textColor);
            Font textFont = new Font(m_fontName, m_sizeText);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            gfx.DrawString(m_text, textFont, textBrush, rect, format);

            textFont.Dispose();
            textBrush.Dispose();
        }

        private void DrawThumbnailPlaceholder(Graphics _gfx)
        {
            ControlPaint.DrawBorder3D(_gfx, 0, 0, this.Size.Width, this.Size.Height);
        }
    }
}
