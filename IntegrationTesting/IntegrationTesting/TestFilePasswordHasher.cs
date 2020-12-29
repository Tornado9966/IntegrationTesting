using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IIG.FileWorker;
using IIG.PasswordHashingUtils;

namespace IntegrationTesting
{
    [TestClass]
    public class TestFilePasswordHasher
    {
        // Test to write hash to file
        [TestMethod]
        public void Test_Write_Hash_To_File()
        {
            string password = "password";
            string salt = "salt";
            Assert.IsTrue(BaseFileWorker.Write(PasswordHasher.GetHash(password, salt), "C:\\TestFiles\\hashes.txt"));
        }

        // Test to read hash from file
        [TestMethod]
        public void Test_Read_Hash_From_File()
        {
            Assert.IsNotNull(BaseFileWorker.ReadAll("C:\\TestFiles\\hashes.txt"));
            Assert.AreEqual("FF361BA585A54825FD5980AB02CFCFC53F3586BCF80A4CE6B1A1CBEB572690C4", BaseFileWorker.ReadAll("C:\\TestFiles\\hashes.txt"));
        }

        // Test equality of writtean and read hash
        [TestMethod]
        public void Test_Write_Read_Hash_Equal()
        {
            string password = "test_password";
            string salt = "test_salt";
            string passHash = PasswordHasher.GetHash(password, salt);
            BaseFileWorker.Write(passHash, "C:\\TestFiles\\hashes.txt");
            Assert.AreEqual(passHash, BaseFileWorker.ReadAll("C:\\TestFiles\\hashes.txt"));
        }
    }
}
