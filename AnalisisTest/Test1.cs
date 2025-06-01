using Microsoft.VisualStudio.TestTools.UnitTesting;
using Apotekku_API.Models;
using TUBES_KPL_KELOMPOK2.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Moq;

[TestClass]
public class AnalisisPenyakitTests
{
    private const string TestFilePath = "Data\\PenyakitAnalisis.Json";
    private Mock<IFileSystem> _fileSystemMock;

    [TestInitialize]
    public void Setup()
    {
        _fileSystemMock = new Mock<IFileSystem>();
    }

    [TestMethod]
    public void GetDiseaseAnalyses_ShouldReturnCopyOfInternalList()
    {
        // Arrange
        var testData = new List<PenyakitAnalisis>
        {
            new PenyakitAnalisis { NamaPenyakit = "Test", JumlahKasus = 1 }
        };

        var jsonData = JsonSerializer.Serialize(testData);
        _fileSystemMock.Setup(fs => fs.FileExists(TestFilePath)).Returns(true);
        _fileSystemMock.Setup(fs => fs.ReadAllText(TestFilePath)).Returns(jsonData);

        var analyser = new AnalisisPenyakit();

        // Act
        var result1 = analyser.GetDiseaseAnalyses().ToList();
        var result2 = analyser.GetDiseaseAnalyses().ToList();

        // Assert
        Assert.AreNotSame(result1, result2);
        CollectionAssert.AreEqual(result1, result2);
    }

    
    public interface IFileSystem
    {
        bool FileExists(string path);
        string ReadAllText(string path);
    }
}