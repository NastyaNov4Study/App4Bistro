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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DGridDishes.ItemsSource = Nov4PracEntities1.GetContext().Блюда.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Блюда));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var dishesForRemoving = DGridDishes.SelectedItems.Cast<Блюда>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующее {dishesForRemoving.Count()} элементы)", "Выполнение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {

                Nov4PracEntities1.GetContext().Блюда.RemoveRange(dishesForRemoving);
                Nov4PracEntities1.GetContext().SaveChanges();
                MessageBox.Show("Данные удалены");

                DGridDishes.ItemsSource = Nov4PracEntities1.GetContext().Блюда.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

            private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                if (Visibility == Visibility.Visible)
                {
                    Nov4PracEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    DGridDishes.ItemsSource = Nov4PracEntities1.GetContext().Блюда.ToList();
                }
            }
        }
    }

