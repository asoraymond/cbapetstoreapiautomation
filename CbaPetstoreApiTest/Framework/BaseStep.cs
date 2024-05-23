using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using CbaPetstoreApiTest.Framework.APIMethods;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TechTalk.SpecFlow;

namespace CbaPetstoreApiTest.Framework
{
    public class BaseStep : IDisposable
    {
        protected IApiCalls _apiCalls;
        private static ExtentReports _extentReports;
        public static ExtentTest _test;

        private readonly ScenarioContext _scenarioContext;

        public BaseStep(ScenarioContext scenarioContext) 
        {
            var serviceProvider = ContainerSingleton.ConfigureServices();
            //var appSettings = serviceProvider.GetService<IOptions<AppSettings>>().Value;
            _apiCalls = serviceProvider.GetService<IApiCalls>();

            if (_extentReports == null)
            {
                var htmlReporter = new ExtentSparkReporter("extentReport.html");
                _extentReports = new ExtentReports();
                _extentReports.AttachReporter(htmlReporter);
            }
            _scenarioContext = scenarioContext;
            _test = _extentReports.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }

        public void Dispose()
        {
            _extentReports.Flush();
        }
    }
}
