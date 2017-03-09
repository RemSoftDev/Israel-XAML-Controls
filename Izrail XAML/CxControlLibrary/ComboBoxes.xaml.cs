using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CxControlLibrary
{
    /// <summary>
    /// Interaction logic for ComboBoxes.xaml
    /// </summary>
    public partial class ComboBoxes : UserControl
    {
        private bool _cxStyle;
        private object _oldItem;
        private object _newItem;
        private ObservableCollection<AutoCompleteEntry> _autoSuggestCollection;
        private AutoCompleteTextBox _autoSuggestTextBox;
        private bool _isAutoComplete;
        private ItemCollection _beckUpComboBoxItemCollection;


        public ComboBoxes()
        {
            InitializeComponent();

            _autoSuggestCollection = new ObservableCollection<AutoCompleteEntry>();
            _autoSuggestTextBox = new AutoCompleteTextBox();
            _autoSuggestTextBox.AutoCompletionList = _autoSuggestCollection;


            CombBox.DropDownOpened += CombBox_DropDownOpened;
            CombBox.SelectionChanged += CombBox_SelectionChanged;

            
        }
        public bool ReadOnly
                {
                    get
                    {
                        return CombBox.IsReadOnly;
                    }
                    set
                    {
                        CombBox.IsReadOnly = value;
                    }
                }
        public bool IsAutoComplete
        {
            get
            {
                return _isAutoComplete;
            }
            set
            {
                //    ConvertToAutoSuggestTextBox();
                AutoCompliteTB.IsComoBox = true;
                ChangeControl(value);

                _isAutoComplete = value;
            }
        }
        public object Selected
        {
            get
            {
                return CombBox.SelectedItem;
            }
            set
            {
                CombBox.SelectedItem = value;
            }
        }
        public bool CxStype
        {
            get
            {
                return _cxStyle;
            }
            set
            {
                if(value)
                {
                    RoundBorder.CornerRadius = new CornerRadius(15);
                }
                else
                {
                    RoundBorder.CornerRadius = new CornerRadius(5);
                }
                _cxStyle = value;
            }
        }
        public ItemCollection ComboBoxItemCollection
        {
            get
            {
                return CombBox.Items;
            }
        }
        public new Brush Background
        {
            get
            {
                return UC.Background;
            }
            set
            {
                UC.Background = value;
            }
        }
        public Brush ArrowColor
        {
            get
            {
                return Arrow.Foreground;
            }
            set
            {
                Arrow.Foreground = value;
            }
        }
        public Object OldItem
        {
            get
            {
                return _oldItem;
            }
            set
            {
                _oldItem = value;
            }
        }
        public Object NewItem
        {
            get
            {
                return _newItem;
            }
            set
            {
                _newItem = value;
            }
        }
        public ObservableCollection<AutoCompleteEntry> AutoComplete
        {
            get
            {
                return AutoCompliteTB.AutoCompletionList;
            }
            set
            {
                AutoCompliteTB.AutoCompletionList = value;
            }
        }
        


        public SelectionChangedEventHandler CxOnSelectionChange;
        private void CombBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (CxOnSelectionChange!=null) 
            {
                CxOnSelectionChange.Invoke(this, e);
            }
            if (!IsAutoComplete)
            {
                NewItem = CombBox.Items[CombBox.SelectedIndex];
            }
        }

        private void CreateBeckUpCollectionItem()
        {
            if (_beckUpComboBoxItemCollection == null)
            {
                _beckUpComboBoxItemCollection = (new ComboBoxes()).ComboBoxItemCollection;
            }
            else
            {
                _beckUpComboBoxItemCollection.Clear();
            }



            foreach (ComboBoxItem item in ComboBoxItemCollection)
            {
                _beckUpComboBoxItemCollection.Add(item);
            }
        }

        private static ObservableCollection<AutoCompleteEntry> GetAutoSugestCollection(ItemCollection collection)
        {
            var result = new ObservableCollection<AutoCompleteEntry>();
            foreach(ComboBoxItem item in collection)
            {
                var itemEntry = new AutoCompleteEntry(item.ToString(), "ItemsCollection");
                result.Add(itemEntry);
            }
            return result;
        }

        public EventHandler CxOnOpen;
        private void CombBox_DropDownOpened(object sender, EventArgs e)
        {
            try
            {
                OldItem = CombBox.Items[CombBox.SelectedIndex];
            }
            catch(ArgumentOutOfRangeException)
            {
                OldItem = null;
            }
            if (CxOnOpen!=null)
            {
                CxOnOpen.Invoke(this, e);
            }
        }

        public void AddCollection(CxControlLibrary.CxComboBoxItem item) 
        {    
            CombBox.Items.Add(item);

            AutoComplete.Add(new AutoCompleteEntry(item.Label, item.Label));
        }
        private void Arrow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CombBox.IsDropDownOpen = true;
            if(CxOnOpen!=null)
            {
                CxOnOpen.Invoke(this, e);
            }
        }


    }

    partial class ComboBoxes
    {
        private ComboBox _myComboBox;
        private AutoCompleteTextBox _myAutoCompliteTextBox;
        private bool _changeControl;

        public void SetComponent(ComboBox cb, AutoCompleteTextBox actb)
        {
            _myComboBox = this.UC.Children.OfType<ComboBox>().FirstOrDefault(); 
            _myAutoCompliteTextBox = this.UC.Children.OfType<AutoCompleteTextBox>().FirstOrDefault();
        }

        public void DelateComboBox()
        {
            CombBox.Visibility = Visibility.Collapsed;
        }
        public void DelateAutoCompliteBox()
        {
            AutoCompliteTB.Visibility = Visibility.Collapsed;
        }

        public void ShowComboBox()
        {
            CombBox.Visibility = Visibility.Visible;
        }
        public void ShowAutoCompliteBox()
        {
            AutoCompliteTB.Visibility = Visibility.Visible;
        }

        public void ChangeControl(bool value)
        {
            if(value)
            {
                DelateComboBox();
                ShowAutoCompliteBox();
                
            }
            else
            {
                DelateAutoCompliteBox();
                ShowComboBox();
            }
        }
    }
}
