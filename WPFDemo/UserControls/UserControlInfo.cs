using System.Collections.Generic;

namespace WPFDemo.UserControls
{
    /// <summary>
    /// Normally this would be in a resource file, but ommited in the case of this demo for brevity.
    /// </summary>
    public static class UserControlInfo
    {
        public const string BasicBinding = "Basic Binding";
        public const string CommandsAndCodeBehind = "Commands and Code Behind";
        public const string ObservableAndGenericCollection = "Observable Collection and Generic Collection";
        public const string SynchronousAndAsynchronous = "Synchronous and Asynchronous";

        public static List<string> BasicBindingDescriptions = new List<string>
        {
            "This section mainly covers the most fundamental principle in WPF, i.e. Binding.",
            "Coverage includes the following: ",
            "- DataContext, Source and Target.",
            "- UI renders and updates via implementing INotifyPropertyChanged.",
            "- Styling with/without Key.",
            "- Global and Local styling scopes.",
            "- Control validation by implementing IDataErrorInfo.",
            "- Complex object binding in ComboBox.",
            "- Static object binding."
        };

        public static List<string> CommandsAndCodeBehindDescriptions = new List<string>
        {
            "This section mainly covers the routing of events caused by user actions.",
            "Coverage includes the following: ",
            "- User actions executed by Commands OR Code Behind.",
            "- Implementation of the ICommand interface for Commands. (RelayCommand)",
            "- Window VS Dialog.",
            "- Shareable UserControl(PersonInfoDisplay) used in current UserControl, Window and Dialog.",
        };

        public static List<string> ObservableAndGenericCollectionDescriptions = new List<string>
        {
            "This section mainly covers the difference between Observable and Generic collection.",
            "Coverage includes the following: ",
            "- Observable collection changes is reflected immediately on the UI.",
            "- Generic list changes is not reflected in the UI even if the Model changes.",
            "- Custom control implementation (PersonInfoDataGrid). *Custom control should not be confused with UserControl.",
            "- Event routing via WPF Bubbling/Tunneling for Custom control."
        };

        public static List<string> SynchronousAndAsynchronousDescriptions = new List<string>
        {
            "This section mainly covers the difference between synchronous and asynchronous operation.",
            "Coverage includes the following: ",
            "- Dependency Property declaration to allow Binding.",
            "- RelativeSource for binding outside of the DataContext.",
            "- Converters that implement IValueConverter.",
            "- DataTrigger for conditional display in XAML.",
            "- Synchronous operation that runs on the UI thread, causing UI to be non-responsive.",
            "- Asynchronous operation that runs on a background thread, freeing up the UI thread to be responsive.",
            "- Cancellable asynchronous operation using CancellationToken.",
            "- Asynchronous operation should not be confused with Concurrent operation."
        };
    }
}
