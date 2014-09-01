using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace JustTicket.Engining.Actions
{
    public class ShowImageAction : Action
    {
        public string FileName
        {
            get;
            set;
        }

        public override void Execute()
        {
            base.Execute();

            Form form = new Form();
            PictureBox pb = new PictureBox();
            pb.Top = 20;
            pb.Left = 20;
            pb.Width = 200;
            pb.Height = 40;
            pb.BackgroundImageLayout = ImageLayout.Stretch;
            pb.Image = new Bitmap(FileName);

            form.Controls.Add(pb);
            form.ShowDialog();
        }
    }
}
