using Azure_Core_API_CRUD;

try
{
        WebApplication webApplication = Utils.BuildWebApplication(args);
        Utils.SetupWebApplication(webApplication);
        webApplication.Run();
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}
