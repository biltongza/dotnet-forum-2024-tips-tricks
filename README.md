# .NET Forum 2024 - Tips & Tricks

This is the code repository for the presentation for the Entelect .NET Forum 2024 - Tips & Tricks session.

It contains a simple structure of projects:

- a library containing shared models (Lib)
- a webapi project to act as an external dependency
- a blazor project to load data from the external dependency

## Branches

- `multi-solution` - to demonstrate the multi solution extension for Visual Studio
- `bug-missing-di-registration` - the same application missing a DI registration causing a runtime rror