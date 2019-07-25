using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;
        }

        private void CodeBehindBtn_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.UpdateFullName(DateTime.Now);
        }

        private void SyncBtn_Click(object sender, RoutedEventArgs e)
        {
            for (var i = 0; i <= _viewModel.Model.MaximumProgressBar; i++)
            {
                PrgsBr.Value += 1;
                Thread.Sleep(100);
            }
        }

        private async void AsyncBtn_Click(object sender, RoutedEventArgs e)
        {
            for (var i = 0; i <= _viewModel.Model.MaximumProgressBar; i++)
            {
                PrgsBr.Value += 1;
                await Task.Delay(100);
            }
        }

        private void ClearProgressBarBtn_Click(object sender, RoutedEventArgs e)
        {
            PrgsBr.Value = 0;
        }

        private async void AsyncWithCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.Model.IsTaskCancellable = true;

                for (var i = 0; i <= _viewModel.Model.MaximumProgressBar; i++)
                {
                    _cancellationTokenSource.Token.ThrowIfCancellationRequested();

                    PrgsBr.Value += 1;
                    await Task.Delay(100, _cancellationTokenSource.Token);
                }
            }
            catch (TaskCanceledException tcex)
            {
                RefreshCancellationTokenSource();
            }
            catch(OperationCanceledException ocex)
            {
                RefreshCancellationTokenSource();
            }
            finally
            {
                _viewModel.Model.IsTaskCancellable = false;
            }
        }

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private void CancelTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }

        private void RefreshCancellationTokenSource()
        {
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = new CancellationTokenSource();
        }
    }
}
