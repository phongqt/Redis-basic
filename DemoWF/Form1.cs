using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoWF.Models;
using DemoWF.Helpers;
using System.Reflection;

namespace DemoWF
{
    public partial class btnCacheAllBySEx : Form
    {
        List<Notification> notificationList = new List<Notification>();
        NotificationRepository notificationRepository = new NotificationRepository();
        public btnCacheAllBySEx()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        private void btnCacheAll_Click(object sender, EventArgs e)
        {
            RedisServiceStackHelper redis = new RedisServiceStackHelper();
            redis.DeleteAll<Notification>();
            foreach (var item in notificationList)
            {
                redis.SetObject<Notification>(item);
            }

            MessageBox.Show("Cached successful!");
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            GetAll();
        }

        private void GetAll()
        {
            RedisServiceStackHelper redis = new RedisServiceStackHelper();
            notificationList = redis.GetAll<Notification>().ToList();
            if (notificationList.Count == 0)
            {
                notificationList = notificationRepository.GetAll();
            }

            dataGridView1.DataSource = notificationList;
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            RedisServiceStackHelper redis = new RedisServiceStackHelper();
            var model = redis.GetByKey<Notification>(txtId.Text.Trim());
            if (model != null)
            {
                var dataSource = notificationList.Where(x => x.ID == int.Parse(txtId.Text.Trim())).ToList();
                dataGridView1.DataSource = dataSource;
            }
        }

        private void btnGetAllBySEx_Click(object sender, EventArgs e)
        {
            var list = RedisStackExchangeHelper.GetList<Notification>("Me:notification");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RedisStackExchangeHelper.SetList<Notification>("Me:notification", notificationList);
        }

        private void btnIncr_Click(object sender, EventArgs e)
        {
            LoadCounter();
        }

        private void tabControl_TabIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
            {
                LoadCounter();
            }
        }

        private void LoadCounter(bool isIncre = true)
        {
            int count = 0;
            var totalClick = RedisStackExchangeHelper.GetDefault("Counter:ClickBtn");
            int.TryParse(totalClick, out count);
            if (isIncre)
            {
                if (count == 0)
                {
                    RedisStackExchangeHelper.Set("Counter:ClickBtn", 1);
                }
                else
                {
                    RedisStackExchangeHelper.Increment("Counter:ClickBtn");
                }

                count++;
            }
            else
            {
                if (count > 0)
                {
                    RedisStackExchangeHelper.Decrement("Counter:ClickBtn");
                }

                count--;
            }

            lblCounter.Text = (count).ToString();
        }

        private void btnDecrement_Click(object sender, EventArgs e)
        {
            LoadCounter(false);
        }
    }



}
