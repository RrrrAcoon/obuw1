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
using System.Data.Entity;
using Obuw6.Modeli;

namespace Obuw6
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            using(var db = new ObuwKontext())
            {
                db.Database.Initialize(false);
            }
        }

        private void Knopka1(object sender, RoutedEventArgs e)
        {
            using(var db = new ObuwKontext())
            {
                var polzovatel = db.Polzovateli
                    .Include(p => p.Rol)
                    .FirstOrDefault(p=> p.Login == txtLogin.Text && txtParol.Text == p.Parol);

                if(polzovatel != null)
                {
                    new MainWindow(polzovatel).Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }

        private void Knopka2(object sender, RoutedEventArgs e)
        {
            new MainWindow(null).Show();
            this.Close();

        }
    }
}
