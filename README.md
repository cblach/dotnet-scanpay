# Scanpay .NET library

## Usage

Load the Scanpay .NET Library:
```csharp
using Scanpay; # Use alias if Client conflicts with anything.
```

Define a Scanpay client:
```csharp
var apikey = "1089:bx2a4DATi8ad87Nm4uaxg5nggYA8J/Hv99CON977YiEdvYa6DmMwdoRPoYWyBJSi";
var client = new Client(apikey);
```


### New Payment Link
Create a payment link to which you can redirect customers.
```csharp
var data = new Client.NewURLReq
{
    orderid = "999",
    items = new Client.Item[]
    {
        new Client.Item
        {
            name     = "Ultra Bike 7000",
            price    = "1337.01 DKK",
            quantity = 2,
        },
    }
};
var url = client.newURL(data);
```


### Seq Request
Get an array with a number of changes since the supplied sequence number:
```csharp
var oldSeq = 3
var seqRes = client.seq(oldSeq, opts);
foreach(var change in seqRes.changes)
{
    // Update your database with change...
}
Console.WriteLine("New seq number is " + seqRes.seq);
```

### Handle Pings
Verify the ping signature and extract the seq number.
```csharp
var ping = client.handlePing(body, request.Headers["X-Signature"]);
Console.WriteLine("Ping seq=" + ping.seq + ", shopid=" + ping.shopid);;
```
