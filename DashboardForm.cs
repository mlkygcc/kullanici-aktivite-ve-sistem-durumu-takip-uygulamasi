using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UserActivity
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(DashboardForm_FormClosed);
        }

        private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private string connectionString = @"Data Source=MELEK\SQLEXPRESS;Initial Catalog=UserActivityDB;Integrated Security=True;TrustServerCertificate=True;";
        private void DashboardForm_Load(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT Username FROM Sessions WHERE Username IS NOT NULL";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            cmbUsers.Items.Add(reader["Username"].ToString());
                        }

                        if (cmbUsers.Items.Count > 0)
                        {
                            cmbUsers.SelectedIndex = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kullanıcı listesi çekilirken bir hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        private string SureyiMetneCevir(int toplamSaniye)
        {
            TimeSpan time = TimeSpan.FromSeconds(toplamSaniye);

            if (time.TotalHours >= 1)
            {
                return $"{(int)time.TotalHours} Saat {time.Minutes} Dakika";
            }
            else if (time.TotalMinutes >= 1)
            {
                return $"{time.Minutes} Dakika {time.Seconds} Saniye";
            }
            else
            {
                return $"{time.Seconds} Saniye";
            }
        }

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedItem == null)
            {
                MessageBox.Show("Lütfen raporu getirilecek kullanıcıyı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedUser = cmbUsers.SelectedItem.ToString();
            DateTime selectedDate = dtpDate.Value.Date;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                a.EventType AS [Durum],
                CONVERT(VARCHAR(8), a.StartTime, 108) AS [Başlangıç Zamanı],
                CONVERT(VARCHAR(8), a.EndTime, 108) AS [Bitiş Zamanı],
                DATEDIFF(SECOND, a.StartTime, ISNULL(a.EndTime, GETDATE())) AS [RawSeconds]
            FROM ActivityLogs a
            INNER JOIN Sessions s ON a.SessionID = s.SessionID
            WHERE s.Username = @Username 
              AND CAST(a.StartTime AS DATE) = @SelectedDate
            ORDER BY a.StartTime DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", selectedUser);
                    cmd.Parameters.AddWithValue("@SelectedDate", selectedDate);

                    try
                    {
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Seçilen güne ait herhangi bir aktivite kaydı bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvLogs.DataSource = null; 
                            return;
                        }

                        int totalWorkSeconds = 0;
                        int totalActiveSeconds = 0;
                        int totalPassiveSeconds = 0;
                        int totalLockedSeconds = 0;

                        if (!dt.Columns.Contains("Süre"))
                        {
                            dt.Columns.Add("Süre", typeof(string));
                        }

                        foreach (DataRow row in dt.Rows)
                        {
                            int currentSeconds = Convert.ToInt32(row["RawSeconds"]);
                            string currentStatus = row["Durum"].ToString();

                            totalWorkSeconds += currentSeconds;

                            if (currentStatus == "Aktif")
                            {
                                totalActiveSeconds += currentSeconds;
                            }
                            else if (currentStatus == "Pasif" || currentStatus == "Uyku") 
                            {
                                totalPassiveSeconds += currentSeconds;
                            }
                            else if (currentStatus == "Kilitli")
                            {
                                totalLockedSeconds += currentSeconds;
                            }

                            row["Süre"] = SureyiMetneCevir(currentSeconds);
                        }

                        lblTotalWork.Text = "Toplam Çalışma Süresi: " + SureyiMetneCevir(totalWorkSeconds);
                        lblTotalActive.Text = "Aktif Süre: " + SureyiMetneCevir(totalActiveSeconds);
                        lblTotalPassive.Text = "Pasif Süre: " + SureyiMetneCevir(totalPassiveSeconds);
                        lblTotalLocked.Text = "Kilitli Kalma Süresi: " + SureyiMetneCevir(totalLockedSeconds);

                        dt.Columns.Remove("RawSeconds");
                        dgvLogs.DataSource = dt;
                        dgvLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Rapor çekilirken veritabanı hatası oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
