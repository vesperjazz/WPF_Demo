﻿- A model is a collection of property, to be changed by the ViewModel and to be presented and bounded to the XAML UI.
- Most of the time it should implement the INotifyPropertyChanged interface to update the UI upon value change.
- It SHOULD NOT contain business logic and should always be a POCO (Plain Old CLR object) class.
- Most of the time, if not all the time, this will be a 1-1 mapping of your database classes.