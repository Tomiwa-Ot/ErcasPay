using ErcasPay.Base;
using ErcasPay.Base.Request;
using ErcasPay.Base.Response;
using ErcasPay.Services.BankTransferService;
using ErcasPay.Services.BankTransferService.Response;
using ErcasPay.Services.CardService;
using ErcasPay.Services.CardService.Response;
using ErcasPay.Services.TransactionService;
using ErcasPay.Services.TransactionService.Response;
using ErcasPay.Services.USSDService;
using ErcasPay.Services.USSDService.Response;
using Moq;
using Xunit;

namespace ErcasPayTests
{
    public class ErcasPayTests
    {
        private readonly Mock<ICardService> _cardServiceMock;
        private readonly Mock<IBankTransferService> _bankTransferServiceMock;
        private readonly Mock<ITransactionService> _transactionServiceMock;
        private readonly Mock<IUSSDService> _ussdServiceMock;
        private readonly ErcasPay.Base.ErcasPay _ercasPay;

        private Transaction transaction = new Transaction
            {
                amount = 1000,
                currency = "NGN",
                customerEmail = "ot.server1@outlook.com",
                customerName = "Tomiwa",
                paymentReference = Guid.NewGuid().ToString()
            };
        private string transactionRef = "ERCS|20241214230520|1734213920972";

        public ErcasPayTests()
        {
            _cardServiceMock = new Mock<ICardService>();
            _bankTransferServiceMock = new Mock<IBankTransferService>();
            _transactionServiceMock = new Mock<ITransactionService>();
            _ussdServiceMock = new Mock<IUSSDService>();

            _ercasPay = new ErcasPay.Base.ErcasPay(_bankTransferServiceMock.Object,
                        _cardServiceMock.Object,
                        _transactionServiceMock.Object,
                        _ussdServiceMock.Object);
        }

        [Fact]
        public async Task PayViaBankTransfer_Test()
        {
            // Arrange 
            var expected = new InitializeBankTransferResponse();
            
            _bankTransferServiceMock.Setup(service => service.InitializeBankTransfer(transaction)).ReturnsAsync(expected);

            // Act
            var result = await _ercasPay.PayViaBankTranfer(transaction);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.ToString(), expected.ToString());
            Assert.True(result.Equals(expected));
        }

