using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IIG.DatabaseConnectionUtils;
using IIG.CoSFE.DatabaseUtils;
using IIG.BinaryFlag;

namespace IntegrationTesting
{
    [TestClass]
    public class TestAddFlag
    {
        private const string Server = @"DESKTOP-J211L71\MSSQLSERVER1";
        private const string Database = @"IIG.CoSWE.FlagpoleDB";
        private const bool IsTrusted = false;
        private const string Login = @"sa";
        private const string Password = @"vfhnjxrf";
        private const int ConnectionTime = 75;

        FlagpoleDatabaseUtils fdu = new FlagpoleDatabaseUtils(Server, Database, IsTrusted, Login, Password, ConnectionTime);

        MultipleBinaryFlag mbf1 = new MultipleBinaryFlag(8);
        MultipleBinaryFlag mbf2 = new MultipleBinaryFlag(8, false);
        MultipleBinaryFlag mbf3 = new MultipleBinaryFlag(10);
        MultipleBinaryFlag mbf4 = new MultipleBinaryFlag(8, true);
        
        // Test that created flag is successfully added to DB
        [TestMethod]
        public void Test_Add_Created_Flag()
        {
            Assert.IsTrue(fdu.AddFlag(mbf1.ToString(), mbf1.GetFlag()));
        }

        // Test that created flag is successfully added to DB (second parameter is written manually)
        [TestMethod]
        public void Test_Add_Created_Flag_Manual_Second_Parameter_1()
        {
            Assert.IsTrue(fdu.AddFlag(mbf3.ToString(), true));
        }

        // Test that created flag is successfully added to DB (second parameter is written manually)
        [TestMethod]
        public void Test_Add_Created_Flag_Manual_Second_Parameter_2()
        {
            Assert.IsTrue(fdu.AddFlag(mbf2.ToString(), false));
        }

        // Test that created flag is not successfully added to DB if state is incorrect
        [TestMethod]
        public void Test_Add_Created_Flag_Unsuccess()
        {
            Assert.IsFalse(fdu.AddFlag(mbf1.ToString(), false));
        }
        
        // Test add of empty flag in string to DB
        [TestMethod]
        public void Test_Add_Empty_Flag_1()
        {
            Assert.IsFalse(fdu.AddFlag("", true));
        }

        // Test add of empty flag in string to DB
        [TestMethod]
        public void Test_Add_Empty_Flag_2()
        {
            Assert.IsFalse(fdu.AddFlag("", false));
        }
        
        // Test add flag with incorrect string format to DB
        [TestMethod]
        public void Test_Add_Flag_Incorrect_String()
        {
            Assert.IsFalse(fdu.AddFlag("SMTH", true));
            Assert.IsFalse(fdu.AddFlag("SMTH", false));
        }
        
        // Test add same flag two times in a row
        [TestMethod]
        public void Test_Add_Two_Same_Flags()
        {
            Assert.IsTrue(fdu.AddFlag(mbf4.ToString(), true));
            Assert.IsTrue(fdu.AddFlag(mbf4.ToString(), true));
        }
        
        // Test add flag with non-existent connection
        [TestMethod]
        public void Test_Add_Flag_None_Connection()
        {
            string FakeDatabase = @"IIG.CoSWE.FakeFlagpoleDB";
            FlagpoleDatabaseUtils fake_fdu = new FlagpoleDatabaseUtils(Server, FakeDatabase, IsTrusted, Login, Password, ConnectionTime);
            Assert.IsFalse(fake_fdu.AddFlag(mbf1.ToString(), true));
        }
        
        // Test add flag after SetFlag method
        [TestMethod]
        public void Test_Add_Flag_After_SetFlag()
        {
            mbf2.SetFlag(3);
            Assert.IsTrue(fdu.AddFlag(mbf2.ToString(), false));
        }
        
        // Test add flag after ResetFlag method
        [TestMethod]
        public void Test_Add_Flag_After_ResetFlag()
        {
            mbf1.ResetFlag(3);
            Assert.IsTrue(fdu.AddFlag(mbf1.ToString(), false));
        }
    }
}
