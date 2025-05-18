using OpenQA.Selenium;

namespace RegistroAutomatizado.Pages
{
    public class FormularioRegistroPage
    {
        private readonly IWebDriver _driver;

        public FormularioRegistroPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void IrAFormulario(string htmlPath)
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl($"file:///{htmlPath}");
        }

        public void LlenarFormulario(string nombre, string correo, string celular, string contrasena)
        {
            _driver.FindElement(By.Id("nombre")).SendKeys(nombre);
            _driver.FindElement(By.Id("correo")).SendKeys(correo);
            _driver.FindElement(By.Id("celular")).SendKeys(celular);
            _driver.FindElement(By.Id("contraseña")).SendKeys(contrasena);
            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        }

        public string ObtenerMensajeExito()
        {
            return _driver.FindElement(By.Id("mensaje")).Text;
        }

        public string ObtenerMensajeError()
        {
            return _driver.FindElement(By.Id("mensajeError")).Text;
        }
    }
}
