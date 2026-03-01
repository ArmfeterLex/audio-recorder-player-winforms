using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using NAudio.Wave;
using NAudio.FileFormats;
using NAudio;

namespace WindowsFormsApp19
{
    public partial class Form1 : Form
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi)]
        public static extern int mciSendString(string strCommand, StringBuilder strReturnString, int cchReturn, IntPtr hwndCallback);

        WaveIn waveIn;
        WaveFileWriter writer;
        string outputFilename = "recorded_sound.wav";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Type wmpType = Type.GetTypeFromProgID("WMPlayer.OCX");
                dynamic WMP = Activator.CreateInstance(wmpType);
                this.Text = WMP.versionInfo;
                WMP.URL = @"E:\Системное программирование\WindowsFormsApp19\music.wma";
                WMP.controls.play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка воспроизведения WMA: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileName = @"E:\Системное программирование\WindowsFormsApp19\town.MID";
            mciSendString("open " + fileName + " type sequencer alias player", null, 0, IntPtr.Zero);
            mciSendString("play player", null, 0, IntPtr.Zero);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mciSendString("close player", null, 0, IntPtr.Zero);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Start Recording");
                waveIn = new WaveIn();
                waveIn.DeviceNumber = 0;
                waveIn.DataAvailable += waveIn_DataAvailable;
                waveIn.RecordingStopped += waveIn_RecordingStopped;
                waveIn.WaveFormat = new WaveFormat(8000, 1);
                writer = new WaveFileWriter(outputFilename, waveIn.WaveFormat);
                waveIn.StartRecording();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (waveIn != null)
            {
                StopRecording();
            }
        }

        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler<WaveInEventArgs>(waveIn_DataAvailable), sender, e);
            }
            else
            {
                writer.Write(e.Buffer, 0, e.BytesRecorded);
            }
        }

        void StopRecording()
        {
            MessageBox.Show("StopRecording");
            waveIn.StopRecording();
        }

        private void waveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler<StoppedEventArgs>(waveIn_RecordingStopped), sender, e);
            }
            else
            {
                waveIn.Dispose();
                waveIn = null;
                writer.Close();
                writer = null;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, @"d:\help\dotnet.chm", "win32map.html");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Help.ShowHelpIndex(this, @"d:\help\dotnet.chm");
        }
    }
}