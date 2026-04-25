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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Obuw6.Modeli;
using System.Data.Entity;

namespace Obuw6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Polzovatel _tekuchiyPolzovatel;
        public MainWindow(Polzovatel polzovatel)
        {
            InitializeComponent();
            _tekuchiyPolzovatel = polzovatel;
            txtPolzovatel.Text = _tekuchiyPolzovatel == null ? "Вы вошли как Гость" : $"{_tekuchiyPolzovatel.Fio} ({_tekuchiyPolzovatel.Rol.Nazvanie})";

            Zagruzka();
        }
        private void Zagruzka()
        {

            using (var db = new ObuwKontext())
            {
                LvElement.ItemsSource = db.Tovari
                    .Include(t => t.Postavchik)
                    .Include(t => t.Proizvoditel)
                    .Include(t => t.Kategoriya)
                    .Include(t => t.EdinicaIzmereniya)
                    .ToList();

            }
        }

        private void Vihod(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            this.Close();
        }
    }
}
