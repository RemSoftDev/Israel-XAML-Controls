using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CxControlLibrary
{
    /// <summary>
    /// Interaction logic for ObjectList.xaml
    /// </summary>
    public partial class ObjectList : UserControl
    {
        public ObjectList()
        {
            InitializeComponent();
            
        }
        private bool _checkForAllItems;


        public event SelectionChangedEventHandler CxOnSelectionChange;
        private void ListObjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = sender as ListBox;
            for (int i = 0; i < list.Items.Count; i++)
            {
                var item = ((ObjectListItem)list.Items[i]);
                if (i == list.SelectedIndex)
                {
                    item.IsSelected = true;
                }
                else
                {
                    item.IsSelected = false;
                }
            }

            if(CxOnSelectionChange!=null)
            {
                CxOnSelectionChange.Invoke(this, e);
            }

        }
        public ItemCollection ObjectlistItemsCollection
        {
            get
            {
                return ListObjects.Items;
            }

        }
        public bool CheckForAllItems
        {
            get
            {
                return _checkForAllItems;
            }
            set
            {
                foreach(ObjectListItem objectItem in ListObjects.Items)
                {

                    if (value)
                    {
                        objectItem.IsCheked = true;
                    }
                    else
                    {
                        objectItem.IsCheked = false;
                    }
                }
                _checkForAllItems = value;
            }

        }

        private void TitleCheckBox_CxCheked(object sender, RoutedEventArgs e)
        {
            CheckForAllItems = true;
        }

        private void TitleCheckBox_CxUnCheked(object sender, RoutedEventArgs e)
        {
            CheckForAllItems = false;
        }
    }
}
