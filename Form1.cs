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
        List<KeyValuePair<int, int>> products = new List<KeyValuePair<int, int>>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            using (var db = new ordShopEntities1())
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
                dataGridView1.ColumnCount = 4;

               
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                    new Font(dataGridView1.Font, FontStyle.Bold);

                dataGridView1.Name = "dataGridView1";                
                dataGridView1.Size = new Size(400, 100);
                dataGridView1.AutoSizeRowsMode =
                    DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                dataGridView1.ColumnHeadersBorderStyle =
                    DataGridViewHeaderBorderStyle.Single;
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                dataGridView1.GridColor = Color.Black;
                dataGridView1.RowHeadersVisible = false;

                dataGridView1.Columns[0].Name = "Code";
                dataGridView1.Columns[1].Name = "Name";
                dataGridView1.Columns[2].Name = "Value";
                dataGridView1.Columns[3].Name = "Cantidad";                                

            }            
        }

        /// <summary>
        /// Crear orden de compra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int clientId = Convert.ToInt32(comboBox1.SelectedValue);
            //validaciones
            if (clientId == 0)
            {
                MessageBox.Show("Seleccione un cliente valido"); return;
            }
                
            if(products.Count == 0)
            {
                MessageBox.Show("La orden de compra debe tener por lo menos un producto"); return;
            }
                

            int idHead = createHeadOrder(clientId);
            
            for (int i = 0; i < products.Count; i++)
            {
                ord_purchaseOrdersBody body = new ord_purchaseOrdersBody();

                //get info
                body.idOrder = idHead;
                int idProduct = products[i].Key;
                body.idProduct = idProduct;
                int cant = products[i].Value;
                body.cant = cant;
                using (var db = new ordShopEntities1())
                {
                    var product = db.ord_products.Where(c => c.id == idProduct).FirstOrDefault();
                    decimal valorTotal = cant * product.value;
                    body.valueUnit = product.value;
                    body.valueTotal = valorTotal;
                    body.priority = true;
                    body.date = DateTime.Now;
                    //add ordr body
                    db.ord_purchaseOrdersBody.Add(body);
                    db.SaveChanges();
                }                
            }
            MessageBox.Show("Order de compra creada corectamente");

        }

        private static int createHeadOrder(int idClient)
        {
            using(var db = new ordShopEntities1())
            {
                var head = new ord_purchaseOrders();
                head.idClient = idClient;
                head.date = DateTime.Now;
                db.ord_purchaseOrders.Add(head);
                db.SaveChanges();

                var idHead = db.ord_purchaseOrders.OrderByDescending(s => s.id).FirstOrDefault();
                return Convert.ToInt32(idHead.id);
            }

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

        /// <summary>
        /// Boton de agregar producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            int idProduct = Convert.ToInt32(comboBox2.SelectedValue);
            string cant = textBox1.Text;
            if (idProduct == 0)
            {
                MessageBox.Show("Seleccione un producto valido");
                return;                
            }

            using(var db = new ordShopEntities1())
            {
                var product = db.ord_products.Where(s => s.id == idProduct).FirstOrDefault();
                //agregamos el producto al inventario
                products.Add(new KeyValuePair<int, int>(idProduct, Convert.ToInt32(cant)));

                string[] row0 = { product.code, product.name, Convert.ToString(product.value), cant};
                dataGridView1.Rows.Add(row0);
            }
                

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
