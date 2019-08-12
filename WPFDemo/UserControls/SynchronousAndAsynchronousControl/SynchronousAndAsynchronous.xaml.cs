using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WPFDemo.UserControls.SynchronousAndAsynchronousControl
{
    /// <summary>
    /// Interaction logic for SynchronousAndAsynchronous.xaml
    /// </summary>
    public partial class SynchronousAndAsynchronous : UserControlBase
    {
        // Dependency Property
        // Biggest difference between this and normal property, is it bindable?
        // Normal property like MaximumProgressBar below does not open up for binding, a source-target relationship.
        public bool IsTaskCancellable
        {
            get { return (bool)GetValue(IsTaskCancellableProperty); }
            // Note that even without raising PropertyChangedEvent, the UI updates accordingly when set.
            // That is because a Dependency Property is included in the WPF property system by default.
            set { SetValue(IsTaskCancellableProperty, value); }
        }
        public static readonly DependencyProperty IsTaskCancellableProperty = DependencyProperty.Register(
          nameof(IsTaskCancellable), typeof(bool), typeof(SynchronousAndAsynchronous), new PropertyMetadata(false));

        public double MaximumProgressBar { get; set; }

        private ApplicationState _applicationState;
        public ApplicationState ApplicationState
        {
            get { return _applicationState; }
            set
            {
                _applicationState = value;
                UpdateUI();
            }
        }

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public SynchronousAndAsynchronous()
        {
            InitializeComponent();
            ApplicationState = ApplicationState.Default;
        }

        private void BtnClearProgressBar_Click(object sender, RoutedEventArgs e)
        {
            ClearProgressBarValue();
        }

        private async void BtnSynchronousTask_Click(object sender, RoutedEventArgs e)
        {
            SetApplicationState(ApplicationState.NonResponsive);
            StartTask();
            // Ignore this, this is to temporarily free-up UI thread to update the 
            // ApplicationState message before real UI blocking task.
            await Task.Delay(100);

            for (var i = 0; i <= MaximumProgressBar; i++)
            {
                PrgsBr.Value += 1;
                Thread.Sleep(100);
            }

            EndTask();
            SetApplicationState(ApplicationState.Default);
        }

        private async void BtnAsynchronousTask_Click(object sender, RoutedEventArgs e)
        {
            SetApplicationState(ApplicationState.Responsive);
            ClearProgressBarValue();
            StartTask();
            for (var i = 0; i <= MaximumProgressBar; i++)
            {
                PrgsBr.Value += 1;
                await PerformIOTaskAsync();
            }
            EndTask();
            SetApplicationState(ApplicationState.Default);
        }

        private async void BtnAsychronousCancelTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetApplicationState(ApplicationState.Responsive);
                ClearProgressBarValue();
                StartTask();

                for (var i = 0; i <= MaximumProgressBar; i++)
                {
                    _cancellationTokenSource.Token.ThrowIfCancellationRequested();

                    PrgsBr.Value += 1;
                    await PerformIOTaskAsync(_cancellationTokenSource.Token);
                }
            }
            catch (TaskCanceledException tcex)
            {
                RefreshCancellationTokenSource();
            }
            catch (OperationCanceledException ocex)
            {
                RefreshCancellationTokenSource();
            }
            finally
            {
                EndTask();
                SetApplicationState(ApplicationState.Default);
            }
        }

        private void BtnCancelTask_Click(object sender, RoutedEventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }

        private void ClearProgressBarValue()
        {
            PrgsBr.Value = 0;
        }

        private void SetApplicationState(ApplicationState applicationState)
        {
            ApplicationState = applicationState;
        }

        // Lambda expression for when you don't really want to see a method body.
        // Not necessary, but fun.
        private void StartTask() => IsTaskCancellable = true;
        private void EndTask() => IsTaskCancellable = false;

        private void RefreshCancellationTokenSource()
        {
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        private async Task PerformIOTaskAsync(CancellationToken? cancellationToken = null)
        {
            if (cancellationToken.HasValue)
                await Task.Delay(100, cancellationToken.Value);
            else
                await Task.Delay(100);
        }
    }
}
