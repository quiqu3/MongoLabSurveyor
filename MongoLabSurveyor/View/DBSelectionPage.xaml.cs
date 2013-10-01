using Microsoft.Phone.Controls;
using MongoLabSurveyor.Service;
using MongoLabSurveyor.ViewModel;

namespace MongoLabSurveyor.View
{
    public partial class DBSelectionPage : PhoneApplicationPage
    {
        public DBSelectionPage()
        {
            InitializeComponent();

            this.DataContext = new DBSelectionViewModel(new MongoLabDataService(new StorageService()));            
        }
    }
}