namespace asignacion.Services
{
        public interface IPasswordService
        {
            string EncryptPassword(string password);
        }

        public class PasswordService : IPasswordService
        {
            public string EncryptPassword(string password)
            {
                string encryptedPassword = SomeEncryptionAlgorithm(password);
                return encryptedPassword;
            }

            private string SomeEncryptionAlgorithm(string password)
            {

                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(password);
                return System.Convert.ToBase64String(plainTextBytes);

            }
        }
    }
