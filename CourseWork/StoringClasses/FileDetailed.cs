using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public class FileDetailed
    {
        public string Path { get; set; }
        public string FileName { get { return Path.Split(new char[] { '\\', '\\' }).Last(); } }
        public string Display { get { return FileName.Split('.')[0]; } }
        public ListViewItem GetListViewItem(string iconId = null)
        {
            var item = new ListViewItem();
            item.Text = item.ToolTipText = Display;
            item.Name = Path;
            if (iconId != null)
                item.ImageKey = iconId;
            return item;
        }
        public override string ToString()
        {
            return Display;
        }
        public FileDetailed(string path)
        {
            Path = path;
        }
    }
}
