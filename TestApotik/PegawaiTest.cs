using Microsoft.VisualStudio.TestTools.UnitTesting;
using Apotekku_API.Controllers;
using Apotekku_API.Models;
using Microsoft.AspNetCore.Mvc;
using APOTEKKU_API_Kelompok2.Controllers;
using System.Collections.Generic;
using System.IO;

namespace Apotekku_API.Tests.Controllers
{
    [TestClass]
    public class PegawaiControllerTests
    {
        [TestMethod]
        public void Get_ReturnsAllPegawai()
        {
            // Arrange
            var controller = new PegawaiController();

            // Act
            var result = controller.Get();

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult, "Hasil seharusnya OK (200)");

            var pegawaiList = okResult.Value as List<Pegawai>;
            Assert.IsNotNull(pegawaiList, "Data pegawai harus berbentuk list");

            // Uji data 
            Assert.AreEqual(4, pegawaiList.Count);
            Assert.IsTrue(pegawaiList.Exists(p => p.nama == "Damai Putra"));
            Assert.IsTrue(pegawaiList.Exists(p => p.id == "PG003" && p.nama == "Dani"));
        }
    }
}
