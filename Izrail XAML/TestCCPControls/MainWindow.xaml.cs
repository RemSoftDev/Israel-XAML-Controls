using CxControlLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

namespace TestCCPControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            PresentationWindow win = new PresentationWindow();
            //this.Hide();
          //  win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
           // win.Close();
            FirstInit();
            //SecondInit();
            win.Show();
        }


        public void SecondInit()
        {
            var Dialog = new CxControlLibrary.CxDialog();
            Dialog.HorizontalAlignment = HorizontalAlignment.Center;


            XAMLStackPanel.Children.Add(Dialog); //add to Xaml

            Dialog.Name = "Dialog";
        }

        /// <summary>
        /// How Create Control in C#
        /// </summary>
        public void FirstInit()
        {
            InitializeClassificationButton(); //How Crate Classification Button
            InitializeClassificationButton1();
            InitializeClasificationButtonCollection(); //How Create Clasification Button Collection
            InitializeClasificationButtonCollection2();
            InitializeMainButton(); //How Create MainButton
            InitializeMainButton2();
            //InitializeMainButton3();
            InitializeSubButton(); //How Create Sub Button
            InitializeAddUserButton(); //How Create AddUserButton

            InitializeTextBox(); //How Crate TextBox
            //вводити текст в текст бок потрібно при наведенні курсора на текстове поле.
            InitializeRectComboBoxes(); //How Create RectComboBox
            InitializeRoundComboBoxes(); //How Create RoundComboBox
            InitializeObjectList(); //How Create ObjectList
        }

        public void InitializeClassificationButton()
        {
            var ClassificationButton = new ClassificationButton();
            ClassificationButton.HorizontalAlignment = HorizontalAlignment.Center;
            ClassificationButton.VerticalAlignment = VerticalAlignment.Center;
            ClassificationButton.Color = new SolidColorBrush(Colors.Green);

            // add to Xaml
            ClassificationButton.Text = "ClassificationButtonTest";
            ClassificationButton.Name = "ClassificationButton";
            ClassificationButton.Margin = new Thickness(5);
            ClassificationButton.Highlighted = true;
            
            XAMLStackPanel.Children.Add(ClassificationButton); 

        }

        public void InitializeClassificationButton1()
        {
            var ClassificationButton1 = new ClassificationButton();
            ClassificationButton1.HorizontalAlignment = HorizontalAlignment.Center;
            ClassificationButton1.VerticalAlignment = VerticalAlignment.Center;
            ClassificationButton1.Color = new SolidColorBrush(Colors.Green);

            // add to Xaml
            ClassificationButton1.Text = "ClassificationButtonTest";
            ClassificationButton1.Name = "ClassificationButton";
            ClassificationButton1.Margin = new Thickness(5);
            ClassificationButton1.Highlighted = false;

            XAMLStackPanel.Children.Add(ClassificationButton1);

        }


        public void InitializeClasificationButtonCollection()
        {
            var ClassificationButtonCollection = new CxControlLibrary.ClassificationButtonCollection();
            ClassificationButtonCollection.HorizontalAlignment = HorizontalAlignment.Center;
            ClassificationButtonCollection.VerticalAlignment = VerticalAlignment.Center;


            ClassificationButtonCollection.AddCollection(new ClassificationButton()
            {
                Color = new SolidColorBrush(Color.FromRgb(236, 58, 88)),
                Text = "Top secret",
                Name = "testBtn1",
                SortIndex = 6
            });
            ClassificationButtonCollection.AddCollection(new ClassificationButton()
            //2
            {
                Color = new SolidColorBrush(Color.FromRgb(252, 120, 84)),
                Text = "Top secret",
                Name = "testBtn2",
                SortIndex = 5
            });
            ClassificationButtonCollection.AddCollection(new ClassificationButton()
            //3
            {
                Color = new SolidColorBrush(Color.FromRgb(236, 58, 88)),
                Text = "Top guarded long headljnjnjnjnj",
                Name = "testBtn3",
                SortIndex = 4
            });
            ClassificationButtonCollection.AddCollection(new ClassificationButton()
            //4
            {
                Color = new SolidColorBrush(Color.FromRgb(252, 222, 83)),
                Text = "Guarded",
                Name = "testBtn4",
                SortIndex = 3
            });
            ClassificationButtonCollection.AddCollection(new ClassificationButton()
            //5
            {
                Color = new SolidColorBrush(Color.FromRgb(72, 247, 150)),
                Text = "Classified B",
                Name = "testBtn5",
                SortIndex = 2
            });
            ClassificationButtonCollection.AddCollection(new ClassificationButton()
            //6
            {
                Color = new SolidColorBrush(Colors.White),
                Text = "Top secret",
                Name = "None",
                SortIndex = 1
            });
            ClassificationButtonCollection.AddCollection(new ClassificationButton()
            //6
            {
                Color = new SolidColorBrush(Colors.White),
                Text = "None",
                Name = "None",
                SortIndex = 0
            });

            
            XAMLStackPanel.Children.Add(ClassificationButtonCollection); // add to Xaml
            
            ClassificationButtonCollection.Name = "ClassificationButtonCollection";
            ClassificationButtonCollection.Margin = new Thickness(5);
            ClassificationButtonCollection.HaveMoreButton = Visibility.Collapsed; //visible or hiden button more

        }

        public void InitializeClasificationButtonCollection2()
        {
            var ClassificationButtonCollection2 = new CxControlLibrary.ClassificationButtonCollection();
            ClassificationButtonCollection2.HorizontalAlignment = HorizontalAlignment.Center;
            ClassificationButtonCollection2.VerticalAlignment = VerticalAlignment.Center;


            ClassificationButtonCollection2.AddCollection(new ClassificationButton()
            {
                Color = new SolidColorBrush(Color.FromRgb(236, 58, 88)),
                Text = "Top secret",
                Name = "testBtn1"
            });
            ClassificationButtonCollection2.AddCollection(new ClassificationButton()
            //2
            {
                Color = new SolidColorBrush(Color.FromRgb(252, 120, 84)),
                Text = "Top secret",
                Name = "testBtn2"
            });
            ClassificationButtonCollection2.AddCollection(new ClassificationButton()
            //3
            {
                Color = new SolidColorBrush(Color.FromRgb(236, 58, 88)),
                Text = "Top guarded long headljnjnjnjnj",
                Name = "testBtn3"
            });
            ClassificationButtonCollection2.AddCollection(new ClassificationButton()
            //4
            {
                Color = new SolidColorBrush(Color.FromRgb(252, 222, 83)),
                Text = "Guarded",
                Name = "testBtn4"
            });
            //ClassificationButtonCollection2.AddCollection(new ClassificationButton()
            ////5
            //{
            //    Color = new SolidColorBrush(Color.FromRgb(72, 247, 150)),
            //    Text = "Classified B",
            //    Name = "testBtn5"
            //});
            //ClassificationButtonCollection2.AddCollection(new ClassificationButton()
            ////6
            //{
            //    Color = new SolidColorBrush(Colors.White),
            //    Text = "Top secret",
            //    Name = "None"
            //});
            //ClassificationButtonCollection2.AddCollection(new ClassificationButton()
            ////6
            //{
            //    Color = new SolidColorBrush(Colors.White),
            //    Text = "None",
            //    Name = "None"
            //});


            XAMLStackPanel.Children.Add(ClassificationButtonCollection2); // add to Xaml
            ClassificationButtonCollection2.Name = "ClassificationButtonCollection2";
            ClassificationButtonCollection2.Margin = new Thickness(5);
            ClassificationButtonCollection2.HaveMoreButton = Visibility.Visible; //visible or hiden button more

        }


        public void InitializeMainButton()
        {
            var MainButton = new CxControlLibrary.MainButton();
            MainButton.HorizontalAlignment = HorizontalAlignment.Center;
            MainButton.Enabled = true;


            //ImageButton icon save and change
           var saveIconBitMap = new BitmapImage();

            saveIconBitMap.BeginInit();
            saveIconBitMap.UriSource = new Uri("pack://application:,,,/Icon/MainButton/ProtectAndSave.png");
            saveIconBitMap.EndInit();

            MainButton.IconRegular = saveIconBitMap;
            MainButton.IconHover = saveIconBitMap;
            MainButton.IconPressed = saveIconBitMap;
            MainButton.IconDisabled = saveIconBitMap;

            XAMLStackPanel.Children.Add(MainButton); //add to Xaml

            MainButton.Name = "MainButton";
            MainButton.Margin = new Thickness(5);
        }

        public void InitializeMainButton2()
        {
            var MainButton = new CxControlLibrary.MainButton();
            MainButton.HorizontalAlignment = HorizontalAlignment.Center;
            MainButton.Enabled = true;


            //ImageButton icon save and change
            var saveIconBitMap = new BitmapImage();

            saveIconBitMap.BeginInit();
            saveIconBitMap.UriSource = new Uri("pack://application:,,,/tempIco.PNG");
            saveIconBitMap.EndInit();

            MainButton.IconRegular = saveIconBitMap;
            MainButton.IconHover = saveIconBitMap;
            MainButton.IconPressed = saveIconBitMap;
            MainButton.IconDisabled = saveIconBitMap;

            XAMLStackPanel.Children.Add(MainButton); //add to Xaml

            MainButton.Name = "MainButton";
            MainButton.Margin = new Thickness(5);
        }
        public void InitializeMainButton3()
        {
            var MainButton = new CxControlLibrary.MainButton();
            MainButton.HorizontalAlignment = HorizontalAlignment.Center;
            MainButton.Enabled = true;


            //ImageButton icon save and change
            var saveIconBitMap = new BitmapImage();

            saveIconBitMap.BeginInit();
            saveIconBitMap.UriSource = new Uri(@"C:\\Users\Yuriy\Desktop\temp2.PNG");
            saveIconBitMap.EndInit();

            MainButton.IconRegular = saveIconBitMap;
            MainButton.IconHover = saveIconBitMap;
            MainButton.IconPressed = saveIconBitMap;
            MainButton.IconDisabled = saveIconBitMap;

            XAMLStackPanel.Children.Add(MainButton); //add to Xaml

            MainButton.Name = "MainButton";
            MainButton.Margin = new Thickness(5);
        }

        public void InitializeSubButton()
        {
            var SubButton = new CxControlLibrary.MainButton();
            SubButton.HorizontalAlignment = HorizontalAlignment.Center;
            SubButton.Enabled = true;
            SubButton.ContentText = String.Empty;//if string is Empty MainButton convert to SubButton

            //Change Beackgroound
            SubButton.BackgroundRegular = new SolidColorBrush(Colors.White);
            SubButton.BackgroundHover = new SolidColorBrush(Color.FromRgb(198, 233, 253));
            SubButton.BackgroundPressed = new SolidColorBrush(Color.FromRgb(114, 179, 216));
            SubButton.BackgroundDisabled = new SolidColorBrush(Color.FromRgb(183, 183, 183));

            XAMLStackPanel.Children.Add(SubButton); //add to Xaml

            SubButton.Name = "SubButton";
            SubButton.Margin = new Thickness(5);
        }

        public void InitializeAddUserButton()
        {
            var AddUserButton = new CxControlLibrary.AddUserButton();
            AddUserButton.HorizontalAlignment = HorizontalAlignment.Center;
            AddUserButton.Enabled = true;

            XAMLStackPanel.Children.Add(AddUserButton); //add to Xaml

            AddUserButton.Name = "AddUserButton";
            AddUserButton.Margin = new Thickness(5);

        }

        public void InitializeTextBox()
        {
            var TextBox = new CxControlLibrary.TextBox();
            TextBox.HorizontalAlignment = HorizontalAlignment.Center;

            XAMLStackPanel.Children.Add(TextBox); //add to Xaml

            TextBox.Name = "TextBoxes";
            TextBox.Margin = new Thickness(5);
        }

        public void InitializeRectComboBoxes()
        {
            var RectComboBoxes = new CxControlLibrary.ComboBoxes();
            RectComboBoxes.IsAutoComplete = true;
            RectComboBoxes.HorizontalAlignment = HorizontalAlignment.Center;
            RectComboBoxes.ReadOnly = false;
           // RectComboBoxes.AutoComplete = true;
            // RectComboBoxes.IsRound = false;
            RectComboBoxes.Background = new SolidColorBrush(Color.FromRgb(234, 234, 234));

            //AddItemComboBox
            RectComboBoxes.AddCollection(new CxControlLibrary.CxComboBoxItem()
            {
                Label = "elele",
                Enabled = true,
                Color = new SolidColorBrush(Colors.Azure),
                BackColor = new SolidColorBrush(Colors.Black)
            });
            RectComboBoxes.AddCollection(new CxControlLibrary.CxComboBoxItem()
            {
                Label = "Item2",
                Enabled = false,
                Color = new SolidColorBrush(Colors.Blue)
            });
            RectComboBoxes.AddCollection(new CxControlLibrary.CxComboBoxItem()
            {
                Label = "Item3",
                Enabled = true,
                Color = new SolidColorBrush(Colors.BlueViolet)
            });
            RectComboBoxes.AddCollection(new CxControlLibrary.CxComboBoxItem()
            {
                Label = "Item4",
                Enabled = true,
                Color = new SolidColorBrush(Colors.DeepSkyBlue)
            });
            RectComboBoxes.AddCollection(new CxControlLibrary.CxComboBoxItem()
            {
                Label = "Item5",
                Enabled = true,
                Color = new SolidColorBrush(Colors.DarkViolet)
            });

            XAMLStackPanel.Children.Add(RectComboBoxes); //add to Xaml

            RectComboBoxes.Name = "RectComboBoxes";
            RectComboBoxes.CxStype = false;
            RectComboBoxes.Margin = new Thickness(5);

        }

        public void InitializeRoundComboBoxes()
        {
            var RoundComboBoxes = new CxControlLibrary.ComboBoxes();
            RoundComboBoxes.HorizontalAlignment = HorizontalAlignment.Center;
            RoundComboBoxes.ReadOnly = true;
            //RoundComboBoxes.AutoComplete = false;
            //   RoundComboBoxes.IsRound = true;
            RoundComboBoxes.Background = new SolidColorBrush(Color.FromRgb(234, 234, 234));
            RoundComboBoxes.ArrowColor = new SolidColorBrush(Color.FromRgb(0, 122, 204));
            RoundComboBoxes.Foreground = RoundComboBoxes.ArrowColor;


            //AddItemComboBox
            RoundComboBoxes.AddCollection(new CxControlLibrary.CxComboBoxItem()
            {
                Label = "Item1",
                Enabled = true,
                Color = new SolidColorBrush(Colors.Azure)
            });
            RoundComboBoxes.AddCollection(new CxControlLibrary.CxComboBoxItem()
            {
                Label = "Item2",
                Enabled = false,
                Color = new SolidColorBrush(Colors.Blue)
            });
            RoundComboBoxes.AddCollection(new CxControlLibrary.CxComboBoxItem()
            {
                Label = "Item3",
                Enabled = true,
                Color = new SolidColorBrush(Colors.BlueViolet)
            });
            RoundComboBoxes.AddCollection(new CxControlLibrary.CxComboBoxItem()
            {
                Label = "Item4",
                Enabled = true,
                Color = new SolidColorBrush(Colors.DeepSkyBlue)
            });
            RoundComboBoxes.AddCollection(new CxControlLibrary.CxComboBoxItem()
            {
                Label = "Item5",
                Enabled = true,
                Color = new SolidColorBrush(Colors.DarkViolet)
            });
            RoundComboBoxes.CxStype = true;
            XAMLStackPanel.Children.Add(RoundComboBoxes); //add to Xaml
            RoundComboBoxes.Name = "RoundComboBoxes";
            RoundComboBoxes.Margin = new Thickness(5);
        }

        public void InitializeObjectList()
        {
            var ObjectList = new CxControlLibrary.ObjectList();

            ObjectList.ObjectlistItemsCollection.Add(new CxControlLibrary.ObjectListItem()
            {
                IsCheked = true,
                AttachmentName = "Attachment Name1",
                Policy = "Policy1",
                ColorRect = new SolidColorBrush(Colors.Red)
            });
            ObjectList.ObjectlistItemsCollection.Add(new CxControlLibrary.ObjectListItem()
            {
                IsCheked = false,
                AttachmentName = "Attachment Name2",
                Policy = "Policy2",
                ColorRect = new SolidColorBrush(Colors.Green)
            });
            ObjectList.ObjectlistItemsCollection.Add(new CxControlLibrary.ObjectListItem()
            {
                IsCheked = true,
                AttachmentName = "Attachment Name3",
                Policy = "Policy3",
                ColorRect = new SolidColorBrush(Colors.Blue)
            });
            ObjectList.ObjectlistItemsCollection.Add(new CxControlLibrary.ObjectListItem()
            {
                IsCheked = true,
                AttachmentName = "Attachment Name4",
                Policy = "Policy1",
                ColorRect = new SolidColorBrush(Colors.Yellow)
            });
            ObjectList.ObjectlistItemsCollection.Add(new CxControlLibrary.ObjectListItem()
            {
                IsCheked = false,
                AttachmentName = "Attachment Name5",
                Policy = "Policy2",
                ColorRect = new SolidColorBrush(Colors.Tomato)
            });
            ObjectList.ObjectlistItemsCollection.Add(new CxControlLibrary.ObjectListItem()
            {
                IsCheked = true,
                AttachmentName = "Attachment Name6",
                Policy = "Policy3",
                ColorRect = new SolidColorBrush(Colors.Tan)
            });


            XAMLStackPanel.Children.Add(ObjectList);
            ObjectList.Name = "ObjectList";
        }


    }
}