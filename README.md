# Paystack.Net.SDK

Paystack.Net.SDK is a library for using the [Paystack](https://paystack.com) API from .Net.

## Donation [![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.me/markadesina) 
If this project help you reduce time to develop, you can give me a cup of coffee (or a Beer of course) :)

[![Support via PayPal](https://cdn.rawgit.com/twolfson/paypal-github-button/1.0.0/dist/button.svg)](https://www.paypal.me/markadesina) 


### Prerequisites

This Library require .Net framework 4.6 or higher



### Installing
Install this library from [Nuget](https://www.nuget.org/packages/Paystack.Net.SDK)

### Sample web Application

 [Check out the sample web Application](https://github.com/developerslearnit/Paystack.Net.SampleApp)


### Usage

#### Transactions

First, Instantiate PaystackTransactionAPI:
Add required using

using Paystack.Net.SDK.Transactions;


##### Transaction Initialization
    var paystackTransactionAPI = new PaystackTransaction(YOUR_SECRET_KEY_HERE);
    var response = await paystackTransactionAPI.InitializeTransaction("customer@gmail.com", 500000);
    if(response.status){
        Response.AddHeader("Access-Control-Allow-Origin", "*");
        Response.AppendHeader("Access-Control-Allow-Origin", "*");
		Response.Redirect(response.data.authorization_url);
    }else{
	//Handle Error
	}

##### Transaction Verification
    var paystackTransactionAPI = new PaystackTransaction(YOUR_SECRET_KEY_HERE);
    var response = await paystackTransactionAPI.VerifyTransaction("cipyd2ikxw");

#### Transaction Listings
    var paystackTransactionAPI = new PaystackTransaction(YOUR_SECRET_KEY_HERE);
    var response = await paystackTransactionAPI.ListTransactions();

#### Fetch Transaction

    var paystackTransactionAPI = new PaystackTransaction(YOUR_SECRET_KEY_HERE);
    var response = await paystackTransactionAPI.FetchTransaction(9149218);

#### Charge Authorization

    var paystackTransactionAPI = new PaystackTransaction(YOUR_SECRET_KEY_HERE);
    var response = await paystackTransactionAPI.ChargeAuthorization("AUTH_lqnf8xjy5j", "mark2kk@gmail.com", 5000);

#### View Transaction Timeline

    var paystackTransactionAPI = new PaystackTransaction(YOUR_SECRET_KEY_HERE);
    var response = await paystackTransactionAPI.TransactionTimeline("cipyd2ikxw");
    

#### Customers

Requires using Paystack.Net.SDK.Customers namespace and an instance of PaystackCustomers

#### Create Customer
     var paystackCustomerAPI = new PaystackCustomers(YOUR_SECRET_KEY_HERE);
     var response = await paystackCustomerAPI.CreateCustomer("person@live.com", "John", "Doe", "08098786543");

#### List Customers
     var paystackCustomerAPI = new PaystackCustomers(YOUR_SECRET_KEY_HERE);
     var response = await paystackCustomerAPI.ListCustomers();

## Authors

* **Mark Adesina** -  [DeveloperslearnIt](http://www.developerslearnit.com/)


## License

This project is licensed under the MIT License

## Still on the roadmap
* Invoices
* etc
