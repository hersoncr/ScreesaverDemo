/*
 * ScreenSaverForm.cs
 * By Frank McCown
 * Summer 2010
 * 
 * Feel free to modify this code.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace ScreenSaver
{
    public partial class ScreenSaverForm : Form
    {
        #region Win32 API functions

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

        #endregion

        private Point pictureBoxAcceleration;
        private Point pictureBoxLocation;
        private Point mouseLocation;
        private bool previewMode = false;
        private Random rand = new Random();

        public ScreenSaverForm()
        {
            InitializeComponent();
        }

        public ScreenSaverForm(Rectangle Bounds)
        {
            InitializeComponent();
            this.Bounds = Bounds;
        }

        public ScreenSaverForm(IntPtr PreviewWndHandle)
        {
            InitializeComponent();

            // Set the preview window as the parent of this window
            SetParent(this.Handle, PreviewWndHandle);

            // Make this a child window so it will close when the parent dialog closes
            SetWindowLong(this.Handle, -16, new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));

            // Place our window inside the parent
            Rectangle ParentRect;
            GetClientRect(PreviewWndHandle, out ParentRect);
            Size = ParentRect.Size;
            Location = new Point(0, 0);

            // Make text smaller
            //textLabel.Font = new System.Drawing.Font("Arial", 6);

            previewMode = true;
        }

        private void ScreenSaverForm_Load(object sender, EventArgs e)
        {            
            LoadSettings();

            Cursor.Hide();            
            TopMost = true;

            pictureBoxAcceleration.X = 3;
            pictureBoxAcceleration.Y = 3;
            moveTimer.Interval = 1000;
            moveTimer.Tick += new EventHandler(moveTimer_Tick);
            moveTimer.Start();

        }

        private void moveTimer_Tick(object sender, System.EventArgs e)
        {
            if (pictureBoxLocation.IsEmpty)
            {
                // Move text to new location
                bisonPictureBox.Left = pictureBoxLocation.X = rand.Next(Math.Max(1, Bounds.Width - bisonPictureBox.Width));
                bisonPictureBox.Top =  pictureBoxLocation.Y =rand.Next(Math.Max(1, Bounds.Height - bisonPictureBox.Height));
                 
            }
            else
            {
                int newY = pictureBoxLocation.Y + pictureBoxAcceleration.Y;
                int newX = pictureBoxLocation.X + pictureBoxAcceleration.X;
                if (newY < 1 || newY > Bounds.Height - bisonPictureBox.Height)
                {
                    pictureBoxAcceleration.Y *= -1;
                }
                if (newX < 1 || newX > Bounds.Width - bisonPictureBox.Width)
                {
                    pictureBoxAcceleration.X *= -1;
                }

                bisonPictureBox.Left = newX;
                bisonPictureBox.Top = newY;
            }
            if (pictureBoxLocation.Y < 1)
            {
                pictureBoxLocation.Y = 1;
            }
            else if (pictureBoxLocation.Y > Bounds.Height - bisonPictureBox.Height)
            {
                pictureBoxLocation.Y = Bounds.Height - bisonPictureBox.Height;
            }

            if (pictureBoxLocation.X < 1)
            {
                pictureBoxLocation.X = 1;
            }
            else if (pictureBoxLocation.X > Bounds.Width - bisonPictureBox.Width)
            {
                pictureBoxLocation.X = Bounds.Width - bisonPictureBox.Width;
            }
        }

        private void LoadSettings()
        {
            // Use the string from the Registry if it exists
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Demo_ScreenSaver");
            //if (key == null)
                //bisonPictureBox.Text = "C# Screen Saver";
            //else
                //textLabel.Text = (string)key.GetValue("text");
        }

        private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!previewMode)
            {
                if (!mouseLocation.IsEmpty)
                {
                    // Terminate if mouse is moved a significant distance
                    if (Math.Abs(mouseLocation.X - e.X) > 5 ||
                        Math.Abs(mouseLocation.Y - e.Y) > 5)
                        Application.Exit();
                }

                // Update current mouse location
                mouseLocation = e.Location;
            }
        }

        private void ScreenSaverForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!previewMode)
                Application.Exit();
        }

        private void ScreenSaverForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (!previewMode)
                Application.Exit();
        }
    }
}
