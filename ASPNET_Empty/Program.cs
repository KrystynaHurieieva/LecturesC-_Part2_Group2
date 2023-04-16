using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
if (builder.Environment.IsProduction())
{
    Console.WriteLine("It's production");
}
// Configure the cert and the key
//builder.Configuration["Kestrel:Certificates:Default:Path"] = "cert.pem";
//builder.Configuration["Kestrel:Certificates:Default:KeyPath"] = "key.pem";
var app = builder.Build();

app.MapGet("/", () => "Hello World! :) ");


//await PrintAsync();

//var m = PrintNameAsync("Michael");
//var j = PrintNameAsync("John");
//var g = PrintNameAsync("Gregory");
//var b = PrintNameAsync("Ben");

//await m;
//await j;
//await g;
//await b;

//var s = new Stopwatch();
//s.Start();
//var res = await SquareAsync(5);
//var res2 = await SquareAsync(15);
//var res3 = await SquareAsync(115);
//var res4 = await SquareAsync(25);
//s.Stop();
//Console.WriteLine($"Print: {s.ElapsedMilliseconds}");

// access delegate [return type] [gelegate name] ([parameters])

//app.Run("https://localhost:3000");
app.Run();


//ValueTask<int>
async Task<int> SquareAsync(int i)
{
    await Task.Delay(3000);
    return i * i;
}

void Print()
{
    Thread.Sleep(3000);
    Console.WriteLine("Print");
}

async Task PrintNameAsync(string name)
{
    await Task.Delay(3000);
    Console.WriteLine($"name : {name}");
}

async Task PrintAsync()
{
    Console.WriteLine("PrintAsync started ");
    await Task.Run(() => Print());
    Console.WriteLine("PrintAsync completed");
}
//await app.StartAsync();
//await Task.Delay(10000);
//await app.StopAsync();

/*var s = new Stopwatch();
s.Start();
var res = SquareAsync(5);
var res2 = SquareAsync(15);
var res3 = SquareAsync(115);
var res4 = SquareAsync(25);

await res;
await res2;
await res3;
await res4;
s.Stop();
Console.WriteLine($"Print: {s.ElapsedMilliseconds}");
*/