using WPFDemo.UserControls.CommandsAndCodeBehindControl;
using WPFDemo.UserControls.ObservableCollectionControl;
using WPFDemo.UserControls.SynchronousAndAsynchronousControl;

namespace WPFDemo
{
    public class MainWindowViewModel
    {
        public MainWindowModel Model { get; }
        public CommandsAndCodeBehindViewModel CommandsAndCodeBehindViewModel { get; }
        public SynchronousAndAsynchronousViewModel SynchronousAndAsynchronousViewModel { get; }
        public ObservableCollectionViewModel ObservableCollectionViewModel { get; }

        public MainWindowViewModel()
        {
            Model = new MainWindowModel();
            CommandsAndCodeBehindViewModel = new CommandsAndCodeBehindViewModel(Model.PersonInfo);
            SynchronousAndAsynchronousViewModel = new SynchronousAndAsynchronousViewModel(Model.PersonInfo);
            ObservableCollectionViewModel = new ObservableCollectionViewModel(Model.PersonInfoList, Model.PersonInfoObservableCollection);
        }
    }
}
