using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using RegistroAutomatizado.Pages;
using System;
using System.IO;

namespace RegistroAutomatizado
{
    public class FormularioRegistroTests
    {
        IWebDriver driver;
        FormularioRegistroPage formulario;
        string htmlFilePath;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            htmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "index.html");
            formulario = new FormularioRegistroPage(driver);
        }

        [Test]
        [Order(1)]
        public void TestRegistroExitoso()
        {
            formulario.IrAFormulario(htmlFilePath);
            formulario.LlenarFormulario("Juan Perez", "juan@email.com", "3211234567", "Segura2024$");
            string mensaje = formulario.ObtenerMensajeExito();
            Assert.AreEqual("¡Registro Exitoso!", mensaje);
        }

        [Test]
        [Order(2)]
        public void TestCorreoYCelularInvalidos()
        {
            formulario.IrAFormulario(htmlFilePath);
            formulario.LlenarFormulario("Ana", "anaemail.com", "12345", "Segura2024$");
            string mensaje = formulario.ObtenerMensajeError();
            Assert.AreEqual("Correo electrónico inválido.", mensaje);
        }

        [Test]
        [Order(3)]
        public void TestContraseñaDebil()
        {
            formulario.IrAFormulario(htmlFilePath);
            formulario.LlenarFormulario("Luis", "luis@email.com", "3211234567", "123");
            string mensaje = formulario.ObtenerMensajeError();
            Assert.AreEqual("La contraseña debe tener al menos 8 caracteres, incluyendo letras y números.", mensaje);
        }

        [Test]
        [Order(4)]
        public void TestCamposVacios()
        {
            formulario.IrAFormulario(htmlFilePath);
            formulario.LlenarFormulario("", "", "", "");
            string mensaje = formulario.ObtenerMensajeError();
            Assert.AreEqual("Todos los campos son obligatorios o tienen un formato incorrecto.", mensaje);
        }

        [Test]
        [Order(5)]
        public void TestContraseñasYNombresEspeciales()
        {
            formulario.IrAFormulario(htmlFilePath);
            formulario.LlenarFormulario("José-123", "jose@email.com", "3211234567", "Contrasena$123");
            string mensaje = formulario.ObtenerMensajeExito();
            Assert.AreEqual("¡Registro Exitoso!", mensaje);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
