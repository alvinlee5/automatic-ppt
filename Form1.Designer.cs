using System;
using System.Windows.Forms;

namespace AutoPoint
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonPublish = new System.Windows.Forms.Button();
            this.buttonAddNewSong = new System.Windows.Forms.Button();
            this.songComboBox = new System.Windows.Forms.ComboBox();
            this.selectedSongsListBox = new System.Windows.Forms.ListBox();
            this.buttonAddSelectedSong = new System.Windows.Forms.Button();
            this.buttomRemoveSelectedSong = new System.Windows.Forms.Button();
            this.buttonEditSongList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPublish
            // 
            this.buttonPublish.Location = new System.Drawing.Point(511, 398);
            this.buttonPublish.Name = "buttonPublish";
            this.buttonPublish.Size = new System.Drawing.Size(194, 40);
            this.buttonPublish.TabIndex = 1;
            this.buttonPublish.Text = "Publish";
            this.buttonPublish.UseVisualStyleBackColor = true;
            this.buttonPublish.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonAddNewSong
            // 
            this.buttonAddNewSong.Location = new System.Drawing.Point(511, 131);
            this.buttonAddNewSong.Name = "buttonAddNewSong";
            this.buttonAddNewSong.Size = new System.Drawing.Size(194, 69);
            this.buttonAddNewSong.TabIndex = 2;
            this.buttonAddNewSong.Text = "Add New Song";
            this.buttonAddNewSong.UseVisualStyleBackColor = true;
            this.buttonAddNewSong.Click += new System.EventHandler(this.button3_Click);
            // 
            // songComboBox
            // 
            this.songComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.songComboBox.FormattingEnabled = true;
            this.songComboBox.Location = new System.Drawing.Point(42, 36);
            this.songComboBox.Name = "songComboBox";
            this.songComboBox.Size = new System.Drawing.Size(254, 28);
            this.songComboBox.Sorted = true;
            this.songComboBox.TabIndex = 3;
            this.songComboBox.SelectionChangeCommitted += new System.EventHandler(this.songComboBox_SelectionChangeCommitted);
            // 
            // selectedSongsListBox
            // 
            this.selectedSongsListBox.FormattingEnabled = true;
            this.selectedSongsListBox.ItemHeight = 20;
            this.selectedSongsListBox.Location = new System.Drawing.Point(42, 95);
            this.selectedSongsListBox.Name = "selectedSongsListBox";
            this.selectedSongsListBox.Size = new System.Drawing.Size(346, 284);
            this.selectedSongsListBox.TabIndex = 4;
            this.selectedSongsListBox.SelectedIndexChanged += new System.EventHandler(this.selectedSongsListBox_SelectedIndexChanged);
            // 
            // buttonAddSelectedSong
            // 
            this.buttonAddSelectedSong.Enabled = false;
            this.buttonAddSelectedSong.Location = new System.Drawing.Point(317, 33);
            this.buttonAddSelectedSong.Name = "buttonAddSelectedSong";
            this.buttonAddSelectedSong.Size = new System.Drawing.Size(71, 35);
            this.buttonAddSelectedSong.TabIndex = 5;
            this.buttonAddSelectedSong.Text = "Add";
            this.buttonAddSelectedSong.UseVisualStyleBackColor = true;
            this.buttonAddSelectedSong.Click += new System.EventHandler(this.buttonAddSelectedSong_Click);
            // 
            // buttomRemoveSelectedSong
            // 
            this.buttomRemoveSelectedSong.Enabled = false;
            this.buttomRemoveSelectedSong.Location = new System.Drawing.Point(139, 395);
            this.buttomRemoveSelectedSong.Name = "buttomRemoveSelectedSong";
            this.buttomRemoveSelectedSong.Size = new System.Drawing.Size(122, 43);
            this.buttomRemoveSelectedSong.TabIndex = 6;
            this.buttomRemoveSelectedSong.Text = "Remove";
            this.buttomRemoveSelectedSong.UseVisualStyleBackColor = true;
            this.buttomRemoveSelectedSong.Click += new System.EventHandler(this.buttonRemoveSelectedSong_Click);
            // 
            // buttonEditSongList
            // 
            this.buttonEditSongList.Location = new System.Drawing.Point(511, 216);
            this.buttonEditSongList.Name = "buttonEditSongList";
            this.buttonEditSongList.Size = new System.Drawing.Size(194, 69);
            this.buttonEditSongList.TabIndex = 7;
            this.buttonEditSongList.Text = "Edit Song List";
            this.buttonEditSongList.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonEditSongList);
            this.Controls.Add(this.buttomRemoveSelectedSong);
            this.Controls.Add(this.buttonAddSelectedSong);
            this.Controls.Add(this.selectedSongsListBox);
            this.Controls.Add(this.songComboBox);
            this.Controls.Add(this.buttonAddNewSong);
            this.Controls.Add(this.buttonPublish);
            this.Name = "Form1";
            this.Text = "AutoPoint";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonPublish;
        private System.Windows.Forms.Button buttonAddNewSong;
        private System.Windows.Forms.ComboBox songComboBox;
        private ListBox selectedSongsListBox;
        private Button buttonAddSelectedSong;
        private Button buttomRemoveSelectedSong;
        private Button buttonEditSongList;
    }
}

