using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Classes;
using WindowsFormsApplication1.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;
using Xceed;

namespace WindowsFormsApplication1
{
    
    public partial class WelcomeForm : Form
    {
       
        public static User user = Main.user1;
        
        public static Client client1;
        public int RoomKey = 0;
        public int ServiceKey = 0;
        public string RoomName = "";
        public bool trg = true;
        public string ServiceName = "";
        public int TotalPrice = 0;
        public List<Order> orders = new List<Order>();
        public WelcomeForm()
        {
            InitializeComponent();
            trg = true;

            checkedListBoxServices.Items.Clear();
            if (client1 == null)
            {
                buttonHistory.Enabled = false;
            }
            else
            {
                buttonHistory.Enabled = true;
            }
            bool trg1 = true;
            using (UserContext db = new UserContext())
            {
                //textBoxCash.Text = user.sum.ToString();
                foreach (Client client in db.Clients)
                {
                    if (Main.user1.Id == client.userId)
                    {
                        client1 = client;
                        trg1 = true;
                        break;
                    }
                    else
                    {
                        trg1 = false;
                    }
                }
                if (trg1)
                {
                    foreach (Order order1 in db.Orders)
                    {
                        if (client1.id == order1.clientId)
                        {
                            orders.Add(order1);
                        }
                    }
                }

                foreach (Order order in orders)
                {
                    if (!order.isPaid && !order.isDeleted)
                    {
                        RoomKey = order.roomId;
                        ServiceKey = order.serviceId;
                        TotalPrice = order.totalPrice;
                        foreach (Room room in db.Rooms)
                        {
                            if (RoomKey == room.id)
                            {
                                RoomName = room.category;
                            }
                        }
                        foreach (Service service in db.Services)
                        {
                            if (ServiceKey == service.id)
                            {
                                ServiceName = service.name;
                            }
                        }
                        checkedListBoxServices.Items.Add("[" + order.id + "] Комната типа: " + RoomName + " с пакетом услуг " + ServiceName + ". Стоимость: " + Convert.ToString(TotalPrice));
                    }
                }
            }
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (User user1 in db.Users)
                {
                    if (user1.Id == client1.userId) {
                        textBoxCash.Text = user1.sum.ToString();
                        user = user1;
                    }
                }
                
            }
        }

        private void WelcomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (trg)
            {
                Main.main.Show();
            }   
            else
            {
               
            }
            //MessageBox.Show("Выберите один из вариантов","Сообщение",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1,MessageBoxOptions.DefaultDesktopOnly);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
       
