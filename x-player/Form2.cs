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
    public partial class video_player : Form
    {
        public video_player()
        {
            InitializeComponent();
        }

        //Create Global variables of String Type Array to save the titles or names of the Tracks and path of the track
        String[] paths, files;

        private void clearButton_Click(object sender, EventArgs e)
        {
            selected_videos_listbox.Items.Clear();
            axWindowsMediaPlayer1.close();
        }

        private void video_player_Load(object sender, EventArgs e)
        {
            selected_videos_listbox.HorizontalScrollbar = true;
            selected_videos_listbox.ScrollAlwaysVisible = true;
        }

        private void selected_videos_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = paths[selected_videos_listbox.SelectedIndex];
        }

        private void fullscreen_button_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.fullScreen = true;
        }

        private void musicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            music_player start_mp = new music_player();
            start_mp.Show();
        }

        private void pictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picture_viewer start_pw = new picture_viewer();
            start_pw.Show();
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
                //Code to select videos
                OpenFileDialog ofd = new OpenFileDialog();
                //Code to enable multiselection
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    files = ofd.SafeFileNames; //Save the names of the track in files array
                    paths = ofd.FileNames; //Save the paths of the tracks in path array
                                           //Display the video titles in listbox
                    for (int i = 0; i < files.Length; i++)
                    {
                        selected_videos_listbox.Items.Add(files[i]); //Display videos in listbox
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong. Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
