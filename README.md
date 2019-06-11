# dotnet-core-learning

1.	What is Kestrel?

2.	How to decouple .Net Core with IIS ?

3.	Details of the below required 

var host = new WebHostBuilder()
.UseKestrel()
.UseUrls("http://*:5000")
.UseContentRoot(Directory.GetCurrentDirectory())
.UseIISIntegration()
.UseStartup<Startup>()
.Build();

4.	Inbuilt Logging Mechanism and how does it work.

5.	IStartupFilter
6.	https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup?view=aspnetcore-2.1

7.	Middle ware

•	Exception/error handling
•	HTTP Strict Transport Security Protocol
•	HTTPS redirection
•	Static file server
•	Cookie policy enforcement
•	Authentication
•	Session
•	MVC


8.	Use, Run, and Map
9.	Run and map when

10.	What is Host ?

11.	Types of Host

o	Web Host: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/web-host?view=aspnetcore-2.1

o	Generic Host: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-2.1

12.	Options?
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-2.1


13.	Review our current project authentication, configure and configure service and swagger implementation
	JWT Or OAuth Authentication

14.	Deployment With Containers(Linux)
15.	Life Cycle 
16.	Dependency Injection
17.	API Vs Micro Services
