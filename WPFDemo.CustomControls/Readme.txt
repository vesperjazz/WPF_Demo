- A custom control is a more complex native control.
- Native control in this case includes all default WPF controls, e.g. TextBox, TextBlock, DataGrid, ComboBox...
- It should only consist of ONE native control that is being enriched with additional features.
- Created to fit different business logics and should be shareable throughout the application.
e.g. 
- PersonInfoDataGrid is still a DataGrid, but customised to fit the PersonInfo class, with predefined columns.
- RedTextBox, still just a textbox, but with it's background colour set to Red always. (Does not exist in the solution!)
