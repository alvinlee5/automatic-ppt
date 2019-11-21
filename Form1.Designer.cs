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
            this.button3 = new System.Windows.Forms.Button();
            this.songComboBox = new System.Windows.Forms.ComboBox();
            this.selectedSongsListBox = new System.Windows.Forms.ListBox();
            this.buttonAddSelectedSong = new System.Windows.Forms.Button();
            this.buttomRemoveSelectedSong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPublish
            // 
            this.buttonPublish.Location = new System.Drawing.Point(528, 377);
            this.buttonPublish.Name = "buttonPublish";
            this.buttonPublish.Size = new System.Drawing.Size(194, 40);
            this.buttonPublish.TabIndex = 1;
            this.buttonPublish.Text = "Publish";
            this.buttonPublish.UseVisualStyleBackColor = true;
            this.buttonPublish.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(84, 348);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(206, 69);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // songComboBox
            // 
            this.songComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.songComboBox.FormattingEnabled = true;
            this.songComboBox.Location = new System.Drawing.Point(42, 36);
            this.songComboBox.Name = "songComboBox";
            this.songComboBox.Size = new System.Drawing.Size(279, 28);
            this.songComboBox.Sorted = true;
            this.songComboBox.TabIndex = 3;
            this.songComboBox.SelectionChangeCommitted += new System.EventHandler(this.songComboBox_SelectionChangeCommitted);
            // 
            // selectedSongsListBox
            // 
            this.selectedSongsListBox.FormattingEnabled = true;
            this.selectedSongsListBox.ItemHeight = 20;
            this.selectedSongsListBox.Location = new System.Drawing.Point(500, 36);
            this.selectedSongsListBox.Name = "selectedSongsListBox";
            this.selectedSongsListBox.Size = new System.Drawing.Size(247, 244);
            this.selectedSongsListBox.TabIndex = 4;
            this.selectedSongsListBox.SelectedIndexChanged += new System.EventHandler(this.selectedSongsListBox_SelectedIndexChanged);
            // 
            // buttonAddSelectedSong
            // 
            this.buttonAddSelectedSong.Location = new System.Drawing.Point(366, 32);
            this.buttonAddSelectedSong.Name = "buttonAddSelectedSong";
            this.buttonAddSelectedSong.Size = new System.Drawing.Size(87, 35);
            this.buttonAddSelectedSong.TabIndex = 5;
            this.buttonAddSelectedSong.Text = "Add";
            this.buttonAddSelectedSong.UseVisualStyleBackColor = true;
            this.buttonAddSelectedSong.Enabled = false;
            this.buttonAddSelectedSong.Click += new System.EventHandler(this.buttonAddSelectedSong_Click);
            // 
            // buttomRemoveSelectedSong
            // 
            this.buttomRemoveSelectedSong.Location = new System.Drawing.Point(565, 286);
            this.buttomRemoveSelectedSong.Name = "buttomRemoveSelectedSong";
            this.buttomRemoveSelectedSong.Size = new System.Drawing.Size(122, 43);
            this.buttomRemoveSelectedSong.TabIndex = 6;
            this.buttomRemoveSelectedSong.Text = "Remove";
            this.buttomRemoveSelectedSong.UseVisualStyleBackColor = true;
            this.buttomRemoveSelectedSong.Enabled = false;
            this.buttomRemoveSelectedSong.Click += new System.EventHandler(this.buttonRemoveSelectedSong_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttomRemoveSelectedSong);
            this.Controls.Add(this.buttonAddSelectedSong);
            this.Controls.Add(this.selectedSongsListBox);
            this.Controls.Add(this.songComboBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonPublish);
            this.Name = "Form1";
            this.Text = "AutoPoint";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonPublish;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox songComboBox;
        private ListBox selectedSongsListBox;
        private Button buttonAddSelectedSong;
        private Button buttomRemoveSelectedSong;
    }
}

