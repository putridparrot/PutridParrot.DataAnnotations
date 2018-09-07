# PutridParrot.DataAnnotations
Various extensions for use with data annotation/validation attribute.

## ExpectedAttribute

Expects a value from one of the options supplied, so can be added to validation
so if the property/field/parameter its used on is not one of the "expected"
values a validation error occurs.

Example:

```
[Expected(new [] { "RED", "AMBER", "GREEN"" })]
```

The error message may be supplied by the user or automatically generated (although
the automatic generation is not currentl localized).
