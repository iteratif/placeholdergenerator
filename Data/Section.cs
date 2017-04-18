using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System;

namespace PlaceholderGenerator.Data
{
    public class FileSection
    {
        private string m_filename;
        public string Filename
        {
            get
            {
                return m_filename;
            }
            set
            {
                m_filename = value;
            }
        }
        private string m_text;
        public string Text
        {
            get
            {
                return m_text;
            }
            set
            {
                m_text = value;
            }
        }
    }

    public class Section : INotifyPropertyChanged
    {
        private PlaceholderType         m_type;
        private bool                    m_auto;

        private int                     m_width;
        private int                     m_height;

        private Color                   m_backgroundColor;
        private Color                   m_borderColor;
        private int                     m_thickness;

        private string                  m_fontName;
        private int                     m_textSize;
        private Color                   m_textColor;


        private string                  m_prefix;
        private string                  m_suffix;
        private string                  m_filename;
        private string                  m_text;
        private List<FileSection>       m_files;

        private decimal                 m_numberOfPlaceholder;
        public decimal                  NumberOfPlaceholder
        {
            get
            {
                if(!Auto)
                {
                    return Files.Count;
                }
                return m_numberOfPlaceholder;
            }
            set
            {
                m_numberOfPlaceholder = value;
            }
        }

        public PlaceholderType Type
        {
            get
            {
                return m_type;
            }

            set
            {
                m_type = value;
            }
        }

        public bool Auto
        {
            get
            {
                return m_auto;
            }

            set
            {
                m_auto = value;
            }
        }

        public int Width
        {
            get
            {
                return m_width;
            }

            set
            {
                m_width = value;
            }
        }

        public int Height
        {
            get
            {
                return m_height;
            }

            set
            {
                m_height = value;
            }
        }

        public Color BackgroundColor
        {
            get
            {
                return m_backgroundColor;
            }

            set
            {
                m_backgroundColor = value;
                NotifyPropertyChanged();
            }
        }

        public Color BorderColor
        {
            get
            {
                return m_borderColor;
            }

            set
            {
                m_borderColor = value;
                NotifyPropertyChanged();
            }
        }

        public int Thickness
        {
            get
            {
                return m_thickness;
            }

            set
            {
                m_thickness = value;
                NotifyPropertyChanged();
            }
        }

        public string FontName
        {
            get
            {
                return m_fontName;
            }

            set
            {
                m_fontName = value;
                NotifyPropertyChanged();
            }
        }

        public int TextSize
        {
            get
            {
                return m_textSize;
            }

            set
            {
                m_textSize = value;
                NotifyPropertyChanged();
            }
        }

        public Color TextColor
        {
            get
            {
                return m_textColor;
            }

            set
            {
                m_textColor = value;
                NotifyPropertyChanged();
            }
        }

        public string Prefix
        {
            get
            {
                return m_prefix;
            }

            set
            {
                m_prefix = value;
                NotifyPropertyChanged();
            }
        }

        public string Suffix
        {
            get
            {
                return m_suffix;
            }

            set
            {
                m_suffix = value;
                NotifyPropertyChanged();
            }
        }

        public string Filename
        {
            get
            {
                return m_filename;
            }

            set
            {
                m_filename = value;
                NotifyPropertyChanged();
            }
        }

        public string Text
        {
            get
            {
                return m_text;
            }

            set
            {
                m_text = value;
                NotifyPropertyChanged();
            }
        }

        public List<FileSection> Files
        {
            get
            {
                return m_files;
            }

            set
            {
                m_files = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Section()
        {
            m_auto = false;
            m_width = 128;
            m_height = 128;

            m_type = PlaceholderType.RECTANGLE;
            m_backgroundColor = Color.White;
            m_borderColor = Color.Black;
            m_thickness = 2;

            m_fontName = "Arial";
            m_textSize = 12;
            m_textColor = Color.Black;

            m_files = new List<FileSection>();
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
