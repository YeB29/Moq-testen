using System;
using Xunit;
using Moq;
using LeerlingAdministratie;

namespace test
{
    public class UnitTest1
    {
        [Fact]
        public void UpdateCijfersTest()
        {
            
           string naam = "Bob";
           var m = new Moq.Mock<IAdministratie>();
           
           
           m.Setup(s => s.UpdateCijfers(It.IsAny<float>()));
           var sut = new Leerling(naam,m.Object);
          

           sut.UpdateCijfers(It.IsAny<float>());

           m.Verify(m =>m.UpdateCijfers(It.IsAny<float>()), Times.Once());

        }

        [Fact]
        public void UpdateBeoordelingTest()
        {
           string naam = "Bob";
           var m = new Moq.Mock<IAdministratie>();
           
           
        //    m.Setup(s => s.UpdateBeoordeling(It.IsAny<string>()));
           var sut = new Leerling(naam,m.Object);
          

           sut.UpdateBeoordeling(It.IsAny<string>());

           m.Verify(m =>m.UpdateBeoordeling(It.IsAny<string>()), Times.Once());

        }

        [Fact]
        public void IsAfwezigTest()
        {
           string naam = "Bob";
           var m = new Moq.Mock<IAdministratie>();

           m.Setup(s => s.StuurDataNaarMinisterieVanOnderwijs(It.IsAny<string>(), It.IsAny<int>()));
           m.Setup(s => s.StuurDataNaarMinisterieVanOnderwijsAlsObject(It.IsAny<IDataLeerling>()));
           var sut = new Leerling(naam,m.Object);

            sut.IsAfwezig(It.IsAny<string>());

            m.Verify(m => m.StuurDataNaarMinisterieVanOnderwijs(It.IsAny<string>(),It.IsAny<int>()), Times.Exactly(1));
            m.Verify(m => m.StuurDataNaarMinisterieVanOnderwijsAlsObject(It.IsAny<IDataLeerling>()), Times.Exactly(1));

        }

        [Fact]
        public void VraagDataOpVanMinisterieVanOnderwijsTest()
        {
            string naam = "Bob";
            var m = new Moq.Mock<IAdministratie>();

            m.Setup(m => m.VraagDataOpVanMinisterieVanOnderwijs(It.IsAny<string>()));
            var sut = new Leerling(naam,m.Object);

            sut.VraagDataOpVanMinisterieVanOnderwijs();

            m.Verify(m =>m.VraagDataOpVanMinisterieVanOnderwijs(It.IsAny<string>()), Times.Once());


        }
    }
}
