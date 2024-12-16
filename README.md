## ErcasPay .Net SDK

![ErcasPay Logo](https://ercaspay.com/_ipx/_/logo-black.png)
This SDK for .Net Core is a wrapper around ErcasPay payment gateway's Direct Integration API. Some of its key features are
- Dependency injection support: the SDK registers all services needed in .Net's dependency container as well as the base class that will be called by users of this SDK. Developers can add this SDK to their project by using the command below
  ```c#
  builder.Services.AddErcasPay();
  ```
- SOLID Principles:
    - Single Responsibility Principle (SRP): Separation of concerns between Base (communication layer), Service (business logic layer) and Infrastructure layer.
    - Interface Segregation: Each module has its corresponding interface.
    - Dependency Inversion Principle (DIP): Clients will interact with the library via interfaces rather than concrete implementations.
    - Testing and mocking
- Supported Project Types
    - Web (Razor, Blazor, MVC, Web API)
    - Console Applications
    - Desktop and Mobile Applications: Winforms, WPF, MAUI

### Installation
```
dotnet add package ErcasPay.12.16.24.002 --version 1.0.0
```
https://www.nuget.org/packages/ErcasPay.12.16.24.002

### Usage
https://github.com/Tomiwa-Ot/ercaspay/wiki

### Documentation
https://tomiwa-ot.github.io/ErcasPay/namespaces.html
