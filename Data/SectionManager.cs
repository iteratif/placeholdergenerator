using System;
using System.Drawing;
using System.Threading;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.ComponentModel;

namespace PlaceholderGenerator.Data
{
    public class SectionManager
    {
        #region Properties
        private string m_outputDir;
        public string OutputDir
        {
            get
            {
                return m_outputDir;
            }
            set
            {
                m_outputDir = value;
            }
        }

        private List<Section> m_sections;
        public Section this[int _index]
        {
            get
            {
                return m_sections[_index];
            }
            set
            {
                m_sections[_index] = value;
            }
        }

        public int numSections
        {
            get
            {
                return m_sections.Count;
            }
        }
        #endregion

        public SectionManager()
        {
            m_sections = new List<Section>();
            m_sections.Add(new Section());
        }

        public void AddSection(Section _section)
        {
            m_sections.Add(_section);
        }

        public void RemoveSection(Section _section)
        {
            m_sections.Remove(_section);
        }

        public void GenerateSections(BackgroundWorker _worker)
        {
            _worker.DoWork += new DoWorkEventHandler(this.startGeneration);
            _worker.RunWorkerAsync();
        }

        private void startGeneration(object _sender, DoWorkEventArgs _event)
        {
            int numBitmaps, count = 1;
            Bitmap bmp;
            Bitmap[] bitmaps;

            BackgroundWorker worker = _sender as BackgroundWorker;
            decimal numberOfPlaceholder = 0;
            foreach (Section s in m_sections)
            {
                numberOfPlaceholder += s.NumberOfPlaceholder;
            }

            foreach(Section s in m_sections)
            {
                if(worker.CancellationPending)
                {
                    _event.Cancel = true;
                    break;
                }
                else
                {
                    bitmaps = GenerateSection(s);
                    numBitmaps = bitmaps.Length;
                    for (int i = 0; i < numBitmaps; i++, count++)
                    {
                        bmp = bitmaps[i];
                        if(s.Auto)
                        {
                            Save(bmp, s.Filename, s.Prefix, s.Suffix, i);
                        }
                        else
                        {
                            FileSection fs = s.Files[i];
                            Save(bmp, fs.Filename, s.Prefix, s.Suffix);
                        }
                        Thread.Sleep(100);
                        int percent = count * 100 / (int)numberOfPlaceholder;
                        worker.ReportProgress(percent);
                        if(worker.CancellationPending)
                        {
                            _event.Cancel = true;
                            break;
                        }
                    }
                }

            }
        }

        private Bitmap[] GenerateSection(Section _section)
        {
            List<Bitmap> bitmaps = new List<Bitmap>();
            for(int i = 0; i < _section.NumberOfPlaceholder; i++)
            {
                if(_section.Auto)
                {
                    bitmaps.Add(CreatePlaceholder(_section,_section.Text));
                }
                else
                {

                    FileSection fs = _section.Files[i];
                    bitmaps.Add(CreatePlaceholder(_section, fs.Text));
                }
            }
            return bitmaps.ToArray();
        }

        private Bitmap CreatePlaceholder(Section _section, string _text)
        {
            Rectangle rect = new Rectangle(0, 0, _section.Width, _section.Height);

            Bitmap bmp = new Bitmap(_section.Width, _section.Height);
            Graphics gfx = Graphics.FromImage(bmp);
            
            Pen pen = new Pen(_section.BorderColor,_section.Thickness);
            pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            Brush brush = new SolidBrush(_section.BackgroundColor);
            Font font = new Font(_section.FontName, _section.TextSize);
            Brush brushFont = new SolidBrush(_section.TextColor);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            if (_section.Type == PlaceholderType.RECTANGLE)
            {
                gfx.FillRectangle(brush, rect);
                gfx.DrawRectangle(pen, rect);
            }
            else if (_section.Type == PlaceholderType.OVAL)
            {
                gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                rect.X -= 1;
                rect.Y -= 1;
                gfx.FillEllipse(brush, rect);
                gfx.DrawEllipse(pen, rect);
            }

            gfx.DrawString(_text, font, brushFont, rect, format);

            brushFont.Dispose();
            format.Dispose();
            font.Dispose();
            brush.Dispose();
            pen.Dispose();
            gfx.Dispose();
            return bmp;
        }

        public void Save(Bitmap _bmp, string _filename, string _prefix, string _suffix, int _index = -1)
        {
            string numerotation = "";
            if(_index != -1)
            {
                numerotation = "_" + _index.ToString();
            }
            ImageCodecInfo imageCodecInfo = GetEncoderInfo("image/png");
            Encoder encoder = Encoder.Quality;
            EncoderParameter parameter = new EncoderParameter(encoder, 100L);
            EncoderParameters parameters = new EncoderParameters(1);
            parameters.Param[0] = parameter;
            _bmp.Save(string.Format(@"{0}\{1}{2}{3}{4}.png", m_outputDir,_prefix,_filename,_suffix,numerotation), /*ImageFormat.Png*/imageCodecInfo, parameters);
        }

        private ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

    }
}
