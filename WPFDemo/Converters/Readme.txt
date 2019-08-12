﻿- Converters are used to convert property from one form to another.
- The conversion can be with the same property data type, e.g. InverseBooleanConverter.
- Different property data type, e.g. ApplicationStateToMessageConvert & DateTimeToAgeConverter.
- The converter intercepts the binding by the target to trick the target as though the source is really of that type/value.
- Most converter works in a 1 way binding, i.e. only the Convert method of the IValueConverter needs to be implemented.
- If the binding is 2 way, then both the Convert and ConvertBack has to be implemented.