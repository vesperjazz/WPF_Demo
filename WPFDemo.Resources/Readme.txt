﻿- A collection of styling that is shareable throughout the application.
- The context is important here, depending on where the resource is imported, the style is only relevant there.
- e.g. If it were to be imported in App.xaml, it will truly be application wide, any XAML will be able to use its style.
- However, if only imported in a specific XAML, then it only be usable in the context of that particular XAML.