        [Fact]
        public async Task PayViaUSSD_Test()
        {
            // Arrange 
            var expected = new InitiateUSSDResponse();
            _ussdServiceMock.Setup(service => service.InitiateUSSDCode(transaction, "access")).ReturnsAsync(expected);

            // Act
            var result = await _ercasPay.PayViaUSSD(transaction, "access");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.ToString(), expected.ToString());
            Assert.True(result.Equals(expected));
        }

        [Fact]
        public async Task GetBankList_Test()
        {
            // Arrange 
            var expected = new GetUSSDBankListResponse();
            _ussdServiceMock.Setup(service => service.GetBankList()).ReturnsAsync(expected);

            // Act
            var result = await _ercasPay.GetUSSDBankList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.ToString(), expected.ToString());
            Assert.True(result.Equals(expected));
        }

        [Fact]
        public async Task CancelTransaction_Test()
        {
            // Arrange 
            var expected = new CancelTransactionResponse();
            _transactionServiceMock.Setup(service => service.CancelTransaction(transactionRef)).ReturnsAsync(expected);

            // Act
            var result = await _ercasPay.CancelTransaction(transactionRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.ToString(), expected.ToString());
            Assert.True(result.Equals(expected));
        }

        [Fact]
        public async Task VerifyTransaction_Test()
        {
            // Arrange 
            var expected = new VerifyTransactionResponse();
            _transactionServiceMock.Setup(service => service.VerifyTransaction(transactionRef)).ReturnsAsync(expected);

            // Act
            var result = await _ercasPay.VerifyTransaction(transactionRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.ToString(), expected.ToString());
            Assert.True(result.Equals(expected));
        }

        [Fact]
        public async Task VerifyCardTransaction_Test()
        {
            // Arrange 
            var expected = new VerifyCardTransactionResponse();
            _cardServiceMock.Setup(service => service.VerifyCardTransaction(transactionRef)).ReturnsAsync(expected);

            // Act
            var result = await _ercasPay.VerifyCardTransaction(transactionRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.ToString(), expected.ToString());
            Assert.True(result.Equals(expected));
        }

        [Fact]
        public async Task FetchTransactionDetails_Test()
        {
            // Arrange 
            var expected = new FetchTransactionDetailsResponse();
            _transactionServiceMock.Setup(service => service.FetchTransactionDetails(transactionRef)).ReturnsAsync(expected);

            // Act
            var result = await _ercasPay.FetchTransactionDetails(transactionRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.ToString(), expected.ToString());
            Assert.True(result.Equals(expected));
        }

        [Fact]
        public async Task FetchTransactionStatus_Test()
        {
            // Arrange 
            var transactionStatus = new TransactionStatus()
            {
                payment_method = "ussd",
                reference = "29c07bbb-ffdb-4391-b46b-68d994597d2f"
            };

            var expected = new FetchTransactionStatusResponse();
            _transactionServiceMock.Setup(service => service.FetchTransactionStatus(transactionRef, transactionStatus)).ReturnsAsync(expected);

            // Act
            var result = await _ercasPay.FetchTransactionStatus(transactionRef, transactionStatus);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.ToString(), expected.ToString());
            Assert.True(result.Equals(expected));
        }

        [Fact]
        public async Task CardDetails_Test()
        {
            // Arrange 
            var expected = new CardDetailsResponse();
            _cardServiceMock.Setup(service => service.CardDetails(transactionRef)).ReturnsAsync(expected);

            // Act
            var result = await _ercasPay.CardDetails(transactionRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.ToString(), expected.ToString());
            Assert.True(result.Equals(expected));
        }

        [Fact]
        public async Task SubmitOTP_Test()
        {
            // Arrange 
            var otp = new OTP()
            {
                otp = "123456",
                gatewayReference = "wdwddd3d3d3"

            };
            var expected = new SubmitOTPResponse();
            _cardServiceMock.Setup(service => service.SubmitOTP(transactionRef, otp)).ReturnsAsync(expected);

            // Act
            var result = await _ercasPay.SubmitOTP(transactionRef, otp);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.ToString(), expected.ToString());
            Assert.True(result.Equals(expected));
        }

        [Fact]
        public async Task ResendOTP_Test()
        {
            // Arrange 
            string gateway = "sdrjhf rjenm";
            var expected = new ResendOTPResponse();
            _cardServiceMock.Setup(service => service.ResendOTP(transactionRef, gateway)).ReturnsAsync(expected);

            // Act
            var result = await _ercasPay.ResendOTP(transactionRef, gateway);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.ToString(), expected.ToString());
            Assert.True(result.Equals(expected));
        }

        [Fact]
        public async Task PayViaCard_Test()
        {
            // Arrange 
            var expected = new InitiatePaymentResponse();
            string publicKeyPath = "../../public.pem";
            var card = new Card()
            {
                pan = "5123450000000008",
                expiryDate = "01/39",
                pin = "1234",
                cvv = "100"
            };
            var deviceDetails = new DeviceDetails()
            {
                payerDeviceDto = new PayerDeviceDto()
                {
                    device = new Device()
                    {
                        browser = "Firefox",
                        browserDetails = new BrowserDetails()
                        {
                            SecureChallengeWindowSize = "FULL_SCREEN",
                            acceptHeaders = "application/json",
                            colorDepth = 24,
                            javaEnabled = true,
                            language = "en-US",
                            screenHeight = 473,
                            screenWidth = 1600,
                            timeZone = 273
                        },
                        ipAddress = "10.10.10.10"
                    }
                }
            };
            _cardServiceMock.Setup(service => service.InitiatePayment(transaction, card, deviceDetails, publicKeyPath)).ReturnsAsync(expected);

            // Act
            var result = await _ercasPay.PayViaCard(transaction, card, deviceDetails, publicKeyPath);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.ToString(), expected.ToString());
            Assert.True(result.Equals(expected));
        }
    }
}