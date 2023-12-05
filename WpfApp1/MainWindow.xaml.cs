using System;
using System.Collections.Generic;
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
//using System.Threading;
using System.Windows.Threading;

/*
 * This new modify file version
 */


namespace WpfApp1
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      timer.Stop();
      timer.Tick += TimerProc;
      timer.Interval = new TimeSpan(0,0,0,0,500); // 500 miliseconds
    }
    // объект - таймер
    DispatcherTimer timer = new DispatcherTimer();

    // Обработчик таймера
    private void TimerProc(object sender, EventArgs e)
    {
      timer.Stop();
      progBar.Value += 1;
      if(progBar.Value < progBar.Maximum)
      {
        timer.Start();
      }
    }
    private void Button_Start_Click(object sender, RoutedEventArgs e)
    {
      progBar.Value = 0;
      progBar.Minimum = 0;
      progBar.Maximum = 113;
      timer.Start();
    }

    private void Button_Stop_Click(object sender, RoutedEventArgs e)
    {
      timer.Stop();
    }

    private void progBar_ValueChanged(object sender,
      RoutedPropertyChangedEventArgs<double> e)
    {
      if (progBar is null || txtProgBar is null) return;

      // 1 variant
      double val = progBar.Value /
        (progBar.Maximum - progBar.Minimum);
      txtProgBar.Text = val.ToString("0.0%");
      // 2 variant
      //double val = 100 * e.NewValue /
      //  (progBar.Maximum - progBar.Minimum);
      //txtProgBar.Text = e.NewValue.ToString("0.0%");
    }

    private void TabControl_SelectionChanged(
      object sender, SelectionChangedEventArgs e)
    {
      TabControl tabControl = sender as TabControl;
      //tabControl.Items.sel

    }
  }
}
