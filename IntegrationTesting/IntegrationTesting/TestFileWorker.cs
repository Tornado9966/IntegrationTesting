using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IIG.PasswordHashingUtils;
using IIG.FileWorker;

namespace IntegrationTesting
{
    [TestClass]
    public class TestFileWorker
    {
        /* Basic tests for MkDir method */

        // Test making directory with empty string as path
        [TestMethod]
        public void Test_MkDir_Empty_Path()
        {
            Assert.ThrowsException<ArgumentException>(() => BaseFileWorker.MkDir(""));
        }

        // Test making directory with space name
        [TestMethod]
        public void Test_MkDir_Space_Name()
        {
            Assert.AreEqual("C:\\TestFiles\\", BaseFileWorker.MkDir("C:\\TestFiles\\ "));
        }

        // Test making directory with correct name
        [TestMethod]
        public void Test_MkDir_Correct_Name()
        {
            Assert.AreEqual("C:\\TestMkDir", BaseFileWorker.MkDir("C:\\TestMkDir"));
        }

        // Test making directory with special symbols name
        [TestMethod]
        public void Test_MkDir_Special_Symbols()
        {
            string[] specsym = new string[4]{ "<", ">", "*", "?" };
            for (int i = 0; i < 4; i++)
            {
                Assert.ThrowsException<ArgumentException>(() => BaseFileWorker.MkDir("C:\\TestMkDir" + specsym[i]));
            }
        }


        /* Basic tests for GetPath method */

        // Test GetPath method with empty path argument
        [TestMethod]
        public void Test_GetPath_Empty_Path()
        {
            Assert.IsNull(BaseFileWorker.GetPath(""));
        }

        // Test to get path for non-existent file
        [TestMethod]
        public void Test_GetPath_Non_Existent_File()
        {
            Assert.IsNull(BaseFileWorker.GetPath("C:\\TestFiles\\2.txt"));
        }

        // Test to get path without extension writing
        [TestMethod]
        public void Test_GetPath_No_Extension()
        {
            Assert.IsNull(BaseFileWorker.GetPath("C:\\TestFiles\\1"));
        }

        // Test to get path for different file types
        [TestMethod]
        public void Test_GetPath_Different_Types()
        {
            Assert.AreEqual("C:\\TestFiles", BaseFileWorker.GetPath("C:\\TestFiles\\1.txt"));
            Assert.AreEqual("C:\\TestFiles", BaseFileWorker.GetPath("C:\\TestFiles\\1.bmp"));
            Assert.AreEqual("C:\\TestFiles", BaseFileWorker.GetPath("C:\\TestFiles\\1.mpp"));
            Assert.AreEqual("C:\\TestFiles", BaseFileWorker.GetPath("C:\\TestFiles\\1.odg"));
            Assert.AreEqual("C:\\TestFiles", BaseFileWorker.GetPath("C:\\TestFiles\\1.rar"));
            Assert.AreEqual("C:\\TestFiles", BaseFileWorker.GetPath("C:\\TestFiles\\1.rtf"));
            Assert.AreEqual("C:\\TestFiles", BaseFileWorker.GetPath("C:\\TestFiles\\1.mp4"));
        }


        /* Basic tests for GetFullPath method */

        // Test GetFullPath method with empty path argument
        [TestMethod]
        public void Test_GetFullPath_Empty_Path()
        {
            Assert.IsNull(BaseFileWorker.GetFullPath(""));
        }

        // Test to get full path for non-existent file
        [TestMethod]
        public void Test_GetFullPath_Non_Existent_File()
        {
            Assert.IsNull(BaseFileWorker.GetFullPath("C:\\TestFiles\\2.txt"));
        }

        // Test to get full path without extension writing
        [TestMethod]
        public void Test_GetFullPath_No_Extension()
        {
            Assert.IsNull(BaseFileWorker.GetFullPath("C:\\TestFiles\\1"));
        }

        // Test to get full path for different file types
        [TestMethod]
        public void Test_GetFullPath_Different_Types()
        {
            Assert.AreEqual("C:\\TestFiles\\1.txt", BaseFileWorker.GetFullPath("C:\\TestFiles\\1.txt"));
            Assert.AreEqual("C:\\TestFiles\\1.bmp", BaseFileWorker.GetFullPath("C:\\TestFiles\\1.bmp"));
            Assert.AreEqual("C:\\TestFiles\\1.mpp", BaseFileWorker.GetFullPath("C:\\TestFiles\\1.mpp"));
            Assert.AreEqual("C:\\TestFiles\\1.odg", BaseFileWorker.GetFullPath("C:\\TestFiles\\1.odg"));
            Assert.AreEqual("C:\\TestFiles\\1.rar", BaseFileWorker.GetFullPath("C:\\TestFiles\\1.rar"));
            Assert.AreEqual("C:\\TestFiles\\1.rtf", BaseFileWorker.GetFullPath("C:\\TestFiles\\1.rtf"));
            Assert.AreEqual("C:\\TestFiles\\1.mp4", BaseFileWorker.GetFullPath("C:\\TestFiles\\1.mp4"));
        }


