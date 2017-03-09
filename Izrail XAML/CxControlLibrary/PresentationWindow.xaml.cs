using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CxControlLibrary
{
    public enum CxDialogResultEnum
        {
            OK, Cancel, Yes, No, Abort, etc
        }
    /// <summary>
    /// Interaction logic for PresentationWindow.xaml
    /// </summary>
    public partial class PresentationWindow : Window
    {
        public PresentationWindow()
        {
            InitializeComponent();
            InitCxButtonCollection();
            InitCxButtonMain(ref SaveButton);
            InitFCxButtonSub(ref FirstSubButton);
            InitSCxButtonSub(ref SecondSubButton);
            InitFirstSearchBox(ref FirstSearchTextBox);
            InitSecondSearchBox(ref SecondSearchTextBox);
            

        }
        

        private bool _isShowTaskBar;
        private CxDialogResultEnum _cxDialogResult;


        public SearchTextBoxControl SearchTextBoxControl;
        public CxDialogResultEnum CxDialogResult
        {
            get
            {
                return _cxDialogResult;
            }
            set
            {
                _cxDialogResult = value;
            }
        }
        public bool IsShowTaskBar
        {
            
            get
            {
                
                return _isShowTaskBar; 
            }
            set
            {
                this.ShowInTaskbar = value;
                _isShowTaskBar = value;
            }
        }

        public void InitCxButtonCollection()
        {
            CxClassificationButtonCollection.AddCollection(new ClassificationButton()
            {
                Color = new SolidColorBrush(Color.FromRgb(236, 58, 88)),
                Text = "Top secret",
                Name = "testBtn1"
            });
            CxClassificationButtonCollection.AddCollection(new ClassificationButton()
            //2
            {
                Color = new SolidColorBrush(Color.FromRgb(252, 120, 84)),
                Text = "Top secret",
                Name = "testBtn2"
            });
            CxClassificationButtonCollection.AddCollection(new ClassificationButton()
            //3
            {
                Color = new SolidColorBrush(Color.FromRgb(236, 58, 88)),
                Text = "Top guarded long headljnjnjnjnj",
                Name = "testBtn3"
            });

            CxClassificationButtonCollection.AddCollection(new ClassificationButton()
            //5
            {
                Color = new SolidColorBrush(Color.FromRgb(72, 247, 150)),
                Text = "Classified B",
                Name = "testBtn5",
                
                
            });
            CxClassificationButtonCollection.AddCollection(new ClassificationButton()
            //6
            {
                Color = new SolidColorBrush(Colors.White),
                Text = "Top secret",
                Name = "None2"
                
            });
            CxClassificationButtonCollection.AddCollection(new ClassificationButton()
            //7
            {
                Color = new SolidColorBrush(Colors.White),
                Text = "None",
                Name = "None", 

            });



        }
        public void InitCxButtonMain(ref CxControlLibrary.MainButton mainButton)
        {
            mainButton.Enabled = true;


            //ImageButton icon save and change
            var dir = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;
            var saveIconBitMap = new BitmapImage();

            saveIconBitMap.BeginInit();
            saveIconBitMap.UriSource = new Uri(dir + @"\CxControlLibrary\Icon\MainButton\ProtectAndSave.png");
            saveIconBitMap.EndInit();

            mainButton.IconRegular = saveIconBitMap;
            mainButton.IconHover = saveIconBitMap;
            mainButton.IconPressed = saveIconBitMap;
            mainButton.IconDisabled = saveIconBitMap;

            //add to Xaml
            mainButton.Margin = new Thickness(5);
            mainButton.CxClick += MainButton_CxClick;
        }

        private void MainButton_CxClick(object sender, EventArgs e)
        {
            CxDialogResult = CxDialogResultEnum.Yes;
            MessageBox.Show(CxDialogResult.ToString());
        }

        public void InitFCxButtonSub(ref CxControlLibrary.MainButton subButton)
        {
            subButton.Enabled = true;
            subButton.ContentText = String.Empty;//if string is Empty MainButton convert to SubButton

            ////Change Beackgroound
            //subButton.BackgroundRegular = new SolidColorBrush(Colors.White);
            //subButton.BackgroundHover = new SolidColorBrush(Color.FromRgb(198, 233, 253));
            //subButton.BackgroundPressed = new SolidColorBrush(Color.FromRgb(114, 179, 216));
            //subButton.BackgroundDisabled = new SolidColorBrush(Color.FromRgb(183, 183, 183));

            var dir = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;
            var DetailsconBitMap = new BitmapImage();

            DetailsconBitMap.BeginInit();
            DetailsconBitMap.UriSource = new Uri(dir + @"\CxControlLibrary\Icon\RoundButton\Details.png");
            DetailsconBitMap.EndInit();

            subButton.IconRegular = DetailsconBitMap;
            subButton.IconHover = DetailsconBitMap;
            subButton.IconPressed = DetailsconBitMap;
            subButton.IconDisabled = DetailsconBitMap;
        }
        public void InitSCxButtonSub(ref CxControlLibrary.MainButton subButton)
        {
            subButton.Enabled = true;
            subButton.ContentText = String.Empty;//if string is Empty MainButton convert to SubButton

            //Change Beackgroound
            subButton.BackgroundRegular = new SolidColorBrush(Colors.White);
            subButton.BackgroundHover = new SolidColorBrush(Color.FromRgb(198, 233, 253));
            subButton.BackgroundPressed = new SolidColorBrush(Color.FromRgb(114, 179, 216));
            subButton.BackgroundDisabled = new SolidColorBrush(Color.FromRgb(183, 183, 183));

            var dir = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;
            var plusIconBitMap = new BitmapImage();

            plusIconBitMap.BeginInit();
            plusIconBitMap.UriSource = new Uri(dir + @"\CxControlLibrary\Icon\RoundButton\Plus.png");
            plusIconBitMap.EndInit();

            subButton.IconRegular = plusIconBitMap;
            subButton.IconHover = plusIconBitMap;
            subButton.IconPressed = plusIconBitMap;
            subButton.IconDisabled = plusIconBitMap;

        }
        public void InitFirstSearchBox(ref UIControls.SearchTextBox serchTextBox)
        {
            SearchTextBoxControl = new SearchTextBoxControl()
            {
                This = serchTextBox,
            };
            SearchTextBoxControl.SetUserIcon("pack://application:,,,/SearchTextBox;component/Images/user.png");
            SearchTextBoxControl.SetGrupCopyIcon("pack://application:,,,/SearchTextBox;component/Images/Group copy.png");
            SearchTextBoxControl.SetSelectionStyle(UIControls.SearchTextBox.SectionsStyles.NormalStyle);
            SearchTextBoxControl.CreateSelections();  //Changing

        }
        public void InitSecondSearchBox(ref UIControls.SearchTextBox serchTextBox)
        {
            SearchTextBoxControl = new SearchTextBoxControl()
            {
                This = serchTextBox,
            };
            SearchTextBoxControl.SetUserIcon("pack://application:,,,/SearchTextBox;component/Images/user.png");
            SearchTextBoxControl.SetGrupCopyIcon("pack://application:,,,/SearchTextBox;component/Images/Group copy.png");
            SearchTextBoxControl.SetSelectionStyle(UIControls.SearchTextBox.SectionsStyles.CheckBoxStyle);
            SearchTextBoxControl.CreateSelections();  //Changing

        }

        private void CxClassificationButtonCollection_CxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = (CxControlLibrary.ClassificationButtonCollection)sender;

            if (list.SelectedItem.Text == "None")
                CustomMessageBox.Show();

            list.SortedBy = false;
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();

        }
    }
}
