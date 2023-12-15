using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
            
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(@"Data Source=ADCLG1;Initial Catalog=Nov4Prac;Integrated Security=True"))
                {
                    sqlConnection.Open();
                    string query = "SELECT COUNT(1) FROM Users WHERE LoginUser=@LoginUser AND PassUser=@PassUser";
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.Parameters.AddWithValue("@LoginUser", login.Text);
                        sqlCommand.Parameters.AddWithValue("@PassUser", password.Text);
                        int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                        if (count == 1)
                        {
                            String allowchar = "";
                            String login1 = login.Text;
                            String password1 = password.Text;
                            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
                            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
                            allowchar += "1,2,3,4,5,6,7,8,9,0";
                            char[] a = { ',' };
                            String[] ar = allowchar.Split(a);
                            String pwd = "";
                            string temp = "";
                            Random r = new Random();
                            for (int i = 0; i < 6; i++)
                            {
                                temp = ar[(r.Next(0, ar.Length))];
                                pwd += temp;
                            }
                            textBox1.Text = pwd;
                           
                           
                        }
                        else
                        {
                            MessageBox.Show("Данных нет в базе или ввод некорректный");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (checkCap.Text == textBox1.Text)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильно");
            }
        }
    }
}
