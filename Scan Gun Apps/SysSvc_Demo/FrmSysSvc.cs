using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NSysSvcApi;

namespace SysSvc_Demo
{
    public partial class FrmSysSvc : Form
    {
        private struct BackLightBrightness
        {
            public ushort SetValue;
            public ushort WriteValueInAC;
            public bool isChangeInAC;
            public ushort WriteValueinBAT;
            public bool isChangeInBAT;
        }

        SysSvcApi SysService;
        BackLightBrightness Brightness;

        bool FlashLightOn = false;

        public FrmSysSvc()
        {
            InitializeComponent();

            //m_usValue = new ushort();
            Brightness = new BackLightBrightness();
            Brightness.isChangeInAC = false;
            Brightness.isChangeInBAT = false;


            SysService = new SysSvcApi();

            comboBox1.SelectedIndex = 0;

            // usValue = Mode passed to the time-out value is set power save mode.
            ushort usValue = new ushort();
            // Backlight brightness set to the power mode, calculate.
            SysService.BacklightReadBrightness(SysSvcApi.MODE_AC, ref usValue);
            comboBox7.SelectedIndex = 0;
            numericUpDown5.Value = usValue;
            Brightness.WriteValueInAC = usValue;
            SysService.BacklightReadBrightness(SysSvcApi.MODE_BAT, ref usValue);
            Brightness.WriteValueinBAT = usValue;
            // For each power mode, set the current time-out value is calculated.
            SysService.BacklightReadTimeoutValue(SysSvcApi.MODE_AC, ref usValue);
            comboBox8.SelectedIndex = 0;
            numericUpDown6.Value = usValue;

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;

            textBox1.Text = SysService.DeviceID;
            textBox2.Text = SysService.UUID;

            // Calculate the current power state of the WLAN module.
            bool bPower = false;
            SysService.GetWlanPowerStatus(ref bPower);
            comboBox2.SelectedIndex = bPower ? 0 : 1;
            comboBox3.SelectedIndex = 1;
            comboBox4.SelectedIndex = 1;

            ushort nBrightness = 0;
            SysService.BacklightGetBrightness(ref nBrightness);
            numericUpDown5.Value = nBrightness;
            comboBox7.SelectedIndex = 0;
            comboBox7.Enabled = false;

        }

        private void pnlBacklight_GotFocus(object sender, EventArgs e)
        {

        }

        // Vibrator motor and enable / disable the.
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
                SysService.SetVibratorEnable(true);
            else
                SysService.SetVibratorEnable(false);
        }

        // WLAN module or the power is removed.
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bPower = false;
            SysService.GetWlanPowerStatus(ref bPower);