        private void buttonAddCash_Click(object sender, EventArgs e)
        {
            trg = false;
            this.Close();
            CashAccount CashAcc = new CashAccount();
            CashAcc.Show();           
           
        }
        public bool IsCreated = false;
        private void buttonBookARoom_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (Client client in db.Clients)
                {
                    if (user.Id == client.userId)
                    {
                        IsCreated = true;
                    }
                }
                if (!IsCreated)
                {
                    PersonalData pd = new PersonalData();
                    pd.Show();
                    this.Hide();
                }
                else
                {
                   
                    BookARoom bookARoom = new BookARoom();
                    bookARoom.Show();
                    this.Hide();
                }
            }
        }
        public int totalPrice = 0;
        List<Order> checkedOrders = new List<Order>();
        private void checkedListBoxServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedOrders.Clear();
            using (UserContext db = new UserContext())
            {
                for (int i = 0; i < checkedListBoxServices.CheckedItems.Count; i++)
                {
                    int count = 1;
                    string checkedOrder = checkedListBoxServices.CheckedItems[i].ToString();
                    string orderId = "";
                    while (checkedOrder[count] != ']')
                    {
                        orderId += checkedOrder[count];
                        count++;
                    }
                    foreach (Order order in db.Orders)
                    {
                        if (order.id == Convert.ToInt32(orderId))
                        {
                            checkedOrders.Add(order);
                            
                        }
                    }
                }                
            }
            totalPrice = 0;
            if (checkedListBoxServices.CheckedItems.Count != 0)
            {               
                    foreach(Order order in checkedOrders)
                {
                    totalPrice += order.totalPrice;
                    textBoxTotalPrice.Text = totalPrice.ToString();
                }             
            }
            else
            {
                totalPrice = 0;
                textBoxTotalPrice.Text = "0";
            }

            //         ---неудачная попытка построения логики---
            //foreach (string checkedItem in checkedListBoxServices.Items)
            //{
            //    for (int i = 0; i < orders.Count; i++)
            //    {
            //        if (checkedItem[1] == Convert.ToChar(orders[i].id))
            //        {
            //            totalPrice += orders[i].totalPrice;
            //            textBoxTotalPrice.Text = totalPrice.ToString();
            //        }
            //    }
            //}

        }
        private void OutputFile()
        {
            string pathDocument = AppDomain.CurrentDomain.BaseDirectory + "first.docx";
            DocX document = DocX.Create(pathDocument);
            document.InsertParagraph("ЧЕК").Bold().Font("Times New Roman").FontSize(18).Alignment = Alignment.center;
            Table table = document.AddTable(checkedListBoxServices.CheckedItems.Count, 1);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;
            for (int i = 0; i < checkedListBoxServices.CheckedItems.Count; i++)
            {
                table.Rows[i].Cells[0].Paragraphs[0].Append(checkedListBoxServices.CheckedItems[i].ToString()).Font("Times New Roman").FontSize(14);
               
            }
            document.InsertParagraph().InsertTableAfterSelf(table);
            document.InsertParagraph("Итого: " + totalPrice.ToString()).Font("Times New Roman").FontSize(14).Alignment = Alignment.center;
            document.Save();
        }
        List<Order> ordersPaid = new List<Order>();
        private void buttonPayServices_Click(object sender, EventArgs e)
        {
            
            using (UserContext db = new UserContext())
            {
                if (Convert.ToInt32(textBoxCash.Text) > totalPrice)
                {
                    foreach(User user1 in db.Users)
                    {
                        if (user1.Id == client1.userId)
                        {
                            user1.sum -= totalPrice;
                            textBoxCash.Text = user1.sum.ToString();
                        }
                    }
                    

                    for (int i = 0; i < checkedListBoxServices.CheckedItems.Count; i++)
                    {
                        int count = 1;
                        string checkedOrder = checkedListBoxServices.CheckedItems[i].ToString();
                        string orderId = "";
                        while(checkedOrder[count] != ']')
                        {
                            orderId += checkedOrder[count];
                            count++;
                        }
                        
                        foreach (Order order in db.Orders)
                        {
                            if (order.id == Convert.ToInt32(orderId))
                            {
                                DialogResult dialogResult = MessageBox.Show("Сохранить чек ?", "Сообщение", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    OutputFile();
                                }
                                else if (dialogResult == DialogResult.No)
                                {

                                }
                                ordersPaid.Add(order);
                                                                                        
                                
                            }
                        }                                                
                    }
                    foreach(Order order1 in db.Orders)
                    {
                        foreach (Order order in ordersPaid)
                        {
                            if (order1.id == order.id)
                            {
                                order1.isPaid = true;
                            }
                        }
                    }
                    checkedListBoxServices.Items.Clear();
                    ordersPaid.Clear();
                    trg = false;
                    Success success = new Success();
                    success.Show();
                    this.Close();                                        
                }
                else
                {
                    MessageBox.Show("Пополните ваш счет", "Сообщение");
                }
                db.SaveChanges();
            }
        }

        private void buttonDeleteServices_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                for (int i = 0; i <= checkedListBoxServices.CheckedItems.Count; i++)
                {
                    int count = 1;
                    string checkedOrder = checkedListBoxServices.CheckedItems[i].ToString();
                    string orderId = "";
                    while (checkedOrder[count] != ']')
                    {
                        orderId += checkedOrder[count];
                        count++;
                    }
                    MessageBox.Show(orderId);
                    foreach (Order order in db.Orders)
                    {
                        if (order.id == Convert.ToInt32(orderId))
                        {
                            order.isDeleted = true;
                            checkedListBoxServices.Items.Remove(checkedListBoxServices.CheckedItems[i]);
                            orders.Remove(order);
                        }
                    }

                }
                db.SaveChanges();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
                OrderHistory orderHistory = new OrderHistory();
                orderHistory.Show();
                this.Close();
                Main.main.Hide();
            
        }

        private void buttonChangeData_Click(object sender, EventArgs e)
        {
            ChangeData changeData = new ChangeData();
            changeData.Show();
            this.Close();
            Main.main.Hide();
        }
    }
}
