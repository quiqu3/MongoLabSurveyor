using System;
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
        }

        private void Save_Click(object sender, EventArgs e)
        {
            ((DBSelectionViewModel)DataContext).SaveSelection();
        }
    }
}