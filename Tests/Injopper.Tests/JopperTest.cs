using System;
using System.ComponentModel.DataAnnotations;
using Injopper.Business;
using Injopper.Core;
using Injopper.Core.Scanners.Realizations;
using Injopper.Data;
using Injopper.Tests.Classes;
using Xunit;

namespace Injopper.Tests
{
    public class JopperTest
    {
        private Jopper _jopper;

        public JopperTest()
        {
            _jopper = new Jopper();
        }

        [Fact]
        public void Register_NoError()
        {
            // Arrange
            _jopper.For<IBanService>().Register<MinecraftBanService>();

            // Act
            var minecraftBanService = _jopper.Resolve<IBanService>();

            // Assert
            Assert.True(minecraftBanService is MinecraftBanService);
        }

        [Fact]
        public void Register_Error()
        {
            // Assert
            Assert.ThrowsAny<Exception>(_jopper.Resolve<IBanService>);
        }

        [Fact]
        public void Decorate_NoError()
        {
            // Arrange
            _jopper.For<IBanService>().Register<MinecraftBanService>();
            _jopper.For<IBanService>().Decorate<LoggedBanService>();

            // Act
            var banService = _jopper.Resolve<IBanService>();

            // Assert
            Assert.True(banService is LoggedBanService);
        }

        [Fact]
        public void Decorate_Error()
        {
            // Arrange
            _jopper.For<IBanService>().Register<MinecraftBanService>();

            // Act
            var banService = _jopper.Resolve<IBanService>();

            // Assert
            Assert.False(banService is LoggedBanService);
        }

        [Fact]
        public void Scan_NoError()
        {
            // Arrange
            const string expectedUserName = "Volodya";

            // Act
            var userService = _jopper.Resolve<IService>();

            // Assert
            Assert.Equal(expectedUserName, userService.GetUserName());
        }

        [Fact]
        public void Scan_Error()
        {
            // Assert
            Assert.ThrowsAny<Exception>(_jopper.Resolve<IBanService>);
        }

        [Fact]
        public void Scan_SpecificAssemblies()
        {
            // Arrange
            const string expectedUserName = "Volodya";

            var scanner = new JopScanner(
                new[]
                {
                    "Injopper.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Injopper.Business, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Injopper.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
                });

            _jopper = new Jopper(scanner);

            // Act
            var userService = _jopper.Resolve<IService>();

            // Assert
            Assert.Equal(expectedUserName, userService.GetUserName());
        }
    }
}
