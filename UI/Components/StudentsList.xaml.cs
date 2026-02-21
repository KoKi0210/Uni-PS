using System.Windows.Controls;
using UI.ViewModel;

namespace UI.Components
{
    /// <summary>
    /// Interaction logic for StudentsList.xaml
    /// </summary>
    public partial class StudentsList : UserControl
    {
        public StudentsList()
        {
            InitializeComponent();
            
            this.DataContext = new StudentsViewModel();
        }
    }
}
