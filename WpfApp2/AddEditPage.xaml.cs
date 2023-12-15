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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Блюда _currentDish = new Блюда();
        public AddEditPage(Блюда selectedDish)
        {
            InitializeComponent();

            if (selectedDish != null)
            {
                _currentDish = selectedDish;
            }
            DataContext = _currentDish;
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentDish.Название_блюда))
            {
                errors.AppendLine("Укажите название блюда");
            }
            if (string.IsNullOrWhiteSpace(_currentDish.Вид_блюда))
            {
                errors.AppendLine("Укажите вид блюда");

            }
            if (string.IsNullOrWhiteSpace(_currentDish.Изображение))
            {
                errors.AppendLine("Укажите название файла изображения");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentDish.Код_блюда == 0)
            {
                Nov4PracEntities1.GetContext().Блюда.Add(_currentDish);
            }
            try
            {
                Nov4PracEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
