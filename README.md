# Paystack.Net.SDK <img src="https://paystack.com/favicon.png" width="50" height="50"/>

[![Version](https://img.shields.io/nuget/vpre/Paystack.Net.SDK)](https://www.nuget.org/packages/Paystack.Net.SDK)
[![Downloads](https://img.shields.io/nuget/dt/Paystack.Net.SDK)](https://www.nuget.org/packages/Paystack.Net.SDK)


Paystack.Net.SDK is a library for using the [Paystack](https://paystack.com) API from .Net, .Net Core & .Net Standard.

It is written entirely in C#, with no external dependencies. Paystack.Net.SDK is released under the permissive MIT License, so it can be used in both proprietary and free/open source applications.

## Donation [![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.me/markadesina) 
If this project help you reduce time to develop, you can give me a cup of coffee (or a Beer of course) :)

[![Support via PayPal](https://cdn.rawgit.com/twolfson/paypal-github-button/1.0.0/dist/button.svg)](https://www.paypal.me/markadesina) 


## Features
 - **Transactions:**
   - Initialize a transaction from your backend
   - Verify Transaction
   - List Transactions
   - FetchTransaction
   - ChargeAuthorization
   - TransactionTimeline
   - TransactionTotals
   - ExportTransactions
   - CheckAuthorization
   - RequestReAuthorization
   
 - **Subscriptions:**
   - CreateSubscription

 - **Transfers:**
   - CreateTransferRecipient
   - ListTransferRecipients
   - InitiateTransfer
   - FetchTransfer
   - ListTransfers
   - FinalizeTransfer

 - **Charge:**
   - ChargeCard

 - **Customer:**
   - CreateCustomer
   - FetchCustomer
   - ListCustomers


## Releases

Stable binaries are released on NuGet, and contain everything you need to collect money via Paystack in your .Net/CLR application. For usage see the [Documentation](https://github.com/developerslearnit/Paystack.Net.SDK/wiki) wiki

- [Nuget](https://www.nuget.org/packages/Paystack.Net.SDK/) (latest)

Paystack.Net.SDK works on .NET and .NET Standard/.NET Core.

| Platform      		| Binaries Folder	| 
|---------------		|-----------		|
| **.NET 2.0**      	| net20     		| 
| **.NET 3.5**      	| net35     		| 
| **.NET 4.0**      	| net40     		| 
| **.NET 4.5**      	| net45     		| 
| **.NET 5.0**      	| net50     		| 
| **.NET Standard 1.4** | netstandard1.4	| 
| **.NET Standard 1.6** | netstandard1.6	| 
| **.NET Standard 2.0** | netstandard2.0	| 
| **.NET Standard 2.1** | netstandard2.1	| 

Paystack.Net.SDK is also supported on these platforms: (via .NET Standard)

  - **Mono** 4.6
  - **Xamarin.iOS** 10.0
  - **Xamarin.Android** 10.0
  - **Universal Windows Platform** 10.0

Binaries for all platforms are built from a single Visual Studio 2019 Project. You will need [VS 2019](https://visualstudio.microsoft.com/downloads/) to build or contribute to Paystack.Net.SDK.


## Documentation and FAQs

Check the [Wiki](https://github.com/developerslearnit/Paystack.Net.SDK/wiki).
