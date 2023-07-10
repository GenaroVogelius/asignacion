using Xunit;
using asignacion.Services;

namespace asignacion.Tests
{
        public class PasswordServiceTests
        {
            [Fact]
            public void EncryptPassword_ReturnsEncryptedPassword()
            {
                // Arrange
                var passwordService = new PasswordService();
                string password = "password123";

                // Act
                string encryptedPassword = passwordService.EncryptPassword(password);

                // Assert
                Assert.NotNull(encryptedPassword);
                Assert.NotEmpty(encryptedPassword);
                Assert.NotEqual(password, encryptedPassword);
            }
        }
    }
