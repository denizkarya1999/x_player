using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace x_player
{
    public partial class picture_viewer : Form
    {
        public picture_viewer()
        {
            InitializeComponent();
        }

        //Create Global variables of String Type Array to save the titles or names of the Tracks and path of the track
        String[] paths, files;

        private void clearButton_Click(object sender, EventArgs e)
        {
            selected_pictures_listbox.Items.Clear();
            pictureBox.Image = null;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            selected_pictures_listbox.HorizontalScrollbar = true;
            selected_pictures_listbox.ScrollAlwaysVisible = true;
        }

        private void selected_pictures_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox.Image = Image.FromFile(paths[selected_pictures_listbox.SelectedIndex]);
        }

        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            video_player start_vp = new video_player();
            start_vp.Show();
        }

        private void musicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            video_player start_vp = new video_player();
            start_vp.Show();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            about start_a = new about();
            start_a.Show();
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            try
            {
                //Code to select pictures
                OpenFileDialog ofd = new OpenFileDialog();
                //Code to enable multiselection
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    files = ofd.SafeFileNames; //Save the names of the track in files array
                    paths = ofd.FileNames; //Save the paths of the tracks in path array
                                           //Display the picture titles in listbox
                    for (int i = 0; i < files.Length; i++)
                    {
                        selected_pictures_listbox.Items.Add(files[i]); //Display pictures in listbox
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong. Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            {

            }
        }
    }
}
