using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CxControlLibrary
{
    /// <summary>
    /// Interaction logic for ClassificationButtonCollection.xaml
    /// </summary>
    public partial class ClassificationButtonCollection : UserControl
    {

        public ClassificationButtonCollection()
        {
            InitializeComponent();
            FactoryButtonToList();

        }

        private ObservableCollection<ClassificationButton> _listButton;
        private bool _sortedBy;

        public int SelectedIndex
        {
            get
            {
                return ButtonList.SelectedIndex;
            }

            set
            {
                ButtonList.SelectedIndex = value;
            }
        }
        public String Title
        {
            get
            {
                return TitleTextBlock.Text;
            }
            set
            {
                TitleTextBlock.Text = value;
            }
        }
        public ClassificationButton SelectedItem
        {
            get
            {
                return (CxControlLibrary.ClassificationButton)ButtonList.SelectedItem ;
            }
            set
            {
                ButtonList.SelectedItem = (object)value;
            }
        }
        public Visibility HaveMoreButton
        {
            get
            {
                return MoreButton.Visibility;
            }
            set
            {
                MoreButton.Visibility = value; 
            }
        }
        public bool IsUseMore
        {
            get
            {
                return IsUseMore;
            }
            set
            {
                if(value)
                {
                    HaveMoreButton = Visibility.Visible;
                }
                else
                {
                    HaveMoreButton = Visibility.Collapsed;
                }
            }
        }
        public bool SortedBy
        {
            get
            {
                return _sortedBy;
            }
            set
            {
                foreach (ClassificationButton btn in _listButton)
                {
                    btn.SortBy = value;
                }
                _sortedBy = value;
            }
        }
        
        private void FactoryButtonToList()
        {
            _listButton = new ObservableCollection<ClassificationButton>();
            ButtonList.Items.Clear();
        }

        public void AddCollection(ClassificationButton button) //add button
        {
            _listButton.Add(button);
            Sort();
            ButtonList.ItemsSource = _listButton;
        }
        private void Sort()
        {
            var List = new List<ClassificationButton>(_listButton);
            List.Sort();
            _listButton = new ObservableCollection<ClassificationButton>(List);    
        }
        public event SelectionChangedEventHandler CxSelectionChanged;
        private void ButtonList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            _listButton[ButtonList.SelectedIndex].OnClick();

            (ButtonList.ItemContainerGenerator
                        .ContainerFromIndex(ButtonList.SelectedIndex) as ListBoxItem)
                        .Background = new SolidColorBrush(Color.FromRgb(71, 104, 126));

            _listButton[ButtonList.SelectedIndex].Background = new SolidColorBrush(Color.FromRgb(71, 104, 126));



            SelectedIndex = ButtonList.SelectedIndex;
            for (int i = 0; i < ButtonList.Items.Count; i++)
            {
                if (i != SelectedIndex)
                {
                    _listButton[i].Selected = false;
                    _listButton[i].Highlighted = false;

                    (ButtonList.ItemContainerGenerator
                        .ContainerFromIndex(i) as ListBoxItem)
                        .Background = new SolidColorBrush(Color.FromRgb(61,70,83));

                    _listButton[ButtonList.SelectedIndex].Background = new SolidColorBrush(Color.FromRgb(71, 104, 126));

                }
               

            }

            if (CxSelectionChanged != null)
            {
                CxSelectionChanged.Invoke(this, e);
            }
            else
            {
                CustomMessageBox.ShowMessageHandler("SelectionChanged");
                return;
            }

        }

        public event RoutedEventHandler CxMoreClick;

        private void MoreButton_Click(object sender, RoutedEventArgs e)
        {
            if(CxMoreClick!=null)
            {
                CxMoreClick.Invoke(this,e);
            }
            else
            {
                CustomMessageBox.ShowMessageHandler("CxMoreClick");
                return;
            }
        }
    }
}
