using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UserActivity
{
    public partial class Form1 : Form
    {

        private string connectionString = @"Data Source=MELEK\SQLEXPRESS;Initial Catalog=UserActivityDB;Integrated Security=True;TrustServerCertificate=True;";

        private int currentSessionId = 0;

        private string currentStatus = "";

        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            public static readonly int SizeOf = Marshal.SizeOf(typeof(LASTINPUTINFO));
            public uint cbSize;
            public uint dwTime;
        }

        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        private int GetIdleTime()
        {
            LASTINPUTINFO lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint)Marshal.SizeOf(lastInPut);
            GetLastInputInfo(ref lastInPut);

            return ((int)Environment.TickCount - (int)lastInPut.dwTime);
        }

        public Form1()
        {
            InitializeComponent();

            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);

            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                LogActivity("Kilitli");
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                LogActivity("Aktif");
            }
        }

        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.Suspend)
            {
                LogActivity("Uyku");
            }
            else if (e.Mode == PowerModes.Resume)
            {
                LogActivity("Aktif");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string windowsUser = Environment.UserName; 
            DateTime loginTime = DateTime.Now;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Sessions (Username, LoginTime) 
                         VALUES (@Username, @LoginTime);
                         SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", windowsUser);
                    cmd.Parameters.AddWithValue("@LoginTime", loginTime);

                    try
                    {
                        conn.Open();
                        currentSessionId = Convert.ToInt32(cmd.ExecuteScalar());

                        LogActivity("Aktif");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message);
                    }
                }
            }

            this.Opacity = 0;
            this.Hide();
        }

        private void LogActivity(string eventType)
        {
            if (currentSessionId == 0) return;

            DateTime now = DateTime.Now;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string updateQuery = @"UPDATE ActivityLogs 
                                   SET EndTime = @Now 
                                   WHERE SessionID = @SessionID AND EndTime IS NULL";

                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@Now", now);
                        updateCmd.Parameters.AddWithValue("@SessionID", currentSessionId);
                        updateCmd.ExecuteNonQuery();
                    }

                    string insertQuery = @"INSERT INTO ActivityLogs (SessionID, EventType, StartTime) 
                                   VALUES (@SessionID, @EventType, @Now)";

                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@SessionID", currentSessionId);
                        insertCmd.Parameters.AddWithValue("@EventType", eventType);
                        insertCmd.Parameters.AddWithValue("@Now", now);
                        insertCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)

        {
            if (currentSessionId == 0)
            {
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                try
                {
                    conn.Open();
                    DateTime now = DateTime.Now;

                    string sessionQuery = "UPDATE Sessions SET LogoutTime = @Now WHERE SessionID = @SessionID";
                    using (SqlCommand cmdSession = new SqlCommand(sessionQuery, conn))
                    {
                        cmdSession.Parameters.AddWithValue("@Now", now);
                        cmdSession.Parameters.AddWithValue("@SessionID", currentSessionId);
                        cmdSession.ExecuteNonQuery();
                    }

                    string activityQuery = "UPDATE ActivityLogs SET EndTime = @Now WHERE SessionID = @SessionID AND EndTime IS NULL";
                    using (SqlCommand cmdActivity = new SqlCommand(activityQuery, conn))
                    {
                        cmdActivity.Parameters.AddWithValue("@Now", now);
                        cmdActivity.Parameters.AddWithValue("@SessionID", currentSessionId);
                        cmdActivity.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int idleTime = GetIdleTime();
            string newStatus = "";

            if (idleTime > 5000)
            {
                newStatus = "Pasif";
            }
            else
            {
                newStatus = "Aktif";
            }

            if (newStatus != currentStatus)
            {
                LogActivity(newStatus); 
                currentStatus = newStatus; 
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide(); 
                notifyIcon1.Visible = true; 
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show(); 
            this.WindowState = FormWindowState.Normal;
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rolDeğiştirÇıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.OpenForms["LoginForm"].Show();
            this.Close();
        }
    }
}
