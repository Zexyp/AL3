
namespace Rekurze
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LenUpDown = new System.Windows.Forms.NumericUpDown();
            this.LenTrackBar = new System.Windows.Forms.TrackBar();
            this.SpaceTrackBar = new System.Windows.Forms.TrackBar();
            this.SpaceUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.LenUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpaceTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpaceUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // LenUpDown
            // 
            this.LenUpDown.Location = new System.Drawing.Point(12, 12);
            this.LenUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.LenUpDown.Name = "LenUpDown";
            this.LenUpDown.Size = new System.Drawing.Size(74, 27);
            this.LenUpDown.TabIndex = 0;
            this.LenUpDown.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.LenUpDown.ValueChanged += new System.EventHandler(this.LenUpDown_ValueChanged);
            // 
            // LenTrackBar
            // 
            this.LenTrackBar.Location = new System.Drawing.Point(92, 12);
            this.LenTrackBar.Maximum = 500;
            this.LenTrackBar.Name = "LenTrackBar";
            this.LenTrackBar.Size = new System.Drawing.Size(218, 56);
            this.LenTrackBar.TabIndex = 1;
            this.LenTrackBar.ValueChanged += new System.EventHandler(this.LenTrackBar_ValueChanged);
            // 
            // SpaceTrackBar
            // 
            this.SpaceTrackBar.Location = new System.Drawing.Point(92, 74);
            this.SpaceTrackBar.Maximum = 100;
            this.SpaceTrackBar.Minimum = 1;
            this.SpaceTrackBar.Name = "SpaceTrackBar";
            this.SpaceTrackBar.Size = new System.Drawing.Size(218, 56);
            this.SpaceTrackBar.TabIndex = 3;
            this.SpaceTrackBar.Value = 1;
            this.SpaceTrackBar.ValueChanged += new System.EventHandler(this.SpaceTrackBar_ValueChanged);
            // 
            // SpaceUpDown
            // 
            this.SpaceUpDown.Location = new System.Drawing.Point(12, 74);
            this.SpaceUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpaceUpDown.Name = "SpaceUpDown";
            this.SpaceUpDown.Size = new System.Drawing.Size(74, 27);
            this.SpaceUpDown.TabIndex = 2;
            this.SpaceUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.SpaceUpDown.ValueChanged += new System.EventHandler(this.SpaceUpDown_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(512, 660);
            this.Controls.Add(this.SpaceTrackBar);
            this.Controls.Add(this.SpaceUpDown);
            this.Controls.Add(this.LenTrackBar);
            this.Controls.Add(this.LenUpDown);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MainForm";
            this.Text = "Window";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LenUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpaceTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpaceUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown LenUpDown;
        private System.Windows.Forms.TrackBar LenTrackBar;
        private System.Windows.Forms.TrackBar SpaceTrackBar;
        private System.Windows.Forms.NumericUpDown SpaceUpDown;
    }
}

