using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ordShop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            using (var db = new ordShopEntities())
            {
                //load clients
                List<ord_clients> result = db.ord_clients.ToList();
                List<ComboItem> clients = new List<ComboItem>();
                clients.Add(new ComboItem { ID = 0, Text = "Seleccione" });
                foreach (var client in result)
                {
                    clients.Add(new ComboItem { ID = Convert.ToInt32(client.id), Text = client.name });
                }

                comboBox1.DataSource = clients;
                comboBox1.DisplayMember = "Text";
                comboBox1.ValueMember = "ID";

                //load productos
                
                List<ord_products> resultProducts = db.ord_products.ToList();
                List<ComboItem> products = new List<ComboItem>();
                products.Add(new ComboItem { ID = 0, Text = "Seleccione" });
                foreach (var product in resultProducts)
                {
                    products.Add(new ComboItem { ID = Convert.ToInt32(product.id), Text = product.name });
                }
                comboBox2.DataSource = products;
                comboBox2.DisplayMember = "Text";
                comboBox2.ValueMember = "ID";

                //table productos
                
            }

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        class ComboItem
        {
            public int ID { get; set; }
            public string Text { get; set; }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