            if (comboBox2.SelectedIndex == 0)
            {
                SysService.SetWlanPowerEnable(true);
            }
            else
            {
                SysService.SetWlanPowerEnable(false);
            }
        }


        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ushort usValue = new ushort();
            //Byte Mode = new byte();
            //if (comboBox7.SelectedIndex == 0)
            //    Mode = SysSvcApi.MODE_AC;
            //else
            //    Mode = SysSvcApi.MODE_BAT;

            //// Backlight brightness set to the power mode, calculate.
            //SysService.BacklightReadBrightness(Mode, ref usValue);
            //numericUpDown5.Value = usValue;
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            // In the current power mode set the backlight brightness values.
            SYSSVC_RESULT result = SYSSVC_RESULT.SYSSVC_RESULT_FAILURE;
            result = SysService.BacklightSetBrightness((ushort)numericUpDown5.Value);
            if (result != SYSSVC_RESULT.SYSSVC_RESULT_SUCCESS)
                MessageBox.Show(result.ToString());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Byte Mode = new byte();

            if (comboBox7.SelectedIndex == 0)
            {
                Mode = SysSvcApi.MODE_AC;
                Brightness.isChangeInAC = true;
                Brightness.WriteValueInAC = (ushort)numericUpDown5.Value;
            }
            else
            {
                Mode = SysSvcApi.MODE_BAT;
                Brightness.isChangeInBAT = true;
                Brightness.WriteValueinBAT = (ushort)numericUpDown5.Value;
            }

            // Backlight brightness values corresponding to the power mode is set.
            SysService.BacklightWriteBrightness(Mode, (ushort)numericUpDown5.Value);
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            ushort usValue = new ushort();
            Byte Mode = new byte();
            if (comboBox8.SelectedIndex == 0)
                Mode = SysSvcApi.MODE_AC;
            else
                Mode = SysSvcApi.MODE_BAT;

            // For each power mode, set the current time-out value is calculated.
            SysService.BacklightReadTimeoutValue(Mode, ref usValue);
            numericUpDown6.Value = usValue;
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            SYSSVC_RESULT result = SYSSVC_RESULT.SYSSVC_RESULT_FAILURE;
            ushort nSeconds = 0;
            byte Mode = 0;

            Mode = comboBox8.SelectedIndex == 0 ? SysSvcApi.MODE_AC : SysSvcApi.MODE_BAT;
            nSeconds = (ushort)numericUpDown6.Value;

            result = SysService.BacklightWriteTimeoutValue(Mode, nSeconds);
            if (result != SYSSVC_RESULT.SYSSVC_RESULT_SUCCESS)
                MessageBox.Show(result.ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Byte Mode = new byte();

            if (comboBox8.SelectedIndex == 0)
                Mode = SysSvcApi.MODE_AC;
            else
                Mode = SysSvcApi.MODE_BAT;

            // Power Mode time-out setting. User input(touch tap or key press)if no hours set the backlight is off.
            SysService.BacklightWriteTimeoutValue(Mode, (ushort)numericUpDown6.Value);
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Byte Mode = new byte();
            ushort usTimeout = new ushort();
            SYSSVC_RESULT result = new SYSSVC_RESULT();


            if (comboBox1.SelectedIndex == 0)
                Mode = SysSvcApi.MODE_AC;
            else
                Mode = SysSvcApi.MODE_BAT;

            // Power mode is set to suspend time-out value is read.
            result = SysService.SuspendReadTimeoutValue(Mode, ref usTimeout);
            if (result != SYSSVC_RESULT.SYSSVC_RESULT_SUCCESS)
            {
                MessageBox.Show(result.ToString());
                return;
            }

            numericUpDown1.Value = usTimeout;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Byte Mode = new byte();
            SYSSVC_RESULT result = new SYSSVC_RESULT();

            if (comboBox1.SelectedIndex == 0)
                Mode = SysSvcApi.MODE_AC;
            else
                Mode = SysSvcApi.MODE_BAT;

            // Power mode to suspend time-out value.
            result = SysService.SuspendWriteTimeoutValue(Mode, (ushort)numericUpDown1.Value);
            if (result != SYSSVC_RESULT.SYSSVC_RESULT_SUCCESS)
            {
                MessageBox.Show(result.ToString());
                return;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SYSSVC_RESULT result = SYSSVC_RESULT.SYSSVC_RESULT_FAILURE;
            ushort nSeconds = 0;

            if (comboBox1.SelectedIndex == 0)   // AC
            {
                result = SysService.SuspendReadTimeoutValue(SysSvcApi.MODE_AC, ref nSeconds);
            }
            else if (comboBox1.SelectedIndex == 1)  // BAT
            {
                result = SysService.SuspendReadTimeoutValue(SysSvcApi.MODE_BAT, ref nSeconds);
            }

            numericUpDown1.Value = nSeconds;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            SYSSVC_RESULT result = SYSSVC_RESULT.SYSSVC_RESULT_FAILURE;
            ushort nSeconds = 0;
            byte Mode = 0;

            Mode = comboBox1.SelectedIndex == 0 ? SysSvcApi.MODE_AC : SysSvcApi.MODE_BAT;
            nSeconds = (ushort)numericUpDown1.Value;

            result = SysService.SuspendWriteTimeoutValue(Mode, nSeconds);
            if (result != SYSSVC_RESULT.SYSSVC_RESULT_SUCCESS)
                MessageBox.Show(result.ToString());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SYSSVC_RESULT result = SYSSVC_RESULT.SYSSVC_RESULT_FAILURE;

            result = SysService.SoftReset();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SYSSVC_RESULT result = SYSSVC_RESULT.SYSSVC_RESULT_FAILURE;
            bool Power = false;

            if (comboBox4.SelectedIndex == 0)
            {
                Power = true;
                result = SysService.EnableFlashLight(Power);
            }
            else
            {
                Power = false;
                result = SysService.EnableFlashLight(Power);
            }

            if (result != SYSSVC_RESULT.SYSSVC_RESULT_SUCCESS)
                MessageBox.Show(result.ToString());
            else
                FlashLightOn = Power;
        }

        private void FrmSysSvc_Closing(object sender, CancelEventArgs e)
        {
            if (FlashLightOn)
                SysService.EnableFlashLight(false);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SysService.EnterSuspendState();
        }

        public void SleepWakeupCallback(bool bEnterSleep)
        {
            if (bEnterSleep)
                MessageBox.Show("SleepWakeupCallback : Sleep");
            else
                MessageBox.Show("SleepWakeupCallback : Wakeup");
        }

        private void btnSetSleepNotification_Click(object sender, EventArgs e)
        {
            // Sleep/wakeup notification service and receive an application to register a callback.
            SysService.SleepWakeupNotificationSet(new SysSvcApi.SleepWakeupNotifyCALLBACK(SleepWakeupCallback));
        }

        private void btnResetSleepNotification_Click(object sender, EventArgs e)
        {
            // Registered sleep /wakeup notification service frees a callback.
            SysService.SleepWakeupNotificationReset();
        }
    }
}