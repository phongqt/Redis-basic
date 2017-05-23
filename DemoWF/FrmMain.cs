using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DemoWF.Models;
using DemoWF.Helpers;

namespace DemoWF
{
    public partial class FrmMain : Form
    {
        List<Notification> notificationList = new List<Notification>();
        NotificationRepository notificationRepository = new NotificationRepository();
        private string keyFriend = string.Concat("Friend:", LoginExtention.UserName);
        private string keyNotification = string.Concat("Notification:", LoginExtention.UserName);
        private string keyCounter = string.Concat("Counter:", LoginExtention.UserName);

        public FrmMain()
        {
            InitializeComponent();
            CenterToScreen();
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
            var list = RedisStackExchangeHelper.GetList<Notification>(keyNotification);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RedisStackExchangeHelper.SetList<Notification>(keyNotification, notificationList);
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

            if (tabControl.SelectedIndex != 2)
            {
                GetAll();
            }
            else
            {
                GetAllMember();
            }
        }

        private void LoadCounter(bool isIncre = true)
        {
            int count = 0;
            var totalClick = RedisStackExchangeHelper.GetDefault(keyCounter);
            int.TryParse(totalClick, out count);
            if (isIncre)
            {
                if (count == 0)
                {
                    RedisStackExchangeHelper.Set(keyCounter, 1);
                }
                else
                {
                    RedisStackExchangeHelper.Increment(keyCounter);
                }

                count++;
            }
            else
            {
                if (count > 0)
                {
                    RedisStackExchangeHelper.Decrement("Me:ClickBtn");
                }

                count--;
            }

            lblCounter.Text = (count).ToString();
        }

        private void btnDecrement_Click(object sender, EventArgs e)
        {
            LoadCounter(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var user = new Member();
            using (FrmAddMember frm = new FrmAddMember())
            {
                frm.ShowDialog();
                user = frm._memer;
                if (user != null)
                {
                    RedisStackExchangeHelper.AddListDefault(keyFriend, user);
                    //RedisStackExchangeHelper.SetMember(keyFriend, user);
                }

                GetAllMember();
            }
        }

        private void GetAllMember()
        {
            //var list = RedisStackExchangeHelper.GetMember<Member>(keyFriend);
            var list = RedisStackExchangeHelper.GetListDefault<Member>(keyFriend); 
            dataGridView1.DataSource = list;
        }

        private void btnRemoveMember_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var dataSource = dataGridView1.DataSource as List<Member>;
                var mem = dataSource[dataGridView1.CurrentRow.Index];
                RedisStackExchangeHelper.RemoveMember(keyFriend, mem);
                GetAllMember();
            }
        }
    }



}
