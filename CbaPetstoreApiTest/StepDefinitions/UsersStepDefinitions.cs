using AutoFixture;
using CbaPetstoreApiTest.Framework;
using CbaPetstoreApiTest.Model;
using RestSharp;
using TechTalk.SpecFlow;
using Xunit;
using Newtonsoft.Json;
using AventStack.ExtentReports;

namespace CbaPetstoreApiTest.StepDefinitions
{
    [Binding]
    public class UsersStepDefinitions : BaseStep
    {
        private RestResponse _response;
        private UserRequest _request;

        public UsersStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [Given(@"I have a valid customer data")]
        public async Task GivenIHaveAValidCustomerData()
        {
            var fixture = new Fixture();
            _request = fixture.Create<UserRequest>();
            _test.Log(Status.Info, "Trying to create an user with email address: "+_request.email);
        }

        [When(@"I call the create user api with the correct data")]
        public async Task WhenICallTheCreateUserApiWithTheCorrectData()
        {
            _response = await _apiCalls.PostMethodAsync("v2/user", _request);
        }

        [Then(@"I should see (.*) response")]
        public async void ThenIShouldSeeResponse(int p0)
        {
            UserResponse userResponse = JsonConvert.DeserializeObject<UserResponse>(_response.Content);
            Assert.Equal(200, (int)_response.StatusCode);
            Assert.Equal("unknown", userResponse.type);
            _test.Log(Status.Pass, "User created successfully");
        }
    }
}