        /* Basic tests for GetFileName method */

        // Test GetFileName method with empty path argument
        [TestMethod]
        public void Test_GetFileName_Empty_Path()
        {
            Assert.IsNull(BaseFileWorker.GetFileName(""));
        }

        // Test to get file name for non-existent file
        [TestMethod]
        public void Test_GetFileName_Non_Existent_File()
        {
            Assert.IsNull(BaseFileWorker.GetFileName("C:\\TestFiles\\2.txt"));
        }

        // Test to get file name without extension writing
        [TestMethod]
        public void Test_GetFileName_No_Extension()
        {
            Assert.IsNull(BaseFileWorker.GetFileName("C:\\TestFiles\\1"));
        }

        // Test to get file name for different file types
        [TestMethod]
        public void Test_GetFileName_Different_Types()
        {
            Assert.AreEqual("1.txt", BaseFileWorker.GetFileName("C:\\TestFiles\\1.txt"));
            Assert.AreEqual("1.bmp", BaseFileWorker.GetFileName("C:\\TestFiles\\1.bmp"));
            Assert.AreEqual("1.mpp", BaseFileWorker.GetFileName("C:\\TestFiles\\1.mpp"));
            Assert.AreEqual("1.odg", BaseFileWorker.GetFileName("C:\\TestFiles\\1.odg"));
            Assert.AreEqual("1.rar", BaseFileWorker.GetFileName("C:\\TestFiles\\1.rar"));
            Assert.AreEqual("1.rtf", BaseFileWorker.GetFileName("C:\\TestFiles\\1.rtf"));
            Assert.AreEqual("1.mp4", BaseFileWorker.GetFileName("C:\\TestFiles\\1.mp4"));
        }


        /* Basic tests for TryWrite method */

        // Test TryWrite method with empty path argument
        [TestMethod]
        public void Test_TryWrite_Empty_Path()
        {
            Assert.IsFalse(BaseFileWorker.TryWrite("smth", ""));
            Assert.IsFalse(BaseFileWorker.TryWrite("smth", "", 7));
            Assert.IsFalse(BaseFileWorker.TryWrite("smth", "", 0));
            Assert.IsFalse(BaseFileWorker.TryWrite("smth", "", -3));
        }

        // Test try to write without file name writing
        [TestMethod]
        public void Test_TryWrite_No_File_Name()
        {
            Assert.IsFalse(BaseFileWorker.TryWrite("smth", "C:\\TestFiles"));
            Assert.IsFalse(BaseFileWorker.TryWrite("smth", "C:\\TestFiles", 7));
            Assert.IsFalse(BaseFileWorker.TryWrite("smth", "C:\\TestFiles", 0));
            Assert.IsFalse(BaseFileWorker.TryWrite("smth", "C:\\TestFiles", -3));
        }

        // Test try to write without file extension writing
        [TestMethod]
        public void Test_TryWrite_No_File_Extension()
        {
            Assert.IsTrue(BaseFileWorker.TryWrite("smth", "C:\\TestFiles\\1"));
            Assert.IsTrue(BaseFileWorker.TryWrite("smth", "C:\\TestFiles\\1", 7));
            Assert.IsFalse(BaseFileWorker.TryWrite("smth", "C:\\TestFiles\\1", 0));
            Assert.IsFalse(BaseFileWorker.TryWrite("smth", "C:\\TestFiles\\1", -3));
        }

        // Test try to write to non-existent file
        [TestMethod]
        public void Test_TryWrite_Non_Existent_File()
        {
            Assert.IsTrue(BaseFileWorker.TryWrite("smth", "C:\\TestFiles\\3.txt"));
            Assert.IsTrue(BaseFileWorker.TryWrite("smth", "C:\\TestFiles\\3.txt", 7));
            Assert.IsFalse(BaseFileWorker.TryWrite("smth", "C:\\TestFiles\\3.txt", 0));
            Assert.IsFalse(BaseFileWorker.TryWrite("smth", "C:\\TestFiles\\3.txt", -3));
        }

        // Test try to write empty text
        [TestMethod]
        public void Test_TryWrite_Empty_Text()
        {
            Assert.IsTrue(BaseFileWorker.TryWrite("", "C:\\TestFiles\\1.txt"));
            Assert.IsTrue(BaseFileWorker.TryWrite("", "C:\\TestFiles\\1.txt", 7));
            Assert.IsFalse(BaseFileWorker.TryWrite("", "C:\\TestFiles\\1.txt", 0));
            Assert.IsFalse(BaseFileWorker.TryWrite("", "C:\\TestFiles\\1.txt", -3));
        }

