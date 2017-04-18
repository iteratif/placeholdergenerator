using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PlaceholderGenerator
{
    class itTabControl : System.Windows.Forms.TabControl
    {
        #region Properties
        private ImageList imageList1;
        private System.ComponentModel.IContainer components;

        private Type m_itemRenderer;
        public Type ItemRenderer
        {
            get
            {
                return m_itemRenderer;
            }
            set
            {
                m_itemRenderer = value;
            }
        } 

        private TabPage m_addTabPage;
        private bool m_showTabCloser = true;
        public bool ShowTabCloser
        {
            get
            {
                return m_showTabCloser;
            }
            set
            {
                m_showTabCloser = value;
            }
        }
        #endregion

        public itTabControl() : base()
        {
            this.SetStyle(ControlStyles.UserPaint | 
                ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.Opaque | 
                ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer, true);

            m_itemRenderer = typeof(TabPage);
            InitializeComponent();
        }


        #region Utilities
        public new Point MousePosition
        {
            get
            {
                return PointToClient(Control.MousePosition);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= Win32.WS_EX_COMPOSITED;
                return cp;
            }
        }

        protected int HitTest()
        {
            Win32.TCHITTESTINFO hitTestInfo = new Win32.TCHITTESTINFO(MousePosition);
            int index = Win32.SendMessage(this.Handle, Win32.TCM_HITTEST, IntPtr.Zero, Win32.ToIntPtr(hitTestInfo)).ToInt32();
            if (index == -1)
            {
                return -1;
            }
            else
            {
                if (this.TabPages[index].Enabled)
                {
                    return index;
                }
                else
                {
                    return -1;
                }
            }
        }

        private Rectangle GetTabAddRect()
        {
            Rectangle rectTab = new Rectangle();
            rectTab.Y = 2;
            rectTab.Width = 20;
            rectTab.Height = 18;
            int lastIndex = this.TabCount - 1;
            if (lastIndex > -1)
            {
                Rectangle rect = this.GetTabRect(lastIndex);
                rectTab.X = rect.Right;
                rectTab.Y += rect.Top;
            }

            return rectTab;
        }

        private Rectangle GetCloserRect(Rectangle _tabRect)
        {
            Rectangle rect = new Rectangle();
            rect.X = _tabRect.Right - 4 - 6;
            rect.Y = (_tabRect.Height - 6) / 2 + _tabRect.Top;
            rect.Width = 6;
            rect.Height = 6;
            return rect;
        }
        #endregion

        #region Events
        protected override void OnSelecting(TabControlCancelEventArgs e)
        {
            if(e.TabPage == m_addTabPage)
            {
                e.Cancel = true;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            int lastIndex = this.TabCount - 1;
            if(this.GetTabRect(lastIndex).Contains(e.Location))
            {
                TabPage ctrl = (TabPage)Activator.CreateInstance(m_itemRenderer);
                ctrl.UseVisualStyleBackColor = true;
                this.TabPages.Insert(lastIndex, ctrl);
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            if(e.Control == m_addTabPage)
            {
                return;
            }
            base.OnControlAdded(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            int index = HitTest();
            if (this.ShowTabCloser && index > 0)
            {
                Rectangle closerRect = this.GetCloserRect(this.GetTabRect(index));
                if (closerRect.Contains(e.Location))
                {
                    // Close Tab
                    this.TabPages.RemoveAt(index);
                }
            }

            base.OnMouseClick(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (ShowTabCloser)
            {
                int index = HitTest();
                if(index > 0 && this.SelectedIndex == index)
                {
                    Rectangle tabRect = this.GetTabRect(index);
                    Rectangle rect = this.GetCloserRect(tabRect);
                    if (rect.Contains(this.MousePosition))
                    {
                        this.Invalidate();
                    }
                }
            }
        }
        #endregion

        #region Drawing
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics gfx = e.Graphics;
            gfx.Clear(this.BackColor);

            // draw tabs
            DrawAddTab(gfx);
            DrawTabsNoSelected(gfx);
            DrawTabAndPageSelected(gfx);
        }

        protected void DrawTabAndPageSelected(Graphics _gfx)
        {
            TabPage tab = this.TabPages[this.SelectedIndex];
            Rectangle rect = this.GetTabRect(this.SelectedIndex);
            Rectangle tabBound = tab.Bounds;
            tabBound.X -= 2;
            tabBound.Y -= 2;
            tabBound.Width += 2;
            tabBound.Height += 2;

            using (Brush br = new SolidBrush(Color.White))
            {
                _gfx.FillRectangle(br, rect);
                rect.Height += 2;
                //_gfx.DrawRectangle(SystemPens.ControlDark, rect);
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Top);
                    path.AddLine(rect.Left, rect.Top, rect.Right, rect.Top);
                    path.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom);
                    // Path TabPage
                    path.AddLine(rect.Right, tabBound.Top, tabBound.Right, tabBound.Top);
                    path.AddLine(tabBound.Right,tabBound.Top,tabBound.Right, tabBound.Bottom);
                    path.AddLine(tabBound.Right, tabBound.Bottom, tabBound.Left, tabBound.Bottom);
                    path.AddLine(tabBound.Left, tabBound.Bottom, tabBound.Left, tabBound.Top);
                    path.AddLine(tabBound.Left, tabBound.Top, rect.Left, tabBound.Top);
                    _gfx.FillPath(Brushes.White, path);
                    _gfx.DrawPath(SystemPens.ControlDark, path);
                }

                if(this.SelectedIndex != 0)
                    DrawCloser(_gfx, rect);

                if(this.Focused)
                {
                    using(Pen pen = new Pen(SystemColors.ControlDarkDark))
                    {
                        rect.X += 2;
                        rect.Y += 2;
                        rect.Width -= 4;
                        rect.Height -= 4;
                        pen.DashStyle = DashStyle.Dot;
                        _gfx.DrawRectangle(pen, rect);
                    }
                }
            }

            rect.Width -= 4;
            TextRenderer.DrawText(_gfx, tab.Text, tab.Font, rect, tab.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        protected void DrawTabsNoSelected(Graphics _gfx)
        {
            TabPage tab;
            Rectangle rect;
            Brush br;
            int tabCount = this.TabCount;
            for(int i = 0; i < tabCount; i++)
            {
                if (this.SelectedIndex == i) continue;

                tab = this.TabPages[i];
                rect = this.GetTabRect(i);

                if(i == tabCount - 1)
                {
                    rect.Width = 20;
                }

                using(br = new SolidBrush(tab.BackColor))
                {
                    _gfx.FillRectangle(br, rect);
                    using(Pen pen = new Pen(SystemColors.ControlLight))
                    {
                        rect.Y += 2;
                        _gfx.DrawRectangle(pen, rect);
                    }
                }

                if(i == tabCount - 1)
                {
                    _gfx.DrawImage(imageList1.Images[0], rect.Left + 2,(rect.Height - 16) / 2+ rect.Top);
                }

                TextRenderer.DrawText(_gfx, tab.Text, tab.Font, rect, tab.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void DrawCloser(Graphics _gfx, Rectangle _tabRect)
        {
            using(GraphicsPath path = new GraphicsPath())
            {
                Rectangle rect = GetCloserRect(_tabRect);

                path.AddLine(rect.Left, rect.Top, rect.Right, rect.Bottom);
                path.CloseFigure();
                path.AddLine(rect.Left, rect.Bottom, rect.Right, rect.Top);
                path.CloseFigure();

                using (Pen pen = new Pen(SystemColors.ControlDark))
                {
                    pen.Width = 2;
                    if (rect.Contains(MousePosition))
                    {
                        pen.Color = Color.Red;
                    }
                    _gfx.DrawPath(pen, path);
                }
            }
        }

        private void DrawAddTab(Graphics _gfx)
        {
            /*int lastIndex = this.TabCount - 1;
            if(lastIndex > -1)
            {
                if(this.ImageList != null && this.ImageList.Images.Count > 0)
                {
                    Rectangle rect = this.GetTabAddRect();
                    _gfx.FillRectangle(SystemBrushes.Control, rect);
                    _gfx.DrawRectangle(SystemPens.ControlLight, rect);

                    Point pt = new Point(rect.Left + 2,(rect.Height - 13)/2 + rect.Top);
                    _gfx.DrawImage(imageList1.Images[0], pt);
                }
            }*/
            if(m_addTabPage == null)
            {
                m_addTabPage = new TabPage();
                m_addTabPage.ImageIndex = 0;
                this.TabPages.Add(m_addTabPage);
                Win32.SendMessage(this.Handle, Win32.TCM_SETMINTABWIDTH, IntPtr.Zero, (IntPtr)32);
            }
        }
        #endregion

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(itTabControl));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.SystemColors.Window;
            this.imageList1.Images.SetKeyName(0, "AddIcon.bmp");
            // 
            // itTabControl
            // 
            this.ImageList = this.imageList1;
            this.ResumeLayout(false);

        }
    }
}
