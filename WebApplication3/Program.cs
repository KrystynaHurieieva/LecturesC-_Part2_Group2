using System.Text;

namespace WebApplication3
{
    public class Program
    {
        private static void HandleMapOne(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from 1st app.Map()");
            });
        }
        private static void HandleMapTwo(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from 2nd app.Map()");
            });
        }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddTransient<ITimeService, ShortTimeService>();

            builder.Services.AddTransient<ICounter, RandomCounter>();
            builder.Services.AddSingleton<CounterService>();
            builder.Services.AddSingleton<LongTimeService>();

            var allServices = builder.Services;

            var app = builder.Build();
            
            app.Map("/one", HandleMapOne);
            app.Map("/second", HandleMapTwo);

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from app.Run");
            });

            // app.UseMiddleware<CounterMiddleware>();

            //app.Run(async context => { 

            //    var time = app.Services.GetService<ICounter>();
            //    await context.Response.WriteAsync($"Count: {time?.Count}");
            //});


            // Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.MapRazorPages();


            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Before Invoke from 1st app.Use()\n");
            //    await next();
            //    await context.Response.WriteAsync("After Invoke from 1st app.Use()\n");
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Before Invoke from 2nd app.Use()\n");
            //    await next();
            //    await context.Response.WriteAsync("After Invoke from 2nd app.Use()\n");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello from 1st app.Run()\n");
            //}); 
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello from 2nd app.Run()\n");
            //});

            ////app.Run(
            ////    async context =>
            ////    {
            ////        var sb = new StringBuilder();
            ////        sb.Append("All");
            ////        foreach (var service in allServices)
            ////        {
            ////            sb.AppendLine($"{service.ServiceType.FullName}\t" +
            ////                $" {service.Lifetime} \t" +
            ////                $"{service.ImplementationType?.FullName}\t \n");
            ////        }
            ////        context.Response.ContentType = "text/html;charset=utf-8";
            ////        await context.Response.WriteAsync(sb.ToString());
            ////    }
            ////    );
            app.Run();
        }
    }

    interface ITimeService
    {
        string GetUtcTime();
    }

    class ShortTimeService: ITimeService
    {
        public string GetUtcTime() => DateTime.UtcNow.ToShortTimeString(); // hh:mm
    }

    class LongTimeService : ITimeService
    {
        public string GetUtcTime() => DateTime.UtcNow.ToLongTimeString(); // hh:mm:ss
    }
    // Singleton 
    // Transient 
    // Scoped 

   public interface ICounter
    {
        public int Count { get; }
    }

    public class RandomCounter : ICounter 
    {
        static Random rnd = new Random();
        int value;
        public RandomCounter()
        {
            value = rnd.Next(0, 1000000000);
        }
        public int Count { get => value; }
    }
    public class CounterMiddleware
    {
        RequestDelegate next;
        int i = 0; 
        public CounterMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext, ICounter counter, CounterService counterService)
        {
            i++;
            httpContext.Response.ContentType = "text/html;charset=utf-8";
            await httpContext.Response.WriteAsync($"Request {i}; Counter: {counter.Count}; Service: {counterService.Counter.Count}");
        }
    }

    public class CounterService
    {
        public ICounter Counter { get; }
        public CounterService(ICounter counter)
        {
            Counter = counter;
        }
    }

   

}