        // Test try to write to existing file
        [TestMethod]
        public void Test_TryWrite_Existing_File()
        {
            Assert.IsTrue(BaseFileWorker.TryWrite("smth", "C:\\TestFiles\\1.txt"));
            Assert.IsTrue(BaseFileWorker.TryWrite("smth", "C:\\TestFiles\\1.txt", 7));
            Assert.IsFalse(BaseFileWorker.TryWrite("smth", "C:\\TestFiles\\1.txt", 0));
            Assert.IsFalse(BaseFileWorker.TryWrite("smth", "C:\\TestFiles\\1.txt", -3));
        }

        // Test try to write to specific file types
        [TestMethod]
        public void Test_TryWrite_Specific_File_Types()
        {
            Assert.IsTrue(BaseFileWorker.TryWrite("smth", "C:\\TestFiles\\1.txt"));
            Assert.IsTrue(BaseFileWorker.TryWrite("smth", "C:\\TestFiles\\1.bmp"));
            Assert.IsTrue(BaseFileWorker.TryWrite("smth", "C:\\TestFiles\\1.mpp"));
            Assert.IsTrue(BaseFileWorker.TryWrite("smth", "C:\\TestFiles\\1.rtf"));
            Assert.IsTrue(BaseFileWorker.TryWrite("smth", "C:\\TestFiles\\1.rar"));
        }


        /* Basic tests for Write method */

        // Test Write method with empty path argument
        [TestMethod]
        public void Test_Write_Empty_Path()
        {
            Assert.IsFalse(BaseFileWorker.Write("smth", ""));
        }

        // Test to write without file name writing
        [TestMethod]
        public void Test_Write_No_File_Name()
        {
            Assert.IsFalse(BaseFileWorker.Write("smth", "C:\\TestFiles"));
        }

        // Test to write without file extension writing
        [TestMethod]
        public void Test_Write_No_File_Extension()
        {
            Assert.IsTrue(BaseFileWorker.Write("smth", "C:\\TestFiles\\1"));
        }

        // Test to write to non-existent file
        [TestMethod]
        public void Test_Write_Non_Existent_File()
        {
            Assert.IsTrue(BaseFileWorker.Write("smth", "C:\\TestFiles\\4.txt"));
        }

        // Test to write empty text
        [TestMethod]
        public void Test_Write_Empty_Text()
        {
            Assert.IsTrue(BaseFileWorker.Write("", "C:\\TestFiles\\1.txt"));
        }

        // Test to write to existing file
        [TestMethod]
        public void Test_Write_Existing_File()
        {
            Assert.IsTrue(BaseFileWorker.Write("smth", "C:\\TestFiles\\1.txt"));
        }

        // Test to write to specific file types
        [TestMethod]
        public void Test_Write_Specific_File_Types()
        {
            Assert.IsTrue(BaseFileWorker.Write("smth", "C:\\TestFiles\\1.txt"));
            Assert.IsTrue(BaseFileWorker.Write("smth", "C:\\TestFiles\\1.bmp"));
            Assert.IsTrue(BaseFileWorker.Write("smth", "C:\\TestFiles\\1.mpp"));
            Assert.IsTrue(BaseFileWorker.Write("smth", "C:\\TestFiles\\1.rtf"));
            Assert.IsTrue(BaseFileWorker.Write("smth", "C:\\TestFiles\\1.rar"));
        }


        /* Basic tests for ReadLines method */

        // Test read file without path writing
        [TestMethod]
        public void Test_ReadLines_Empty_Path()
        {
            Assert.IsNull(BaseFileWorker.ReadLines(""));
        }

        // Test read file from non-existent path
        [TestMethod]
        public void Test_ReadLines_Non_Existent_Path()
        {
            Assert.IsNull(BaseFileWorker.ReadLines("C:\\TestFiles\\2.txt"));
            Assert.IsNull(BaseFileWorker.ReadLines("C:\\TestFiles1\\1.txt"));
        }

        // Test read existing file
        [TestMethod]
        public void Test_ReadLines_Existing_File()
        {
            string[] result = new string[3] { "first row", "second row", "third row" };
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(result[i], BaseFileWorker.ReadLines("C:\\TestFiles\\rows.txt")[i]);
            }
        }


        /* Basic tests for ReadAll method */

        // Test read file without path writing
        [TestMethod]
        public void Test_ReadAll_Empty_Path()
        {
            Assert.IsNull(BaseFileWorker.ReadAll(""));
        }

        // Test read file from non-existent path
        [TestMethod]
        public void Test_ReadAll_Non_Existent_Path()
        {
            Assert.IsNull(BaseFileWorker.ReadAll("C:\\TestFiles\\2.txt"));
            Assert.IsNull(BaseFileWorker.ReadAll("C:\\TestFiles1\\1.txt"));
        }

        // Test read existing file
        [TestMethod]
        public void Test_ReadAll_Existing_File()
        {
            Assert.AreEqual("first row\r\nsecond row\r\nthird row", BaseFileWorker.ReadAll("C:\\TestFiles\\rows.txt"));
        }
    }
}
