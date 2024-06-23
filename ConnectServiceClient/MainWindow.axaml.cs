using System.Threading.Tasks;
using Avalonia.Controls;
using ReactiveUI;

namespace ConnectServiceClient
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
        
    }
}