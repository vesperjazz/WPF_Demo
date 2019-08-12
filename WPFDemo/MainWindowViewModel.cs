using WPFDemo.UserControls.CommandsAndCodeBehindControl;
using WPFDemo.UserControls.ObservableCollectionControl;
using WPFDemo.UserControls.SynchronousAndAsynchronousControl;

namespace WPFDemo
{
    public class MainWindowViewModel
    {
        // A readonly property whose reference cannot be changed.
        // Can only be initialised in the constructor.
        public MainWindowModel Model { get; }
        // A public property whose reference can be read and changed at any time.
        //public MainWindowModel Model { get; set; }
        // A public readonly property whose reference can be changed at any time but only in this class. 
        //public MainWindowModel Model { get; private set; }

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

        public void AddPersonToTable()
        {
            // Cloning to make a new reference
            Model.PersonInfoList.Add(Model.PersonInfo.Clone());
            Model.PersonInfoObservableCollection.Add(Model.PersonInfo.Clone());
        }
    }
}
