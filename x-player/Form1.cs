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
    public partial class music_player : Form
    {
        public music_player()
        {
            InitializeComponent();
        }

        public String displaySongName()
        {
            string song_name = "";
            return song_name;
        }

        //Create Global variables of String Type Array to save the titles or names of the Tracks and path of the track
        String[] paths, files;
        private void clearButton_Click(object sender, EventArgs e)
        {
            selected_songs_listbox.Items.Clear();
            axWindowsMediaPlayer1.close();
        }

        private void selected_songs_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = paths[selected_songs_listbox.SelectedIndex];
        }

        private void music_player_Load(object sender, EventArgs e)
        {
            selected_songs_listbox.HorizontalScrollbar = true;
            selected_songs_listbox.ScrollAlwaysVisible = true;
        }

        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            video_player start_vp = new video_player();
            start_vp.Show();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

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
                //Code to select songs
                OpenFileDialog ofd = new OpenFileDialog();
                //Code to enable multiselection
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    files = ofd.SafeFileNames; //Save the names of the track in files array
                    paths = ofd.FileNames; //Save the paths of the tracks in path array
                                           //Display the music titles in listbox
                    for (int i = 0; i < files.Length; i++)
                    {
                        selected_songs_listbox.Items.Add(files[i]); //Display songs in listbox
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Something went wrong. Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
