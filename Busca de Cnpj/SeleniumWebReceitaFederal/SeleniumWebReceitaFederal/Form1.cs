
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace SeleniumWebReceitaFederal
{
    public partial class Form1 : Form
    {
        IWebDriver driver;
        string url = "https://www.google.com";

        public Form1()
        {
            InitializeComponent();
            driver = new ChromeDriver();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dynamic body = webBrowser1.Document.Body.DomElement;
            //dynamic controlRange = body.createControlRange();
            //dynamic element = webBrowser1.Document.GetElementById("imgCaptcha").DomElement;
            //controlRange.add(element);
            //controlRange.execCommand("Copy", false, null);
            //pictureBox1.Image = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);

            driver.Navigate().GoToUrl("http://servicos.receita.fazenda.gov.br/Servicos/cnpjreva/Cnpjreva_Solicitacao.asp");
            IWebElement submit;
            submit = driver.FindElement(By.XPath("//*[@id=\"captchaSonoro\"]"));
            submit.Click();

            var remElement = driver.FindElement(By.Id("imgCaptcha"));
            Point location = remElement.Location;

            var screenshot = (driver as ChromeDriver).GetScreenshot();
            using (MemoryStream stream = new MemoryStream(screenshot.AsByteArray))
            {
                using (Bitmap bitmap = new Bitmap(stream))
                {
                    RectangleF part = new RectangleF(location.X, location.Y, remElement.Size.Width, remElement.Size.Height);
                    using (Bitmap bn = bitmap.Clone(part, bitmap.PixelFormat))
                    {
                        bn.Save("CaptchImage.png", System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
            }
            pictureBox1.Load("CaptchImage.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IWebElement submit;
            driver.FindElement(By.Id("cnpj")).SendKeys("1");
            driver.FindElement(By.Id("cnpj")).SendKeys("8");
            driver.FindElement(By.Id("cnpj")).SendKeys("4");
            driver.FindElement(By.Id("cnpj")).SendKeys("1");
            driver.FindElement(By.Id("cnpj")).SendKeys("2");
            driver.FindElement(By.Id("cnpj")).SendKeys("4");
            Thread.Sleep(500);
            driver.FindElement(By.Id("cnpj")).SendKeys("67000");
            Thread.Sleep(500);
            driver.FindElement(By.Id("cnpj")).SendKeys("1");
            driver.FindElement(By.Id("cnpj")).SendKeys("0");
            driver.FindElement(By.Id("cnpj")).SendKeys("4");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("txtTexto_captcha_serpro_gov_br")).SendKeys(textBox1.Text);

            submit = driver.FindElement(By.XPath("//*[@id=\"frmConsulta\"]/ div[3]/div/button[1]"));

            submit.Submit();//*[@id="principal"]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/font[2]/b

            label1.Text = driver.FindElement(By.XPath("//*[@id=\"principal\"]/ table[1]/tbody/tr/td/table[2]/tbody/tr/td[1]/font[2]/b[1]")).Text;//NÚMERO DE INSCRIÇÃO
            label2.Text = driver.FindElement(By.XPath("//*[@id=\"principal\"]/table[1]/tbody/tr/td/table[3]/tbody/tr/td/font[2]/b")).Text;//NOME EMPRESARIAL
            label3.Text = driver.FindElement(By.XPath("//*[@id=\"principal\"]/ table[1]/tbody/tr/td/table[4]/tbody/tr/td[3]/font[2]/b")).Text;//PORTE
            label4.Text = driver.FindElement(By.XPath("//*[@id=\"principal\"]/ table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/font[2]/b")).Text;//DATA DE ABERTURA
            label5.Text = driver.FindElement(By.XPath("//*[@id=\"principal\"]/ table[1]/tbody/tr/td/table[5]/tbody/tr/td/font[2]/b")).Text;//CÓDIGO E DESCRIÇÃO DA ATIVIDADE ECONÔMICA PRINCIPAL
            label6.Text = driver.FindElement(By.XPath("//*[@id=\"principal\"]/ table[1]/tbody/tr/td/table[6]/tbody/tr/td/font[2]/b")).Text;//CÓDIGO E DESCRIÇÃO DAS ATIVIDADES ECONÔMICAS SECUNDÁRIAS
            label7.Text = driver.FindElement(By.XPath("//*[@id=\"principal\"]/ table[1]/tbody/tr/td/table[7]/tbody/tr/td/font[2]/b")).Text;//CÓDIGO E DESCRIÇÃO DA NATUREZA JURÍDICA
            label8.Text = driver.FindElement(By.XPath("//*[@id=\"principal\"]/ table[1]/tbody/tr/td/table[8]/tbody/tr/td[1]/font[2]/b")).Text;//LOGRADOURO
            label9.Text = driver.FindElement(By.XPath("//*[@id=\"principal\"]/ table[1]/tbody/tr/td/table[8]/tbody/tr/td[3]/font[2]/b")).Text;//NÚMERO
            label10.Text = driver.FindElement(By.XPath("//*[@id=\"principal\"]/ table[1]/tbody/tr/td/table[9]/tbody/tr/td[1]/font[2]/b")).Text;//CEP
            label11.Text = driver.FindElement(By.XPath("//*[@id=\"principal\"]/ table[1]/tbody/tr/td/table[9]/tbody/tr/td[3]/font[2]/b")).Text;//BAIRRO/DISTRITO
            label12.Text = driver.FindElement(By.XPath("//*[@id=\"principal\"]/ table[1]/tbody/tr/td/table[9]/tbody/tr/td[5]/font[2]/b")).Text;//MUNICÍPIO
            label13.Text = driver.FindElement(By.XPath("//*[@id=\"principal\"]/ table[1]/tbody/tr/td/table[9]/tbody/tr/td[7]/font[2]/b")).Text;//UF
            label14.Text = driver.FindElement(By.XPath("//*[@id=\"principal\"]/ table[1]/tbody/tr/td/table[10]/tbody/tr/td[1]/font[2]/b")).Text;//ENDEREÇO ELETRÔNICO
            label15.Text = driver.FindElement(By.XPath("//*[@id=\"principal\"]/ table[1]/tbody/tr/td/table[10]/tbody/tr/td[3]/font[2]/b")).Text;//TELEFONE
            label16.Text = driver.FindElement(By.XPath("//*[@id=\"principal\"]/ table[1]/tbody/tr/td/table[12]/tbody/tr/td[1]/font[2]/b")).Text;//SITUAÇÃO CADASTRAL
        }
    }
}
