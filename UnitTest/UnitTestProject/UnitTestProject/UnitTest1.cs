using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Rudimentary_Antivirus;
using System.Text;
using Moq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using Moq.Protected;
using System.Threading;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EnryptionUnitTest()
        {

            string password = "myPassword";
            byte[] expectedBytes = Encoding.UTF8.GetBytes(password);
            string expectedBase64String = Convert.ToBase64String(expectedBytes);

            string encryptedString = RegistrationWindow.Enryption(password);

            Assert.AreEqual(expectedBase64String, encryptedString);
        }

        private LoginWindow loginWindow;
        private Mock<HttpMessageHandler> httpMessageHandlerMock;
        private HttpClient httpClient;
        private RegistrationWindow registrationWindow;

        [TestInitialize]
        public void Setup()
        {
            httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            httpClient = new HttpClient(httpMessageHandlerMock.Object);
            loginWindow = new LoginWindow(httpClient);
            registrationWindow = new RegistrationWindow();
        }

        [TestMethod]
        public async Task LoginUserUnitTest_SuccessfulLogin_True()
        {
            string userName = "testuser";
            string password = "testpassword";
            string apiUrl = $"http://localhost/API/login.php?userName={userName}&password={password}";
            string jsonResponse = "{\"error\": 0}";

            HttpResponseMessage successResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonResponse)
            };

            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(successResponse);


            bool result = await loginWindow.LoginUser(userName, password);


            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task LoginUser_FailedLogin_ReturnsFalse()
        {
            // Arrange
            string userName = "faketestuser";
            string password = "faketestpassword";
            string apiUrl = $"http://localhost/API/login.php?userName={userName}&password={password}";
            string jsonResponse = "{\"error\": 1, \"message\": \"Login failed.\"}";

            HttpResponseMessage failureResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonResponse)
            };

            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(failureResponse);

            // Act
            bool result = await loginWindow.LoginUser(userName, password);

            // Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public async Task LoginUser_HttpError_False()
        {
            string userName = "testuser";
            string password = "testpassword";
            string apiUrl = $"http://localhost/API/login.php?userName={userName}&password={password}";

            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new HttpRequestException("An error occurred while sending the request."));

            bool result = await loginWindow.LoginUser(userName, password);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task RegisterUser_RegistrationSuccess_ReturnsTrue()
        {
            string userName = "newtestuser2";
            string password = "newtestpassword2";
            string apiUrl = "http://localhost/API/registration.php";

            var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == apiUrl && req.Method == HttpMethod.Post),
                    ItExpr.IsAny<System.Threading.CancellationToken>()).ReturnsAsync(new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent("{ \"error\": 0 }"),
                    });

            var httpClient = new HttpClient(mockHandler.Object);
            registrationWindow._httpClient = httpClient;
            
            bool result = await registrationWindow.RegisterUser(userName, password);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task RegisterUser_FailedRegistration_ReturnsFalse()
        {
            string userName = "newtestuser2";
            string password = "newtestpassword2";
            string apiUrl = "http://localhost/API/registration.php";

            var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == apiUrl && req.Method == HttpMethod.Post),
                    ItExpr.IsAny<System.Threading.CancellationToken>()).ReturnsAsync(new HttpResponseMessage
                    {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{ \"error\": 1, \"message\": \"Something already exists. :( \" }"),
                    });

            var httpClient = new HttpClient(mockHandler.Object);
            registrationWindow._httpClient = httpClient;

            bool result = await registrationWindow.RegisterUser(userName, password);

            Assert.IsFalse(result);
        }
    }


}

