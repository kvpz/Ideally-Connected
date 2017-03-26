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
using IdeallyConnected.Test;

namespace IdeallyConnected.TestDriver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private ObservableCollection<UnitTestInfo> _results = new ObservableCollection<UnitTestInfo>();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = Assert.TestResults;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var testClass = new TestAnalysis();
            Assert.RunTests();
            //testClass.TestPassedMethod();
            //testClass.TestFailedMethod();
            
            //_results.Add(testClass.TestFailed());
            //var testInfo = testClass.TestPassed();
            //MessageBox.Show($"{testInfo.DidTestPass} - {testInfo.TestFailureMessage ?? "Test Passed" }");
        }
    }
}
