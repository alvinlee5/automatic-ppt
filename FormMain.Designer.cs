using System;
using System.Windows.Forms;

namespace AutoPoint
{
    partial class FormMain
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
            this.selectedSongsListBox = new System.Windows.Forms.ListBox();
            this.buttomRemoveSelectedSong = new System.Windows.Forms.Button();
            this.buttonEditSongList = new System.Windows.Forms.Button();
            this.songListBox = new System.Windows.Forms.ListBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonPublish
            // 
            this.buttonPublish.Location = new System.Drawing.Point(516, 388);
            this.buttonPublish.Name = "buttonPublish";
            this.buttonPublish.Size = new System.Drawing.Size(194, 40);
            this.buttonPublish.TabIndex = 6;
            this.buttonPublish.TabStop = false;
            this.buttonPublish.Text = "Publish";
            this.buttonPublish.UseVisualStyleBackColor = true;
            this.buttonPublish.Click += new System.EventHandler(this.buttonPublish_Click);
            // 
            // buttonAddNewSong
            // 
            this.buttonAddNewSong.Location = new System.Drawing.Point(248, 359);
            this.buttonAddNewSong.Name = "buttonAddNewSong";
            this.buttonAddNewSong.Size = new System.Drawing.Size(156, 69);
            this.buttonAddNewSong.TabIndex = 5;
            this.buttonAddNewSong.TabStop = false;
            this.buttonAddNewSong.Text = "Add New Song";
            this.buttonAddNewSong.UseVisualStyleBackColor = true;
            this.buttonAddNewSong.Click += new System.EventHandler(this.buttonAddNewSong_Click);
            // 
            // selectedSongsListBox
            // 
            this.selectedSongsListBox.FormattingEnabled = true;
            this.selectedSongsListBox.ItemHeight = 20;
            this.selectedSongsListBox.Location = new System.Drawing.Point(455, 48);
            this.selectedSongsListBox.Name = "selectedSongsListBox";
            this.selectedSongsListBox.Size = new System.Drawing.Size(346, 244);
            this.selectedSongsListBox.TabIndex = 4;
            this.selectedSongsListBox.TabStop = false;
            this.selectedSongsListBox.SelectedIndexChanged += new System.EventHandler(this.selectedSongsListBox_SelectedIndexChanged);
            // 
            // buttomRemoveSelectedSong
            // 
            this.buttomRemoveSelectedSong.Enabled = false;
            this.buttomRemoveSelectedSong.Location = new System.Drawing.Point(536, 316);
            this.buttomRemoveSelectedSong.Name = "buttomRemoveSelectedSong";
            this.buttomRemoveSelectedSong.Size = new System.Drawing.Size(155, 44);
            this.buttomRemoveSelectedSong.TabIndex = 3;
            this.buttomRemoveSelectedSong.TabStop = false;
            this.buttomRemoveSelectedSong.Text = "Remove";
            this.buttomRemoveSelectedSong.UseVisualStyleBackColor = true;
            this.buttomRemoveSelectedSong.Click += new System.EventHandler(this.buttonRemoveSelectedSong_Click);
            // 
            // buttonEditSongList
            // 
            this.buttonEditSongList.Location = new System.Drawing.Point(58, 359);
            this.buttonEditSongList.Name = "buttonEditSongList";
            this.buttonEditSongList.Size = new System.Drawing.Size(155, 69);
            this.buttonEditSongList.TabIndex = 2;
            this.buttonEditSongList.TabStop = false;
            this.buttonEditSongList.Text = "Edit Song List";
            this.buttonEditSongList.UseVisualStyleBackColor = true;
            this.buttonEditSongList.Click += new System.EventHandler(this.buttonEditSongList_Click);
            // 
            // songListBox
            // 
            this.songListBox.FormattingEnabled = true;
            this.songListBox.ItemHeight = 20;
            this.songListBox.Location = new System.Drawing.Point(58, 88);
            this.songListBox.Name = "songListBox";
            this.songListBox.Size = new System.Drawing.Size(346, 244);
            this.songListBox.TabIndex = 1;
            this.songListBox.TabStop = false;
            this.songListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.songListBox_OnMouseDoubleClick);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(58, 48);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(346, 26);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.TabStop = false;
            this.searchTextBox.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            this.searchTextBox.GotFocus += new System.EventHandler(this.textBoxSearch_GotFocus);
            this.searchTextBox.LostFocus += new System.EventHandler(this.textBoxSearch_LostFocus);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 456);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.songListBox);
            this.Controls.Add(this.buttonEditSongList);
            this.Controls.Add(this.buttomRemoveSelectedSong);
            this.Controls.Add(this.selectedSongsListBox);
            this.Controls.Add(this.buttonAddNewSong);
            this.Controls.Add(this.buttonPublish);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoPoint";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonPublish;
        private System.Windows.Forms.Button buttonAddNewSong;
        private ListBox selectedSongsListBox;
        private Button buttomRemoveSelectedSong;
        private Button buttonEditSongList;
        private ListBox songListBox;
        private TextBox searchTextBox;
    }
}

