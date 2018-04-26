using Fasetto.Word.Core;
using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();

            DataContext = new DialogWindowViewModel(this);

            (DataContext as DialogWindowViewModel).Title = "Message Title";
        }
    }
}
