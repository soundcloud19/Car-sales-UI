using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace Car_sales_UI
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void get_button_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44341/");
                HttpResponseMessage response = client.GetAsync("api/customers/").Result;
                var customer = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
                customerDataGridView.DataSource = customer;
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer() {CustomerId = Convert.ToInt64(customerId.Text), CustomerDetails = customerDetails.Text};
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44341/");
            HttpResponseMessage response = client.PostAsJsonAsync("api/customers/", customer).Result; 
        }

        private void customerDetails_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44341/");
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = client.GetAsync("api/customers/"+idTextBox.Text).Result;
            Customer customer = response.Content.ReadAsAsync<Customer>().Result;
            List<Customer> customerList = new List<Customer>();
            customerList.Add(customer);
            customerDataGridView.DataSource = customerList;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44341/");
            HttpResponseMessage response = client.DeleteAsync("api/customers/"+customerId.Text).Result;
        }
    }
}
